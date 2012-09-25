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

   ReadOnly conn As DbConnection
   ReadOnly log As TextWriter

   Public Sub New(ByVal conn As DbConnection, ByVal log As TextWriter)
      Me.conn = conn
      Me.log = log
   End Sub

   Public Function StaticQuery() As IEnumerable(Of Product)

      Return conn _
         .CreateCommand("SELECT * FROM Products WHERE ProductID = {0}", 1) _
         .Map(Of Product)(log)

   End Function

   Public Function SelectWithManyToOne() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID, '' AS MissingProperty") _
         .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName") _
         .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName") _
         .FROM("Products p") _
         .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID") _
         .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID") _
         .WHERE("p.ProductID < {0}", 3)

      Return conn.Map(Of Product)(query, log)

   End Function

   Public Function SelectWithManyToOneNested() As IEnumerable(Of EmployeeTerritory)

      Dim query = SQL _
         .SELECT("et.EmployeeID, et.TerritoryID") _
         .SELECT("t.TerritoryID AS Territory$TerritoryID, t.TerritoryDescription AS Territory$TerritoryDescription, t.RegionID AS Territory$RegionID") _
         .SELECT("r.RegionID AS Territory$Region$RegionID, r.RegionDescription AS Territory$Region$RegionDescription") _
         .FROM("EmployeeTerritories et") _
         .LEFT_JOIN("Territories t ON et.TerritoryID = t.TerritoryID") _
         .LEFT_JOIN("Region r ON t.RegionID = r.RegionID") _
         .WHERE("et.EmployeeID < {0}", 3)

      Return conn.Map(Of EmployeeTerritory)(query, log)

   End Function

   Public Function AnnonymousType() As IEnumerable

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 3)

      Return conn.Map(query, Function(r) _
         New With {
            .ProductID = r.GetInt32(0),
            .ProductName = r.GetStringOrNull(1)
         }, log)

   End Function

   Public Function MappingCalculatedColumn() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 3) _
         .ORDER_BY("ValueInStock")

      Return conn.Map(Of Product)(query, log)

   End Function

   Public Function Exists() As Boolean

      Dim result = conn.Exists(SQL _
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
         .WHERE("ProductID < {0}", 3)

      Dim settings = New XmlMappingSettings With {
         .CollectionName = New XmlQualifiedName("Products", "http://example.com/ns/Store"), _
         .ItemName = "Product", _
         .NullHandling = XmlNullHandling.IncludeNilAttribute, _
         .TypeAnnotation = XmlTypeAnnotation.XmlSchema
      }

      Dim reader = conn.MapXml(query, settings, log)

      Using reader
         Dim writer = XmlWriter.Create(log, New XmlWriterSettings With {.Indent = True})

         Using writer
            While (Not reader.EOF)
               writer.WriteNode(reader, defattr:=True)
            End While
         End Using
      End Using

   End Sub

End Class

