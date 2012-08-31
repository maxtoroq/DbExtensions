using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Shippers")]
   public class Shipper {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int ShipperID { get; set; }

      [Column(CanBeNull = false)]
      public string CompanyName { get; set; }

      [Column]
      public string Phone { get; set; }

      [Association(OtherKey = "ShipVia")]
      public Collection<Order> Orders { get; private set; }

      public Shipper() {
         this.Orders = new Collection<Order>();
      }
   }
}
