namespace Samples.FSharp

open System
open System.Data
open System.Data.Common
open System.IO
open DbExtensions
open Samples.FSharp.Northwind

type SqlSetSamples(conn : DbConnection, log : TextWriter) =
   
   let log = log
   let productSet = conn.Set<Product>(new SqlBuilder("SELECT * FROM Products"), log)

   member this.AreThereAnyProducts() =
      productSet.Any()

   member this.DoAllProductsHaveUnitPrice() =
      productSet.All("NOT UnitPrice IS NULL")

   member this.DoSomeProductsAreOutOfStock() =
      productSet.Any("UnitsInStock = 0")

   member this.HowManyProductsAreOutOfStock() =
      productSet.Count("UnitsInStock = 0")

   member this.FirstProduct() =
      productSet.First()

   member this.SecondProduct() =
      productSet.Skip(1).First()

   member this.FirstOutOfStockProduct() =
      productSet.First("UnitsInStock = 0")

   member this.Top5ProductsWithLowestStock() =
      
      productSet.Where("UnitsInStock > 0")
         .OrderBy("UnitsInStock")
         .Take(5)
         .Select((fun r -> (r.GetString(0), r.GetInt16(1))), "ProductName, UnitsInStock")
         .AsEnumerable();

   member this.NamesOfOutOfStockProducts() =
         
      productSet.Where("UnitsInStock = 0")
         .Select((fun r -> r.GetString(0)), "ProductName")
         .AsEnumerable()
   
   member this.GetSpecificProduct() =
      productSet.SingleOrDefault("ProductID = 5")