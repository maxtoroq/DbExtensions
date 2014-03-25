using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlSetBehavior {

      readonly Database db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests());

      Database MySqlDatabase() {
         return new Database(MySql.Data.MySqlClient.MySqlClientFactory.Instance.CreateConnection());
      }

      [TestMethod]
      public void AsEnumerable_Reference_Type() {

         SqlSet<string> set = db.From(SQL
            .SELECT("'a'")
            , r => r.GetString(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }

      [TestMethod]
      public void AsEnumerable_Value_Type() {

         SqlSet<int> set = db.From(SQL
            .SELECT("0")
            , r => r.GetInt32(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }

      [TestMethod]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Where("UnitsInStock > 0")
            .Skip(0)
            .Take(5);

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM("products")
            .WHERE("UnitsInStock > 0")
            .LIMIT(5)
            .OFFSET(0);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Where_After_Where_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Where("UnitsInStock > 0")
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .WHERE("UnitsInStock > 0"), "_")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Where_After_OrderBy_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .OrderBy("ProductID DESC")
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .ORDER_BY("ProductID DESC"), "_")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Where_After_Skip_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Skip(5)
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .OFFSET(5), "_")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Where_After_Take_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Take(5)
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .LIMIT(5), "_")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_OrderBy_After_OrderBy_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .OrderBy("ProductID DESC")
            .OrderBy("UnitPrice");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .ORDER_BY("ProductID DESC"), "_")
            .ORDER_BY("UnitPrice");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_OrderBy_After_Skip_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Skip(5)
            .OrderBy("UnitPrice");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .OFFSET(5), "_")
            .ORDER_BY("UnitPrice");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_OrderBy_After_Take_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Take(5)
            .OrderBy("UnitPrice");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .LIMIT(5), "_")
            .ORDER_BY("UnitPrice");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Skip_After_Skip_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Skip(5)
            .Skip(1);

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .OFFSET(5), "_")
            .OFFSET(1);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Skip_After_Take_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Take(5)
            .Skip(1);

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .LIMIT(5), "_")
            .OFFSET(1);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Apply_Take_After_Take_Call() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Take(5)
            .Take(1);

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM(SQL
               .SELECT("*")
               .FROM("products")
               .LIMIT(5), "_")
            .LIMIT(1);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Dont_Use_Subquery_For_Cast() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Cast(typeof(object))
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM("products")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Dont_Use_Subquery_For_Cast_Generic() {

         Database db = MySqlDatabase();

         SqlSet set = db.From("products")
            .Cast<object>()
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM("products")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      bool SqlEquals(SqlSet set, SqlBuilder query) {
         return TestUtil.SqlEquals(set, query);
      }
   }
}
