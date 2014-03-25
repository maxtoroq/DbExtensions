using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.IO;
using System.Transactions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {

   public class DatabaseMappedSamples {

      readonly NorthwindDatabase db;

      public DatabaseMappedSamples(string connectionString, MetaModel mapping, TextWriter log) {

         this.db = new NorthwindDatabase(connectionString, mapping) {
            Configuration = { 
               Log = log
            }
         };
      }

      public IEnumerable<Product> PredicateOnly() {
         return db.Products.Where("ProductID <= {0}", 7).AsEnumerable();
      }

      public bool ContainsKey() {
         return db.Products.ContainsKey(1);
      }

      public Product Find() {
         return db.Products.Find(1);
      }

      public void Refresh() {

         Product product = db.Products.Find(1);

         Debug.Assert(product.ProductName == "Chai");

         product.ProductName = "xxx";

         db.Products.Refresh(product);

         Debug.Assert(product.ProductName == "Chai");
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

         db.Orders.Insert(order, deep: true);

         order.Freight = 10m;

         db.Orders.Update(order);

         // The following line is not needed when cascade delete is configured on the database
         db.OrderDetails.DeleteRange(order.OrderDetails);

         db.Orders.Delete(order);
      }
   }
}