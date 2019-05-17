Imports System
Imports DbExtensions

Namespace Northwind

   <Table>
   Public Class CustomerCustomerDemo

      <Column(IsPrimaryKey:=True)>
      Property CustomerID As String

      <Column(IsPrimaryKey:=True)>
      Property CustomerTypeID As String

      <Association(ThisKey:=NameOf(CustomerID))>
      Property Customer As Customer

      <Association(ThisKey:=NameOf(CustomerTypeID))>
      Property CustomerDemographic As CustomerDemographic

   End Class

End Namespace
