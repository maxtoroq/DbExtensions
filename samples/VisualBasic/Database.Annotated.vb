Imports System
Imports System.Transactions
Imports Samples.VisualBasic.Northwind

Public Class DatabaseAnnotatedSamples

   ReadOnly db As NorthwindDatabase

   Sub New(ByVal db As NorthwindDatabase)
      Me.db = db
   End Sub

   Function IncludeManyToOne() As IEnumerable(Of Product)

      Return db.Products _
         .Include("Category") _
         .Include("Supplier") _
         .Take(3) _
         .AsEnumerable()

   End Function

   Function IncludeManyToOneNested() As IEnumerable(Of EmployeeTerritory)

      Return db.EmployeeTerritories _
         .Include("Territory.Region") _
         .Take(3) _
         .AsEnumerable()

   End Function

   Function IncludeOneToMany() As Region

      Return db.Regions _
         .Include("Territories") _
         .First()

   End Function

   Function ContainsKey() As Boolean
      Return db.Products.ContainsKey(1)
   End Function

   Function Find() As Product
      Return db.Products.Find(1)
   End Function

   Sub Transactions_AdoNet()

      Using tx = db.EnsureInTransaction()
         ' Connection is automatically opened if not open

         Transactions_DoWork()

         tx.Commit()
      End Using
      ' Connection is closed if wasn't open

   End Sub

   Sub Transactions_TransactionScope()

      Using tx As New TransactionScope()
         Using db.EnsureConnectionOpen()
            ' Open connection if not open

            Transactions_DoWork()

            tx.Complete()
         End Using

         ' Connection is closed if wasn't open
      End Using
   End Sub

   Private Sub Transactions_DoWork()

      Dim order As New Order With {
         .CustomerID = "ALFKI"
      }

      order.OrderDetails.Add(New OrderDetail With {.ProductID = 77, .Quantity = 1})
      order.OrderDetails.Add(New OrderDetail With {.ProductID = 41, .Quantity = 2})

      db.Orders.Add(order)

      order.Freight = 10

      db.Orders.Update(order)

      ' The following line is not needed when cascade delete is configured on the database
      db.OrderDetails.RemoveRange(order.OrderDetails)

      db.Orders.Remove(order)

   End Sub

End Class
