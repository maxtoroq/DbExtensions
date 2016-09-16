using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Customers")]
   public class Customer {

      [Column(IsPrimaryKey = true)]
      public string CustomerID { get; set; }

      [Column]
      public string CompanyName { get; set; }

      [Column]
      public string ContactName { get; set; }

      [Column]
      public string ContactTitle { get; set; }

      [Column]
      public string Address { get; set; }

      [Column]
      public string City { get; set; }

      [Column]
      public string Region { get; set; }

      [Column]
      public string PostalCode { get; set; }

      [Column]
      public string Country { get; set; }

      [Column]
      public string Phone { get; set; }

      [Column]
      public string Fax { get; set; }

      [Association(OtherKey = nameof(CustomerCustomerDemo.CustomerID))]
      public Collection<CustomerCustomerDemo> CustomerCustomerDemos { get; } = new Collection<CustomerCustomerDemo>();

      [Association(OtherKey = nameof(Order.CustomerID))]
      public Collection<Order> Orders { get; } = new Collection<Order>();
   }
}
