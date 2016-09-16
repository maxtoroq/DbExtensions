using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Categories")]
   public class Category {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int CategoryID { get; set; }

      [Column]
      public string CategoryName { get; set; }

      [Column]
      public string Description { get; set; }

      [Column]
      public byte[] Picture { get; set; }

      [Association(OtherKey = nameof(Product.CategoryID))]
      public Collection<Product> Products { get; } = new Collection<Product>();
   }
}
