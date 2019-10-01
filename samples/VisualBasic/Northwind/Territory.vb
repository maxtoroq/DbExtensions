Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Territories")>
   Public Class Territory

      <Column>
      Property RegionID As Integer

      <Column>
      Property TerritoryDescription As String

      <Column(IsPrimaryKey:=True)>
      Property TerritoryID As String

      <Association(OtherKey:=NameOf(EmployeeTerritory.TerritoryID))>
      ReadOnly Property EmployeeTerritories As New Collection(Of EmployeeTerritory)

      <Association(ThisKey:=NameOf(RegionID))>
      Property [Region] As Region

   End Class

End Namespace
