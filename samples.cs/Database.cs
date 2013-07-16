using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Transactions;
using DbExtensions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {

   public class DatabaseSamples : IDisposable {

      readonly NorthwindDatabase db;

      public DatabaseSamples(string connectionString, MetaModel mapping, TextWriter log) {

         this.db = new NorthwindDatabase(connectionString, mapping) {
            Configuration = { 
               Log = log
            }
         };
      }

      public IEnumerable<Product> PredicateOnly() {
         return db.Products.Where("ProductID <= {0}", 7).AsEnumerable();
      }

      public Product Find() {

         Product product = db.Products.Find(1);
         return product;
      }

      public void Refresh() {

         Product product = db.Products.Find(1);

         Debug.Assert(product.ProductName == "Chai");

         product.ProductName = "xxx";

         db.Products.Refresh(product);

         Debug.Assert(product.ProductName == "Chai");
      }

      public void DefaultValues() {

         Product product = new Product();

         Debug.Assert(product.UnitsInStock == null);

         db.Products.Initialize(product);

         Debug.Assert(product.UnitsInStock.HasValue && product.UnitsInStock.Value == 0);
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

      private void Transactions_DoWork() {

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

         db.OrderDetails.DeleteRange(order.OrderDetails);
         db.Orders.Delete(order);
      }

      public void Dispose() {
         this.db.Dispose();
      }
   }
}