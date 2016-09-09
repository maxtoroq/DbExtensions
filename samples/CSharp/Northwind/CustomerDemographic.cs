using System;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "CustomerDemographics")]
   public class CustomerDemographic {

      [Column(IsPrimaryKey = true)]
      public string CustomerTypeID { get; set; }

      [Column(UpdateCheck = UpdateCheck.Never)]
      public string CustomerDesc { get; set; }

      [Association(OtherKey = nameof(CustomerCustomerDemo.CustomerTypeID))]
      public Collection<CustomerCustomerDemo> CustomerCustomerDemos { get; } = new Collection<CustomerCustomerDemo>();
   }
}
