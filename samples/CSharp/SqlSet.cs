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

      readonly SqlSet<Product> productSet;

      public SqlSetSamples(DbConnection conn, TextWriter log) {
         this.productSet = conn.From<Product>("Products", log);
      }

      public bool AreThereAnyProducts() {
         return productSet.Any();
      }

      public bool DoAllProductsHaveUnitPrice() {
         return productSet.All("NOT UnitPrice IS NULL");
      }

      public bool DoSomeProductsAreOutOfStock() {
         return productSet.Any("UnitsInStock = 0");
      }

      public int HowManyProductsAreOutOfStock() {
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

      public IEnumerable<string> NamesOfOutOfStockProducts() {
         
         return productSet.Where("UnitsInStock = 0")
            .Select(r => r.GetString(0), "ProductName")
            .AsEnumerable();
      }

      public Product GetSpecificProduct() {
         return productSet.SingleOrDefault("ProductID = 5");
      }
   }
}
