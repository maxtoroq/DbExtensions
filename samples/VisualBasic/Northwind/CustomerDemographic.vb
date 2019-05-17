Imports System
Imports System.Collections.ObjectModel
Imports DbExtensions

Namespace Northwind

   <Table(Name:="CustomerDemographics")>
   Public Class CustomerDemographic

      <Column>
      Property CustomerDesc As String

      <Column(IsPrimaryKey:=True)>
      Property CustomerTypeID As String

      <Association(OtherKey:=NameOf(CustomerCustomerDemo.CustomerTypeID))>
      ReadOnly Property CustomerCustomerDemos As New Collection(Of CustomerCustomerDemo)

   End Class

End Namespace
