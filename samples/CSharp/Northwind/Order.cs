using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Orders")]
   public class Order {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int OrderID { get; set; }

      [Column]
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

      [Association(OtherKey = nameof(OrderDetail.OrderID))]
      public Collection<OrderDetail> OrderDetails { get; } = new Collection<OrderDetail>();

      [Association(ThisKey = nameof(CustomerID))]
      public Customer Customer { get; set; }

      [Association(ThisKey = nameof(EmployeeID))]
      public Employee Employee { get; set; }

      [Association(ThisKey = nameof(ShipVia))]
      public Shipper Shipper { get; set; }
   }
}
