using System;
using System.Data.Linq.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestClass]
   public class SqlTableBehavior {

      readonly Database db = MySqlDatabase(new AttributeMappingSource().GetModel(typeof(SqlTable.Product)));

      [TestMethod]
      public void Dont_Use_Subqueries_When_Methods_Are_Called_In_Order() {

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
   }

   namespace SqlTable {

      [Table]
      class Product {

         [Column]
         public int Id { get; set; }
      }
   }
}
