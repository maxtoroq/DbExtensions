using System;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class BasicTests {

      [Test]
      public void Create_Interpolated() {

         var query = (SqlBuilder)$"""
            SELECT ProductID, ProductName
            FROM Products
            WHERE CategoryID = {1}
            """;

         Assert.AreEqual("""
            SELECT ProductID, ProductName
            FROM Products
            WHERE CategoryID = {0}
            """, query.ToString());
         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(1, query.ParameterValues[0]);
      }

      [Test]
      public void Multiple_Parameters() {

         var query = SQL
            .SELECT($"{1}, {2}");

         Assert.AreEqual("SELECT {0}, {1}", query.ToString());
         Assert.AreEqual(2, query.ParameterValues.Count);
      }

      [Test]
      public void Expand_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE($"c IN ({new[] { 1, 2, 3 }:list})");

         Assert.AreEqual("SELECT *\r\nWHERE c IN ({0}, {1}, {2})", query.ToString());
         Assert.AreEqual(3, query.ParameterValues.Count);
      }

      [Test]
      public void Adjust_Other_Placeholders_When_Using_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE($"c IN ({new[] { 1, 2, 3 }:list}) AND c <> {4}");

         Assert.AreEqual("SELECT *\r\nWHERE c IN ({0}, {1}, {2}) AND c <> {3}", query.ToString());
         Assert.AreEqual(4, query.ParameterValues.Count);
      }

      [Test]
      public void Allow_Empty_List() {

         var query = SQL
            .SELECT($"1 IN ({new int[0]:list})");

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
      public void Values_List() {

         var query = SQL
            .INSERT_INTO("tbl")
            .VALUES(1, 2, 3);

         Assert.AreEqual("INSERT INTO tbl\r\nVALUES ({0}, {1}, {2})", query.ToString());
         Assert.AreEqual(3, query.ParameterValues.Count);
      }

      [Test]
      public void Treat_SqlBuilder_As_SubQuery() {

         var query = SQL
            .SELECT("*")
            .FROM($"({SQL
               .SELECT($"{5}")}) AS t0");

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(5, query.ParameterValues[0]);
      }

      [Test]
      public void Treat_SqlSet_As_SubQuery() {

         var db = TestUtil.MockDatabase();

         var query = SQL
            .SELECT("*")
            .FROM($"({db.FromQuery($"SELECT {5}")}) AS t0");

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(5, query.ParameterValues[0]);
      }
   }
}
