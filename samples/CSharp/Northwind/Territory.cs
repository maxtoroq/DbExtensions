using System;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Territories")]
   public class Territory {

      [Column(CanBeNull = false, IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Column(CanBeNull = false)]
      public string TerritoryDescription { get; set; }

      [Column]
      public int RegionID { get; set; }

      [Association(OtherKey = nameof(EmployeeTerritory.TerritoryID))]
      public Collection<EmployeeTerritory> EmployeeTerritories { get; } = new Collection<EmployeeTerritory>();

      [Association(ThisKey = nameof(RegionID), IsForeignKey = true)]
      public Region Region { get; set; }
   }
}
