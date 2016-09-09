Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="CustomerCustomerDemo")>
   Public Class CustomerCustomerDemo

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerID As String

      <Column(IsPrimaryKey:=True)>
      Public Property CustomerTypeID As String

      <Association(ThisKey:=NameOf(CustomerID), IsForeignKey:=True)>
      Public Property Customer As Customer

      <Association(ThisKey:=NameOf(CustomerTypeID), IsForeignKey:=True)>
      Public Property CustomerDemographic As CustomerDemographic

   End Class

End Namespace

