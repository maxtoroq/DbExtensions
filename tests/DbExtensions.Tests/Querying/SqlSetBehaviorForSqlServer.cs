using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlSetBehaviorForSqlServer {

      readonly Database db = new Database(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests());

      [TestMethod]
      public void Use_Parameter_On_Skip() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Use_Parameter_On_Skip_And_Take() {

         var query = db.From(SQL.SELECT("1"))
            .Skip(1)
            .Take(1)
            .GetDefiningQuery();

         Assert.AreEqual(2, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Pagination_Sql2008() {

         Database db = new SqlSetForSqlServer.Sql2008Database();

         SqlSet set = db.From("products")
            .Where("UnitsInStock > 0")
            .OrderBy("ProductID")
            .Skip(0)
            .Take(5)
            .Select("ProductName");

         SqlBuilder expected = SQL
            .SELECT("ProductName")
            .FROM(SQL
               .SELECT("ROW_NUMBER() OVER (ORDER BY ProductID) AS dbex_rn, __rn.*")
               .FROM(SQL
                  .SELECT("*")
                  .FROM("products"), "__rn")
               .WHERE("UnitsInStock > 0"), "_")
            .WHERE("dbex_rn BETWEEN {0} AND {1}", 1, 5)
            .ORDER_BY("dbex_rn");

         Assert.IsTrue(SqlEquals(set, expected));
      }

      bool SqlEquals(SqlSet set, SqlBuilder query) {
         return TestUtil.SqlEquals(set, query);
      }
   }
}

namespace DbExtensions.Tests.Querying.SqlSetForSqlServer {
   using System.Data.Linq.Mapping;
   using System.Data.Linq.SqlClient;

   [Provider(typeof(Sql2008Provider))]
   class Sql2008Database : Database {

      public Sql2008Database()
         : base(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests()) { }
   }
}