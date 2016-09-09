Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Territories")>
   Public Class Territory

      <Column>
      Public Property RegionID As Integer

      <Column(CanBeNull:=False)>
      Public Property TerritoryDescription As String

      <Column(CanBeNull:=False, IsPrimaryKey:=True)>
      Public Property TerritoryID As String

      <Association(OtherKey:=NameOf(EmployeeTerritory.TerritoryID))>
      Public ReadOnly Property EmployeeTerritories As New Collection(Of EmployeeTerritory)

      <Association(ThisKey:=NameOf(RegionID), IsForeignKey:=True)>
      Public Property [Region] As Region

   End Class

End Namespace

