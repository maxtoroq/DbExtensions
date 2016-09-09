using System;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Region")]
   public class Region {

      [Column(IsPrimaryKey = true)]
      public int RegionID { get; set; }

      [Column(CanBeNull = false)]
      public string RegionDescription { get; set; }

      [Association(OtherKey = nameof(Territory.RegionID))]
      public Collection<Territory> Territories { get; } = new Collection<Territory>();
   }
}
