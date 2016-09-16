Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Shippers")>
   Public Class Shipper

      <Column>
      Public Property CompanyName As String

      <Column>
      Public Property Phone As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property ShipperID As Integer

      <Association(OtherKey:=NameOf(Order.ShipVia))>
      Public ReadOnly Property Orders As New Collection(Of Order)

   End Class

End Namespace

