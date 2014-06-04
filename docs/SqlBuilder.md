SqlBuilder Tutorial
===================

Overview
--------
[SqlBuilder][1] is a class designed to make dynamic SQL tasks easier. The main design goals are:

- The query should look like SQL, and all SQL queries should be possible.
- SqlBuilder is about building SQL, not getting or mapping data, so it should not be bound to any particular data-access implementation.

Let's take a look at the first example:

```csharp
var query = new SqlBuilder()
   .SELECT("*")
   .FROM("Products")
   .WHERE("Name LIKE {0}", "A%")
```

What makes SqlBuilder very easy to learn/use is that all methods have the same signature:

```csharp
SqlBuilder SELECT(string, params object[]);
SqlBuilder FROM(string, params object[]);
SqlBuilder WHERE(string, params object[]);
...
```

The first parameter is a composite format string, as used on [String.Format][2], and the second parameter is an array of the parameter values you want to use in your command. So, if we call [ToString][3] on the first example this is what we get:

```sql
SELECT *
FROM products
WHERE name LIKE {0}
```

Pretty much the same. The parameter placeholder is still there, and the 'A%' value is kept in the [ParameterValues][4] collection. To turn this into a command we need either a [DbProviderFactory][5] or a [DbConnection][6] instance:

```csharp
DbCommand command = query.ToCommand(SqlClientFactory.Instance);
Console.WriteLine(command.ToTraceString());
```

Outputs:

```sql
SELECT *
FROM Products
WHERE Name LIKE @p0
-- @p0: Input String (Size = 2) [A%]
```

The parameter placeholder is now replaced with a parameter name, and the parameter value is included in the command.

Keeping track of the last clause
--------------------------------
SqlBuilder keeps track of the last clause to determine when to use separators like commas (', '), logical operators (' AND '), etc, when building the clause body. This allows you to call the same method more than once:

```csharp
// SQL.SELECT is just a shortcut to new SqlBuilder().SELECT
var query = SQL
   .SELECT("ID")
   .SELECT("Name")
   .FROM("Products")
   .WHERE("Name LIKE {0}", "A%")
   .WHERE("CategoryID = {0}", 2); 

Console.WriteLine(query);
```

Outputs:

```sql
SELECT ID, Name
FROM Products
WHERE Name LIKE {0} AND CategoryID = {1}
```

This is how you can dynamically construct the clause body. This *separator* feature does not apply for all clauses. For example, calling JOIN two times will append JOIN on both calls. Also notice we used a zero index for both parameter placeholders, but the output shows zero and one indexes. The format string must always use method-call-relative placeholders, SqlBuilder takes care of translating those into instance-relative.

To keep things DRY you can also use the [_][7] method for clause continuation:

```csharp
var query = SQL
   .SELECT("ID")
   ._("Name")
   .FROM("Products")
   .WHERE("Name LIKE {0}", "A%")
   ._("CategoryID = {0}", 2);
```

Dynamic SQL
-----------
So far we've only used SqlBuilder to dynamically construct queries that are static, meaning the resulting SQL will always be the same. Let's look at a real dynamic query example:

```csharp
void DynamicSql(int? categoryId, int? supplierId) { 

   var query = SQL
      .SELECT("ID, Name")
      .FROM("Products")
      .WHERE()
      ._If(categoryId.HasValue, "CategoryID = {0}", categoryId)
      ._If(supplierId.HasValue, "SupplierID = {0}", supplierId)
      .ORDER_BY("Name DESC"); 

   Console.WriteLine(query);
}
```

Let's call this several times with different arguments:

```csharp
DynamicSql(2, null);
DynamicSql(null, 3);
DynamicSql(2, 3);
DynamicSql(null, null);
```

Outputs:

```sql
SELECT ID, Name
FROM Products
WHERE CategoryID = {0}
ORDER BY Name DESC

SELECT ID, Name
FROM Products
WHERE SupplierID = {0}
ORDER BY Name DESC

SELECT ID, Name
FROM Products
WHERE CategoryID = {0} AND SupplierID = {1}
ORDER BY Name DESC

SELECT ID, Name
FROM Products
ORDER BY Name DESC
```

