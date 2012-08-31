using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Territories")]
   public class Territory {

      [Column(CanBeNull = false, IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Column(CanBeNull = false)]
      public string TerritoryDescription { get; set; }

      [Column]
      public int RegionID { get; set; }

      [Association(OtherKey = "TerritoryID")]
      public Collection<EmployeeTerritory> EmployeeTerritories { get; private set; }

      [Association(ThisKey = "RegionID", IsForeignKey = true)]
      public Region Region { get; set; }

      public Territory() {
         this.EmployeeTerritories = new Collection<EmployeeTerritory>();
      }
   }
}
