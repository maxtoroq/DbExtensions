using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Moq;
using Moq.Protected;

namespace DbExtensions.Tests;

static class TestUtil {

   public static Database
   MockDatabase(string providerInvariantName = "MySql.Data.MySqlClient") =>
      MockDatabaseImpl(providerInvariantName).Object;

   static Mock<Database>
   MockDatabaseImpl(string providerInvariantName) {

      var mockConn = new Mock<DbConnection>();

      var mockDb = new Mock<Database>(mockConn.Object, providerInvariantName) {
         CallBase = true
      };

      return mockDb;
   }

   public static Database
   MockQuery(params IEnumerable<KeyValuePair<string, object>>[] data) {

      var reader = new TestDataReader(data
         .Select(p => p as KeyValuePair<string, object>[]
            ?? p.ToArray())
         .ToArray());

      var mockDb = MockDatabaseImpl("MySql.Data.MySqlClient");

      SetupReader(mockDb, reader);

      return mockDb.Object;
   }

   public static void
   SetupReader(Mock<Database> mockDb, DbDataReader reader, string commandText = null) {

      mockDb.Setup(db => db.CreateCommand(It.IsAny<SqlBuilder>()))
         .Returns(() => {

            var command = new Mock<DbCommand>();
            command.SetupProperty(p => p.CommandText, commandText);

            var commandProt = command.Protected();

            commandProt.Setup<DbConnection>("DbConnection")
               .Returns(mockDb.Object.Connection);

            commandProt.Setup<DbDataReader>("ExecuteDbDataReader", It.IsAny<CommandBehavior>())
               .Returns(reader);

            return command.Object;
         });
   }

   public static Database
   RealDatabase() {

      var builder = new SQLiteConnectionStringBuilder {
         DataSource = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\samples\App\bin\Debug\net8.0\Northwind\Northwind.sl3")),
         FailIfMissing = true
      };

      var conn = new SQLiteConnection(builder.ToString());

      var db = new Database(conn);

#if DEBUG
      db.Configuration.Log = Console.Out;
#endif

      return db;
   }

   public static bool
   SqlEquals(SqlSet set, SqlBuilder query) =>
      String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
}

class TestDataReader : DbDataReader {

   readonly KeyValuePair<string, object>[][]
   _data;

   KeyValuePair<string, object>[]
   _row;

   int
   _rowIndex;

   public override object
   this[int i] => _row[i].Value;

   public override object
   this[string name] => _row[GetOrdinal(name)].Value;

   public override int
   Depth => throw new NotImplementedException();

   public override int
   FieldCount => _row.Length;

   public override bool
   HasRows => _data.Length > 0;

   public override bool
   IsClosed => false;

   public override int
   RecordsAffected => -1;

   public
   TestDataReader(params KeyValuePair<string, object>[][] data) {
      _data = data;
   }

   public override IEnumerator
   GetEnumerator() =>
      throw new NotImplementedException();

   public override bool
   GetBoolean(int i) =>
      (bool)this[i];

   public override byte
   GetByte(int i) =>
      (byte)this[i];

   public override long
   GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) =>
      throw new NotImplementedException();

   public override char
   GetChar(int i) =>
      (char)this[i];

   public override long
   GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) =>
      throw new NotImplementedException();

   public override string
   GetDataTypeName(int i) =>
      throw new NotImplementedException();

   public override DateTime
   GetDateTime(int i) =>
      (DateTime)this[i];

   public override decimal
   GetDecimal(int i) =>
      (decimal)this[i];

   public override double
   GetDouble(int i) =>
      (double)this[i];

   public override Type
   GetFieldType(int i) =>
      throw new NotImplementedException();

   public override float
   GetFloat(int i) =>
      (float)this[i];

   public override Guid
   GetGuid(int i) =>
      (Guid)this[i];

   public override short
   GetInt16(int i) =>
      (short)this[i];

   public override int
   GetInt32(int i) =>
      (int)this[i];

   public override long
   GetInt64(int i) =>
      (long)this[i];

   public override string
   GetName(int i) =>
      _row[i].Key;

   public override int
   GetOrdinal(string name) =>
      _row.Select((p, i) => new { p, i })
         .Where(p => p.p.Key == name)
         .Select(p => p.i)
         .DefaultIfEmpty(-1)
         .First();

   public override string
   GetString(int i) =>
      (string)this[i];

   public override object
   GetValue(int i) =>
      this[i];

   public override int
   GetValues(object[] values) =>
      throw new NotImplementedException();

   public override bool
   IsDBNull(int i) =>
      this[i] is null;

   public override bool
   NextResult() =>
      throw new NotImplementedException();

   public override bool
   Read() {

      if (_data.Length > _rowIndex) {
         _row = _data[_rowIndex];
         _rowIndex++;
         return true;
      }

      return false;
   }
}
