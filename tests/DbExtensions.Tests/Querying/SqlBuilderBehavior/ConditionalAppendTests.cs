using System;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class ConditionalAppendTests {

      // ## AppendIf

      [Test]
      public void AppendIf() {

         var queryTrue = SQL
            .SELECT("A")
            .AppendIf(true, $"B");

         Assert.AreEqual("SELECT AB", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            .AppendIf(false, $"B");

         Assert.AreEqual("SELECT A", queryFalse.ToString());
      }

      [Test]
      public void AppendIf_Different_Clause() {

         var query = SQL
            .SELECT("A")
            .WHERE()
            .AppendIf(true, $"B");

         Assert.AreEqual("SELECT AB", query.ToString());
      }


      // ## AppendElseIf

      [Test]
      public void AppendElseIf() {

         var queryTrue = SQL
            .SELECT("A")
            .AppendIf(true, $"B")
            .AppendElseIf(true, $"C");

         Assert.AreEqual("SELECT AB", queryTrue.ToString());

         var queryFalse = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendElseIf(false, $"C")
            .AppendElseIf(true, $"D");

         Assert.AreEqual("SELECT AD", queryFalse.ToString());
      }

      [Test]
      public void AppendElseIf_No_If() {

         var query = SQL
            .SELECT("A")
            .AppendElseIf(true, $"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void AppendElseIf_After_Else() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendElse($"C")
            .AppendElseIf(true, $"D");

         Assert.AreEqual("SELECT AC", query.ToString());
      }

      [Test]
      public void AppendElseIf_Different_Clause() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .WHERE("1 = 1")
            .AppendElseIf(true, $"C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void AppendElseIf_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .WHERE()
            .AppendElseIf(true, $"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }


      // ## AppendElse

      [Test]
      public void AppendElse() {

         var queryTrue = SQL
            .SELECT("A")
            .AppendIf(true, $"B")
            .AppendElse($"C");

         Assert.AreEqual("SELECT AB", queryTrue.ToString());

         var queryFalseIf = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendElse($"C");

         Assert.AreEqual("SELECT AC", queryFalseIf.ToString());

         var queryFalseElseIf = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendElseIf(false, $"C")
            .AppendElse($"D");

         Assert.AreEqual("SELECT AD", queryFalseElseIf.ToString());
      }

      [Test]
      public void AppendElse_Duplicate() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendElse($"C")
            .AppendElse($"D");

         Assert.AreEqual("SELECT AC", query.ToString());
      }

      [Test]
      public void AppendElse_No_If() {

         var query = SQL
            .SELECT("A")
            .AppendElse($"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }

      [Test]
      public void AppendElse_Not_Nested() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .AppendIf(true, $"C")
            .AppendElse($"D")
            .AppendElse($"E");

         Assert.AreEqual("SELECT AC", query.ToString());
      }

      [Test]
      public void AppendElse_Different_Clause() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .WHERE("1 = 1")
            .AppendElse($"C");

         Assert.AreEqual("SELECT A\r\nWHERE 1 = 1", query.ToString());
      }

      [Test]
      public void AppendElse_Different_Next_Clause() {

         var query = SQL
            .SELECT("A")
            .AppendIf(false, $"B")
            .WHERE()
            .AppendElse($"C");

         Assert.AreEqual("SELECT A", query.ToString());
      }
   }
}
