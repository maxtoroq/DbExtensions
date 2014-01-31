Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Suppliers")>
   Public Class Supplier

      <Column()>
      Public Property Address As String

      <Column()>
      Public Property City As String

      <Column(CanBeNull:=False)>
      Public Property CompanyName As String

      <Column()>
      Public Property ContactName As String

      <Column()>
      Public Property ContactTitle As String

      <Column()>
      Public Property Country As String

      <Column()>
      Public Property Fax As String

      <Column(UpdateCheck:=UpdateCheck.Never)>
      Public Property HomePage As String

      <Column()>
      Public Property Phone As String

      <Column()>
      Public Property PostalCode As String

      <Association(OtherKey:="SupplierID")>
      Public Property Products As Collection(Of Product)

      <Column()>
      Public Property [Region] As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property SupplierID As Integer

      Public Sub New()
         Me.Products = New Collection(Of Product)
      End Sub
   End Class

End Namespace

