using System;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table]
   public class CustomerCustomerDemo {

      [Column(IsPrimaryKey = true)]
      public string CustomerID { get; set; }

      [Column(IsPrimaryKey = true)]
      public string CustomerTypeID { get; set; }

      [Association(ThisKey = nameof(CustomerTypeID), IsForeignKey = true)]
      public CustomerDemographic CustomerDemographic { get; set; }

      [Association(ThisKey = nameof(CustomerID), IsForeignKey = true)]
      public Customer Customer { get; set; }
   }
}
