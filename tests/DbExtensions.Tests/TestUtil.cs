using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace DbExtensions.Tests {

   static class TestUtil {

      static bool IsAppVeyor = Environment.GetEnvironmentVariable("APPVEYOR") == "True";

      public static Database MySqlDatabase() {

         DbConnection conn = MySqlClientFactory.Instance.CreateConnection();

         return new Database(conn);
      }

      public static Database SqlServerDatabase() {

         var builder = new SqlConnectionStringBuilder();
         builder.DataSource = @"(localdb)\mssqllocaldb";

         if (IsAppVeyor) {
            builder.DataSource = @"(local)\sql2012sp1";
            builder.UserID = "sa";
            builder.Password = "Password12!";
         }

         DbConnection conn = SqlClientFactory.Instance.CreateConnection();
         conn.ConnectionString = builder.ToString();

         return new Database(conn);
      }

      public static DbConnection SqlServerNorthwindConnection() {

         var builder = new SqlConnectionStringBuilder();
         builder.DataSource = @"(localdb)\mssqllocaldb";
         builder.AttachDBFilename = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\samples\App\bin\Debug\Northwind\Northwind.mdf"));
         builder.IntegratedSecurity = true;
         builder.MultipleActiveResultSets = true;

         if (IsAppVeyor) {
            builder.DataSource = @"(local)\sql2012sp1";
            builder.UserID = "sa";
            builder.Password = "Password12!";
         }

         DbConnection conn = SqlClientFactory.Instance.CreateConnection();
         conn.ConnectionString = builder.ToString();

         return conn;
      }

      public static Database SqlServerNorthwindDatabase() {
         return new Database(SqlServerNorthwindConnection());
      }

      public static bool SqlEquals(SqlSet set, SqlBuilder query) {
         return String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
      }
   }
}
