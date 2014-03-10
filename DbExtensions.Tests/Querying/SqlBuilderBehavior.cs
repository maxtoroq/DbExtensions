using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlBuilderBehavior {

      [TestMethod]
      public void Multiple_Parameters() {

         var query = SQL
            .SELECT("{0}, {1}", 1, 2);

         Assert.AreEqual("SELECT {0}, {1}", query.ToString());
         Assert.AreEqual(2, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Expand_Array_Parameter_To_List() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0})", new object[] { new int[] { 1, 2, 3 } });

         Assert.IsTrue(query.ToString().Contains("{2}"));
      }

      [TestMethod]
      public void Adjust_Other_Placeholders_When_Using_Array_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0}) AND c <> {1}", new object[] { new int[] { 1, 2, 3 }, 4 });

         Assert.IsTrue(query.ToString().Contains("{3}"));
         Assert.AreEqual(4, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Workaround_Array_Parameter_Expansion() {

         var query = SQL
            .UPDATE("images")
            .SET("content = {0}", SQL.Param(new byte[] { 1, 2, 3 }));

         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.IsInstanceOfType(query.ParameterValues[0], typeof(byte[]));
      }

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
   }
}
