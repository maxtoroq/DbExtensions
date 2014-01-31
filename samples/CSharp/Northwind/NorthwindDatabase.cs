using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using DbExtensions;

namespace Samples.CSharp.Northwind {
   
   public class NorthwindDatabase : Database {

      public SqlTable<Product> Products {
         get { return Table<Product>(); }
      }

      public SqlTable<Order> Orders {
         get { return Table<Order>(); }
      }

      public SqlTable<OrderDetail> OrderDetails {
         get { return Table<OrderDetail>(); }
      }

      public NorthwindDatabase(string connectionString) 
         : base(connectionString) { }

      public NorthwindDatabase(string connectionString, MetaModel mapping)
         : base(connectionString, mapping) { }
   }
}
