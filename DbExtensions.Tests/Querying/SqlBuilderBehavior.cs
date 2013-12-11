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
      public void VerifyStringArrayToList2() {
         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", "a", "b", "c");

         Assert.AreEqual(3, query.ParameterValues.Count);

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));
      }

      [TestMethod]
      public void VerifyStringListToList2() {
         var ids = new List<string> { "a", "b", "c" };

         var query = SQL
             .SELECT("*")
             .WHERE("VALUE IN ({0})", ids.ToArray());

         var cmd = query.ToCommand(conn);
         Assert.IsTrue(cmd.CommandText.Contains("@p2"));

         Assert.AreEqual(3, query.ParameterValues.Count);
      }
   }
}
