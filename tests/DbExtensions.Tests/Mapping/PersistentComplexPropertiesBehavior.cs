using NUnit.Framework;

namespace DbExtensions.Tests.Mapping.Annotated {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class PersistentComplexPropertiesBehavior(bool useCompiledMapping) {

      readonly Database db = RealDatabase(useCompiledMapping);

      [Test]
      public void Can_Read_Default_Name() {

         var entity = db.Table<PersistentComplexProperties.DefaultName.Customer>()
            .Find("ANATR");

         Assert.IsNotNull(entity);
         Assert.IsNotNull(entity.Contact);
         Assert.AreEqual("Ana Trujillo", entity.Contact.Name);
         Assert.AreEqual("Owner", entity.Contact.Title);
      }

      [Test]
      public void Can_Read_Custom_Name() {

         var entity = db.Table<PersistentComplexProperties.CustomName.Customer>()
            .Find("ANATR");

         Assert.IsNotNull(entity);
         Assert.IsNotNull(entity.CustomerContact);
         Assert.AreEqual("Ana Trujillo", entity.CustomerContact.Name);
         Assert.AreEqual("Owner", entity.CustomerContact.Title);
      }

      [Test]
      public void Can_Insert() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<PersistentComplexProperties.Insert.Customer>();

            var entity = new PersistentComplexProperties.Insert.Customer {
               CustomerID = "XXXXX",
               CompanyName = "X5 Corp.",
               Contact = new PersistentComplexProperties.Insert.Contact {
                  Name = "Mr. X",
                  Title = "Owner"
               }
            };

            table.Add(entity);

            entity = table.Find(entity.CustomerID);

            Assert.IsNotNull(entity);
            Assert.AreEqual("XXXXX", entity.CustomerID);
            Assert.IsNotNull(entity.Contact);
            Assert.AreEqual("Mr. X", entity.Contact.Name);

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Update() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<PersistentComplexProperties.Update.Customer>();

            var entity = table.Find("ANATR");

            Assert.AreEqual("Ana Trujillo", entity.Contact.Name);

            entity.Contact.Name = "Ana Torroja";

            table.Update(entity);

            entity = table.Find(entity.CustomerID);

            Assert.AreEqual("Ana Torroja", entity.Contact.Name);

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Update_Null_Complex_Property() {

         using (var tx = db.EnsureInTransaction()) {

            var table = db.Table<PersistentComplexProperties.UpdateNullComplexProperty.Customer>();

            var entity = table.Find("ANATR");

            Assert.AreEqual("Ana Trujillo", entity.Contact.Name);

            entity.Contact = null;

            table.Update(entity);

            Assert.IsTrue(table.Any("CustomerID = {0} AND ContactName IS NULL AND ContactTitle IS NULL", entity.CustomerID));

            entity = table.Find(entity.CustomerID);

            Assert.IsNull(entity.Contact);

            tx.Rollback();
         }
      }

      [Test]
      public void Can_Configure_Default_Separator() {

         var db = MockDatabase(useCompiledMapping);
         db.Configuration.DefaultComplexPropertySeparator = "$";

         var expected = SQL
            .SELECT(db.QuoteIdentifier("CustomerID"))
            ._(db.QuoteIdentifier("CompanyName"))
            ._(db.QuoteIdentifier("Contact$Name"))
            ._(db.QuoteIdentifier("Contact$Title"))
            .FROM(db.QuoteIdentifier("Customers"));

         var actual = db.Table<PersistentComplexProperties.ConfigureSeparator.Customer>();

         Assert.IsTrue(SqlEquals(actual, expected));
      }

      [Test]
      public void Can_Override_Default_Separator() {

         var db = MockDatabase(useCompiledMapping);
         db.Configuration.DefaultComplexPropertySeparator = "$";

         var expected = SQL
            .SELECT(db.QuoteIdentifier("CustomerID"))
            ._(db.QuoteIdentifier("CompanyName"))
            ._(db.QuoteIdentifier("Contact_Name") + " AS " + db.QuoteIdentifier("Contact$Name"))
            ._(db.QuoteIdentifier("Contact_Title") + " AS " + db.QuoteIdentifier("Contact$Title"))
            .FROM(db.QuoteIdentifier("Customers"));

         var actual = db.Table<PersistentComplexProperties.OverrideSeparator.Customer>();

         Assert.IsTrue(SqlEquals(actual, expected));
      }

      [Test]
      public void Can_Override_Default_Separator_With_Empty_String() {

         var db = MockDatabase(useCompiledMapping);
         db.Configuration.DefaultComplexPropertySeparator = "$";

         var expected = SQL
            .SELECT(db.QuoteIdentifier("CustomerID"))
            ._(db.QuoteIdentifier("CompanyName"))
            ._(db.QuoteIdentifier("ContactName") + " AS " + db.QuoteIdentifier("Contact$Name"))
            ._(db.QuoteIdentifier("ContactTitle") + " AS " + db.QuoteIdentifier("Contact$Title"))
            .FROM(db.QuoteIdentifier("Customers"));

         var actual = db.Table<PersistentComplexProperties.OverrideSeparatorEmptyString.Customer>();

         Assert.IsTrue(SqlEquals(actual, expected));
      }
   }

   namespace PersistentComplexProperties {

      namespace DefaultName {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace CustomName {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty(Name = "Contact")]
            public Contact CustomerContact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace Insert {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace Update {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace UpdateNullComplexProperty {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace ConfigureSeparator {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace OverrideSeparator {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty(Separator = "_")]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }

      namespace OverrideSeparatorEmptyString {

         [Table(Name = "Customers")]
         class Customer {

            [Column(IsPrimaryKey = true)]
            public string CustomerID { get; set; }

            [Column]
            public string CompanyName { get; set; }

            [ComplexProperty(Separator = "")]
            public Contact Contact { get; set; }
         }

         class Contact {

            [Column]
            public string Name { get; set; }

            [Column]
            public string Title { get; set; }
         }
      }
   }
}
