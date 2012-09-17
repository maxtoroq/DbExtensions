namespace Samples.FSharp

open System
open System.Collections
open System.Collections.Generic
open System.Data
open System.IO
open System.Xml
open DbExtensions
open Samples.FSharp.Northwind

type ExtensionMethodsSamples(connectionString : string, log : TextWriter) = 
   
   let conn = DbFactory.CreateConnection(connectionString)
   let log = log

   member this.StaticQuery() =
      conn
         .CreateCommand("SELECT * FROM Products WHERE ProductID = {0}", 1)
         .Map<Product>(log)

   member this.SelectWithManyToOne() =
      
      let query = 
         SQL
            .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID, '' AS MissingProperty")
            .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName")
            .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName")
            .FROM("Products p")
            .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID")
            .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID")
            .WHERE("p.ProductID < {0}", 3)

      conn.Map<Product>(query, log)
   
   member this.SelectWithManyToOneNested() =

      let query = 
         SQL
            .SELECT("et.EmployeeID, et.TerritoryID")
            .SELECT("t.TerritoryID AS Territory$TerritoryID, t.TerritoryDescription AS Territory$TerritoryDescription, t.RegionID AS Territory$RegionID")
            .SELECT("r.RegionID AS Territory$Region$RegionID, r.RegionDescription AS Territory$Region$RegionDescription")
            .FROM("EmployeeTerritories et")
            .LEFT_JOIN("Territories t ON et.TerritoryID = t.TerritoryID")
            .LEFT_JOIN("Region r ON t.RegionID = r.RegionID")
            .WHERE("et.EmployeeID < {0}", 3)

      conn.Map<EmployeeTerritory>(query, log)

   member this.AnnonymousType() =

      let query = 
         SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3)

      conn.Map(query, (fun (r : IDataRecord) -> (r.GetInt32(0), r.GetStringOrNull(1))), log)

   member this.MappingCalculatedColumn() =

      let query = 
         SQL
            .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3)
            .ORDER_BY("ValueInStock")

      conn.Map<Product>(query, log)
   
   member this.Exists() =

      conn.Exists(SQL
         .SELECT("ProductID")
         .FROM("Products")
         .WHERE("ProductID = 1"));

   member this.Xml() =

      let query = 
         SQL
            .SELECT("p.ProductID, p.ProductName")
            .SELECT("c.CategoryID AS Category$CategoryID")
            .SELECT("c.CategoryName AS Category$CategoryName")
            .SELECT("p.UnitPrice")
            .FROM("Products p")
            .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID")
            .WHERE("ProductID < {0}", 3)

      let settings = 
         new XmlMappingSettings(
            CollectionName = new XmlQualifiedName("Products", "http://example.com/ns/Store"),
            ItemName = "Product",
            NullHandling = XmlNullHandling.IncludeNilAttribute,
            TypeAnnotation = XmlTypeAnnotation.XmlSchema
         )

      using (conn.MapXml(query, settings, log)) ( fun reader ->
         using (XmlWriter.Create(log, new XmlWriterSettings(Indent = true))) ( fun writer ->
            while not reader.EOF do
               writer.WriteNode(reader, defattr = true)
         )
      )
      