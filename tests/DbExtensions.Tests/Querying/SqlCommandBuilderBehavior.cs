using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExtensions.Tests.Querying {
   using WorkaroundArrayParameterExpansion = SqlCommandBuilder.WorkaroundArrayParameterExpansion;
   
   [TestClass]
   public class SqlCommandBuilderBehavior {

      [TestMethod]
      public void Workaround_Array_Parameter_Expansion_INSERT_INTO_VALUES() {

         var db = new WorkaroundArrayParameterExpansion.MyDatabase();

         var entity = new WorkaroundArrayParameterExpansion.Product { 
            Id = 1, 
            Image = new byte[] { 1, 2, 3 } 
         };

         var query = db.Products.SQL
            .INSERT_INTO_VALUES(entity);

         Assert.AreEqual(1, query.ParameterValues.Count);
      }

      [TestMethod]
      public void Workaround_Array_Parameter_Expansion_UPDATE_SET_WHERE() {

         var db = new WorkaroundArrayParameterExpansion.MyDatabase();

         var entity = new WorkaroundArrayParameterExpansion.Product {
            Id = 1,
            Image = new byte[] { 1, 2, 3 }
         };

         var query = db.Products.SQL
            .UPDATE_SET_WHERE(entity);

         Assert.AreEqual(2, query.ParameterValues.Count);
      }
   }
}

namespace DbExtensions.Tests.Querying.SqlCommandBuilder.WorkaroundArrayParameterExpansion {

   class MyDatabase : Database {

      public SqlTable<Product> Products {
         get { return Table<Product>(); }
      }

      public MyDatabase() 
         : base(System.Data.SqlClient.SqlClientFactory.Instance.CreateSqlServerConnectionForTests()) { }
   }

   [Table]
   class Product {

      [Column(IsPrimaryKey = true, IsDbGenerated = true)]
      public int Id { get; set; }

      [Column(UpdateCheck = UpdateCheck.Never)]
      public byte[] Image { get; set; }
   }
}