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

         SqlSet<Include.Product> set = db.Table<Include.Product>()
            .Where("NOT CategoryID IS NULL AND NOT SupplierID IS NULL")
            .Include("Category")
            .Include("Supplier");

         Include.Product item = set.First();

         Assert.IsNotNull(item.Category);
         Assert.IsNotNull(item.Supplier);
      }

      [Test]
      public void Can_Include_One_Nested() {

         SqlSet<Include.EmployeeTerritory> set = db.Table<Include.EmployeeTerritory>()
            .Include("Territory.Region");

         Include.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Territory);
         Assert.IsNotNull(item.Territory.Region);
      }

      [Test]
      public void Can_Include_Many() {

         SqlSet<Include.Category> set = db.Table<Include.Category>()
            .Include("Products");

         Include.Category item = set.First();

         Assert.IsNotNull(item.Products);
         Assert.AreNotEqual(0, item.Products.Count);
         Assert.IsTrue(item.Products.All(p => Object.ReferenceEquals(p.Category, item)));
      }

      [Test]
      public void Can_Include_Many_Multiple() {

         SqlSet<Include.Employee> set1 = db.Table<Include.Employee>()
            .Include("EmployeeTerritories");

         SqlSet<Include.Employee> set2 = set1.Include("Orders");

         Include.Employee item = set1.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => Object.ReferenceEquals(p.Employee, item)));

         // test immutability
         Assert.IsTrue(item.Orders == null || item.Orders.Count == 0);

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

         SqlSet<Include.EmployeeTerritory> set = db.Table<Include.EmployeeTerritory>()
            .Include("Employee.Orders");

         Include.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Employee);
         Assert.AreNotEqual(0, item.Employee.Orders.Count);
         Assert.IsTrue(item.Employee.Orders.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));
      }

      [Test]
      public void Can_Include_One_In_Many() {

         SqlSet<Include.Employee> set = db.Table<Include.Employee>()
            .Include("EmployeeTerritories.Territory");

         Include.Employee item = set.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => p.Territory != null));
      }

      [Test]
      public void Cannot_Include_Many_In_Many() {

         Assert.Throws<ArgumentException>(() => db.Table<Include.Employee>()
            .Include("Orders.OrderDetails"));
      }
   }

   namespace Include {

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
}
