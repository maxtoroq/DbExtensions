Imports System
Imports DbExtensions
Imports Samples.VisualBasic.Northwind

Public Class SqlSetSamples

   ReadOnly products As SqlSet(Of Product)

   Sub New(ByVal db As Database)
      Me.products = db.From(Of Product)("Products")
   End Sub

   Function AreThereAnyProducts() As Boolean
      Return products.Any()
   End Function

   Function DoAllProductsHaveUnitPrice() As Boolean
      Return products.All("NOT UnitPrice IS NULL")
   End Function

   Function DoSomeProductsAreOutOfStock() As Boolean
      Return products.Any("UnitsInStock = 0")
   End Function

   Function HowManyProductsAreOutOfStock() As Integer
      Return products.Count("UnitsInStock = 0")
   End Function

   Function FirstProduct() As Product
      Return products.First()
   End Function

   Function SecondProduct() As Product
      Return products.Skip(1).First()
   End Function

   Function FirstOutOfStockProduct() As Product
      Return products.First("UnitsInStock = 0")
   End Function

   Function Top5ProductsWithLowestStock() As IEnumerable

      Return products _
         .Where("UnitsInStock > 0") _
         .OrderBy("UnitsInStock") _
         .Take(5) _
         .Select(Function(r) New With {.Name = r.GetString(0), .UnitsInStock = r.GetInt16(1)}, "ProductName, UnitsInStock") _
         .AsEnumerable()

   End Function

   Function NamesOfOutOfStockProducts() As IEnumerable(Of String)

      Return products _
         .Where("UnitsInStock = 0") _
         .Select(Function(r) r.GetString(0), "ProductName") _
         .AsEnumerable()

   End Function

   Function GetSpecificProduct() As Product
      Return products.SingleOrDefault("ProductID = 5")
   End Function

End Class
