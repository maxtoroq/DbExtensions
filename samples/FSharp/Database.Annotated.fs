namespace Samples.FSharp

open System
open Samples.FSharp.Northwind

type DatabaseAnnotatedSamples(db : NorthwindDatabase) =

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

    // Connection is automatically opened if not open
    use tx = db.EnsureInTransaction()

    let order = new Order(CustomerID = "ALFKI")
    order.OrderDetails.Add(new OrderDetail(ProductID = 77, Quantity = 1s))
    order.OrderDetails.Add(new OrderDetail(ProductID = 41, Quantity = 2s))

    db.Orders.Add(order)

    order.Freight <- new Nullable<decimal>(10m)

    db.Orders.Update(order)

    // The following line is not needed when cascade delete is configured on the database
    db.OrderDetails.RemoveRange(order.OrderDetails);

    db.Orders.Remove(order)

    tx.Commit()
    // Connection is closed if wasn't open
