using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "CustomerCustomerDemo")]
   public class CustomerCustomerDemo {

      [Column(IsPrimaryKey = true)]
      public string CustomerID { get; set; }

      [Column(IsPrimaryKey = true)]
      public string CustomerTypeID { get; set; }

      [Association(ThisKey = "CustomerTypeID", IsForeignKey = true)]
      public CustomerDemographic CustomerDemographic { get; set; }

      [Association(ThisKey = "CustomerID", IsForeignKey = true)]
      public Customer Customer { get; set; }
   }
}
