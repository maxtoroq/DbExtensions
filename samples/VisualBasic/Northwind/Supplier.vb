Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Suppliers")>
   Public Class Supplier

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

      <Column>
      Property Fax As String

      <Column>
      Property Phone As String

      <Column>
      Property PostalCode As String

      <Column>
      Property [Region] As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property SupplierID As Integer

      <Association(OtherKey:=NameOf(Product.SupplierID))>
      ReadOnly Property Products As New Collection(Of Product)

   End Class

End Namespace
