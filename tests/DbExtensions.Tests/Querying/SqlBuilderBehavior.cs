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

         var db = TestUtil.MockDatabase(true);

         var query = SQL
            .SELECT("*")
            .FROM("({0}) AS t0", db.From(SQL
               .SELECT("{0}", 5)));

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(5, query.ParameterValues[0]);
      }

      [Test]
      public void If_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, "B");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            ._If(false, "B");

         Assert.AreEqual("SELECT A", queryFalse.ToString());
      }


      // ## ElseIf_Continuation

      [Test]
      public void ElseIf_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, "B")
            ._ElseIf(true, "C");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            ._If(false, "B")
            ._ElseIf(false, "C")
            ._ElseIf(true, "D");

         Assert.AreEqual("SELECT A, D", queryFalse.ToString());
      }

      [Test]
      public void ElseIf_Continuation_No_If() {

         var query = SQL
            .SELECT("A")
            ._ElseIf(true, "C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_After_Else() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            ._Else("C")
            ._ElseIf(true, "D");

         Assert.AreEqual("SELECT A, C", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_Different_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            .WHERE("1 = 1")
            ._ElseIf(true, "C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            .WHERE()
            ._ElseIf(true, "C");

         Assert.AreEqual("SELECT A", query.ToString());
      }


      // ## Else_Continuation

      [Test]
      public void Else_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, "B")
            ._Else("C");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalseIf = SQL
            .SELECT("A")
            ._If(false, "B")
            ._Else("C");

         Assert.AreEqual("SELECT A, C", queryFalseIf.ToString());

         var queryFalseElseIf = SQL
            .SELECT("A")
            ._If(false, "B")
            ._ElseIf(false, "C")
            ._Else("D");

         Assert.AreEqual("SELECT A, D", queryFalseElseIf.ToString());
      }

      [Test]
      public void Else_Continuation_No_If() {

         var query = SQL
            .SELECT("A")
            ._Else("C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void Else_Continuation_Not_Nested() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            ._If(true, "C")
            ._Else("D")
            ._Else("E");

         Assert.AreEqual("SELECT A, C", query.ToString());
      }

      [Test]
      public void Else_Continuation_Different_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            .WHERE("1 = 1")
            ._Else("C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void Else_Continuation_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, "B")
            .WHERE()
            ._Else("C");

         Assert.AreEqual("SELECT A", query.ToString());
      }
   }
}
