using System;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "EmployeeTerritories")]
   public class EmployeeTerritory {

      [Column(IsPrimaryKey = true)]
      public int EmployeeID { get; set; }

      [Column(IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Association(ThisKey = nameof(EmployeeID))]
      public Employee Employee { get; set; }

      [Association(ThisKey = nameof(TerritoryID))]
      public Territory Territory { get; set; }
   }
}
