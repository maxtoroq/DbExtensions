Imports System
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Order Details")>
   Public Class OrderDetail

      <Column>
      Property Discount As Single

      <Column(IsPrimaryKey:=True)>
      Property OrderID As Integer

      <Column(IsPrimaryKey:=True)>
      Property ProductID As Integer

      <Column>
      Property Quantity As Short

      <Column>
      Property UnitPrice As Decimal

      <Association(ThisKey:=NameOf(OrderID))>
      Property Order As Order

      <Association(ThisKey:=NameOf(ProductID))>
      Property Product As Product

   End Class

End Namespace
