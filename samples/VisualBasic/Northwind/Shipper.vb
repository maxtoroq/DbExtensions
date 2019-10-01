Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Shippers")>
   Public Class Shipper

      <Column>
      Property CompanyName As String

      <Column>
      Property Phone As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property ShipperID As Integer

      <Association(OtherKey:=NameOf(Order.ShipVia))>
      ReadOnly Property Orders As New Collection(Of Order)

   End Class

End Namespace
