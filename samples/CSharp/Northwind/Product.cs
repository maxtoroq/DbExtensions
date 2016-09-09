using System;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Products")]
   public partial class Product {

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

      [Association(OtherKey = nameof(OrderDetail.ProductID))]
      public Collection<OrderDetail> OrderDetails { get; } = new Collection<OrderDetail>();

      [Association(ThisKey = nameof(CategoryID), IsForeignKey = true)]
      public Category Category { get; set; }

      [Association(ThisKey = nameof(SupplierID), IsForeignKey = true)]
      public Supplier Supplier { get; set; }
   }
}
