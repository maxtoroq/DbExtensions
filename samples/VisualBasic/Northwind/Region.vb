Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Region")>
   Public Class [Region]

      <Column>
      Public Property RegionDescription As String

      <Column(IsPrimaryKey:=True)>
      Public Property RegionID As Integer

      <Association(OtherKey:=NameOf(Territory.RegionID))>
      Public ReadOnly Property Territories As New Collection(Of Territory)

   End Class

End Namespace

