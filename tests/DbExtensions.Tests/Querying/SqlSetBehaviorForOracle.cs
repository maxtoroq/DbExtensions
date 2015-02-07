using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlSetBehaviorForOracle {

      readonly Database db = new Database(Database.GetProviderFactory("System.Data.OracleClient").CreateConnection());

      [TestMethod]
      public void Where_Take_Select() {

         SqlSet set = db.From("products")
            .Where("UnitsInStock > 0")
            .Take(5)
            .Select("ProductName");

         SqlBuilder expected = SQL
            .SELECT("ProductName")
            .FROM(SQL
               .SELECT("ROWNUM AS dbex_rn, __rn.*")
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
