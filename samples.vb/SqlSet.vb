Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Text
Imports DbExtensions
Imports Samples.VisualBasic.Northwind

Public Class SqlSetSamples

   ReadOnly connection As DbConnection
   ReadOnly productSet As SqlSet(Of Product)

   Public Sub New(ByVal connectionString As String, ByVal log As TextWriter)
      Me.connection = DbFactory.CreateConnection(connectionString)
      Me.productSet = Me.connection.Set(Of Product)(New SqlBuilder("SELECT * FROM Products"), log)
   End Sub

   Public Function AreThereAnyProducts() As Object
      Return productSet.Any()
   End Function

   Public Function DoAllProductsHaveUnitPrice() As Object
      Return productSet.All("NOT UnitPrice IS NULL")
   End Function

   Public Function DoSomeProductsAreOutOfStock() As Object
      Return productSet.Any("UnitsInStock = 0")
   End Function

   Public Function HowManyProductsAreOutOfStock() As Object
      Return productSet.Count("UnitsInStock = 0")
   End Function

   Public Function FirstProduct() As Product
      Return productSet.First()
   End Function

   Public Function SecondProduct() As Product
      Return productSet.Skip(1).First()
   End Function

   Public Function FirstOutOfStockProduct() As Product
      Return productSet.First("UnitsInStock = 0")
   End Function

   Public Function Top5ProductsWithLowestStock() As IEnumerable

      Return productSet.Where("UnitsInStock > 0") _
         .OrderBy("UnitsInStock") _
         .Take(5) _
         .Select(Function(r) New With {.Name = r.GetString("ProductName"), .UnitsInStock = r.GetInt16("UnitsInStock")}) _
         .AsEnumerable()

   End Function

   Public Function NamesOfOutOfStockProducts() As Object

      Return productSet.Where("UnitsInStock = 0") _
         .Select(Function(r) r.GetString(0), "ProductName") _
         .ToArray()

   End Function

   Public Function GetSpecificProduct() As Product
      Return productSet.SingleOrDefault("ProductID = 5")
   End Function

End Class
