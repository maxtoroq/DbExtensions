using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbExtensions.Tests {
   
   static class TestUtil {

      public static DbConnection CreateSqlServerConnectionForTests(this DbProviderFactory factory) {
         return factory.CreateConnection(@"Data Source=(localdb)\v11.0;");
      }

      public static DbConnection CreateSqlServerConnectionForTests_Northwind(this DbProviderFactory factory) {
         return factory.CreateConnection(@"Data Source=(localdb)\v11.0; AttachDbFileName="+ Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\samples\App\bin\Debug\Northwind\Northwind.mdf")) + "; Integrated Security=true");
      }

      public static bool SqlEquals(SqlSet set, SqlBuilder query) {
         return String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
      }
   }
}
