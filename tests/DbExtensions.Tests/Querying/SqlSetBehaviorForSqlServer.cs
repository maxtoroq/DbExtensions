using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture]
   public class SqlSetBehaviorForSqlServer {

      readonly Database db = MockDatabase("System.Data.SqlClient");

      [Test]
      public void Use_Parameter_On_Skip() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [Test]
      public void Use_Parameter_On_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [Test]
      public void Use_Parameter_On_Skip_And_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(2, query.ParameterValues.Count);
      }
   }
}
