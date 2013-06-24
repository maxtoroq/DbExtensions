Imports System.Data.Linq.Mapping
Imports DbExtensions

Namespace Northwind

   Public Class NorthwindDatabase
      Inherits Database

      Public ReadOnly Property Products As SqlTable(Of Product)
         Get
            Return Table(Of Product)()
         End Get
      End Property

      Public ReadOnly Property Orders As SqlTable(Of Order)
         Get
            Return Table(Of Order)()
         End Get
      End Property

      Public ReadOnly Property OrderDetails As SqlTable(Of OrderDetail)
         Get
            Return Table(Of OrderDetail)()
         End Get
      End Property

      Public Sub New(ByVal connectionString As String)
         MyBase.New(connectionString)
      End Sub

      Public Sub New(ByVal connectionString As String, ByVal mapping As MetaModel)
         MyBase.New(connectionString, mapping)
      End Sub

   End Class
End Namespace
