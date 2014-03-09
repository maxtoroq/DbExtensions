namespace Samples.FSharp

open System
open DbExtensions

type SqlBuilderSamples() =

   let DynamicSql(categoryId : Nullable<int>, supplierId : Nullable<int>) =

      SQL
         .SELECT("p.ProductID, p.ProductName")
         .FROM("Products p")
         .WHERE()
         ._If(categoryId.HasValue, "p.CategoryID = {0}", categoryId)
         ._If(supplierId.HasValue, "p.SupplierID = {0}", supplierId)
         .ORDER_BY("p.ProductName, p.ProductID DESC")

   member this.DynamicSql_1() =
      DynamicSql(new Nullable<int>(2), new Nullable<int>(3))
   
   member this.DynamicSql_2() =
      DynamicSql(new Nullable<int>(), new Nullable<int>(3))

   member this.DynamicSql_3() =
      DynamicSql(new Nullable<int>(2), new Nullable<int>())

   member this.DynamicSql_4() =
      DynamicSql(new Nullable<int>(), new Nullable<int>())

   member this.Or() =

      let parameters = [| [| 1; 2 |]; [| 3; 4 |] |]
      
      SQL
         .SELECT("p.ProductID, p.ProductName")
         .FROM("Products p")
         .WHERE()
         ._OR(parameters, "(p.CategoryID = {0} AND p.SupplierID = {1})", fun (p) -> [| p.[0]; p.[1] |])
         .ORDER_BY("p.ProductName, p.ProductID DESC")

   member this.Subquery() =

      SQL
         .SELECT("o.OrderID, o.CustomerID, ({0}) AS TotalItems", SQL
            .SELECT("COUNT(od.Quantity)")
            .FROM("OrderDetails od")
            .WHERE("od.OrderID = o.OrderID"))
         .FROM("Orders o")

   /// <remarks>
   /// If there's a large chunk of the query that is static you can pass it to the
   /// constructor and extend it from there.
   /// </remarks>
   member this.ExtendRawSql() =

      (new SqlBuilder(@"
         SELECT ProductID, ProductName
         FROM Products"))
         .WHERE("CategoryID = {0}", 1);

   member this.ArrayArgument() =

      let range = [| 1; 2; 3 |]

      SQL
         .SELECT("p.ProductID, p.CategoryID")
         .FROM("Products p")
         .WHERE("p.CategoryID = {0} AND p.ProductID IN ({1})", 1, range)
         .WHERE("EXISTS ({0})", SQL
            .SELECT("ProductID")
            .FROM("OrderDetails")
            .WHERE("OrderID = {0}", 77))
         .GROUP_BY("p.ProductID");
      
   member this.Insert() =

      SQL
         .INSERT_INTO("Products(ProductName, UnitPrice, CategoryID)")
         .VALUES("Chai", 15.56, 5)

   member this.Update() =

      SQL
         .UPDATE("Products")
         .SET("Discontinued = {0}", true)
         .WHERE("ProductID = {0}", 1)

   member this.UpdateWithSubquery() =

      SQL
         .UPDATE("Products p")
         .SET("p.Discontinued = {0}", true)
         .WHERE("p.ProductID = ({0})", SQL
            .SELECT("p2.ProductID")
            .FROM("Products p2")
            .WHERE("p2.ProductID <> p.ProductID"))

   member this.Delete() =

      SQL
         .DELETE_FROM("Products")
         .WHERE("ProductID = {0}", 1);

   /// <summary>
   /// SELECT Products.*, Categories.CategoryName
   /// FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
   /// WHERE (((Products.Discontinued)=0))
   /// </summary>
   /// <remarks>Northwind.Alphabetical list of products</remarks>
   member this.AlphabeticalListOfProducts() =

      SQL
         .SELECT("Products.*, Categories.CategoryName")
         .FROM("Categories").LEFT_JOIN("Products ON Categories.CategoryID = Products.CategoryID")
         .WHERE("Products.Discontinued = {0}", 0);

   /// <summary>
   /// SELECT City, CompanyName, ContactName, 'Customers' AS Relationship 
   /// FROM Customers
   /// UNION SELECT City, CompanyName, ContactName, 'Suppliers'
   /// FROM Suppliers
   /// </summary>
   /// <remarks>Northwind.Customer and Suppliers by City</remarks>
   member this.CustomersAndSuppliersByCity() =

      SQL
         .SELECT("City, CompanyName, ContactName, 'Customers' AS Relationship")
         .FROM("Customers")
         .UNION()
         .SELECT("City, CompanyName, ContactName, 'Suppliers'")
         .FROM("Suppliers");

   /// <summary>
   /// SELECT Products.ProductName, Products.UnitPrice
   /// FROM Products
   /// WHERE Products.UnitPrice > (SELECT AVG(UnitPrice) From Products)
   /// </summary>
   /// <remarks>Northwind.Products Above Average Price</remarks>
   member this.ProductsAboveAveragePrice() =

      SQL
         .SELECT("Products.ProductName, Products.UnitPrice")
         .FROM("Products")
         .WHERE("Products.UnitPrice > ({0})", SQL
            .SELECT("AVG(UnitPrice)")
            .FROM("Products")
         );

   /// <summary>
   /// SELECT Categories.CategoryName, Products.ProductName, 
   /// Sum(CONVERT(money,("Order Details".UnitPrice*Quantity*(1-Discount)/100))*100) AS ProductSales
   /// FROM (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID) 
   /// INNER JOIN (Orders 
   ///       INNER JOIN "Order Details" ON Orders.OrderID = "Order Details".OrderID) 
   ///    ON Products.ProductID = "Order Details".ProductID
   /// WHERE (((Orders.ShippedDate) Between '19970101' And '19971231'))
   /// GROUP BY Categories.CategoryName, Products.ProductName
   /// </summary>
   /// <remarks>Northwind.Product Sales for 1997</remarks>
   member this.ProductSalesFor1997() =

      SQL
         .SELECT("Categories.CategoryName, Products.ProductName, Sum(CONVERT(money,(\"Order Details\".UnitPrice*Quantity*(1-Discount)/100))*100) AS ProductSales")
         .FROM("(Categories").INNER_JOIN("Products ON Categories.CategoryID = Products.CategoryID)")
         .INNER_JOIN("(Orders").INNER_JOIN("\"Order Details\" ON Orders.OrderID = \"Order Details\".OrderID) ON Products.ProductID = \"Order Details\".ProductID")
         .WHERE("(((Orders.ShippedDate) Between {0} And {1}))", DateTime.Parse("1997-01-01"), DateTime.Parse("1997-12-31"))
         .GROUP_BY("Categories.CategoryName, Products.ProductName")