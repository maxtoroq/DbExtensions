using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Products")]
   public class Product {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int ProductID { get; set; }

      [Column(CanBeNull = false)]
      public string ProductName { get; set; }

      [Column]
      public int? SupplierID { get; set; }

      [Column]
      public int? CategoryID { get; set; }

      [Column]
      public string QuantityPerUnit { get; set; }

      [Column]
      public decimal? UnitPrice { get; set; }

      [Column]
      public short? UnitsInStock { get; set; }

      [Column]
      public short? UnitsOnOrder { get; set; }

      [Column]
      public short? ReorderLevel { get; set; }

      [Column]
      public bool Discontinued { get; set; }

      public decimal ValueInStock { get; set; }

      [Association(OtherKey = "ProductID")]
      public Collection<OrderDetail> OrderDetails { get; private set; }

      [Association(ThisKey = "CategoryID", IsForeignKey = true)]
      public Category Category { get; set; }

      [Association(ThisKey = "SupplierID", IsForeignKey = true)]
      public Supplier Supplier { get; set; }

      public Product() {
         this.OrderDetails = new Collection<OrderDetail>();
      }
   }
}
