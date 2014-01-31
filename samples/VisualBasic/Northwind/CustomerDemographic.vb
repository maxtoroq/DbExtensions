Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="CustomerDemographics")>
   Public Class CustomerDemographic

      <Association(OtherKey:="CustomerTypeID")>
      Public Property CustomerCustomerDemos As Collection(Of CustomerCustomerDemo)

      <Column(UpdateCheck:=UpdateCheck.Never)>
      Public Property CustomerDesc As String

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerTypeID As String

      Public Sub New()
         Me.CustomerCustomerDemos = New Collection(Of CustomerCustomerDemo)
      End Sub
   End Class

End Namespace

