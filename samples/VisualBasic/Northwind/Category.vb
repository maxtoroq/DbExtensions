Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Categories")>
   Public Class Category

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property CategoryID As Integer

      <Column>
      Property CategoryName As String

      <Column>
      Property Description As String

      <Column>
      Property Picture As Byte()

      <Association(OtherKey:=NameOf(Product.CategoryID))>
      ReadOnly Property Products As New Collection(Of Product)

   End Class

End Namespace
