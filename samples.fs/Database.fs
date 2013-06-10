namespace Samples.FSharp

open System
open System.IO
open System.Data.Linq.Mapping
open System.Diagnostics;
open System.Transactions;
open DbExtensions
open Samples.FSharp.Northwind

type DatabaseSamples(connectionString : string, mapping : MetaModel, log : TextWriter) =

   let db = 
      let db1 = new NorthwindDatabase(connectionString, mapping) 
      db1.Configuration.Log <- log
      db1

   member this.PredicateOnly() =
      db.Products.Where("ProductID <= {0}", 7).AsEnumerable()

   member this.Find() =

      let product = db.Products.Find(1)
      product

   member this.Refresh() =

      let product = db.Products.Find(1)

      Debug.Assert(product.ProductName = "Chai")

      product.ProductName <- "xxx"

      db.Products.Refresh(product)

      Debug.Assert(product.ProductName = "Chai")

   member this.DefaultValues() =

      let product = new Product()

      Debug.Assert(not product.UnitsInStock.HasValue);

      db.Products.Initialize(product)
      
      Debug.Assert(product.UnitsInStock.HasValue && product.UnitsInStock.Value = 0s)
   
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

      db.OrderDetails.DeleteRange(order.OrderDetails);
      db.Orders.Delete(order)