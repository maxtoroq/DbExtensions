using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlSetBehaviorForSqlServer {

      DbConnection conn;

      [TestInitialize]
      public void Initialize() {

         this.conn = Database.GetProviderFactory("System.Data.SqlClient")
            .CreateConnection();
      }

      [TestMethod]
      public void Use_Parameter_On_Skip() {

         var query = conn.Set(SQL.SELECT("1"))
            .Skip(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Take() {

         var query = conn.Set(SQL.SELECT("1"))
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Skip_And_Take() {

         var query = conn.Set(SQL.SELECT("1"))
            .Skip(1)
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(2, query.ParameterValues.Count);
      }
   }
}
