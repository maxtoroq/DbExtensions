using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class SqlTableBehavior(bool useCompiledMapping) {

      [Test]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         var db = MockDatabase(useCompiledMapping);

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

         var db = MockDatabase(useCompiledMapping, "System.Data.SqlClient");

         SqlSet set = db.Table<SqlTable.Model2.Product>();

         SqlBuilder expected = SQL
            .SELECT("[ProductID], [ProductName]")
            .FROM("[dbo].[Products]");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      [Test]
      public void Can_Update_Assigned_Key() {

         var db = RealDatabase(useCompiledMapping);
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

      [Test]
      public void Refresh() {

         var db = RealDatabase(useCompiledMapping);
         var table = db.Table<SqlTable.Refresh.Product>();

         using (var tx = db.EnsureInTransaction()) {

            var entity = new SqlTable.Refresh.Product {
               ProductName = "Foo",
               Discontinued = false,
            };

            table.Add(entity);

            var id = entity.ProductID;

            Assert.AreNotEqual(0, id);

            entity.ProductName = "Bar";
            entity.Discontinued = true;

            table.Refresh(entity);

            Assert.AreEqual(id, entity.ProductID);
            Assert.AreEqual("Foo", entity.ProductName);
            Assert.AreEqual(false, entity.Discontinued);

            tx.Rollback();
         }
      }
   }

   namespace SqlTable {

      namespace Model1 {

         [Table]
         public class Product {

            [Column]
            public int Id { get; set; }
         }
      }

      namespace Model2 {

         [Table(Name = "[dbo].[Products]")]
         public class Product {

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

      namespace Refresh {

         [Table(Name = "Products")]
         public class Product {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int ProductID { get; set; }

            [Column]
            public string ProductName { get; set; }

            [Column]
            public bool Discontinued { get; set; }
         }
      }
   }
}
