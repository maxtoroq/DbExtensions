using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlSetBehaviorForSqlServer {

      readonly Database db = SqlServerDatabase();

      [TestMethod]
      public void Use_Parameter_On_Skip() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Skip_And_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(2, query.ParameterValues.Count);
      }
   }
}
