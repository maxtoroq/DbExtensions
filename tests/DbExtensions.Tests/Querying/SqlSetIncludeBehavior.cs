using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlSetIncludeBehavior {

      readonly Database db = SqlServerNorthwindDatabase();

      [TestMethod]
      public void Can_Include_One() {

         SqlSet<SqlSetInclude.Product> set = db.Table<SqlSetInclude.Product>()
            .Where("NOT CategoryID IS NULL AND NOT SupplierID IS NULL")
            .Include("Category")
            .Include("Supplier");

         SqlSetInclude.Product item = set.First();

         Assert.IsNotNull(item.Category);
         Assert.IsNotNull(item.Supplier);
      }

      [TestMethod]
      public void Can_Include_One_Nested() {

         SqlSet<SqlSetInclude.EmployeeTerritory> set = db.Table<SqlSetInclude.EmployeeTerritory>()
            .Include("Territory.Region");

         SqlSetInclude.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Territory);
         Assert.IsNotNull(item.Territory.Region);
      }

      [TestMethod]
      public void Can_Include_Many() {

         SqlSet<SqlSetInclude.Category> set = db.Table<SqlSetInclude.Category>()
            .Include("Products");

         SqlSetInclude.Category item = set.First();

         Assert.IsNotNull(item.Products);
         Assert.AreNotEqual(0, item.Products.Count);
         Assert.IsTrue(item.Products.All(p => Object.ReferenceEquals(p.Category, item)));
      }

      [TestMethod]
      public void Can_Include_Many_Multiple() {

         SqlSet<SqlSetInclude.Employee> set1 = db.Table<SqlSetInclude.Employee>()
            .Include("EmployeeTerritories");

         SqlSet<SqlSetInclude.Employee> set2 = set1.Include("Orders");

         SqlSetInclude.Employee item = set1.First();

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

      [TestMethod]
      public void Can_Include_Many_In_One() {

         SqlSet<SqlSetInclude.EmployeeTerritory> set = db.Table<SqlSetInclude.EmployeeTerritory>()
            .Include("Employee.Orders");

         SqlSetInclude.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Employee);
         Assert.AreNotEqual(0, item.Employee.Orders.Count);
         Assert.IsTrue(item.Employee.Orders.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));
      }

      [TestMethod]
      public void Can_Include_One_In_Many() {

         SqlSet<SqlSetInclude.Employee> set = db.Table<SqlSetInclude.Employee>()
            .Include("EmployeeTerritories.Territory");

         SqlSetInclude.Employee item = set.First();

         Assert.IsNotNull(item.EmployeeTerritories);
         Assert.AreNotEqual(0, item.EmployeeTerritories.Count);
         Assert.IsTrue(item.EmployeeTerritories.All(p => p.Territory != null));
      }

      [TestMethod, ExpectedException(typeof(ArgumentException))]
      public void Cannot_Include_Many_In_Many() {

         SqlSet<SqlSetInclude.Employee> set = db.Table<SqlSetInclude.Employee>()
            .Include("Orders.OrderDetails");

         SqlSetInclude.Employee item = set.First();
      }
   }

   namespace SqlSetInclude {

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
