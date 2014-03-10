using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbExtensions.Tests {
   
   static class TestUtil {

      public static DbConnection CreateSqlServerConnectionForTests(this DbProviderFactory factory) {
         return factory.CreateConnection(@"Data Source=(localdb)\v11.0;");
      }

      public static bool SqlEquals(SqlSet set, SqlBuilder query) {
         return String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
      }
   }
}
