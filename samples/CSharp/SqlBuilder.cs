using System;
using DbExtensions;

namespace Samples.CSharp {

   public class SqlBuilderSamples {

#pragma warning disable CA1822
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

      SqlBuilder DynamicSql(int? categoryId, int? supplierId) {

         return SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE()
            ._If(categoryId.HasValue, $"p.CategoryID = {categoryId.Value}")
            ._If(supplierId.HasValue, $"p.SupplierID = {supplierId.Value}")
            .ORDER_BY("p.ProductName, p.ProductID DESC");
      }

      public SqlBuilder Subquery() {

         return SQL
            .SELECT($"o.OrderID, o.CustomerID, ({SQL
               .SELECT("COUNT(od.Quantity)")
               .FROM("OrderDetails od")
               .WHERE("od.OrderID = o.OrderID")}) AS TotalItems")
            .FROM("Orders o");
      }

      public SqlBuilder ExtendRawSql() {

         return ((SqlBuilder)$"""
             SELECT ProductID, ProductName
             FROM Products
             """)
            .WHERE($"CategoryID = {1}");
      }

      public SqlBuilder ListArgument() {

         int[] range = { 1, 2, 3 };

         return SQL
            .SELECT("p.ProductID, p.CategoryID")
            .FROM("Products p")
            .WHERE($"p.CategoryID = {1} AND p.ProductID IN ({range:list})")
            ._($"EXISTS ({SQL
               .SELECT("ProductID")
               .FROM("OrderDetails")
               .WHERE($"OrderID = {77}")})")
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
            .SET($"Discontinued = {true}")
            .WHERE($"ProductID = {1}");
      }

      public SqlBuilder UpdateWithSubquery() {

         return SQL
            .UPDATE("Products p")
            .SET($"p.Discontinued = {true}")
            .WHERE($"p.ProductID = ({SQL
               .SELECT("p2.ProductID")
               .FROM("Products p2")
               .WHERE("p2.ProductID <> p.ProductID")})");
      }

      public SqlBuilder Delete() {

         return SQL
            .DELETE_FROM("Products")
            .WHERE($"ProductID = {1}");
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
            .FROM("Categories")
            .LEFT_JOIN("Products ON Categories.CategoryID = Products.CategoryID")
            .WHERE($"Products.Discontinued = {0}");
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
            .WHERE($"Products.UnitPrice > ({SQL
               .SELECT("AVG(UnitPrice)")
               .FROM("Products")})");
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
            .WHERE($"(((Orders.ShippedDate) Between {new DateTime(1997, 1, 1)} And {new DateTime(1997, 12, 31)}))")
            .GROUP_BY("Categories.CategoryName, Products.ProductName");
      }
   }
}
