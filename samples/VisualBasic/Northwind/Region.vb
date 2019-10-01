Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Region")>
   Public Class [Region]

      <Column>
      Property RegionDescription As String

      <Column(IsPrimaryKey:=True)>
      Property RegionID As Integer

      <Association(OtherKey:=NameOf(Territory.RegionID))>
      ReadOnly Property Territories As New Collection(Of Territory)

   End Class

End Namespace
