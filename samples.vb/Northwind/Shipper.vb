Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Shippers")>
   Public Class Shipper

      <Column(CanBeNull:=False)>
      Public Property CompanyName As String

      <Association(OtherKey:="ShipVia")>
      Public Property Orders As Collection(Of Order)

      <Column()>
      Public Property Phone As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property ShipperID As Integer

      Public Sub New()
         Me.Orders = New Collection(Of Order)
      End Sub
   End Class

End Namespace

