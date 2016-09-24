Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Orders")>
   Public Class Order

      <Column>
      Public Property CustomerID As String

      <Column>
      Public Property EmployeeID As Integer?

      <Column>
      Public Property Freight As Decimal?

      <Column>
      Public Property OrderDate As DateTime?

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property OrderID As Integer

      <Column>
      Public Property RequiredDate As DateTime?

      <Column>
      Public Property ShipAddress As String

      <Column>
      Public Property ShipCity As String

      <Column>
      Public Property ShipCountry As String

      <Column>
      Public Property ShipName As String

      <Column>
      Public Property ShippedDate As DateTime?

      <Column>
      Public Property ShipPostalCode As String

      <Column>
      Public Property ShipRegion As String

      <Column>
      Public Property ShipVia As Integer?

      <Association(ThisKey:=NameOf(CustomerID))>
      Public Property Customer As Customer

      <Association(ThisKey:=NameOf(EmployeeID))>
      Public Property Employee As Employee

      <Association(OtherKey:=NameOf(OrderDetail.OrderID))>
      Public ReadOnly Property OrderDetails As New Collection(Of OrderDetail)

      <Association(ThisKey:=NameOf(ShipVia))>
      Public Property Shipper As Shipper

   End Class

End Namespace

