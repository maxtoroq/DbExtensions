using System;
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
      public void Expand_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0})", SQL.List(1, 2, 3));

         Assert.IsTrue(query.ToString().Contains("{2}"));
      }

      [TestMethod]
      public void Adjust_Other_Placeholders_When_Using_List_Parameter() {

         var query = SQL
            .SELECT("*")
            .WHERE("c IN ({0}) AND c <> {1}", SQL.List(1, 2, 3), 4);

         Assert.IsTrue(query.ToString().Contains("{3}"));
         Assert.AreEqual(4, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Allow_Empty_List() {

         var query = SQL
            .SELECT("1 IN ({0})", SQL.List());

         Assert.AreEqual("SELECT 1 IN ({0})", query.ToString());
         Assert.AreEqual(1, query.ParameterValues.Count);
         Assert.AreEqual(null, query.ParameterValues[0]);
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
