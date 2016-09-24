Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="Employees")>
   Public Class Employee

      <Column>
      Public Property Address As String

      <Column>
      Public Property BirthDate As DateTime?

      <Column>
      Public Property City As String

      <Column>
      Public Property Country As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property EmployeeID As Integer

      <Column>
      Public Property Extension As String

      <Column>
      Public Property FirstName As String

      <Column>
      Public Property HireDate As DateTime?

      <Column>
      Public Property HomePhone As String

      <Column>
      Public Property LastName As String

      <Column>
      Public Property Notes As String

      <Column>
      Public Property Photo As Byte()

      <Column>
      Public Property PhotoPath As String

      <Column>
      Public Property PostalCode As String

      <Column>
      Public Property [Region] As String

      <Column>
      Public Property ReportsTo As Integer?

      <Column>
      Public Property Title As String

      <Column>
      Public Property TitleOfCourtesy As String

      <Association(OtherKey:=NameOf(Order.EmployeeID))>
      Public ReadOnly Property Orders As New Collection(Of Order)

      <Association(ThisKey:=NameOf(ReportsTo))>
      Public Property ReportsToEmployee As Employee

      <Association(OtherKey:=NameOf(Employee.ReportsTo))>
      Public ReadOnly Property Employees As New Collection(Of Employee)

      <Association(OtherKey:=NameOf(EmployeeTerritory.EmployeeID))>
      Public ReadOnly Property EmployeeTerritories As New Collection(Of EmployeeTerritory)

   End Class

End Namespace

