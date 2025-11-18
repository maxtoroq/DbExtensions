using System;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlSetAnnotatedBehavior {

   using static TestUtil;

   [TestFixture]
   public class IncludeTests {

      readonly Database db = RealDatabase();

      [Test]
      public void Can_Include_One() {

         var set = db.Table<Include.Model1.Product>()
            .Where("NOT CategoryID IS NULL AND NOT SupplierID IS NULL")
            .Include(p => p.Category)
            .Include(p => p.Supplier);

         var item = set.First();

         Assert.IsNotNull(item.Category);
         Assert.IsNotNull(item.Supplier);
      }

      [Test]
      public void Can_Include_One_Nested() {

         var set = db.Table<Include.Model1.EmployeeTerritory>()
            .Include(p => p.Territory.Region);

         var item = set.First();

         Assert.IsNotNull(item.Territory);
         Assert.IsNotNull(item.Territory.Region);
      }

      [Test]
      public void Can_Include_One_Nested_Key_Name_Member_Differs() {

         var set = db.Table<Include.Model2.EmployeeTerritory>()
            .Include(p => p.Territory.Region);

         var item = set.First();

         Assert.IsNotNull(item.Territory);
         Assert.IsNotNull(item.Territory.Region);
      }

      [Test]
      public void Can_Include_Many() {

         var set = db.Table<Include.Model1.Category>()
            .IncludeMany(p => p.Products);

         var item = set.First();

         Assert.IsNotNull(item.Products);
         Assert.AreNotEqual(0, item.Products.Count);
         Assert.IsTrue(item.Products.All(p => Object.ReferenceEquals(p.Category, item)));
      }

      [Test]
      public void Can_Include_Many_Multiple() {

         var set1 = db.Table<Include.Model1.Employee>()
            .IncludeMany(p => p.EmployeeTerritories);

         var set2 = set1.IncludeMany(p => p.Orders);

         var item = set1.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => Object.ReferenceEquals(p.Employee, item)));

         // test immutability
         Assert.IsTrue(item.Orders is null or { Count: 0 });

         item = set2.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => Object.ReferenceEquals(p.Employee, item)));

         Assert.IsNotNull(item.Orders);
         Assert.AreNotEqual(0, item.Orders.Count);
         Assert.IsTrue(item.Orders.All(p => Object.ReferenceEquals(p.Employee, item)));
      }

      [Test]
      public void Can_Include_Many_In_One() {

         var set = db.Table<Include.Model1.EmployeeTerritory>()
            .Include(p => p.Employee)
            .IncludeMany(p => p.Employee.Orders);

         var item = set.First();

         Assert.IsNotNull(item.Employee);
         Assert.AreNotEqual(0, item.Employee.Orders.Count);
         Assert.IsTrue(item.Employee.Orders.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));
      }

      [Test]
      public void Can_Include_Many_In_One_Multiple() {

         var set = db.Table<Include.Model1.EmployeeTerritory>()
            .Include(p => p.Employee)
            .IncludeMany(p => p.Employee.Orders)
            .IncludeMany(p => p.Employee.EmployeeTerritories);

         var item = set.First();

         Assert.IsNotNull(item.Employee);
         Assert.AreNotEqual(0, item.Employee.Orders.Count);
         Assert.IsTrue(item.Employee.Orders.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));

         Assert.AreNotEqual(0, item.Employee.EmployeeTerritories.Count);
         Assert.IsTrue(item.Employee.EmployeeTerritories.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));
      }

      [Test]
      public void Can_Include_One_In_Many() {

         var set = db.Table<Include.Model1.Employee>()
            .IncludeMany(p => p.EmployeeTerritories, q => q.Territory);

         var item = set.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => p.Territory != null));
      }

      [Test]
      public void Cannot_Include_Many_In_Many() {

         Assert.Throws<ArgumentException>(() => db.Table<Include.Model1.Employee>()
            .IncludeMany("Orders.OrderDetails"));
      }
   }

   namespace Include.Model1 {

      [Table(Name = "Products")]
      class Product {

         [Column(IsPrimaryKey = true)]
         public int ProductID { get; set; }

         [Column]
         public int? CategoryID { get; set; }

         [Column]
         public int? SupplierID { get; set; }

         [Association(ThisKey = nameof(CategoryID))]
         public Category Category { get; set; }

         [Association(ThisKey = nameof(SupplierID))]
         public Supplier Supplier { get; set; }
      }

      [Table(Name = "Categories")]
      class Category {

         [Column(IsPrimaryKey = true)]
         public int CategoryID { get; set; }

         [Column]
         public string CategoryName { get; set; }

         [Association(OtherKey = nameof(Product.CategoryID))]
         public Collection<Product> Products { get; private set; }
      }

      [Table(Name = "Suppliers")]
      class Supplier {

         [Column(IsPrimaryKey = true)]
         public int SupplierID { get; set; }

         [Column]
         public string CompanyName { get; set; }
      }

      [Table(Name = "Employees")]
      class Employee {

         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int EmployeeID { get; set; }

         [Column]
         public string LastName { get; set; }

         [Column]
         public string FirstName { get; set; }

         [Association(OtherKey = nameof(EmployeeTerritory.EmployeeID))]
         public Collection<EmployeeTerritory> EmployeeTerritories { get; private set; }

         [Association(OtherKey = nameof(EmployeeTerritory.EmployeeID))]
         public Collection<Order> Orders { get; private set; }
      }

      [Table(Name = "EmployeeTerritories")]
      class EmployeeTerritory {

         [Column(IsPrimaryKey = true)]
         public int EmployeeID { get; set; }

         [Column(IsPrimaryKey = true)]
         public string TerritoryID { get; set; }

         [Association(ThisKey = nameof(EmployeeID))]
         public Employee Employee { get; set; }

         [Association(ThisKey = nameof(TerritoryID))]
         public Territory Territory { get; set; }
      }

      [Table(Name = "Territories")]
      class Territory {

         [Column(IsPrimaryKey = true)]
         public string TerritoryID { get; set; }

         [Column]
         public string TerritoryDescription { get; set; }

         [Column]
         public int RegionID { get; set; }

         [Association(ThisKey = nameof(RegionID))]
         public Region Region { get; set; }
      }

      [Table]
      class Region {

         [Column(IsPrimaryKey = true)]
         public int RegionID { get; set; }

         [Column]
         public string RegionDescription { get; set; }
      }

      [Table(Name = "Orders")]
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

      [Table(Name = "Order Details")]
      class OrderDetail {

         [Column(IsPrimaryKey = true)]
         public int OrderID { get; set; }

         [Column(IsPrimaryKey = true)]
         public int ProductID { get; set; }

         [Association(ThisKey = nameof(OrderID))]
         public Order Order { get; set; }

         [Association(ThisKey = nameof(ProductID))]
         public Product Product { get; set; }
      }
   }

   namespace Include.Model2 {

      [Table(Name = "EmployeeTerritories")]
      class EmployeeTerritory {

         [Column(IsPrimaryKey = true)]
         public int EmployeeID { get; set; }

         [Column(Name = "TerritoryID", IsPrimaryKey = true)]
         public string Territory_ID { get; set; }

         [Association(ThisKey = nameof(Territory_ID))]
         public Territory Territory { get; set; }
      }

      [Table(Name = "Territories")]
      class Territory {

         [Column(IsPrimaryKey = true)]
         public string TerritoryID { get; set; }

         [Column]
         public string TerritoryDescription { get; set; }

         [Column(Name = "RegionID")]
         public int Region_ID { get; set; }

         [Association(ThisKey = nameof(Region_ID))]
         public Region Region { get; set; }
      }

      [Table]
      class Region {

         [Column(IsPrimaryKey = true)]
         public int RegionID { get; set; }

         [Column]
         public string RegionDescription { get; set; }
      }
   }
}
