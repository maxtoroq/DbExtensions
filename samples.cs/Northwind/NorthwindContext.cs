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

      public NorthwindDatabase(string connString, MetaModel mapping) 
         : base(connString, mapping) { }
   }
}
