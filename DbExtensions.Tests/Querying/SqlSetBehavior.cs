using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlSetBehavior {

      DbConnection conn;

      [TestInitialize]
      public void Initialize() {

         this.conn = Database.GetProviderFactory("System.Data.SqlClient")
            .CreateConnection(@"Data Source=(localdb)\v11.0;");
      }

      [TestMethod]
      public void AsEnumerableReferenceType() {

         SqlSet<string> set = conn.Set(SQL
            .SELECT("'a'")
            , r => r.GetString(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }

      [TestMethod]
      public void AsEnumerableValueType() {

         SqlSet<int> set = conn.Set(SQL
            .SELECT("0")
            , r => r.GetInt32(0));

         set.AsEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsEnumerable();
      }
   }
}
