using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DbExtensions.Tests.Querying {

   using static TestUtil;

   [TestFixture]
   public class SqlSetAsyncBehavior {

      [Test]
      public void AsAsyncEnumerable_Reference_Type() {

         var data = new Dictionary<string, object> {
            { "a", "a" }
         };

         var db = MockQuery(data);

         SqlSet<string> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetString(0));

         set.AsAsyncEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsAsyncEnumerable();
      }

      [Test]
      public void AsAsyncEnumerable_Value_Type() {

         var data = new Dictionary<string, object> {
            { "0", 0 }
         };

         var db = MockQuery(data);

         SqlSet<int> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetInt32(0));

         set.AsAsyncEnumerable();

         SqlSet untypedSet = set;

         untypedSet.AsAsyncEnumerable();
      }

      [Test]
      public async Task Async_Enumerate() {

         var data = new Dictionary<string, object> {
            { "a", "a" }
         };

         var db = MockQuery(data);

         SqlSet<string> set = db.From(SQL
            .SELECT("NULL")
            , r => r.GetString(0));

         var results = new List<string>();

         await foreach (var item in set.AsAsyncEnumerable()) {
            results.Add(item);
         }

         Assert.AreEqual(1, results.Count);
         Assert.AreEqual(data["a"], results[0]);
      }
   }
}
