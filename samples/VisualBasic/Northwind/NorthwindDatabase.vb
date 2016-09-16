Imports DbExtensions

Namespace Northwind

   Public Class NorthwindDatabase
      Inherits Database

      Public ReadOnly Property Products As SqlTable(Of Product)
         Get
            Return Table(Of Product)()
         End Get
      End Property

      Public ReadOnly Property Orders As SqlTable(Of Order)
         Get
            Return Table(Of Order)()
         End Get
      End Property

      Public ReadOnly Property OrderDetails As SqlTable(Of OrderDetail)
         Get
            Return Table(Of OrderDetail)()
         End Get
      End Property

      Public ReadOnly Property Employees As SqlTable(Of Employee)
         Get
            Return Table(Of Employee)()
         End Get
      End Property

      Public ReadOnly Property EmployeeTerritories As SqlTable(Of EmployeeTerritory)
         Get
            Return Table(Of EmployeeTerritory)()
         End Get
      End Property

      Public ReadOnly Property Regions As SqlTable(Of Region)
         Get
            Return Table(Of Region)()
         End Get
      End Property

      Public Sub New(connectionString As String, providerInvariantName As String)
         MyBase.New(connectionString, providerInvariantName)
      End Sub

   End Class
End Namespace
