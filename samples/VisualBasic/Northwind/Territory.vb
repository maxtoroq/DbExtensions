Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Territories")>
   Public Class Territory

      <Column>
      Public Property RegionID As Integer

      <Column>
      Public Property TerritoryDescription As String

      <Column(IsPrimaryKey:=True)>
      Public Property TerritoryID As String

      <Association(OtherKey:=NameOf(EmployeeTerritory.TerritoryID))>
      Public ReadOnly Property EmployeeTerritories As New Collection(Of EmployeeTerritory)

      <Association(ThisKey:=NameOf(RegionID))>
      Public Property [Region] As Region

   End Class

End Namespace

