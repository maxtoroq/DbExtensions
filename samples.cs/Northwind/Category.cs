using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

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

      [Association(OtherKey = "CategoryID")]
      public Collection<Product> Products { get; private set; }

      public Category() {
         this.Products = new Collection<Product>();
      }
   }
}
