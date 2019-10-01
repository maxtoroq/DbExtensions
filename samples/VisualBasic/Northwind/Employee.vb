Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Employees")>
   Public Class Employee

      <Column>
      Property Address As String

      <Column>
      Property BirthDate As Date?

      <Column>
      Property City As String

      <Column>
      Property Country As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Property EmployeeID As Integer

      <Column>
      Property Extension As String

      <Column>
      Property FirstName As String

      <Column>
      Property HireDate As Date?

      <Column>
      Property HomePhone As String

      <Column>
      Property LastName As String

      <Column>
      Property Notes As String

      <Column>
      Property Photo As Byte()

      <Column>
      Property PhotoPath As String

      <Column>
      Property PostalCode As String

      <Column>
      Property [Region] As String

      <Column>
      Property ReportsTo As Integer?

      <Column>
      Property Title As String

      <Column>
      Property TitleOfCourtesy As String

      <Association(OtherKey:=NameOf(Order.EmployeeID))>
      ReadOnly Property Orders As New Collection(Of Order)

      <Association(ThisKey:=NameOf(ReportsTo))>
      Property ReportsToEmployee As Employee

      <Association(OtherKey:=NameOf(Employee.ReportsTo))>
      ReadOnly Property Employees As New Collection(Of Employee)

      <Association(OtherKey:=NameOf(EmployeeTerritory.EmployeeID))>
      ReadOnly Property EmployeeTerritories As New Collection(Of EmployeeTerritory)

   End Class

End Namespace
