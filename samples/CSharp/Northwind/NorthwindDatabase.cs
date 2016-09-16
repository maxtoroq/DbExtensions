using System;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   public class NorthwindDatabase : Database {

      public SqlTable<Product> Products => Table<Product>();

      public SqlTable<Order> Orders => Table<Order>();

      public SqlTable<OrderDetail> OrderDetails => Table<OrderDetail>();

      public SqlTable<Employee> Employees => Table<Employee>();

      public SqlTable<EmployeeTerritory> EmployeeTerritories => Table<EmployeeTerritory>();

      public SqlTable<Region> Regions => Table<Region>();

      public NorthwindDatabase(string connectionString, string providerInvariantName)
         : base(connectionString, providerInvariantName) { }
   }
}
