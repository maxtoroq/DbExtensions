Imports System
Imports DbExtensions

Namespace Northwind

   <Table(Name:="EmployeeTerritories")>
   Public Class EmployeeTerritory

      <Column(IsPrimaryKey:=True)>
      Property EmployeeID As Integer

      <Column(IsPrimaryKey:=True)>
      Property TerritoryID As String

      <Association(ThisKey:=NameOf(EmployeeID))>
      Property Employee As Employee

      <Association(ThisKey:=NameOf(TerritoryID))>
      Property Territory As Territory

   End Class

End Namespace
