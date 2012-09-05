Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports DbExtensions

Public Class SqlBuilderSamples

   Public Function DynamicSql_1() As SqlBuilder
      Return DynamicSql(2, 3)
   End Function

   Public Function DynamicSql_2() As SqlBuilder
      Return DynamicSql(Nothing, 3)
   End Function

   Public Function DynamicSql_3() As SqlBuilder
      Return DynamicSql(2, Nothing)
   End Function

   Public Function DynamicSql_4() As SqlBuilder
      Return DynamicSql(Nothing, Nothing)
   End Function

   Private Function DynamicSql(ByVal categoryId As Integer?, ByVal supplierId As Integer?) As SqlBuilder

      Return SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .FROM("Products p") _
         .WHERE() _
         ._If(categoryId.HasValue, "p.CategoryID = {0}", categoryId) _
         ._If(supplierId.HasValue, "p.SupplierID = {0}", supplierId) _
         .ORDER_BY("p.ProductName, p.ProductID DESC")

   End Function


   Public Function [Or]() As SqlBuilder

      Dim parameters()() As Integer = {New Integer() {1, 2}, New Integer() {3, 4}}

      Return SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .FROM("Products p") _
         .WHERE() _
         ._OR(parameters, "(p.CategoryID = {0} AND p.SupplierID = {1})", Function(p) New Object() {p(0), p(1)}) _
         .ORDER_BY("p.ProductName, p.ProductID DESC")

   End Function

   Public Function Subquery() As SqlBuilder

      Return SQL _
         .SELECT("o.OrderID, o.CustomerID, ({0}) AS TotalItems", SQL _
            .SELECT("COUNT(od.Quantity)") _
            .FROM("OrderDetails od") _
            .WHERE("od.OrderID = o.OrderID")) _
         .FROM("Orders o")

   End Function

   ''' <remarks>
   ''' If there's a large chunk of the query that is static you can pass it to the
   ''' constructor and extend it from there.
   ''' </remarks>
   Public Function ExtendRawSql() As SqlBuilder

      Return SQL.ctor(
         "SELECT ProductID, ProductName" &
         "FROM Products") _
         .WHERE("CategoryID = {0}", 1)

   End Function

   Public Function ArrayArgument() As SqlBuilder

      Dim range = New Integer() {1, 2, 3}

      Return SQL _
         .SELECT("p.ProductID, p.CategoryID") _
         .FROM("Products p") _
         .WHERE("p.CategoryID = {0} AND p.ProductID IN ({1})", 1, range) _
         .WHERE("EXISTS ({0})", SQL _
            .SELECT("ProductID") _
            .FROM("OrderDetails") _
            .WHERE("OrderID = {0}", 77)) _
         .GROUP_BY("p.ProductID")

   End Function

   Public Function Insert() As SqlBuilder

      Return SQL _
         .INSERT_INTO("Products(ProductName, UnitPrice, CategoryID)") _
         .VALUES("Chai", 15.56, 5)

   End Function

   Public Function Update() As SqlBuilder

      Return SQL _
         .UPDATE("Products") _
         .SET("Discontinued = {0}", True) _
         .WHERE("ProductID = {0}", 1)

   End Function

   Public Function UpdateWithSubquery() As SqlBuilder

      Return SQL _
         .UPDATE("Products p") _
         .SET("p.Discontinued = {0}", True) _
         .WHERE("p.ProductID = ({0})", SQL _
            .SELECT("p2.ProductID") _
            .FROM("Products p2") _
            .WHERE("p2.ProductID <> p.ProductID"))

   End Function

   Public Function Delete() As SqlBuilder

      Return SQL _
         .DELETE_FROM("Products") _
         .WHERE("ProductID = {0}", 1)

   End Function

   ''' <summary>
   ''' SELECT Products.*, Categories.CategoryName
   ''' FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
   ''' WHERE (((Products.Discontinued)=0))
   ''' </summary>
   ''' <remarks>Northwind.Alphabetical list of products</remarks>
   Public Function AlphabeticalListOfProducts() As SqlBuilder

      Return SQL _
         .SELECT("Products.*, Categories.CategoryName") _
         .FROM("Categories") _
         .LEFT_JOIN("Products ON Categories.CategoryID = Products.CategoryID") _
         .WHERE("Products.Discontinued = {0}", 0)

   End Function

   ''' <summary>
   ''' SELECT City, CompanyName, ContactName, 'Customers' AS Relationship 
   ''' FROM Customers
   ''' UNION SELECT City, CompanyName, ContactName, 'Suppliers'
   ''' FROM Suppliers
   ''' </summary>
   ''' <remarks>Northwind.Customer and Suppliers by City</remarks>
   Public Function CustomersAndSuppliersByCity() As SqlBuilder

      Return SQL _
         .SELECT("City, CompanyName, ContactName, 'Customers' AS Relationship") _
         .FROM("Customers") _
         .UNION _
         .SELECT("City, CompanyName, ContactName, 'Suppliers'") _
         .FROM("Suppliers")

   End Function

   ''' <summary>
   ''' SELECT Products.ProductName, Products.UnitPrice
   ''' FROM Products
   ''' WHERE Products.UnitPrice > (SELECT AVG(UnitPrice) From Products)
   ''' </summary>
   ''' <remarks>Northwind.Products Above Average Price</remarks>
   Public Function ProductsAboveAveragePrice() As SqlBuilder

      Return SQL _
         .SELECT("Products.ProductName, Products.UnitPrice") _
         .FROM("Products") _
         .WHERE("Products.UnitPrice > ({0})", SQL _
            .SELECT("AVG(UnitPrice)") _
            .FROM("Products"))

   End Function

   ''' <summary>
   ''' SELECT Categories.CategoryName, Products.ProductName, 
   ''' Sum(CONVERT(money,("Order Details".UnitPrice*Quantity*(1-Discount)/100))*100) AS ProductSales
   ''' FROM (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID) 
   ''' INNER JOIN (Orders 
   '''       INNER JOIN "Order Details" ON Orders.OrderID = "Order Details".OrderID) 
   '''    ON Products.ProductID = "Order Details".ProductID
   ''' WHERE (((Orders.ShippedDate) Between '19970101' And '19971231'))
   ''' GROUP BY Categories.CategoryName, Products.ProductName
   ''' </summary>
   ''' <remarks>Northwind.Product Sales for 1997</remarks>
   Public Function ProductSalesFor1997() As SqlBuilder

      Return SQL _
         .SELECT("Categories.CategoryName, Products.ProductName, Sum(CONVERT(money,(""Order Details"".UnitPrice*Quantity*(1-Discount)/100))*100) AS ProductSales") _
         .FROM("(Categories").INNER_JOIN("Products ON Categories.CategoryID = Products.CategoryID)") _
         .INNER_JOIN("(Orders").INNER_JOIN("""Order Details"" ON Orders.OrderID = ""Order Details"".OrderID) ON Products.ProductID = ""Order Details"".ProductID") _
         .WHERE("(((Orders.ShippedDate) Between {0} And {1}))", DateTime.Parse("1997-01-01"), DateTime.Parse("1997-12-31")) _
         .GROUP_BY("Categories.CategoryName, Products.ProductName")

   End Function

End Class

