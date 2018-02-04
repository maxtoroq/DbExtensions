using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlSetAnnotatedBehavior {

      [TestMethod]
      public void Contains() {

         var db = SqlServerNorthwindDatabase();

         SqlSet<SqlSetAnnotated.Model1.Product> table = db.Table<SqlSetAnnotated.Model1.Product>();

         var prod1 = table.Single("ProductID = 1");

         Assert.IsTrue(table.Contains(prod1));
         Assert.IsFalse(table.Where("ProductID = 2").Contains(prod1));
      }

      [TestMethod]
      public void ContainsKey() {

         var db = SqlServerNorthwindDatabase();

         SqlSet<SqlSetAnnotated.Model1.Product> table = db.Table<SqlSetAnnotated.Model1.Product>();

         Assert.IsTrue(table.ContainsKey(1));
         Assert.IsFalse(table.Where("ProductID = 2").ContainsKey(1));
      }

      [TestMethod]
      public void Find() {

         var db = SqlServerNorthwindDatabase();

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
