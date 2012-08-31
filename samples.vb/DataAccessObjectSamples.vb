Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Transactions
Imports DbExtensions
Imports Samples.VisualBasic.Northwind

Public Class DataAccessObjectSamples

   ReadOnly db As NorthwindContext

   Public Sub New(ByVal db As NorthwindContext)
      Me.db = db
   End Sub

   Public Function Find() As Product
      Return db.Products.Find(1)
   End Function

   Public Function PredicateOnly() As IEnumerable(Of Product)
      Return db.Products.Where("ProductID <= {0}", 7).Map()
   End Function

   Public Sub Refresh()

      Dim product As Product = db.Products.Find(1)

      Debug.Assert((product.ProductName = "Chai"))

      product.ProductName = "xxx"

      db.Products.Refresh(product)

      Debug.Assert((product.ProductName = "Chai"))

   End Sub

   Public Sub DefaultValues()

      Dim product As New Product()

      Debug.Assert(product.UnitsInStock Is Nothing)

      db.Products.FillDefaults(product)

      Debug.Assert(product.UnitsInStock = 0)

   End Sub

   Public Sub Transactions_Dao()

      Using tx = db.EnsureInTransaction()
         '' Connection is automatically opened if not open

         Transactions_DoWork()

         tx.Commit()
      End Using
      '' Connection is closed if wasn't open

   End Sub


   Public Sub Transactions_TransactionScope()

      Using tx As New TransactionScope()
         Using db.EnsureConnectionOpen()
            '' Open connection if not open

            Transactions_DoWork()

            tx.Complete()
         End Using

         '' Connection is closed if wasn't open
      End Using
   End Sub

   Private Sub Transactions_DoWork()

      Dim order As New Order With {
         .CustomerID = "ALFKI"
      }

      order.OrderDetails.Add(New OrderDetail With {.ProductID = 77, .Quantity = 1})
      order.OrderDetails.Add(New OrderDetail With {.ProductID = 41, .Quantity = 2})

      db.Orders.InsertDeep(order)

      order.Freight = 10

      db.Orders.Update(order)

      db.Affect(db.Set(Of OrderDetail) _
         .DELETE_FROM() _
         .WHERE("OrderID = {0}", order.OrderID) _
         , order.OrderDetails.Count)

      db.Orders.Delete(order)

   End Sub

End Class

