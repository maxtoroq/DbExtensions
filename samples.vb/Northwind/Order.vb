Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Orders")>
   Public Class Order

      <Association(ThisKey:="CustomerID", IsForeignKey:=True)>
      Public Property Customer As Customer

      <Column(CanBeNull:=False)>
      Public Property CustomerID As String

      <Association(ThisKey:="EmployeeID", IsForeignKey:=True)>
      Public Property Employee As Employee

      <Column()>
      Public Property EmployeeID As Integer?

      <Column()>
      Public Property Freight As Decimal?

      <Column()>
      Public Property OrderDate As DateTime?

      <Association(OtherKey:="OrderID")>
      Public Property OrderDetails As Collection(Of OrderDetail)

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property OrderID As Integer

      <Column()>
      Public Property RequiredDate As DateTime?

      <Column()>
      Public Property ShipAddress As String

      <Column()>
      Public Property ShipCity As String

      <Column()>
      Public Property ShipCountry As String

      <Column()>
      Public Property ShipName As String

      <Column()>
      Public Property ShippedDate As DateTime?

      <Association(ThisKey:="ShipVia", IsForeignKey:=True)>
      Public Property Shipper As Shipper

      <Column()>
      Public Property ShipPostalCode As String

      <Column()>
      Public Property ShipRegion As String

      <Column()>
      Public Property ShipVia As Integer?

      Public Sub New()
         Me.OrderDetails = New Collection(Of OrderDetail)
      End Sub
   End Class

End Namespace

