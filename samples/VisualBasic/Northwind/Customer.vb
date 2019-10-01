Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Customers")>
   Public Class Customer

      <Column>
      Property Address As String

      <Column>
      Property City As String

      <Column>
      Property CompanyName As String

      <Column>
      Property ContactName As String

      <Column>
      Property ContactTitle As String

      <Column>
      Property Country As String

      <Column(IsPrimaryKey:=True)>
      Property CustomerID As String

      <Column>
      Property Fax As String

      <Column>
      Property Phone As String

      <Column>
      Property PostalCode As String

      <Column>
      Property [Region] As String

      <Association(OtherKey:=NameOf(CustomerCustomerDemo.CustomerID))>
      ReadOnly Property CustomerCustomerDemos As New Collection(Of CustomerCustomerDemo)

      <Association(OtherKey:=NameOf(Order.CustomerID))>
      ReadOnly Property Orders As New Collection(Of Order)

   End Class

End Namespace