The [WHERE][8] method that takes no parameters only sets WHERE as the next clause, it does not append the clause, so when a clause continuation method is used, such as [_If][9], SqlBuilder knows which clause to use.

Sub-queries
-----------
Parameter placeholders are always used for command parameters, except when you pass another SqlBuilder instance, in which case the supplied builder's text is injected at the placeholder. This is how SqlBuilder supports sub-queries:

```csharp
var query = SQL
   .SELECT("c.CategoryName, t0.TotalProducts")
   .FROM("Categories c")
   .JOIN("({0}) t0 ON c.CategoryID = t0.CategoryID", SQL
      .SELECT("CategoryID, COUNT(*) AS TotalProducts")
      .FROM("Products")
      .GROUP_BY("CategoryID"))
   .ORDER_BY("t0.TotalProducts DESC");

Console.WriteLine(query);
```

Outputs:

```sql
SELECT c.CategoryName, t0.TotalProducts
FROM Categories c
JOIN (
   SELECT CategoryID, COUNT(*) AS TotalProducts
   FROM Products
   GROUP BY CategoryID) t0 ON c.CategoryID = t0.CategoryID
ORDER BY t0.TotalProducts DESC
```

If the sub-query contains any parameter values these are copied to the outer query. SqlBuilder doesn't keep any reference to sub-queries, all instances are completely independent and composability is achieved by copying state from one instance to the other.

Arrays
------
Not many SQL dialects support array types, but a very common requirement is to use an array of values as the right expression of the IN operator:

```csharp
int[] ids = { 1, 2, 3 };

var query = SQL
   .SELECT("*")
   .FROM("Products")
   .WHERE("CategoryID IN ({0})", ids);

Console.WriteLine(query);
```

Outputs:

```sql
SELECT *
FROM Products
WHERE CategoryID IN ({0}, {1}, {2})
```

Note: If you use an array of a reference type and no other parameters you have to cast the array to [Object][10], e.g. `(object)new string[] { "a", "b", "c" }`. See [this thread][11] for more info.

Extending an existing query
---------------------------
If there's a large portion of the query that is static, there's no need to convert everything to method calls, just pass it to the constructor and extend it from there:

```csharp
var query = new SqlBuilder(@"
    SELECT ProductID, ProductName
    FROM Products")
   .WHERE("CategoryID = {0}", 1);

Console.WriteLine(query);
```

Outputs:

```sql
         SELECT ProductID, ProductName
         FROM Products
WHERE CategoryID = {0}
```

In this case I favored source code readability over SQL readability.

Inserts, Updates, Deletes
-------------------------
There's really no limit to the kind of statements SqlBuilder can handle:

```csharp
var insert = SQL
   .INSERT_INTO("Products(ProductName, UnitPrice, CategoryID)")
   .VALUES("Chai", 15.56, 5);

var update = SQL
   .UPDATE("Products")
   .SET("Discontinued = {0}", true)
   .WHERE("ProductID = {0}", 1);

var delete = SQL
   .DELETE_FROM("Products")
   .WHERE("ProductID = {0}", 1)
   .LIMIT(1);

Console.WriteLine(insert);
Console.WriteLine(update);
Console.WriteLine(delete);
```

Outputs:

```sql
INSERT INTO Products(ProductName, UnitPrice, CategoryID)
VALUES ({0}, {1}, {2})

UPDATE Products
SET Discontinued = {0}
WHERE ProductID = {1}

DELETE FROM Products
WHERE ProductID = {0}
LIMIT 1
```

You can see here some methods that do not take the format string, like [VALUES][12] and [LIMIT][13]. Since the format of these clauses is well known, all you need to pass in are parameters.

Extensibility
-------------
To understand how SqlBuilder can be extended let's take a look at how some of the built-in clauses are implemented:

```csharp
public SqlBuilder SELECT(string format, params object[] args) {
   return AppendClause("SELECT", ", ", format, args);
}

public SqlBuilder FROM(string format, params object[] args) {
   return AppendClause("FROM", ", ", format, args);
}

public SqlBuilder JOIN(string format, params object[] args) {
   return AppendClause("JOIN", null, format, args);
}
```

