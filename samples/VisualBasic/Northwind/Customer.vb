Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Customers")>
   Public Class Customer

      <Column()>
      Public Property Address As String

      <Column()>
      Public Property City As String

      <Column()>
      Public Property CompanyName As String

      <Column()>
      Public Property ContactName As String

      <Column()>
      Public Property ContactTitle As String

      <Column()>
      Public Property Country As String

      <Association(OtherKey:="CustomerID")>
      Public Property CustomerCustomerDemos As Collection(Of CustomerCustomerDemo)

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerID As String

      <Column()>
      Public Property Fax As String

      <Association(OtherKey:="CustomerID")>
      Public Property Orders As Collection(Of Order)

      <Column()>
      Public Property Phone As String

      <Column()>
      Public Property PostalCode As String

      <Column()>
      Public Property [Region] As String

      Public Sub New()
         Me.CustomerCustomerDemos = New Collection(Of CustomerCustomerDemo)
         Me.Orders = New Collection(Of Order)
      End Sub

   End Class

End Namespace

