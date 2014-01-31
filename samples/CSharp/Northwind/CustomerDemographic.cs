using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "CustomerDemographics")]
   public class CustomerDemographic {

      [Column(IsPrimaryKey = true)]
      public string CustomerTypeID { get; set; }

      [Column(UpdateCheck = UpdateCheck.Never)]
      public string CustomerDesc { get; set; }

      [Association(OtherKey = "CustomerTypeID")]
      public Collection<CustomerCustomerDemo> CustomerCustomerDemos { get; private set; }

      public CustomerDemographic() {
         this.CustomerCustomerDemos = new Collection<CustomerCustomerDemo>();
      }
   }
}
