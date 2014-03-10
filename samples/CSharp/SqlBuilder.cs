using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DbExtensions;

namespace Samples.CSharp {

   public class SqlBuilderSamples {

      public SqlBuilder DynamicSql_1() {
         return DynamicSql(2, 3);
      }

      public SqlBuilder DynamicSql_2() {
         return DynamicSql(null, 3);
      }

      public SqlBuilder DynamicSql_3() {
         return DynamicSql(2, null);
      }

      public SqlBuilder DynamicSql_4() {
         return DynamicSql(null, null);
      }

      private SqlBuilder DynamicSql(int? categoryId, int? supplierId) {

         return SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE()
            ._If(categoryId.HasValue, "p.CategoryID = {0}", categoryId)
            ._If(supplierId.HasValue, "p.SupplierID = {0}", supplierId)
            .ORDER_BY("p.ProductName, p.ProductID DESC");
      }

      public SqlBuilder Or() {

         int[][] parameters = { new[] { 1, 2 }, new[] { 3, 4} };

         return SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE()
            ._OR(parameters, "(p.CategoryID = {0} AND p.SupplierID = {1})", p => new object[] { p[0], p[1] })
            .ORDER_BY("p.ProductName, p.ProductID DESC");
      }

      public SqlBuilder Subquery() {

         return SQL
            .SELECT("o.OrderID, o.CustomerID, ({0}) AS TotalItems", SQL
               .SELECT("COUNT(od.Quantity)")
               .FROM("OrderDetails od")
               .WHERE("od.OrderID = o.OrderID"))
            .FROM("Orders o");
      }

      /// <remarks>
      /// If there's a large chunk of the query that is static you can pass it to the
      /// constructor and extend it from there.
      /// </remarks>
      public SqlBuilder ExtendRawSql() {

         return new SqlBuilder(@"
             SELECT ProductID, ProductName
             FROM Products")
            .WHERE("CategoryID = {0}", 1);
      }

      public SqlBuilder ArrayArgument() {

         int[] range = { 1, 2, 3 };

         return SQL
            .SELECT("p.ProductID, p.CategoryID")
            .FROM("Products p")
            .WHERE("p.CategoryID = {0} AND p.ProductID IN ({1})", 1, range)
            ._("EXISTS ({0})", SQL
               .SELECT("ProductID")
               .FROM("OrderDetails")
               .WHERE("OrderID = {0}", 77))
            .GROUP_BY("p.ProductID");
      }
      
      public SqlBuilder Insert() {

         return SQL
            .INSERT_INTO("Products(ProductName, UnitPrice, CategoryID)")
            .VALUES("Chai", 15.56, 5);
      }

      public SqlBuilder Update() {

         return SQL
            .UPDATE("Products")
            .SET("Discontinued = {0}", true)
            .WHERE("ProductID = {0}", 1);
      }

      public SqlBuilder UpdateWithSubquery() {

         return SQL
            .UPDATE("Products p")
            .SET("p.Discontinued = {0}", true)
            .WHERE("p.ProductID = ({0})", SQL
               .SELECT("p2.ProductID")
               .FROM("Products p2")
               .WHERE("p2.ProductID <> p.ProductID"));
      }

      public SqlBuilder Delete() {

         return SQL
            .DELETE_FROM("Products")
            .WHERE("ProductID = {0}", 1);
      }

      /// <summary>
      /// SELECT Products.*, Categories.CategoryName
      /// FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
      /// WHERE (((Products.Discontinued)=0))
      /// </summary>
      /// <remarks>Northwind.Alphabetical list of products</remarks>
      public SqlBuilder AlphabeticalListOfProducts() {

         return SQL
            .SELECT("Products.*, Categories.CategoryName")
            .FROM("Categories").LEFT_JOIN("Products ON Categories.CategoryID = Products.CategoryID")
            .WHERE("Products.Discontinued = {0}", 0);
      }

      /// <summary>
      /// SELECT City, CompanyName, ContactName, 'Customers' AS Relationship 
      /// FROM Customers
      /// UNION SELECT City, CompanyName, ContactName, 'Suppliers'
      /// FROM Suppliers
      /// </summary>
      /// <remarks>Northwind.Customer and Suppliers by City</remarks>
      public SqlBuilder CustomersAndSuppliersByCity() {

         return SQL
            .SELECT("City, CompanyName, ContactName, 'Customers' AS Relationship")
            .FROM("Customers")
            .UNION()
            .SELECT("City, CompanyName, ContactName, 'Suppliers'")
            .FROM("Suppliers");
      }

      /// <summary>
      /// SELECT Products.ProductName, Products.UnitPrice
      /// FROM Products
      /// WHERE Products.UnitPrice > (SELECT AVG(UnitPrice) From Products)
      /// </summary>
      /// <remarks>Northwind.Products Above Average Price</remarks>
      public SqlBuilder ProductsAboveAveragePrice() {

         return SQL
            .SELECT("Products.ProductName, Products.UnitPrice")
            .FROM("Products")
            .WHERE("Products.UnitPrice > ({0})", SQL
               .SELECT("AVG(UnitPrice)")
               .FROM("Products")
            );
      }

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
      public SqlBuilder ProductSalesFor1997() {

         return SQL
            .SELECT("Categories.CategoryName, Products.ProductName, Sum(CONVERT(money,(\"Order Details\".UnitPrice*Quantity*(1-Discount)/100))*100) AS ProductSales")
            .FROM("(Categories").INNER_JOIN("Products ON Categories.CategoryID = Products.CategoryID)")
            .INNER_JOIN("(Orders").INNER_JOIN("\"Order Details\" ON Orders.OrderID = \"Order Details\".OrderID) ON Products.ProductID = \"Order Details\".ProductID")
            .WHERE("(((Orders.ShippedDate) Between {0} And {1}))", DateTime.Parse("1997-01-01"), DateTime.Parse("1997-12-31"))
            .GROUP_BY("Categories.CategoryName, Products.ProductName");
      }
   }
}
