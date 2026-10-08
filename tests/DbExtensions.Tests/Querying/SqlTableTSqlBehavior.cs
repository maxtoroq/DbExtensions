using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture]
   public class SqlTableTSqlBehavior {

      readonly Database db = MockDatabase("Microsoft.Data.SqlClient");

      [Test]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order_With_Skip_And_Take() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id")
            .Skip(0)
            .Take(5);

         SqlBuilder expected = SQL
            .SELECT(db.QuoteIdentifier("Id"))
            .FROM(db.QuoteIdentifier("Product"))
            .WHERE("UnitsInStock > 0")
            .ORDER_BY("Id")
            .OFFSET($"{0} ROWS")
            .AppendLine()
            .Append($"FETCH NEXT {5} ROWS ONLY");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order_With_Take() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id")
            .Take(5);

         SqlBuilder expected = SQL
            .SELECT($"TOP({5}) *")
            .FROM(SQL
               .SELECT($"{db.QuoteIdentifier("Id"):sql}")
               .FROM(db.QuoteIdentifier("Product"))
               .WHERE("UnitsInStock > 0")
               .ORDER_BY("Id"), "_");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id");

         SqlBuilder expected = SQL
            .SELECT(db.QuoteIdentifier("Id"))
            .FROM(db.QuoteIdentifier("Product"))
            .WHERE("UnitsInStock > 0")
            .ORDER_BY("Id")
            .OFFSET("0 ROWS");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Do_Use_Subquery_To_Honor_Original_Column_List_With_Skip_And_Take() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id")
            .Skip(0)
            .Take(5)
            .Select("Id + 1");

         SqlBuilder expected = SQL
            .SELECT("Id + 1")
            .FROM(SQL
               .SELECT(db.QuoteIdentifier("Id"))
               .FROM(db.QuoteIdentifier("Product"))
               .WHERE("UnitsInStock > 0")
               .ORDER_BY("Id")
               .OFFSET($"{0} ROWS")
               .AppendLine()
               .Append($"FETCH NEXT {5} ROWS ONLY"), "_");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Do_Use_Subquery_To_Honor_Original_Column_List_With_Take() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id")
            .Take(5)
            .Select("Id + 1");

         SqlBuilder expected = SQL
            .SELECT($"TOP({5}) Id + 1")
            .FROM(SQL
               .SELECT($"{db.QuoteIdentifier("Id"):sql}")
               .FROM(db.QuoteIdentifier("Product"))
               .WHERE("UnitsInStock > 0")
               .ORDER_BY("Id"), "_");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Do_Use_Subquery_To_Honor_Original_Column_List() {

         SqlSet set = db.Table<SqlTableTSql.Model1.Product>()
            .Where("UnitsInStock > 0")
            .OrderBy("Id")
            .Select("Id + 1");

         SqlBuilder expected = SQL
            .SELECT("Id + 1")
            .FROM(SQL
               .SELECT(db.QuoteIdentifier("Id"))
               .FROM(db.QuoteIdentifier("Product"))
               .WHERE("UnitsInStock > 0")
               .ORDER_BY("Id")
               .OFFSET("0 ROWS"), "_");

         Assert.IsTrue(SqlEquals(set, expected));
      }
   }

   namespace SqlTableTSql {

      namespace Model1 {

         [Table]
         public class Product {

            [Column]
            public int Id { get; set; }
         }
      }
   }
}
