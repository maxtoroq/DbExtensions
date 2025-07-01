using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class SqlSetAnnotatedBehavior(bool useCompiledMapping) {

      readonly Database db = RealDatabase(useCompiledMapping);

      [Test]
      public void Contains() {

         SqlSet<SqlSetAnnotated.Model1.Product> table = db.Table<SqlSetAnnotated.Model1.Product>();

         var prod1 = table.Single("ProductID = 1");

         Assert.IsTrue(table.Contains(prod1));
         Assert.IsFalse(table.Where("ProductID = 2").Contains(prod1));
      }

      [Test]
      public void ContainsKey() {

         SqlSet<SqlSetAnnotated.Model1.Product> table = db.Table<SqlSetAnnotated.Model1.Product>();

         Assert.IsTrue(table.ContainsKey(1));
         Assert.IsFalse(table.Where("ProductID = 2").ContainsKey(1));
      }

      [Test]
      public void Find() {

         SqlSet<SqlSetAnnotated.Model1.Product> table = db.Table<SqlSetAnnotated.Model1.Product>();

         Assert.IsNotNull(table.Find(1));
         Assert.IsNull(table.Where("ProductID = 2").Find(1));
      }
   }

   namespace SqlSetAnnotated {

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
