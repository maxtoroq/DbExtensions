using System;
using System.Collections;
using System.Collections.Generic;
using DbExtensions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {
   
   public class SqlSetSamples {

      readonly SqlSet<Product> products;

      public SqlSetSamples(Database db) {
         this.products = db.From<Product>("Products");
      }

      public bool AreThereAnyProducts() {
         return products.Any();
      }

      public bool DoAllProductsHaveUnitPrice() {
         return products.All("NOT UnitPrice IS NULL");
      }

      public bool DoSomeProductsAreOutOfStock() {
         return products.Any("UnitsInStock = 0");
      }

      public int HowManyProductsAreOutOfStock() {
         return products.Count("UnitsInStock = 0");
      }

      public Product FirstProduct() {
         return products.First();
      }

      public Product SecondProduct() {
         return products.Skip(1).First();
      }

      public Product FirstOutOfStockProduct() {
         return products.First("UnitsInStock = 0");
      }

      public IEnumerable Top5ProductsWithLowestStock() {
         
         return products
            .Where("UnitsInStock > 0")
            .OrderBy("UnitsInStock")
            .Take(5)
            .Select(r => new { Name = r.GetString(0), UnitsInStock = r.GetInt16(1) }, "ProductName, UnitsInStock")
            .AsEnumerable();
      }

      public IEnumerable<string> NamesOfOutOfStockProducts() {
         
         return products
            .Where("UnitsInStock = 0")
            .Select(r => r.GetString(0), "ProductName")
            .AsEnumerable();
      }

      public Product GetSpecificProduct() {
         return products.SingleOrDefault("ProductID = 5");
      }
   }
}
