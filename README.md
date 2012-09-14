The SQL framework for .NET
=============================================================================== 
DbExtensions consists of 4 components that can be used together 
or separately: 

1. A set of extension methods that simplifies raw ADO.NET programming
2. A POCO query API: `SqlSet`
3. An API for building SQL queries: `SqlBuilder`
4. CRUD operations: `Database`, `SqlTable`

The key features of this library are the granularity of it's components and API aesthetics.

Querying with SqlSet (new in v4)
--------------------------------
```csharp
DbConnection conn = DbFactory.CreateConnection("name=Northwind");

SqlSet<Product> products = conn.Set<Product>(new SqlBuilder("SELECT * FROM Products"));
SqlSet<Product> productsToReorder = products.Where("UnitsInStock < {0}", 10);

if (productsToReorder.Any()) {

   SqlSet<Product> top5WithLowestStock = productsToReorder.OrderBy("UnitsInStock").Take(5);
   Product first = top5WithLowestStock.First();

   if (top5WithLowestStock.Count() > 1) {
      Product second = top5WithLowestStock.Skip(1).First();
   }
}
```
`SqlSet` provides a LINQish API for making queries, but using SQL instead of lambda expressions.

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
- POCO support for queries, including many-to-one associations
- Attributes or XML mapping for inserts, updates and deletes, using [System.Data.Linq.Mapping](http://msdn.microsoft.com/library/system.data.linq.mapping) (LINQ to SQL mapping)
- Generic and non-generic APIs (for when the type of the entity is not known at build time)
- Automatic connection management (no need to explicitly open connection, but you are allowed to)
- Optimistic concurrency (using version column)
- Batch and deep inserts (recursively insert entity and all one-to-many associations)
- Delete by primary key
- Query results as XML
- Profiling
- Provider-independent (tested against SQLite, SQL Server CE, SQL Server and MySQL)

DbExtensions does not do
------------------------
- Identity map
- Lazy loading
- Change tracking
- Unit of work

Limitations
-----------
- For SQL Server and SQL Server CE, `SqlSet.Skip()` uses OFFSET, available
  in SQL Server 2012 and SQL Server CE 4

Source code and releases
------------------------
Hosted on [GitHub](https://github.com/maxtoroq/DbExtensions). Also available via [NuGet](http://www.nuget.org/packages/DbExtensions).

This project was originally hosted on [SourceForge](https://sourceforge.net/projects/dbextensions/), source code and releases for
versions 1.x, 2.x and 3.x remain available there.

Resources
---------
- [Documentation](https://github.com/maxtoroq/DbExtensions/wiki)
- [Ask for help](http://sourceforge.net/p/dbextensions/discussion/)
- [Report an issue](https://github.com/maxtoroq/DbExtensions/issues)