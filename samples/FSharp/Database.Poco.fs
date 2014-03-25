namespace Samples.FSharp

open System
open System.Collections
open System.Collections.Generic
open System.IO
open System.Linq
open System.Xml
open DbExtensions
open Samples.FSharp.Northwind

type Money =
   struct
      val Amount : decimal
      val Currency : string

      new(amount : decimal, currency : string) = {
         Amount = amount
         Currency = currency
      }
   end

type MappingToConstructorArgumentsSample(id : int, url : Uri, price : Nullable<Money>) =

   member val Id = id with get,set
   member val Url : Uri = url with get,set
   member val Price = price with get,set

   new(id) = MappingToConstructorArgumentsSample(id, null, new Nullable<Money>())

type DatabasePocoSamples(connectionString : string, log : TextWriter) =

   let db = 
      let db1 = new Database(connectionString) 
      db1.Configuration.Log <- log
      db1

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

      db.Map<Product>(query)
   
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

      db.Map<EmployeeTerritory>(query)

   member this.AnnonymousType() =

      let query = 
         SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3)

      db.Map(query, (fun r -> (r.GetInt32(0), r.GetStringOrNull(1))))

   member this.MappingCalculatedColumn() =

      let query = 
         SQL
            .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3)
            .ORDER_BY("ValueInStock")

      db.Map<Product>(query)
   
   member this.MappingToConstructorArguments() =

      let query = 
         SQL
            .SELECT("1 AS '1'")
            .SELECT("'http://example.com' AS Url$1")
            .SELECT("15.5 AS Price$1, 'USD' AS Price$2")

      db.Map<MappingToConstructorArgumentsSample>(query)
        .Single()

   member this.MappingToConstructorArgumentsNested() =

      let query = 
         SQL
            .SELECT("1 AS '1'")
            .SELECT("'http://example.com' AS '2$1'")
            .SELECT("15.5 AS '3$1', 'USD' AS '3$2'")

      db.Map<MappingToConstructorArgumentsSample>(query)
        .Single()

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

      using (db.MapXml(query, settings)) ( fun reader ->
         using (XmlWriter.Create(log, new XmlWriterSettings(Indent = true))) ( fun writer ->
            while not reader.EOF do
               writer.WriteNode(reader, defattr = true)
         )
      )

   member this.Dynamic() =

      let query =
         SQL
            .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID")
            .SELECT("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName")
            .SELECT("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName")
            .FROM("Products p")
            .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID")
            .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID")
            .WHERE("p.ProductID < {0}", 3)

      db.Map(query)
