using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using DbExtensions;

namespace Samples.CSharp.Northwind {
   
   public class NorthwindContext : DataAccessObject {

      public SqlTable<Product> Products {
         get { return Set<Product>(); }
      }

      public SqlTable<Order> Orders {
         get { return Set<Order>(); }
      }

      public NorthwindContext(string connString, MetaModel mapping) 
         : base(connString, mapping) { }
   }
}
