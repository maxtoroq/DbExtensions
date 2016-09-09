using System;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Order Details")]
   public class OrderDetail {

      [Column(IsPrimaryKey = true)]
      public int OrderID { get; set; }

      [Column(IsPrimaryKey = true)]
      public int ProductID { get; set; }

      [Column]
      public decimal UnitPrice { get; set; }

      [Column]
      public short Quantity { get; set; }

      [Column]
      public float Discount { get; set; }

      [Association(ThisKey = nameof(OrderID), IsForeignKey = true)]
      public Order Order { get; set; }

      [Association(ThisKey = nameof(ProductID), IsForeignKey = true)]
      public Product Product { get; set; }
   }
}
