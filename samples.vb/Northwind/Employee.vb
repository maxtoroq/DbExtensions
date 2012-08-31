Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Employees")>
   Public Class Employee

      <Column()>
      Public Property Address As String

      <Column()>
      Public Property BirthDate As DateTime?

      <Column()>
      Public Property City As String

      <Column()>
      Public Property Country As String

      <Column(IsPrimaryKey:=True, IsDbGenerated:=True)>
      Public Property EmployeeID As Integer

      <Association(OtherKey:="ReportsTo")>
      Public Property Employees As Collection(Of Employee)

      <Association(OtherKey:="EmployeeID")>
      Public Property EmployeeTerritories As Collection(Of EmployeeTerritory)

      <Column()>
      Public Property Extension As String

      <Column()>
      Public Property FirstName As String

      <Column()>
      Public Property HireDate As DateTime?

      <Column()>
      Public Property HomePhone As String

      <Column()>
      Public Property LastName As String

      <Column(UpdateCheck:=UpdateCheck.Never)>
      Public Property Notes As String

      <Association(OtherKey:="EmployeeID")>
      Public Property Orders As Collection(Of Order)

      <Column(UpdateCheck:=UpdateCheck.Never)>
      Public Property Photo As Byte()

      <Column()>
      Public Property PhotoPath As String

      <Column()>
      Public Property PostalCode As String

      <Column()>
      Public Property [Region] As String

      <Column()>
      Public Property ReportsTo As Integer?

      <Association(ThisKey:="ReportsTo", IsForeignKey:=True)>
      Public Property ReportsToEmployee As Employee

      <Column()>
      Public Property Title As String

      <Column()>
      Public Property TitleOfCourtesy As String

      Public Sub New()
         Me.Employees = New Collection(Of Employee)
         Me.EmployeeTerritories = New Collection(Of EmployeeTerritory)
         Me.Orders = New Collection(Of Order)
      End Sub
   End Class

End Namespace

