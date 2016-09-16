using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Suppliers")]
   public class Supplier {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int SupplierID { get; set; }

      [Column]
      public string CompanyName { get; set; }

      [Column]
      public string ContactName { get; set; }

      [Column]
      public string ContactTitle { get; set; }

      [Column]
      public string Address { get; set; }

      [Column]
      public string City { get; set; }

      [Column]
      public string Region { get; set; }

      [Column]
      public string PostalCode { get; set; }

      [Column]
      public string Country { get; set; }

      [Column]
      public string Phone { get; set; }

      [Column]
      public string Fax { get; set; }

      [Association(OtherKey = nameof(Product.SupplierID))]
      public Collection<Product> Products { get; } = new Collection<Product>();
   }
}
