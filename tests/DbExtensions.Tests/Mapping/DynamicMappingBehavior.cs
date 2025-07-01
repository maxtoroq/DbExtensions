using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DbExtensions.Tests.Mapping {

   using static TestUtil;

   [TestFixture]
   public class DynamicMappingBehavior {

      [Test]
      public void Constructor_Parameters_Not_Allowed() {

         var data = new Dictionary<string, object> {
            { "1", "foo" }
         };

         var db = MockQuery(true, data);

         var results = db.Map(SQL
            .SELECT("NULL"));

         Assert.Throws<ArgumentException>(() => results.Single());
      }
   }
}
