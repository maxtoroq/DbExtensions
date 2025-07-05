using NUnit.Framework;

namespace DbExtensions.Tests.Mapping.Annotated {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class EnumMappingBehavior(bool useCompiledMapping) {

      readonly Database db = RealDatabase(useCompiledMapping);

      [Test]
      public void Can_Map_Numeric_Column_To_Enum() {

         var item = db.Table<Enum.ToNumericColumn.Product>()
            .First("CategoryID = {0}", Enum.CategoryEnum.Condiments);

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryID);
         Assert.AreEqual((int)Enum.CategoryEnum.Condiments, (int)item.CategoryID);
      }

      [Test]
      public void Can_Map_Numeric_Column_To_Nullable_Enum() {

         var item = db.Table<Enum.NullableToNumericColumn.Product>()
            .First("CategoryID = {0}", Enum.CategoryEnum.Condiments);

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryID);
         Assert.AreEqual((int)Enum.CategoryEnum.Condiments, (int)item.CategoryID);
      }

      [Test]
      public void Can_Persist_Enum_To_Numeric_Column() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<Enum.ToNumericColumn.Product>();

            var item = new Enum.ToNumericColumn.Product {
               CategoryID = Enum.CategoryEnum.Beverages,
               ProductName = ""
            };

            table.Add(item);

            Assert.AreEqual(1, table.Count("ProductID = {0} AND CategoryID = {1}", item.ProductID, item.CategoryID));

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Persist_Nullable_Enum_To_Numeric_Column() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<Enum.NullableToNumericColumn.Product>();

            var item = new Enum.NullableToNumericColumn.Product {
               CategoryID = Enum.CategoryEnum.Beverages,
               ProductName = ""
            };

            table.Add(item);

            Assert.AreEqual(1, table.Count("ProductID = {0} AND CategoryID = {1}", item.ProductID, item.CategoryID));

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Map_Text_Column_To_Enum() {

         var item = db.Table<Enum.ToTextColumn.Category>()
            .Single("CategoryName = {0}", Enum.CategoryEnum.Condiments.ToString());

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryName);
         Assert.AreEqual(Enum.CategoryEnum.Condiments.ToString(), item.CategoryName.ToString());
      }

      [Test]
      public void Can_Map_Text_Column_To_Nullable_Enum() {

         var item = db.Table<Enum.NullableToTextColumn.Category>()
            .Single("CategoryName = {0}", Enum.CategoryEnum.Condiments.ToString());

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryName);
         Assert.AreEqual(Enum.CategoryEnum.Condiments.ToString(), item.CategoryName.ToString());
      }

      [Test]
      public void Can_Persist_Enum_To_Text_Column() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<Enum.ToTextColumn.Category>();

            var item = new Enum.ToTextColumn.Category {
               CategoryName = Enum.CategoryEnum.Foo
            };

            table.Add(item);

            Assert.AreEqual(1, table.Count("CategoryID = {0} AND CategoryName = {1}", item.CategoryID, item.CategoryName.ToString()));

            item.CategoryName = Enum.CategoryEnum.Bar;

            table.Update(item);

            Assert.AreEqual(1, table.Count("CategoryID = {0} AND CategoryName = {1}", item.CategoryID, item.CategoryName.ToString()));

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Persist_Nullable_Enum_To_Text_Column() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<Enum.NullableToTextColumn.Category>();

            var item = new Enum.NullableToTextColumn.Category {
               CategoryName = Enum.CategoryEnum.Foo
            };

            table.Add(item);

            Assert.AreEqual(1, table.Count("CategoryID = {0} AND CategoryName = {1}", item.CategoryID, item.CategoryName.ToString()));

            item.CategoryName = Enum.CategoryEnum.Bar;

            table.Update(item);

            Assert.AreEqual(1, table.Count("CategoryID = {0} AND CategoryName = {1}", item.CategoryID, item.CategoryName.ToString()));

            tx.Rollback();
         }
      }
   }

   namespace Enum {

      public enum CategoryEnum {
         Beverages = 1,
         Condiments = 2,
         Foo = 1000,
         Bar = 1001
      }

      namespace ToNumericColumn {

         [Table(Name = "Products")]
         public class Product {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int ProductID { get; set; }

            [Column]
            public string ProductName { get; set; }

            [Column]
            public CategoryEnum CategoryID { get; set; }
         }
      }

      namespace NullableToNumericColumn {

         [Table(Name = "Products")]
         public class Product {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int ProductID { get; set; }

            [Column]
            public string ProductName { get; set; }

            [Column]
            public CategoryEnum? CategoryID { get; set; }
         }
      }

      namespace ToTextColumn {

         [Table(Name = "Categories")]
         public class Category {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int CategoryID { get; set; }

            [Column(ConvertTo = typeof(string))]
            public CategoryEnum CategoryName { get; set; }
         }
      }

      namespace NullableToTextColumn {

         [Table(Name = "Categories")]
         public class Category {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int CategoryID { get; set; }

            [Column(ConvertTo = typeof(string))]
            public CategoryEnum? CategoryName { get; set; }
         }
      }
   }
}
