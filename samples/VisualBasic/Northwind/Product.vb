Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Products")>
   Public Class Product

      <Association(ThisKey:="CategoryID", IsForeignKey:=True)>
      Public Property Category As Category

      <Column()>
      Public Property CategoryID As Integer?

      <Column()>
      Public Property Discontinued As Boolean

      <Association(OtherKey:="ProductID")>
      Public Property OrderDetails As Collection(Of OrderDetail)

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property ProductID As Integer

      <Column(CanBeNull:=False)>
      Public Property ProductName As String

      <Column()>
      Public Property QuantityPerUnit As String

      <Column()>
      Public Property ReorderLevel As Short?

      <Association(ThisKey:="SupplierID", IsForeignKey:=True)>
      Public Property Supplier As Supplier

      <Column()>
      Public Property SupplierID As Integer?

      <Column()>
      Public Property UnitPrice As Decimal?

      <Column()>
      Public Property UnitsInStock As Short?

      <Column()>
      Public Property UnitsOnOrder As Short?

      Public Property ValueInStock As Decimal

      Public Sub New()
         Me.OrderDetails = New Collection(Of OrderDetail)
      End Sub
   End Class

End Namespace

