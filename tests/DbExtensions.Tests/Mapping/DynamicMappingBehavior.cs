using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Mapping {

   using static TestUtil;

   [TestClass]
   public class DynamicMappingBehavior {

      [TestMethod, ExpectedException(typeof(ArgumentException))]
      public void Constructor_Parameters_Not_Allowed() {

         var data = new Dictionary<string, object> {
            { "1", "foo" }
         };

         Database db = MockQuery(data);

         var value = db.Map(SQL
            .SELECT("'foo' AS '1'"))
            .Single();
      }
   }
}
