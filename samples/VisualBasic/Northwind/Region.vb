Imports System
Imports System.Collections.ObjectModel
Imports System.Data.Linq.Mapping

Namespace Northwind

   <Table(Name:="Region")>
   Public Class [Region]

      <Column(CanBeNull:=False)>
      Public Property RegionDescription As String

      <Column(IsPrimaryKey:=True)>
      Public Property RegionID As Integer

      <Association(OtherKey:="RegionID")>
      Public Property Territories As Collection(Of Territory)

      Public Sub New()
         Me.Territories = New Collection(Of Territory)
      End Sub
   End Class

End Namespace

