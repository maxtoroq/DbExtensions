using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class SetClauseTests {

      [Test]
      public void Set_Continuation() {

         var query = SQL
            .UPDATE("tbl")
            .SET($"foo = {1}")
            .SET($"bar = {2}");

         Assert.AreEqual("UPDATE tbl\r\nSET foo = {0},\r\nbar = {1}", query.ToString());
         Assert.AreEqual(2, query.ParameterValues.Count);
      }
   }
}
