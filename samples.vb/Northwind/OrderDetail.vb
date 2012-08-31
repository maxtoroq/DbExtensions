Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Order Details")>
   Public Class OrderDetail

      <Column()>
      Public Property Discount As Single

      <Association(ThisKey:="OrderID", IsForeignKey:=True)>
      Public Property Order As Order

      <Column(IsPrimaryKey:=True)>
      Public Property OrderID As Integer

      <Association(ThisKey:="ProductID", IsForeignKey:=True)>
      Public Property Product As Product

      <Column(IsPrimaryKey:=True)>
      Public Property ProductID As Integer

      <Column()>
      Public Property Quantity As Short

      <Column()>
      Public Property UnitPrice As Decimal

   End Class

End Namespace

