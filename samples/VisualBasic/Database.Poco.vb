Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Xml
Imports DbExtensions
Imports Samples.VisualBasic.Northwind

Public Class DatabasePocoSamples

   ReadOnly db As Database

   Sub New(ByVal connectionString As String, ByVal log As TextWriter)
      Me.db = New Database(connectionString)
      Me.db.Configuration.Log = log
   End Sub

   Function SelectWithManyToOne() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID, '' AS MissingProperty") _
         .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName") _
         .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName") _
         .FROM("Products p") _
         .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID") _
         .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID") _
         .WHERE("p.ProductID < {0}", 3)

      Return db.Map(Of Product)(query)

   End Function

   Function SelectWithManyToOneNested() As IEnumerable(Of EmployeeTerritory)

      Dim query = SQL _
         .SELECT("et.EmployeeID, et.TerritoryID") _
         .SELECT("t.TerritoryID AS Territory$TerritoryID, t.TerritoryDescription AS Territory$TerritoryDescription, t.RegionID AS Territory$RegionID") _
         .SELECT("r.RegionID AS Territory$Region$RegionID, r.RegionDescription AS Territory$Region$RegionDescription") _
         .FROM("EmployeeTerritories et") _
         .LEFT_JOIN("Territories t ON et.TerritoryID = t.TerritoryID") _
         .LEFT_JOIN("Region r ON t.RegionID = r.RegionID") _
         .WHERE("et.EmployeeID < {0}", 3)

      Return db.Map(Of EmployeeTerritory)(query)

   End Function

   Function AnnonymousType() As IEnumerable

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 3)

      Return db.Map(query, Function(r) _
         New With {
            .ProductID = r.GetInt32(0),
            .ProductName = r.GetStringOrNull(1)
         })

   End Function

   Function MappingCalculatedColumn() As IEnumerable(Of Product)

      Dim query = SQL _
         .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock") _
         .FROM("Products p") _
         .WHERE("p.ProductID < {0}", 3) _
         .ORDER_BY("ValueInStock")

      Return db.Map(Of Product)(query)

   End Function

   Function MappingToConstructorArguments() As MappingToConstructorArgumentsSample

      Dim query = SQL _
         .SELECT("1 AS '1'") _
         .SELECT("'http://example.com' AS Url$1") _
         .SELECT("15.5 AS Price$1, 'USD' AS Price$2")

      Return db.Map(Of MappingToConstructorArgumentsSample)(query).Single()

   End Function

   Function MappingToConstructorArgumentsNested() As MappingToConstructorArgumentsSample

      Dim query = SQL _
         .SELECT("1 AS '1'") _
         .SELECT("'http://example.com' AS '2$1'") _
         .SELECT("15.5 AS '3$1', 'USD' AS '3$2'")

      Return db.Map(Of MappingToConstructorArgumentsSample)(query).Single()

   End Function

   Sub Xml()

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

      Dim reader = db.MapXml(query, settings)

      Using reader
         Dim writer = XmlWriter.Create(db.Configuration.Log, New XmlWriterSettings With {.Indent = True})

         Using writer
            While (Not reader.EOF)
               writer.WriteNode(reader, defattr:=True)
            End While
         End Using
      End Using

   End Sub

   Function Dynamic() As IEnumerable(Of Object)

      Dim query = SQL _
         .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID") _
         .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName") _
         .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName") _
         .FROM("Products p") _
         .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID") _
         .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID") _
         .WHERE("p.ProductID < {0}", 3)

      Return db.Map(query)

   End Function

End Class

Public Class MappingToConstructorArgumentsSample

   Property Id As Integer
   Property Url As Uri
   Property Price As Nullable(Of Money)

   Sub New(id As Integer)
      Me.Id = id
   End Sub

   Sub New(id As Integer, url As Uri, price As Nullable(Of Money))
      Me.New(id)

      Me.Url = url
      Me.Price = price
   End Sub

End Class

Public Structure Money

   ReadOnly Amount As Decimal
   ReadOnly Currency As String

   Sub New(amount As Decimal, currency As String)
      Me.Amount = amount
      Me.Currency = currency
   End Sub

End Structure