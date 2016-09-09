using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlSetBehavior {

      readonly Database db = MySqlDatabase();

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

         SqlSet set = db.From("products")
            .Cast<object>()
            .Where("NOT UnitPrice IS NULL");

         SqlBuilder expected = SQL
            .SELECT("*")
            .FROM("products")
            .WHERE("NOT UnitPrice IS NULL");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Dont_Require_Type_For_Select() {

         Database db = SqlServerDatabase();

         dynamic value = db.From(SQL.SELECT("'a' AS foo, 'b' AS bar"))
            .Select("foo")
            .Single();

         Assert.AreEqual("a", value.foo);
      }

      [TestMethod]
      public void Remember_Mapper() {

         Database db = SqlServerDatabase();

         SqlSet<string> set = db.From(SQL
            .SELECT("'a' AS c")
            , r => r.GetString(0))
            .OrderBy("c");

         string value = set.Single();
      }
   }
}
