Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Products")>
   Public Class Product

      <Column>
      Property CategoryID As Integer?

      <Column>
      Property Discontinued As Boolean

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property ProductID As Integer

      <Column>
      Property ProductName As String

      <Column>
      Property QuantityPerUnit As String

      <Column>
      Property ReorderLevel As Short?

      <Column>
      Property SupplierID As Integer?

      <Column>
      Property UnitPrice As Decimal?

      <Column>
      Property UnitsInStock As Short?

      <Column>
      Property UnitsOnOrder As Short?

      <Association(ThisKey:=NameOf(CategoryID))>
      Property Category As Category

      <Association(OtherKey:=NameOf(OrderDetail.ProductID))>
      ReadOnly Property OrderDetails As New Collection(Of OrderDetail)

      <Association(ThisKey:=NameOf(SupplierID))>
      Property Supplier As Supplier

   End Class

End Namespace
