using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Shippers")]
   public class Shipper {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int ShipperID { get; set; }

      [Column]
      public string CompanyName { get; set; }

      [Column]
      public string Phone { get; set; }

      [Association(OtherKey = nameof(Order.ShipVia))]
      public Collection<Order> Orders { get; } = new Collection<Order>();
   }
}
