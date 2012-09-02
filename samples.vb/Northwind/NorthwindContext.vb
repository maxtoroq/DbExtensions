Imports System.Data.Linq.Mapping
Imports DbExtensions

Namespace Northwind

   Public Class NorthwindContext
      Inherits DataAccessObject

      Public Property Products As SqlTable(Of Product)
         Get
            Return Table(Of Product)()
         End Get
         Set(value As SqlTable(Of Product))
         End Set
      End Property

      Public Property Orders As SqlTable(Of Order)
         Get
            Return Table(Of Order)()
         End Get
         Set(value As SqlTable(Of Order))
         End Set
      End Property

      Public Sub New(ByVal connString As String, ByVal mapping As MetaModel)
         MyBase.New(connString, mapping)
      End Sub

   End Class
End Namespace
