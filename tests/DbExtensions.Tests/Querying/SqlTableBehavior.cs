using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture]
   public class SqlTableBehavior {

      [Test]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         Database db = MockDatabase(true);

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

      [Test]
      public void Can_Use_Multipart_Identifier() {

         Database db = MockDatabase(true, "System.Data.SqlClient");

         SqlSet set = db.Table<SqlTable.Model2.Product>();

         SqlBuilder expected = SQL
            .SELECT("[ProductID], [ProductName]")
            .FROM("[dbo].[Products]");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Can_Update_Assigned_Key() {

         Database db = RealDatabase(true);
         var table = db.Table<SqlTable.Model3.Customer>();

         string originalId = "FISSA";
         string newId = "FOO";

         using (var tx = db.EnsureInTransaction()) {

            var cust1 = table.Find(originalId);

            Assert.IsNotNull(cust1);

            cust1.CustomerID = newId;

            table.Update(cust1, originalId);

            Assert.IsTrue(table.ContainsKey(newId));
            Assert.IsFalse(table.ContainsKey(originalId));

            tx.Rollback();
         }
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

      namespace Model3 {

         [Table(Name = "Customers")]
         public class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }
         }
      }
   }
}
