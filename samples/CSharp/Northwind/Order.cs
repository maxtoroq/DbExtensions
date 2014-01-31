using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Orders")]
   public class Order {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int OrderID { get; set; }

      [Column(CanBeNull = false)]
      public string CustomerID { get; set; }

      [Column]
      public int? EmployeeID { get; set; }

      [Column]
      public DateTime? OrderDate { get; set; }

      [Column]
      public DateTime? RequiredDate { get; set; }

      [Column]
      public DateTime? ShippedDate { get; set; }

      [Column]
      public int? ShipVia { get; set; }

      [Column]
      public decimal? Freight { get; set; }

      [Column]
      public string ShipName { get; set; }

      [Column]
      public string ShipAddress { get; set; }

      [Column]
      public string ShipCity { get; set; }

      [Column]
      public string ShipRegion { get; set; }

      [Column]
      public string ShipPostalCode { get; set; }

      [Column]
      public string ShipCountry { get; set; }

      [Association(OtherKey = "OrderID")]
      public Collection<OrderDetail> OrderDetails { get; private set; }

      [Association(ThisKey = "CustomerID", IsForeignKey = true)]
      public Customer Customer { get; set; }

      [Association(ThisKey = "EmployeeID", IsForeignKey = true)]
      public Employee Employee { get; set; }

      [Association(ThisKey = "ShipVia", IsForeignKey = true)]
      public Shipper Shipper { get; set; }

      public Order() {
         this.OrderDetails = new Collection<OrderDetail>();
      }
   }
}
