Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Xml
Imports DbExtensions
Imports Samples.VisualBasic.Northwind

Public Class ExtensionMethodsSamples

   ReadOnly connection As DbConnection
   ReadOnly log As TextWriter

   Public Sub New(ByVal connectionString As String, ByVal log As TextWriter)
      Me.connection = DbFactory.CreateConnection(connectionString)
      Me.log = log
   End Sub

   Public Sub Before()

      Dim command = connection.CreateCommand()
      command.CommandText = "SELECT @param"

      Dim param = command.CreateParameter()
      param.ParameterName = "@param"
      param.Value = "Hello World"
      command.Parameters.Add(param)

      Me.connection.Open()

      Try
         Dim reader = command.ExecuteReader()

         Do While reader.Read()
            log.WriteLine(reader.GetString(0))
         Loop
      Finally
         connection.Close()
      End Try

   End Sub

   Public Sub After()

      Dim results = connection _
         .CreateCommand("SELECT {0}", "Hello World") _
         .Map(Function(r) r.GetString(0))

      For Each item In results
         log.WriteLine(item)
      Next

   End Sub

   Public Function SelectWithManyToOne() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID, '' AS MissingProperty") _
         .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName") _
         .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName") _
         .FROM("Products p") _
         .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID") _
         .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID") _
         .WHERE("p.ProductID < {0}", 7)

      Dim results = connection.Map(Of Product)(query, log).ToList()

      Return results

   End Function

   Public Function SelectWithManyToOneNested() As IEnumerable(Of EmployeeTerritory)

      Dim query = SQL _
         .SELECT("et.EmployeeID, et.TerritoryID") _
         .SELECT("t.TerritoryID AS Territory$TerritoryID, t.TerritoryDescription AS Territory$TerritoryDescription, t.RegionID AS Territory$RegionID") _
         .SELECT("r.RegionID AS Territory$Region$RegionID, r.RegionDescription AS Territory$Region$RegionDescription") _
         .FROM("EmployeeTerritories et") _
         .LEFT_JOIN("Territories t ON et.TerritoryID = t.TerritoryID") _
         .LEFT_JOIN("Region r ON t.RegionID = r.RegionID") _
         .WHERE("et.EmployeeID < {0}", 7)

      Dim results = connection.Map(Of EmployeeTerritory)(query, log).ToList()

      Return results

   End Function

   Public Function AnnonymousType() As IEnumerable

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 7)

      Dim results = connection.Map(query, Function(r) _
          New With {
            .ProductID = r.GetNullableInt32(0).GetValueOrDefault(),
            .ProductName = r.GetStringOrNull(1)
          }, log) _
         .ToList()

      Return results

   End Function

   Public Function MappingCalculatedColumn() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 7) _
         .ORDER_BY("ValueInStock")

      Dim results = connection.Map(Of Product)(query, log).ToList()

      Return results

   End Function

   Public Function Exists() As Object

      Dim result = connection.Exists(SQL _
         .SELECT("ProductID") _
         .FROM("Products") _
         .WHERE("ProductID = 1"))

      Return result

   End Function

   Public Sub Xml()

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .SELECT("c.CategoryID AS Category$CategoryID") _
         .SELECT("c.CategoryName AS Category$CategoryName") _
         .SELECT("p.UnitPrice") _
         .FROM("Products p") _
         .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID") _
         .WHERE("ProductID < {0}", 5)

      Dim xmlmap = connection.MapXml(query, log)
      xmlmap.CollectionName = New XmlQualifiedName("Products", "http://example.com/ns/Store")
      xmlmap.ItemName = "Product"
      xmlmap.TypeAnnotation = XmlTypeAnnotation.XmlSchema
      xmlmap.NullHandling = XmlNullHandling.IncludeNilAttribute

      Dim writer = XmlWriter.Create(log, New XmlWriterSettings With {.Indent = True})

      Using writer
         xmlmap.WriteXml(writer)
      End Using

   End Sub

End Class

