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

   ReadOnly productSet As SqlSet(Of Product)

   Public Sub New(ByVal conn As DbConnection, ByVal log As TextWriter)
      Me.productSet = conn.From(Of Product)("Products", log)
   End Sub

   Public Function AreThereAnyProducts() As Boolean
      Return productSet.Any()
   End Function

   Public Function DoAllProductsHaveUnitPrice() As Boolean
      Return productSet.All("NOT UnitPrice IS NULL")
   End Function

   Public Function DoSomeProductsAreOutOfStock() As Boolean
      Return productSet.Any("UnitsInStock = 0")
   End Function

   Public Function HowManyProductsAreOutOfStock() As Integer
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
         .Select(Function(r) New With {.Name = r.GetString(0), .UnitsInStock = r.GetInt16(1)}, "ProductName, UnitsInStock") _
         .AsEnumerable()

   End Function

   Public Function NamesOfOutOfStockProducts() As IEnumerable(Of String)

      Return productSet.Where("UnitsInStock = 0") _
         .Select(Function(r) r.GetString(0), "ProductName") _
         .AsEnumerable()

   End Function

   Public Function GetSpecificProduct() As Product
      Return productSet.SingleOrDefault("ProductID = 5")
   End Function

End Class
