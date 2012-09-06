using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using DbExtensions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {
   
   public class SqlSetSamples {

      readonly DbConnection connection;
      readonly SqlSet<Product> productSet;

      public SqlSetSamples(string connectionString, TextWriter log) {
         
         this.connection = DbFactory.CreateConnection(connectionString);
         this.productSet = new SqlSet<Product>(this.connection, new SqlBuilder("SELECT * FROM Products"), log);
      }

      public object AreThereAnyProducts() {
         return productSet.Any();
      }

      public object DoAllProductsHaveUnitPrice() {
         return productSet.All("NOT UnitPrice IS NULL");
      }

      public object DoSomeProductsAreOutOfStock() {
         return productSet.Any("UnitsInStock = 0");
      }

      public object HowManyProductsAreOutOfStock() {
         return productSet.Count("UnitsInStock = 0");
      }

      public Product FirstProduct() {
         return productSet.First();
      }

      public Product SecondProduct() {
         return productSet.Skip(1).First();
      }

      public Product FirstOutOfStockProduct() {
         return productSet.First("UnitsInStock = 0");
      }

      public IEnumerable Top5ProductsWithLowestStock() {
         return productSet.Where("UnitsInStock > 0")
            .OrderBy("UnitsInStock")
            .Take(5)
            .Select(r => new { Name = r.GetString(0), UnitsInStock = r.GetInt16(1) }, "ProductName, UnitsInStock")
            .AsEnumerable();
      }

      public object NamesOfOutOfStockProducts() {
         
         return productSet.Where("UnitsInStock = 0")
            .Select(r => r.GetString(0), "ProductName")
            .ToArray();
      }

      public Product GetSpecificProduct() {
         return productSet.SingleOrDefault("ProductID = 5");
      }
   }
}
