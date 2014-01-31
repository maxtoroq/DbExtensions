Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="EmployeeTerritories")>
   Public Class EmployeeTerritory

      <Association(ThisKey:="EmployeeID", IsForeignKey:=True)>
      Public Property Employee As Employee

      <Column(IsPrimaryKey:=True)>
      Public Property EmployeeID As Integer

      <Association(ThisKey:="TerritoryID", IsForeignKey:=True)>
      Public Property Territory As Territory

      <Column(CanBeNull:=False, IsPrimaryKey:=True)>
      Public Property TerritoryID As String

   End Class

End Namespace

