using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   
   [TestClass]
   public class SqlTableBehavior {

      DbConnection MySqlConnection() {

         return MySql.Data.MySqlClient.MySqlClientFactory.Instance
            .CreateConnection();
      }

      [TestMethod]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

         var db = new Database(MySqlConnection(), new AttributeMappingSource().GetModel(typeof(SqlTable.Product)));

         SqlSet set = db.Table<SqlTable.Product>()
            .Where("UnitsInStock > 0")
            .Skip(0)
            .Take(5);

         SqlBuilder expected = SQL
            .SELECT(db.QuoteIdentifier("Id"))
            .FROM(db.QuoteIdentifier("Product"))
            .WHERE("UnitsInStock > 0")
            .LIMIT(5)
            .OFFSET(0);

         Assert.IsTrue(SqlEquals(set, expected));
      }

      bool SqlEquals(SqlSet set, SqlBuilder query) {
         return TestUtil.SqlEquals(set, query);
      }
   }
}

namespace DbExtensions.Tests.Querying.SqlTable {

   [Table]
   class Product {

      [Column]
      public int Id { get; set; }
   }
}