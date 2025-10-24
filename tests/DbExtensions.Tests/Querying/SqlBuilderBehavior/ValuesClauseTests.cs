using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class ValuesClauseTests {

      [Test]
      public void Values_List() {

         var query = SQL
            .INSERT_INTO("tbl")
            .VALUES(1, 2, 3);

         Assert.AreEqual("INSERT INTO tbl\r\nVALUES ({0}, {1}, {2})", query.ToString());
         Assert.AreEqual(3, query.ParameterValues.Count);
      }

      [Test]
      public void Values_Continuation() {

         var query = SQL
            .INSERT_INTO("tbl")
            .VALUES(1, 2, 3)
            .VALUES(4, 5, 6);

         Assert.AreEqual("INSERT INTO tbl\r\nVALUES ({0}, {1}, {2}),\r\n({3}, {4}, {5})", query.ToString());
         Assert.AreEqual(6, query.ParameterValues.Count);
      }
   }
}
