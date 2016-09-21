using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlTableBehavior {

      [TestMethod]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         Database db = MySqlDatabase();

         SqlSet set = db.Table<SqlTable.Model1.Product>()
            .Where("UnitsInStock > 0")
            .Skip(0)
            .Take(5);

         SqlBuilder expected = SQL
            .SELECT(db.QuoteIdentifier("Id"))
            .FROM(db.QuoteIdentifier("Product"))
            .WHERE("UnitsInStock > 0")
            .LIMIT(5)
            .OFFSET(0);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [TestMethod]
      public void Can_Use_Multipart_Identifier() {

         Database db = SqlServerNorthwindDatabase();

         db.Table<SqlTable.Model2.Product>().First();
      }
   }

   namespace SqlTable {

      namespace Model1 {

         [Table]
         class Product {

            [Column]
            public int Id { get; set; }
         }
      }

      namespace Model2 {

         [Table(Name = "[dbo].[Products]")]
         class Product {

            [Column(IsPrimaryKey = true)]
            public int ProductID { get; set; }

            [Column]
            public string ProductName { get; set; }
         }
      }
   }
}
