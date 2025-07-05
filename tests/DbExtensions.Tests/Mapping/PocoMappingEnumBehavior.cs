using NUnit.Framework;

namespace DbExtensions.Tests.Mapping.Poco {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class PocoMappingEnumBehavior(bool useCompiledMapping) {

      readonly Database db = RealDatabase(useCompiledMapping);

      [Test]
      public void Can_Map_Numeric_Column_To_Enum() {

         var item = db.From<Enum.ToNumericColumn.Product>("Products")
            .First("CategoryID = {0}", Enum.CategoryEnum.Condiments);

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryID);
         Assert.AreEqual((int)Enum.CategoryEnum.Condiments, (int)item.CategoryID);
      }

      [Test]
      public void Can_Map_Numeric_Column_To_Nullable_Enum() {

         var item = db.From<Enum.NullableToNumericColumn.Product>("Products")
            .First("CategoryID = {0}", Enum.CategoryEnum.Condiments);

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryID);
         Assert.AreEqual((int)Enum.CategoryEnum.Condiments, (int)item.CategoryID);
      }

      [Test]
      public void Can_Map_Text_Column_To_Enum() {

         var item = db.From<Enum.ToTextColumn.Category>("Categories")
            .Single("CategoryName = {0}", Enum.CategoryEnum.Condiments.ToString());

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryName);
         Assert.AreEqual(Enum.CategoryEnum.Condiments.ToString(), item.CategoryName.ToString());
      }

      [Test]
      public void Can_Map_Text_Column_To_Nullable_Enum() {

         var item = db.From<Enum.NullableToTextColumn.Category>("Categories")
            .Single("CategoryName = {0}", Enum.CategoryEnum.Condiments.ToString());

         Assert.AreEqual(Enum.CategoryEnum.Condiments, item.CategoryName);
         Assert.AreEqual(Enum.CategoryEnum.Condiments.ToString(), item.CategoryName.ToString());
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

         public class Product {

            public int ProductID { get; set; }

            public string ProductName { get; set; }

            public CategoryEnum CategoryID { get; set; }
         }
      }

      namespace NullableToNumericColumn {

         public class Product {

            public int ProductID { get; set; }

            public string ProductName { get; set; }

            public CategoryEnum? CategoryID { get; set; }
         }
      }

      namespace ToTextColumn {

         public class Category {

            public int CategoryID { get; set; }

            public CategoryEnum CategoryName { get; set; }
         }
      }

      namespace NullableToTextColumn {

         public class Category {

            public int CategoryID { get; set; }

            public CategoryEnum? CategoryName { get; set; }
         }
      }
   }
}
