Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Orders")>
   Public Class Order

      <Column>
      Property CustomerID As String

      <Column>
      Property EmployeeID As Integer?

      <Column>
      Property Freight As Decimal?

      <Column>
      Property OrderDate As Date?

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property OrderID As Integer

      <Column>
      Property RequiredDate As Date?

      <Column>
      Property ShipAddress As String

      <Column>
      Property ShipCity As String

      <Column>
      Property ShipCountry As String

      <Column>
      Property ShipName As String

      <Column>
      Property ShippedDate As Date?

      <Column>
      Property ShipPostalCode As String

      <Column>
      Property ShipRegion As String

      <Column>
      Property ShipVia As Integer?

      <Association(ThisKey:=NameOf(CustomerID))>
      Property Customer As Customer

      <Association(ThisKey:=NameOf(EmployeeID))>
      Property Employee As Employee

      <Association(OtherKey:=NameOf(OrderDetail.OrderID))>
      ReadOnly Property OrderDetails As New Collection(Of OrderDetail)

      <Association(ThisKey:=NameOf(ShipVia))>
      Property Shipper As Shipper

   End Class

End Namespace
