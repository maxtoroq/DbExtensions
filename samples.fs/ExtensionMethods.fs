namespace Samples.FSharp

open System
open System.Collections
open System.Collections.Generic
open System.IO
open DbExtensions
open Samples.FSharp.Northwind

type ExtensionMethodsSamples(connectionString : string, log : TextWriter) = 
   
   let connection = DbFactory.CreateConnection(connectionString)
   let log = log

   member this.StaticQuery() =
      connection
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

      connection.Map<Product>(query, log)
   
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

      connection.Map<EmployeeTerritory>(query, log)