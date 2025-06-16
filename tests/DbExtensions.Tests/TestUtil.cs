using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using Moq;

namespace DbExtensions.Tests {

   static class TestUtil {

      public static Database MockDatabase(string providerInvariantName = "MySql.Data.MySqlClient") {
         return MockDatabaseImpl(providerInvariantName).Object;
      }

      static Mock<Database> MockDatabaseImpl(string providerInvariantName) {

         var mockConn = new Mock<IDbConnection>();

         var mockDb = new Mock<Database>(mockConn.Object, providerInvariantName) {
            CallBase = true
         };

         return mockDb;
      }

      public static Database MockQuery(params IEnumerable<KeyValuePair<string, object>>[] data) {

         var mockReader = new Mock<IDataReader>();
         var readSetup = mockReader.SetupSequence(m => m.Read());

         for (int i = 0; i < data.Length; i++) {

            if (i == 0) {
               readSetup.Returns(true);
            }

            var j = -1;

            foreach (var cell in data[i]) {

               j++;

               mockReader.Setup(m => m.GetName(j)).Returns(cell.Key);
               mockReader.Setup(m => m.GetValue(j)).Returns(cell.Value);
               mockReader.Setup(m => m.IsDBNull(j)).Returns(cell.Value == null);
            }

            if (i == 0) {
               mockReader.Setup(m => m.FieldCount).Returns(j + 1);
            }
         }

         readSetup.Returns(false);

         var mockConn = new Mock<IDbConnection>();

         var mockDb = MockDatabaseImpl("MySql.Data.MySqlClient");

         mockDb.Setup(db => db.CreateCommand(It.IsAny<string>(), It.IsAny<object[]>()))
            .Returns(() => {
               var command = new Mock<IDbCommand>();
               command.SetupProperty(cmd => cmd.Connection, mockConn.Object);
               command.Setup(cmd => cmd.ExecuteReader())
                  .Returns(() => mockReader.Object);
               return command.Object;
            });

         return mockDb.Object;
      }

      public static Database RealDatabase() {

         var builder = new SQLiteConnectionStringBuilder {
            DataSource = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\samples\App\bin\Debug\net472\Northwind\Northwind.sl3")),
            FailIfMissing = true
         };

         var conn = new SQLiteConnection(builder.ToString());

         var db = new Database(conn);
         db.Configuration.Log = Console.Out;

         return db;
      }

      public static bool SqlEquals(SqlSet set, SqlBuilder query) {
         return String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
      }
   }
}
