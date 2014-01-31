Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Territories")>
   Public Class Territory

      <Association(OtherKey:="TerritoryID")>
      Public Property EmployeeTerritories As Collection(Of EmployeeTerritory)

      <Association(ThisKey:="RegionID", IsForeignKey:=True)>
      Public Property [Region] As Region

      <Column()>
      Public Property RegionID As Integer

      <Column(CanBeNull:=False)>
      Public Property TerritoryDescription As String

      <Column(CanBeNull:=False, IsPrimaryKey:=True)>
      Public Property TerritoryID As String

      Public Sub New()
         Me.EmployeeTerritories = New Collection(Of EmployeeTerritory)
      End Sub
   End Class

End Namespace

