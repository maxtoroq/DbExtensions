using System;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class ConditionalClauseTests {

      [Test]
      public void If_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, $"B");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            ._If(false, $"B");

         Assert.AreEqual("SELECT A", queryFalse.ToString());
      }


      // ## ElseIf_Continuation

      [Test]
      public void ElseIf_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, $"B")
            ._ElseIf(true, $"C");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            ._If(false, $"B")
            ._ElseIf(false, $"C")
            ._ElseIf(true, $"D");

         Assert.AreEqual("SELECT A, D", queryFalse.ToString());
      }

      [Test]
      public void ElseIf_Continuation_No_If() {

         var query = SQL
            .SELECT("A")
            ._ElseIf(true, $"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_After_Else() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            ._Else($"C")
            ._ElseIf(true, $"D");

         Assert.AreEqual("SELECT A, C", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_Different_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            .WHERE("1 = 1")
            ._ElseIf(true, $"C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void ElseIf_Continuation_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            .WHERE()
            ._ElseIf(true, $"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }


      // ## Else_Continuation

      [Test]
      public void Else_Continuation() {

         var queryTrue = SQL
            .SELECT("A")
            ._If(true, $"B")
            ._Else($"C");

         Assert.AreEqual("SELECT A, B", queryTrue.ToString());

         var queryFalseIf = SQL
            .SELECT("A")
            ._If(false, $"B")
            ._Else($"C");

         Assert.AreEqual("SELECT A, C", queryFalseIf.ToString());

         var queryFalseElseIf = SQL
            .SELECT("A")
            ._If(false, $"B")
            ._ElseIf(false, $"C")
            ._Else($"D");

         Assert.AreEqual("SELECT A, D", queryFalseElseIf.ToString());
      }

      [Test]
      public void Else_Continuation_No_If() {

         var query = SQL
            .SELECT("A")
            ._Else($"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void Else_Continuation_Not_Nested() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            ._If(true, $"C")
            ._Else($"D")
            ._Else($"E");

         Assert.AreEqual("SELECT A, C", query.ToString());
      }

      [Test]
      public void Else_Continuation_Different_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            .WHERE("1 = 1")
            ._Else($"C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void Else_Continuation_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            ._If(false, $"B")
            .WHERE()
            ._Else($"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }
   }
}
