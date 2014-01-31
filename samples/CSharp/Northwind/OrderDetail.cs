using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

      [Association(ThisKey = "OrderID", IsForeignKey = true)]
      public Order Order { get; set; }

      [Association(ThisKey = "ProductID", IsForeignKey = true)]
      public Product Product { get; set; }
   }
}
