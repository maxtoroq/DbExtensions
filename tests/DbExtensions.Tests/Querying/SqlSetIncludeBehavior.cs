using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   [TestClass]
   public class SqlSetIncludeBehavior {

      [TestMethod]
      public void Can_Include_One() {

         var db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests_Northwind(), new AttributeMappingSource().GetModel(typeof(SqlSetInclude.Product)));

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

         var db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests_Northwind(), new AttributeMappingSource().GetModel(typeof(SqlSetInclude.Product)));

         SqlSet<SqlSetInclude.EmployeeTerritory> set = db.Table<SqlSetInclude.EmployeeTerritory>()
            .Include("Territory.Region");

         SqlSetInclude.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Territory);
         Assert.IsNotNull(item.Territory.Region);
      }

      [TestMethod]
      public void Can_Include_Many() {

         var db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests_Northwind(), new AttributeMappingSource().GetModel(typeof(SqlSetInclude.Product)));

         SqlSet<SqlSetInclude.Category> set = db.Table<SqlSetInclude.Category>()
            .Include("Products");

         SqlSetInclude.Category item = set.First();

         Assert.IsNotNull(item.Products);
         Assert.AreNotEqual(0, item.Products.Count);
         Assert.IsTrue(item.Products.All(p => Object.ReferenceEquals(p.Category, item)));
      }

      [TestMethod]
      public void Can_Include_Many_Multiple() {

         var db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests_Northwind(), new AttributeMappingSource().GetModel(typeof(SqlSetInclude.Product)));

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
         //Assert.IsTrue(item.Orders.All(p => Object.ReferenceEquals(p.Employee, item)));
      }

      [TestMethod]
      public void Can_Include_Many_In_One() {

         var db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests_Northwind(), new AttributeMappingSource().GetModel(typeof(SqlSetInclude.Product)));

         SqlSet<SqlSetInclude.EmployeeTerritory> set = db.Table<SqlSetInclude.EmployeeTerritory>()
            .Include("Employee.Orders");

         SqlSetInclude.EmployeeTerritory item = set.First();

         Assert.IsNotNull(item.Employee);
         Assert.AreNotEqual(0, item.Employee.Orders.Count);
         //Assert.IsTrue(item.Employee.Orders.All(p => Object.ReferenceEquals(p.Employee, item.Employee)));
      }
   }
}

namespace DbExtensions.Tests.Querying.SqlSetInclude {

   [Table(Name = "Products")]
   class Product {

      [Column(IsPrimaryKey = true)]
      public int ProductID { get; set; }

      [Column]
      public int? CategoryID { get; set; }

      [Column]
      public int? SupplierID { get; set; }

      [Association(ThisKey = "CategoryID", IsForeignKey = true)]
      public Category Category { get; set; }

      [Association(ThisKey = "SupplierID", IsForeignKey = true)]
      public Supplier Supplier { get; set; }
   }

   [Table(Name = "Categories")]
   class Category {

      [Column(IsPrimaryKey = true)]
      public int CategoryID { get; set; }

      [Column]
      public string CategoryName { get; set; }

      [Association(OtherKey = "CategoryID")]
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

      [Association(OtherKey = "EmployeeID")]
      public Collection<EmployeeTerritory> EmployeeTerritories { get; private set; }

      [Association(OtherKey = "EmployeeID")]
      public Collection<Order> Orders { get; private set; }
   }

   [Table(Name = "EmployeeTerritories")]
   class EmployeeTerritory {

      [Column(IsPrimaryKey = true)]
      public int EmployeeID { get; set; }

      [Column(CanBeNull = false, IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Association(ThisKey = "EmployeeID", IsForeignKey = true)]
      public Employee Employee { get; set; }

      [Association(ThisKey = "TerritoryID", IsForeignKey = true)]
      public Territory Territory { get; set; }
   }

   [Table(Name = "Territories")]
   class Territory {

      [Column(CanBeNull = false, IsPrimaryKey = true)]
      public string TerritoryID { get; set; }

      [Column(CanBeNull = false)]
      public string TerritoryDescription { get; set; }

      [Column]
      public int RegionID { get; set; }

      [Association(ThisKey = "RegionID", IsForeignKey = true)]
      public Region Region { get; set; }
   }

   [Table(Name = "Region")]
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

      [Association(OtherKey = "OrderID")]
      public Collection<OrderDetail> OrderDetails { get; private set; }

      [Association(ThisKey = "EmployeeID", IsForeignKey = true)]
      public Employee Employee { get; set; }
   }

   [Table(Name = "Order Details")]
   class OrderDetail {

      [Column(IsPrimaryKey = true)]
      public int OrderID { get; set; }

      [Column(IsPrimaryKey = true)]
      public int ProductID { get; set; }

      [Association(ThisKey = "OrderID", IsForeignKey = true)]
      public Order Order { get; set; }

      [Association(ThisKey = "ProductID", IsForeignKey = true)]
      public Product Product { get; set; }
   }
}