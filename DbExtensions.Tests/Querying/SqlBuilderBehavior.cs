using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlBuilderBehavior {

      [TestMethod]
      public void Use_Parameter_On_Limit_Clause() {

         var query = SQL
            .SELECT("*")
            .LIMIT(1);

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Offset_Clause() {

         var query = SQL
            .SELECT("*")
            .OFFSET(1);

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void VerifyArrayToList()
      {
          var query = SQL
              .SELECT("*")
              .WHERE("VALUE IN ({0})", new object[] { "a", "b", "c" });

          Assert.AreEqual(3, query.ParameterValues.Count);
      }
   }
}
