Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Suppliers")>
   Public Class Supplier

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

      <Column>
      Public Property Fax As String

      <Column>
      Public Property Phone As String

      <Column>
      Public Property PostalCode As String

      <Column>
      Public Property [Region] As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property SupplierID As Integer

      <Association(OtherKey:=NameOf(Product.SupplierID))>
      Public ReadOnly Property Products As New Collection(Of Product)

   End Class

End Namespace

