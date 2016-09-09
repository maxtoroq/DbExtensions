Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="EmployeeTerritories")>
   Public Class EmployeeTerritory

      <Column(IsPrimaryKey:=True)>
      Public Property EmployeeID As Integer

      <Column(CanBeNull:=False, IsPrimaryKey:=True)>
      Public Property TerritoryID As String

      <Association(ThisKey:=NameOf(EmployeeID), IsForeignKey:=True)>
      Public Property Employee As Employee

      <Association(ThisKey:=NameOf(TerritoryID), IsForeignKey:=True)>
      Public Property Territory As Territory

   End Class

End Namespace

