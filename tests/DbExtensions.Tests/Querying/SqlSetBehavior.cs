using System.Collections.Generic;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture]
   public class SqlSetBehavior {

      readonly Database db = MockDatabase();

      [Test]
      public void AsEnumerable_Reference_Type() {

         var data = new Dictionary<string, object> {
            { "a", "a" }
         };

         var db = MockQuery(data);

         SqlSet<string> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetString(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }

      [Test]
      public void AsEnumerable_Value_Type() {

         var data = new Dictionary<string, object> {
            { "0", 0 }
         };

         var db = MockQuery(data);

         SqlSet<int> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetInt32(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
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

      [Test]
      public void Dont_Require_Type_For_Select() {

         var data = new Dictionary<string, object> {
            { "foo", "a" }
         };

         var db = MockQuery(data);

         dynamic value = db.From(SQL.SELECT("NULL"))
            .Select("foo")
            .Single();

         Assert.AreEqual("a", value.foo);
      }

      [Test]
      public void Remember_Mapper() {

         var data = new Dictionary<string, object> {
            { "c", "a" }
         };

         var db = MockQuery(data);

         SqlSet<string> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetString(0))
            .OrderBy("c");

         string value = set.Single();
      }
   }
}
