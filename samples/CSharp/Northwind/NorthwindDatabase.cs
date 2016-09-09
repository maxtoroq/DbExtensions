using System;
using System.Data.Common;
using System.Data.Linq.Mapping;
using DbExtensions;

namespace Samples.CSharp.Northwind {

   public class NorthwindDatabase : Database {

      public SqlTable<Product> Products => Table<Product>();

      public SqlTable<Order> Orders => Table<Order>();

      public SqlTable<OrderDetail> OrderDetails => Table<OrderDetail>();

      public SqlTable<Employee> Employees => Table<Employee>();

      public SqlTable<EmployeeTerritory> EmployeeTerritories => Table<EmployeeTerritory>();

      public SqlTable<Region> Regions => Table<Region>();

      public NorthwindDatabase(DbConnection connection)
         : base(connection) { }

      public NorthwindDatabase(DbConnection connection, MetaModel mapping)
         : base(connection, mapping) { }
   }
}
