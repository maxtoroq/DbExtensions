using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Moq;

namespace DbExtensions.Tests;

static class TestUtil {

   public static Database MockDatabase(bool useCompiledMapping, string providerInvariantName = "MySql.Data.MySqlClient") =>
      MockDatabaseImpl(useCompiledMapping, providerInvariantName).Object;

   public static Mock<Database> MockDatabaseImpl(bool useCompiledMapping, string providerInvariantName) {

      var mockConn = new Mock<IDbConnection>();

      var mockDb = new Mock<Database>(mockConn.Object, providerInvariantName) {
         CallBase = true
      };

      mockDb.Object.Configuration.UseCompiledMapping = useCompiledMapping;

      return mockDb;
   }

   public static Database MockQuery(bool useCompiledMapping, params IEnumerable<KeyValuePair<string, object>>[] data) {

      var reader = new TestDataReader(data
         .Select(p => p as KeyValuePair<string, object>[]
            ?? p.ToArray())
         .ToArray());

      var mockDb = MockDatabaseImpl(useCompiledMapping, "MySql.Data.MySqlClient");

      SetupReader(mockDb, reader);

      return mockDb.Object;
   }

   public static void SetupReader(Mock<Database> mockDb, IDataReader reader, string commandText = null) {

      mockDb.Setup(db => db.CreateCommand(It.IsAny<string>(), It.IsAny<object[]>()))
         .Returns(() => {
            var command = new Mock<IDbCommand>();
            command.SetupProperty(cmd => cmd.Connection, mockDb.Object.Connection);
            command.SetupProperty(cmd => cmd.CommandText, commandText);
            command.Setup(cmd => cmd.ExecuteReader())
               .Returns(() => reader);
            return command.Object;
         });
   }

   public static Database RealDatabase(bool useCompiledMapping) {

      var builder = new SQLiteConnectionStringBuilder {
         DataSource = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\samples\App\bin\Debug\net472\Northwind\Northwind.sl3")),
         FailIfMissing = true
      };

      var conn = new SQLiteConnection(builder.ToString());

      var db = new Database(conn);
      db.Configuration.UseCompiledMapping = useCompiledMapping;
      db.Configuration.Log = Console.Out;

      return db;
   }

   public static bool SqlEquals(SqlSet set, SqlBuilder query) =>
      String.Equals(Regex.Replace(set.ToString(), "dbex_set[0-9]+", "_"), query.ToString(), StringComparison.Ordinal);
}

class TestDataReader : IDataReader {

   readonly KeyValuePair<string, object>[][] _data;
   KeyValuePair<string, object>[] _row;
   int _rowIndex;

   public object this[int i] => _row[i].Value;

   public object this[string name] => _row[GetOrdinal(name)].Value;

   public int Depth => throw new NotImplementedException();

   public bool IsClosed => false;

   public int RecordsAffected => -1;

   public int FieldCount => _row.Length;

   public TestDataReader(params KeyValuePair<string, object>[][] data) {
      _data = data;
   }

   public void Close() { }

   public void Dispose() { }

   public bool GetBoolean(int i) =>
      (bool)this[i];

   public byte GetByte(int i) =>
      (byte)this[i];

   public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) =>
      throw new NotImplementedException();

   public char GetChar(int i) =>
      (char)this[i];

   public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) =>
      throw new NotImplementedException();

   public IDataReader GetData(int i) =>
      throw new NotImplementedException();

   public string GetDataTypeName(int i) =>
      throw new NotImplementedException();

   public DateTime GetDateTime(int i) =>
      (DateTime)this[i];

   public decimal GetDecimal(int i) =>
      (decimal)this[i];

   public double GetDouble(int i) =>
      (double)this[i];

   public Type GetFieldType(int i) =>
      throw new NotImplementedException();

   public float GetFloat(int i) =>
      (float)this[i];

   public Guid GetGuid(int i) =>
      (Guid)this[i];

   public short GetInt16(int i) =>
      (short)this[i];

   public int GetInt32(int i) =>
      (int)this[i];

   public long GetInt64(int i) =>
      (long)this[i];

   public string GetName(int i) =>
      _row[i].Key;

   public int GetOrdinal(string name) =>
      _row.Select((p, i) => new { p, i })
         .Where(p => p.p.Key == name)
         .Select(p => p.i)
         .DefaultIfEmpty(-1)
         .First();

   public DataTable GetSchemaTable() =>
      throw new NotImplementedException();

   public string GetString(int i) =>
      (string)this[i];

   public object GetValue(int i) =>
      this[i];

   public int GetValues(object[] values) =>
      throw new NotImplementedException();

   public bool IsDBNull(int i) =>
      this[i] is null;

   public bool NextResult() =>
      throw new NotImplementedException();

   public bool Read() {

      if (_data.Length > _rowIndex) {
         _row = _data[_rowIndex];
         _rowIndex++;
         return true;
      }

      return false;
   }

   public void Reset() {
      _row = null;
      _rowIndex = 0;
   }
}
