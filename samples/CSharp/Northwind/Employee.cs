using System;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

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

      [Association(ThisKey = nameof(ReportsTo), IsForeignKey = true)]
      public Employee ReportsToEmployee { get; set; }

      [Association(OtherKey = nameof(Employee.ReportsTo))]
      public Collection<Employee> Employees { get; } = new Collection<Employee>();

      [Association(OtherKey = nameof(EmployeeTerritory.EmployeeID))]
      public Collection<EmployeeTerritory> EmployeeTerritories { get; } = new Collection<EmployeeTerritory>();

      [Association(OtherKey = nameof(Order.EmployeeID))]
      public Collection<Order> Orders { get; } = new Collection<Order>();
   }
}
