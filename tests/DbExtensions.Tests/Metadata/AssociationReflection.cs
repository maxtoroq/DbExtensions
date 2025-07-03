using System.Collections.ObjectModel;
using NUnit.Framework;
using DbExtensions.Metadata;

namespace DbExtensions.Tests.Metadata {

   using static TestUtil;

   [TestFixture]
   public class AssociationReflection {

      readonly Database db = MockDatabase(true);

      [Test]
      public void One_To_Many() {

         MetaType metaType = db.Configuration.GetMetaType(typeof(Model.Employee));

         Assert.AreEqual(2, metaType.Associations.Count);

         MetaAssociation assoc = metaType.Associations[1];

         Assert.IsTrue(assoc.IsMany);
         Assert.IsFalse(assoc.OtherKeyIsPrimaryKey);

         Assert.AreEqual(typeof(Model.Employee), assoc.ThisMember.DeclaringType.Type);
         Assert.AreEqual(nameof(Model.Employee.EmployeeTerritories), assoc.ThisMember.Name);
         Assert.AreEqual(typeof(Collection<Model.EmployeeTerritory>), assoc.ThisMember.Type);

         Assert.AreEqual(typeof(Model.EmployeeTerritory), assoc.OtherMember.DeclaringType.Type);
         Assert.AreEqual(nameof(Model.EmployeeTerritory.Employee), assoc.OtherMember.Name);
         Assert.AreEqual(typeof(Model.Employee), assoc.OtherMember.Type);
      }

      [Test]
      public void Many_To_One() {

         MetaType metaType = db.Configuration.GetMetaType(typeof(Model.EmployeeTerritory));

         Assert.AreEqual(2, metaType.Associations.Count);

         MetaAssociation assoc = metaType.Associations[1];

         Assert.IsFalse(assoc.IsMany);
         Assert.IsTrue(assoc.OtherKeyIsPrimaryKey);

         Assert.AreEqual(typeof(Model.EmployeeTerritory), assoc.ThisMember.DeclaringType.Type);
         Assert.AreEqual(nameof(Model.EmployeeTerritory.Employee), assoc.ThisMember.Name);
         Assert.AreEqual(typeof(Model.Employee), assoc.ThisMember.Type);

         Assert.AreEqual(typeof(Model.Employee), assoc.OtherMember.DeclaringType.Type);
         Assert.AreEqual(nameof(Model.Employee.EmployeeTerritories), assoc.OtherMember.Name);
         Assert.AreEqual(typeof(Collection<Model.EmployeeTerritory>), assoc.OtherMember.Type);
      }
   }

   namespace Model {

      [Table]
      class Employee {

         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int EmployeeID { get; set; }

         [Column]
         public string LastName { get; set; }

         [Column]
         public string FirstName { get; set; }

         [Association(OtherKey = nameof(Order.EmployeeID))]
         public Collection<Order> Orders { get; private set; }

         [Association(OtherKey = nameof(EmployeeTerritory.EmployeeID))]
         public Collection<EmployeeTerritory> EmployeeTerritories { get; private set; }
      }

      [Table]
      class EmployeeTerritory {

         [Column(IsPrimaryKey = true)]
         public int EmployeeID { get; set; }

         [Column(IsPrimaryKey = true)]
         public string TerritoryID { get; set; }

         [Association(ThisKey = nameof(TerritoryID))]
         public Territory Territory { get; set; }

         [Association(ThisKey = nameof(EmployeeID))]
         public Employee Employee { get; set; }
      }

      [Table]
      class Territory {

         [Column(IsPrimaryKey = true)]
         public string TerritoryID { get; set; }

         [Column]
         public string TerritoryDescription { get; set; }
      }

      [Table]
      class Order {

         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int OrderID { get; set; }

         [Column]
         public int? EmployeeID { get; set; }

         [Association(OtherKey = nameof(OrderDetail.OrderID))]
         public Collection<OrderDetail> OrderDetails { get; private set; }

         [Association(ThisKey = nameof(EmployeeID))]
         public Employee Employee { get; set; }
      }

      [Table]
      class OrderDetail {

         [Column(IsPrimaryKey = true)]
         public int OrderID { get; set; }

         [Column(IsPrimaryKey = true)]
         public int ProductID { get; set; }
      }
   }
}
