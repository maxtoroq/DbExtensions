using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Employees")]
   public class Employee {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int EmployeeID { get; set; }

      [Column]
      public string LastName { get; set; }

      [Column]
      public string FirstName { get; set; }

      [Column]
      public string Title { get; set; }

      [Column]
      public string TitleOfCourtesy { get; set; }

      [Column]
      public DateTime? BirthDate { get; set; }

      [Column]
      public DateTime? HireDate { get; set; }

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
      public string HomePhone { get; set; }

      [Column]
      public string Extension { get; set; }

      [Column(UpdateCheck = UpdateCheck.Never)]
      public byte[] Photo { get; set; }

      [Column(UpdateCheck = UpdateCheck.Never)]
      public string Notes { get; set; }

      [Column]
      public int? ReportsTo { get; set; }

      [Column]
      public string PhotoPath { get; set; }

      [Association(ThisKey = "ReportsTo", IsForeignKey = true)]
      public Employee ReportsToEmployee { get; set; }

      [Association(OtherKey = "ReportsTo")]
      public Collection<Employee> Employees { get; private set; }

      [Association(OtherKey = "EmployeeID")]
      public Collection<EmployeeTerritory> EmployeeTerritories { get; private set; }

      [Association(OtherKey = "EmployeeID")]
      public Collection<Order> Orders { get; private set; }

      public Employee() {
         this.Employees = new Collection<Employee>();
         this.EmployeeTerritories = new Collection<EmployeeTerritory>();
         this.Orders = new Collection<Order>();
      }
   }
}
