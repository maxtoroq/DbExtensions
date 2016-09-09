Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Customers")>
   Public Class Customer

      <Column>
      Public Property Address As String

      <Column>
      Public Property City As String

      <Column>
      Public Property CompanyName As String

      <Column>
      Public Property ContactName As String

      <Column>
      Public Property ContactTitle As String

      <Column>
      Public Property Country As String

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerID As String

      <Column>
      Public Property Fax As String

      <Column>
      Public Property Phone As String

      <Column>
      Public Property PostalCode As String

      <Column>
      Public Property [Region] As String

      <Association(OtherKey:=NameOf(CustomerCustomerDemo.CustomerID))>
      Public ReadOnly Property CustomerCustomerDemos As New Collection(Of CustomerCustomerDemo)

      <Association(OtherKey:=NameOf(Order.CustomerID))>
      Public ReadOnly Property Orders As New Collection(Of Order)

   End Class

End Namespace

