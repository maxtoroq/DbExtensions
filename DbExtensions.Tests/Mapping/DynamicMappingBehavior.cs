using System;
using System.Data.Common;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Mapping {
   
   [TestClass]
   public class DynamicMappingBehavior {

      readonly DbConnection conn = System.Data.SqlClient.SqlClientFactory.Instance
         .CreateSqlServerConnectionForTests();

      [TestMethod, ExpectedException(typeof(ArgumentException))]
      public void Constructor_Parameters_Not_Allowed() {

         var value = conn.Map(SQL
            .SELECT("'foo' AS '1'"))
            .Single();
      }
   }
}
