using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Mapping {

   using static TestUtil;

   [TestClass]
   public class PersistentComplexPropertiesBehavior {

      readonly Database db = RealDatabase();

      [TestMethod]
      public void Can_Read_Default_Name() {

         var entity = db.Table<PersistentComplexProperties.DefaultName.Customer>()
            .Find("ANATR");

         Assert.IsNotNull(entity);
         Assert.IsNotNull(entity.Contact);
         Assert.AreEqual("Ana Trujillo", entity.Contact.Name);
         Assert.AreEqual("Owner", entity.Contact.Title);
      }

      [TestMethod]
      public void Can_Read_Custom_Name() {

         var entity = db.Table<PersistentComplexProperties.CustomName.Customer>()
            .Find("ANATR");

         Assert.IsNotNull(entity);
         Assert.IsNotNull(entity.CustomerContact);
         Assert.AreEqual("Ana Trujillo", entity.CustomerContact.Name);
         Assert.AreEqual("Owner", entity.CustomerContact.Title);
      }

      [TestMethod]
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

      [TestMethod]
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

      [TestMethod]
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
   }
}
