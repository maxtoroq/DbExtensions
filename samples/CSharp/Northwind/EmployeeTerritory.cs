using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "EmployeeTerritories")]
   public class EmployeeTerritory {

      [Column(IsPrimaryKey = true)]
      public int EmployeeID { get; set; }

      [Column(CanBeNull = false, IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Association(ThisKey = "EmployeeID", IsForeignKey = true)]
      public Employee Employee { get; set; }

      [Association(ThisKey = "TerritoryID", IsForeignKey = true)]
      public Territory Territory { get; set; }
   }
}
