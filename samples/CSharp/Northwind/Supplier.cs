using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Suppliers")]
   public class Supplier {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int SupplierID { get; set; }

      [Column(CanBeNull = false)]
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

      [Association(OtherKey = "SupplierID")]
      public Collection<Product> Products { get; private set; }

      public Supplier() {
         this.Products = new Collection<Product>();
      }
   }
}