As you can see implementing a clause can be as easy as writing one line of code, it all depends on the parameters you define and how much you need to analyze them to produce a format string. Alternatively, you can access the underlying [StringBuilder][14] directly to append text, through the [Buffer][15] property.

Mapping to objects with Entity Framework (DbContext)
----------------------------------------------------
As stated in the design goals, getting and mapping data is beyond the scope of SqlBuilder, so to get data we need a data access component. SqlBuilder was inspired by LINQ to SQL's [ExecuteQuery][16] and [ExecuteCommand][17] methods. Entity Framework provides the same functionality with the [SqlQuery][18] and [ExecuteSqlCommand][19] methods:

```csharp
public class NorthwindContext : DbContext {

   public DbSet<Product> Products { get; set; }

   public NorthwindContext() 
      : base("name=Northwind") { }

   public IEnumerable<Product> GetProducts(int? categoryId) {

      var query = SQL
         .SELECT("ProductID, ProductName, UnitPrice")
         .FROM("Products")
         .WHERE()
         ._If(categoryId.HasValue, "CategoryID = {0}", categoryId)
         .ORDER_BY("ProductName");

      return this.Database.SqlQuery<Product>(query.ToString(), query.ParameterValues.ToArray());
   }
}
```

Entity Framework maps columns to properties based on the column aliases used.

Mapping to objects with DbExtensions
------------------------------------
SqlBuilder is part of the DbExtensions library, which also supports automatic mapping based on column aliases, including many-to-one associations:

```csharp
readonly Database db = new Database("name=Northwind");

public IEnumerable<Product> GetProducts(int? categoryId) {

   var query = SQL
      .SELECT("p.ProductID, p.ProductName, p.UnitPrice, p.CategoryID")
      ._("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName")
      .FROM("Products p")
      .JOIN("Categories c ON p.CategoryID = c.CategoryID")
      .WHERE()
      ._If(categoryId.HasValue, "p.CategoryID = {0}", categoryId);

   return this.db.Map<Product>(query);      
}
```

Note the aliases `Category$CategoryID` and `Category$CategoryName`, these are used to tell the mapper to set `CategoryID` and `CategoryName` on the `Product.Category` association property.

Conclusions
-----------
SqlBuilder helps your build dynamic SQL in a database/ORM independent way. A generic query API like LINQ works great for simple queries, but its statically-typed nature tends to become a disadvantage for complex scenarios, and is very difficult to extend. Many ORM products have their own query APIs, but using them means marrying to a particular product and more APIs to learn. To optimize queries you require complete of the executing SQL. SqlBuilder gives you that control, freeing you from dealing with low-level objects like DbCommand and DbParameter.

[1]: api/DbExtensions/SqlBuilder/README.md
[2]: http://msdn.microsoft.com/en-us/library/system.string.format
[3]: api/DbExtensions/SqlBuilder/ToString.md
[4]: api/DbExtensions/SqlBuilder/ParameterValues.md
[5]: http://msdn.microsoft.com/en-us/library/system.data.common.dbproviderfactory
[6]: http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection
[7]: api/DbExtensions/SqlBuilder/_.md
[8]: api/DbExtensions/SqlBuilder/WHERE.md
[9]: api/DbExtensions/SqlBuilder/_If_3.md
[10]: http://msdn.microsoft.com/en-us/library/system.object
[11]: https://github.com/maxtoroq/DbExtensions/issues/21#issuecomment-38370185
[12]: api/DbExtensions/SqlBuilder/VALUES.md
[13]: api/DbExtensions/SqlBuilder/LIMIT_1.md
[14]: http://msdn.microsoft.com/en-us/library/system.text.stringbuilder
[15]: api/DbExtensions/SqlBuilder/Buffer.md
[16]: http://msdn.microsoft.com/en-us/library/system.data.linq.datacontext.executequery
[17]: http://msdn.microsoft.com/en-us/library/system.data.linq.datacontext.executecommand
[18]: http://msdn.microsoft.com/en-us/library/system.data.entity.database.sqlquery
[19]: http://msdn.microsoft.com/en-us/library/system.data.entity.database.executesqlcommand
