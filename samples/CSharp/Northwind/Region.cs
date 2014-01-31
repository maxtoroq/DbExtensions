using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Samples.CSharp.Northwind {

   [Table(Name = "Region")]
   public class Region {

      [Column(IsPrimaryKey = true)]
      public int RegionID { get; set; }

      [Column(CanBeNull = false)]
      public string RegionDescription { get; set; }

      [Association(OtherKey = "RegionID")]
      public Collection<Territory> Territories { get; private set; }

      public Region() {
         this.Territories = new Collection<Territory>();
      }
   }
}
