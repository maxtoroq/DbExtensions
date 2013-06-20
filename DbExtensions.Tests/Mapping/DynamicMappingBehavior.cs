using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Mapping {
   
   [TestClass]
   public class DynamicMappingBehavior {

      DbConnection conn;

      [TestInitialize]
      public void Initialize() {

         this.conn = Database.GetProviderFactory("System.Data.SqlClient")
            .CreateConnection(@"Data Source=(localdb)\v11.0;");
      }

      [TestMethod, ExpectedException(typeof(ArgumentException))]
      public void Constructor_Parameters_Not_Allowed() {

         var value = conn.Map(SQL
            .SELECT("'foo' AS '1'"))
            .Single();
      }
   }
}
