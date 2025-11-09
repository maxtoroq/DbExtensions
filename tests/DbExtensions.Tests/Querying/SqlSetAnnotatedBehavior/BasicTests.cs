using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlSetAnnotatedBehavior {

   using static TestUtil;

   [TestFixture]
   public class BasicTests {

      readonly Database db = RealDatabase();

      [Test]
      public void Contains() {

         SqlSet<Basic.Model1.Product> table = db.Table<Basic.Model1.Product>();

         var prod1 = table.Single("ProductID = 1");

         Assert.IsTrue(table.Contains(prod1));
         Assert.IsFalse(table.Where("ProductID = 2").Contains(prod1));
      }

      [Test]
      public void ContainsKey() {

         SqlSet<Basic.Model1.Product> table = db.Table<Basic.Model1.Product>();

         Assert.IsTrue(table.ContainsKey(1));
         Assert.IsFalse(table.Where("ProductID = 2").ContainsKey(1));
      }

      [Test]
      public void Find() {

         SqlSet<Basic.Model1.Product> table = db.Table<Basic.Model1.Product>();

         Assert.IsNotNull(table.Find(1));
         Assert.IsNull(table.Where("ProductID = 2").Find(1));
      }
   }

   namespace Basic {

      namespace Model1 {

         [Table(Name = "Products")]
         public class Product {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int ProductID { get; set; }

            public string ProductName { get; set; }
         }
      }
   }
}
