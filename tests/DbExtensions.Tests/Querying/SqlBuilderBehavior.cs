using System;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   [TestFixture]
   public class SqlBuilderBehavior {

      [Test]
      public void Multiple_Parameters() {

         var query = SQL
            .SELECT("{0}, {1}", 1, 2);

         Assert.AreEqual("SELECT {0}, {1}", query.ToString());
         Assert.AreEqual(2, query.ParameterValues.Count);
      }

      [Test]
      public void Expand_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0})", SQL.List(1, 2, 3));

         Assert.IsTrue(query.ToString().Contains("{2}"));
      }

      [Test]
      public void Adjust_Other_Placeholders_When_Using_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0}) AND c <> {1}", SQL.List(1, 2, 3), 4);

         Assert.IsTrue(query.ToString().Contains("{3}"));
         Assert.AreEqual(4, query.ParameterValues.Count);
      }

      [Test]
      public void Allow_Empty_List() {

         var query = SQL
            .SELECT("1 IN ({0})", SQL.List());

         Assert.AreEqual("SELECT 1 IN ({0})", query.ToString());
         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(null, query.ParameterValues[0]);
      }

      [Test]
      public void Use_Parameter_On_Limit_Clause() {

         var query = SQL
            .SELECT("*")
            .LIMIT(1);

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [Test]
      public void Use_Parameter_On_Offset_Clause() {

         var query = SQL
            .SELECT("*")
            .OFFSET(1);

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [Test]
      public void Treat_SqlBuilder_As_SubQuery() {

         var query = SQL
            .SELECT("*")
            .FROM("({0}) AS t0", SQL
               .SELECT("{0}", 5));

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(5, query.ParameterValues[0]);
      }

      [Test]
      public void Treat_SqlSet_As_SubQuery() {

         var db = TestUtil.MockDatabase();

         var query = SQL
            .SELECT("*")
            .FROM("({0}) AS t0", db.From(SQL
               .SELECT("{0}", 5)));

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(5, query.ParameterValues[0]);
      }
   }
}
