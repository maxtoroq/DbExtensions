using System;
using System.Collections.Generic;
using System.Transactions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {

   public class DatabaseAnnotatedSamples {

      readonly NorthwindDatabase db;

      public DatabaseAnnotatedSamples(NorthwindDatabase db) {
         this.db = db;
      }

      public IEnumerable<Product> IncludeManyToOne() {

         return db.Products
            .Include("Category")
            .Include("Supplier")
            .Take(3)
            .AsEnumerable();
      }

      public IEnumerable<EmployeeTerritory> IncludeManyToOneNested() {

         return db.EmployeeTerritories
            .Include("Territory.Region")
            .Take(3)
            .AsEnumerable();
      }

      public Region IncludeOneToMany() {

         return db.Regions
            .Include("Territories")
            .First();
      }

      public bool ContainsKey() {
         return db.Products.ContainsKey(1);
      }

      public Product Find() {
         return db.Products.Find(1);
      }

      public void Transactions_AdoNet() {

         using (var tx = db.EnsureInTransaction()) {
            // Connection is automatically opened if not open

            Transactions_DoWork();

            tx.Commit();
         }
         // Connection is closed if wasn't open
      }

      public void Transactions_TransactionScope() {

         using (var tx = new TransactionScope()) {
            using (db.EnsureConnectionOpen()) {
               // Open connection if not open

               Transactions_DoWork();

               tx.Complete();
            }
            // Connection is closed if wasn't open
         }
      }

      void Transactions_DoWork() {

         var order = new Order {
            CustomerID = "ALFKI",
            OrderDetails = {
               new OrderDetail { ProductID = 77, Quantity = 1 },
               new OrderDetail { ProductID = 41, Quantity = 2 }
            }
         };

         db.Orders.Add(order);

         order.Freight = 10m;

         db.Orders.Update(order);

         // The following line is not needed when cascade delete is configured on the database
         db.OrderDetails.RemoveRange(order.OrderDetails);

         db.Orders.Remove(order);
      }
   }
}