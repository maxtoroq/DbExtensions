Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="CustomerCustomerDemo")>
   Public Class CustomerCustomerDemo

      <Association(ThisKey:="CustomerID", IsForeignKey:=True)>
      Public Property Customer As Customer

      <Association(ThisKey:="CustomerTypeID", IsForeignKey:=True)>
      Public Property CustomerDemographic As CustomerDemographic

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerID As String

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerTypeID As String

   End Class

End Namespace

