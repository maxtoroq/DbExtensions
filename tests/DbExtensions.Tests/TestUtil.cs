using System;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace DbExtensions.Tests {

   static class TestUtil {

      public static Database MySqlDatabase() {

         DbConnection conn = MySql.Data.MySqlClient.MySqlClientFactory.Instance.CreateConnection();

         return new Database(conn);
      }

      public static Database SqlServerDatabase() {

         DbConnection conn = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection();
         conn.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;";

         return new Database(conn);
      }

      public static Database SqlServerNorthwindDatabase() {

         DbConnection conn = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection();
         conn.ConnectionString = $@"Data Source=(localdb)\mssqllocaldb; AttachDbFileName={Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\samples\App\bin\Debug\Northwind\Northwind.mdf"))}; Integrated Security=true; MultipleActiveResultSets=true";

         return new Database(conn);
      }

      public static bool SqlEquals(SqlSet set, SqlBuilder query) {
         return String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
      }
   }
}
