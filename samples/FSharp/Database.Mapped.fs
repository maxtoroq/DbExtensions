namespace Samples.FSharp

open System
open System.Collections
open System.Collections.Generic
open System.Data.Linq.Mapping
open System.IO
open System.Transactions
open DbExtensions
open Samples.FSharp.Northwind

type DatabaseMappedSamples(connectionString : string, mapping : MetaModel, log : TextWriter) =

   let db = 
      let db1 = new NorthwindDatabase(connectionString, mapping) 
      db1.Configuration.Log <- log
      db1

   member this.IncludeManyToOne() =
         
      db.Products
         .Include("Category")
         .Include("Supplier")
         .Take(3)
         .AsEnumerable()

   member this.IncludeManyToOneNested() =

      db.EmployeeTerritories
         .Include("Territory.Region")
         .Take(3)
         .AsEnumerable()

   member this.IncludeOneToMany() =

      db.Regions
         .Include("Territories")
         .First()

   member this.ContainsKey() =
      db.Products.ContainsKey(1)

   member this.Find() =
      db.Products.Find(1)

   member this.Transactions_AdoNet() =

      using (db.EnsureInTransaction())(fun tx ->
         // Connection is automatically opened if not open

         this.Transactions_DoWork()

         tx.Commit()
      )
      // Connection is closed if wasn't open

   member this.Transactions_TransactionScope() =

      using (new TransactionScope())(fun tx -> 
         using (db.EnsureConnectionOpen())(fun x ->
            // Open connection if not open

            this.Transactions_DoWork()

            tx.Complete()
         )
         // Connection is closed if wasn't open
      )

   member private this.Transactions_DoWork() =

      let order = new Order(CustomerID = "ALFKI")
      order.OrderDetails.Add(new OrderDetail(ProductID = 77, Quantity = 1s))
      order.OrderDetails.Add(new OrderDetail(ProductID = 41, Quantity = 2s))

      db.Orders.Insert(order, deep = true)

      order.Freight <- new Nullable<decimal>(10m)

      db.Orders.Update(order)

      // The following line is not needed when cascade delete is configured on the database
      db.OrderDetails.DeleteRange(order.OrderDetails);

      db.Orders.Delete(order)
