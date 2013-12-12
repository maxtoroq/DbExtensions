using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace DbExtensions.Tests.Querying {

   [TestClass]
   public class SqlBuilderBehavior {
      DbConnection conn;

      [TestInitialize]
      public void Initialize() {

         this.conn = Database.GetProviderFactory("System.Data.SqlClient")
            .CreateConnection();
      }

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
      public void VerifySingleValue() {
         int id = 1;

         var query = SQL
             .SELECT("*")
             .WHERE("VALUE = {0}", id);

         Assert.AreEqual(1, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p0"));
         Assert.IsFalse(cmd.CommandText.Contains("@p1"));
      }

      [TestMethod]
      public void VerifySingleValue2() {
         var query = SQL
             .SELECT("*")
             .WHERE("VALUE = {0}", 1);

         Assert.AreEqual(1, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p0"));
         Assert.IsFalse(cmd.CommandText.Contains("@p1"));
      }

      [TestMethod]
      public void VerifyArrayToList() {
         int[] ids = { 1, 2, 3 };

         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", ids);

         Assert.AreEqual(3, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));
      }

      [TestMethod]
      public void VerifyArrayToList2() {
         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", 1, 2, 3);

         Assert.AreEqual(3, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));
      }

      [TestMethod]
      public void VerifyStringArrayToList() {
         string[] ids = { "a", "b", "c" };

         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", ids);

         Assert.AreEqual(3, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));
      }

      [TestMethod]
      public void VerifySinglePlusArrayToListIsBroken() {
         int[] ids = { 1, 2, 3 };

         var query = SQL
             .SELECT("*")
             .WHERE("X = {0} OR VALUE IN ({0})", 1, ids);

         // TODO fix when SqlBuilder supports dealing with mix of array and non-array
         // HACK this "test" will start to fail when SqlBuilder gets fixed
         Assert.IsFalse(query.ToString().Contains("WHERE X = {0} OR VALUE IN ({1}, {2}, {3})"));

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p3"));
      }

      [TestMethod]
      public void VerifyStringArrayToList2() {
         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", "a", "b", "c");

         Assert.AreEqual(3, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));
      }
   }
}
