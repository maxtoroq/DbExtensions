using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying.SqlBuilderBehavior {

   [TestFixture]
   public class ExtensibilityTests {

      [Test]
      public void Extension_Clause() {

         var query = ((SqlBuilder)$"""
            SELECT ProductID, ProductName
            FROM Products
            OFFSET {10} ROWS
            """)
            .FETCH($"NEXT {5} ROWS ONLY");

         Assert.AreEqual(new StringBuilder("""
            SELECT ProductID, ProductName
            FROM Products
            OFFSET {0} ROWS
            """)
            .AppendLine()
            .Append("FETCH NEXT {1} ROWS ONLY")
            .ToString()
            , query.ToString());

         Assert.IsTrue(query.CurrentClause is SqlBuilderExtensions.FetchClause);
      }
   }

   public static class SqlBuilderExtensions {

      public sealed record class FetchClause() : SqlClause("FETCH", null);

      public static SqlBuilder FETCH(this SqlBuilder sql, [InterpolatedStringHandlerArgument(nameof(sql))] ref SqlBuilder.ClauseStringHandler<FetchClause> handler) {
         return sql;
      }

      public static SqlBuilder FETCH(this SqlBuilder sql, string text) {
         return sql.AppendClause<FetchClause>()
            .Append(text);
      }
   }
}
