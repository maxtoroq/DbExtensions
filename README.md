The SQL framework for .NET
=============================================================================== 
DbExtensions consists of 4 components that can be used together 
or separately: 

1. A set of extension methods that simplifies raw ADO.NET programming
2. A POCO query API: `SqlSet`
3. An API for building SQL queries: `SqlBuilder`
4. CRUD operations: `Database`, `SqlTable`

The key features of this library are the granularity of its components and code aesthetics.

Querying with SqlSet
--------------------
```csharp
DbConnection conn = Database.CreateConnection("name=Northwind");

SqlSet<Product> products = conn.From<Product>("Products");
SqlSet<Product> productsToReorder = products.Where("UnitsInStock < {0}", 10);

if (productsToReorder.Any()) {

   SqlSet<Product> top5WithLowestStock = productsToReorder.OrderBy("UnitsInStock").Take(5);
   Product first = top5WithLowestStock.First();

   if (top5WithLowestStock.Count() > 1) {
      Product second = top5WithLowestStock.Skip(1).First();
   }
}
```
`SqlSet` provides a LINQish API for making queries, but using SQL instead of lambda expressions. The above code executes the following queries:

```sql
SELECT (CASE WHEN EXISTS (
   SELECT *
   FROM Products
   WHERE UnitsInStock < @p0) THEN 1 ELSE 0 END)
-- @p0: Input Int32 (Size = 0) [10]
-- [-1] records affected.
SELECT *
FROM (
   SELECT *
   FROM Products
   WHERE UnitsInStock < @p0
   ORDER BY UnitsInStock
   LIMIT @p1) dbex_set5
LIMIT @p2
-- @p0: Input Int32 (Size = 0) [10]
-- @p1: Input Int32 (Size = 0) [5]
-- @p2: Input Int32 (Size = 0) [1]
-- [-1] records affected.
SELECT COUNT(*)
FROM (
   SELECT *
   FROM Products
   WHERE UnitsInStock < @p0
   ORDER BY UnitsInStock
   LIMIT @p1) dbex_count
-- @p0: Input Int32 (Size = 0) [10]
-- @p1: Input Int32 (Size = 0) [5]
-- [-1] records affected.
SELECT *
FROM (
   SELECT *
   FROM Products
   WHERE UnitsInStock < @p0
   ORDER BY UnitsInStock
   LIMIT @p1) dbex_set6
LIMIT @p2
OFFSET @p3
-- @p0: Input Int32 (Size = 0) [10]
-- @p1: Input Int32 (Size = 0) [5]
-- @p2: Input Int32 (Size = 0) [1]
-- @p3: Input Int32 (Size = 0) [1]
-- [-1] records affected.
```

Building queries with SqlBuilder
--------------------------------
```csharp
var query = SQL
   .SELECT("p.ProductID, p.ProductName, s.UnitPrice, p.CategoryID")
   ._("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName")
   .FROM("Products p")
   .JOIN("Categories c ON p.CategoryID = c.CategoryID")
   .WHERE()
   ._If(categoryId.HasValue, "p.CategoryID = {0}", categoryId);

IEnumerable<Product> products = conn.Map<Product>(query);
```
With `SqlBuilder` you have complete control of the executing SQL.

Changing data
-------------
```csharp
public class NorthwindDatabase : Database {
   
   public SqlTable<Product> Products { // SqlTable inherits from SqlSet
      get { return Table<Product>(); } 
   }

   public NorthwindDatabase() 
      : base("name=Northwind") { }
}

var db = new NorthwindDatabase();

Product prod = db.Products.Find(1);
prod.UnitPrice = prod.UnitPrice * 1.1;

db.Products.Update(prod);
```
You can also use `SqlBuilder` to build insert, update and delete commands.

Features
--------
- Deferred execution
- POCO and dynamic mapping for queries
  - Mapping to properties (including complex)
  - Mapping to constructor arguments
- Attributes or XML mapping for inserts, updates and deletes, using [System.Data.Linq.Mapping](http://msdn.microsoft.com/library/system.data.linq.mapping) (LINQ to SQL mapping)
- Generic and non-generic APIs (for when the type of the entity is not known at build time)
- Automatic connection management (no need to explicitly open connection, but you are allowed to)
- Optimistic concurrency (using version column)
- Batch and deep commands (e.g. recursively insert entity and all one-to-many associations)
- Query results as XML
- Profiling
- Provider-independent (tested against SQLite, SQL Server Compact, SQL Server and MySQL)

Not included
------------------------
DbExtensions doesn't provide the following functionality:

- Identity map
- Lazy loading
- Change tracking
- Unit of work

Limitations
-----------
- For SQL Server and SQL Server Compact, `SqlSet.Skip()` uses OFFSET, available
  in SQL Server 2012 and SQL Server Compact 4

Source code and releases
------------------------
Code hosted on [GitHub](https://github.com/maxtoroq/DbExtensions). 
Releases available on [GitHub](https://github.com/maxtoroq/DbExtensions/releases)
and [NuGet](http://www.nuget.org/packages/DbExtensions).

This project was originally hosted on [SourceForge](https://sourceforge.net/projects/dbextensions/), source code and releases for
versions 1.x, 2.x and 3.x remain available there.

Resources
---------
- [Documentation](https://github.com/maxtoroq/DbExtensions/wiki)
- [Ask for help](https://github.com/maxtoroq/DbExtensions/issues?labels=question&state=closed)
- [Report an issue](https://github.com/maxtoroq/DbExtensions/issues?state=open)
- [Roadmap](https://github.com/maxtoroq/DbExtensions/issues/milestones)

<a href="https://github.com/maxtoroq/DbExtensions/wiki/Donate"><img src="http://maxtoroq.users.sourceforge.net/donate/paypal/btn_donate_SM.gif" alt="Donate"/></a>
<a href="http://flattr.com/thing/1761218/DbExtensions" target="_blank"><img src="http://api.flattr.com/button/flattr-badge-large.png" alt="Flattr this" title="Flattr this" border="0" /></a>
