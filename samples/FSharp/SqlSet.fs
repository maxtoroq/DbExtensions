namespace Samples.FSharp

open System
open DbExtensions
open Samples.FSharp.Northwind

type SqlSetSamples(db : Database) =
   
   let products = db.From<Product>("Products")

   member this.AreThereAnyProducts() =
      products.Any()

   member this.DoAllProductsHaveUnitPrice() =
      products.All("NOT UnitPrice IS NULL")

   member this.DoSomeProductsAreOutOfStock() =
      products.Any("UnitsInStock = 0")

   member this.HowManyProductsAreOutOfStock() =
      products.Count("UnitsInStock = 0")

   member this.FirstProduct() =
      products.First()

   member this.SecondProduct() =
      products.Skip(1).First()

   member this.FirstOutOfStockProduct() =
      products.First("UnitsInStock = 0")

   member this.Top5ProductsWithLowestStock() =
      
      products
         .Where("UnitsInStock > 0")
         .OrderBy("UnitsInStock")
         .Take(5)
         .Select((fun r -> (r.GetString(0), r.GetInt16(1))), "ProductName, UnitsInStock")
         .AsEnumerable();

   member this.NamesOfOutOfStockProducts() =
         
      products
         .Where("UnitsInStock = 0")
         .Select((fun r -> r.GetString(0)), "ProductName")
         .AsEnumerable()
   
   member this.GetSpecificProduct() =
      products.SingleOrDefault("ProductID = 5")