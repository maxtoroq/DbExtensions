using System;
using System.Collections.ObjectModel;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Region")]
   public class Region {

      [Column(IsPrimaryKey = true)]
      public int RegionID { get; set; }

      [Column]
      public string RegionDescription { get; set; }

      [Association(OtherKey = nameof(Territory.RegionID))]
      public Collection<Territory> Territories { get; } = new Collection<Territory>();
   }
}
