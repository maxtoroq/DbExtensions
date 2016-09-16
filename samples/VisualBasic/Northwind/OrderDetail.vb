Imports System
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Order Details")>
   Public Class OrderDetail

      <Column>
      Public Property Discount As Single

      <Column(IsPrimaryKey:=True)>
      Public Property OrderID As Integer

      <Column(IsPrimaryKey:=True)>
      Public Property ProductID As Integer

      <Column>
      Public Property Quantity As Short

      <Column>
      Public Property UnitPrice As Decimal

      <Association(ThisKey:=NameOf(OrderID), IsForeignKey:=True)>
      Public Property Order As Order

      <Association(ThisKey:=NameOf(ProductID), IsForeignKey:=True)>
      Public Property Product As Product

   End Class

End Namespace

