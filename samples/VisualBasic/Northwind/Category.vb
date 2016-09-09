Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Categories")>
   Public Class Category

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property CategoryID As Integer

      <Column>
      Public Property CategoryName As String

      <Column>
      Public Property Description As String

      <Column>
      Public Property Picture As Byte()

      <Association(OtherKey:=NameOf(Product.CategoryID))>
      Public ReadOnly Property Products As New Collection(Of Product)

   End Class

End Namespace

