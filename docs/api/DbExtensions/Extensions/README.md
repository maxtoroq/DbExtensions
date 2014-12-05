Extensions Class
================
Provides extension methods for common ADO.NET objects.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.Extensions**  

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static class Extensions
```

The **Extensions** type exposes the following members.


Methods
-------

                                                | Name                                                                         | Description                                                                                                                                                                                                                                                                                                                    
----------------------------------------------- | ---------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method]![Static member]                | [Affect(IDbCommand, Int32)][3]                                               | Executes the *command* in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                            
![Public method]![Static member]                | [Affect(IDbCommand, Int32, AffectedRecordsPolicy)][4]                        | Executes the *command* in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                            
![Public method]![Static member]                | [Affect(IDbCommand, Int32, TextWriter)][5]                                   | Executes the *command* in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                            
![Public method]![Static member]                | [Affect(IDbCommand, Int32, AffectedRecordsPolicy, TextWriter)][6]            | Executes the *command* in a new or existing transaction, and validates the affected records value before comitting.                                                                                                                                                                                                            
![Public method]![Static member]                | [AffectOne(IDbCommand)][7]                                                   | Executes the *command* in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                       
![Public method]![Static member]                | [AffectOne(IDbCommand, TextWriter)][8]                                       | Executes the *command* in a new or existing transaction, and validates that the affected records value is equal to one before comitting.                                                                                                                                                                                       
![Public method]![Static member]                | [AffectOneOrNone(IDbCommand)][9]                                             | Executes the *command* in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                               
![Public method]![Static member]                | [AffectOneOrNone(IDbCommand, TextWriter)][10]                                | Executes the *command* in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.                                                                                                                                                                               
![Public method]![Static member]                | [CreateCommand(DbConnection, SqlBuilder)][11]                                | Creates and returns a [DbCommand][12] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]![Static member]                | [CreateCommand(DbConnection, String)][13]                                    | Creates and returns a [DbCommand][12] object whose [CommandText][14] property is initialized with the *commandText* parameter.                                                                                                                                                                                                 
![Public method]![Static member]                | [CreateCommand(DbProviderFactory, SqlBuilder)][15]                           | Creates and returns a [DbCommand][12] object from the specified *sqlBuilder*.                                                                                                                                                                                                                                                  
![Public method]![Static member]                | [CreateCommand(DbProviderFactory, String)][16]                               | Creates and returns a [DbCommand][12] object whose [CommandText][14] property is initialized with the *commandText* parameter.                                                                                                                                                                                                 
![Public method]![Static member]                | [CreateCommand(DbConnection, String, Object[])][17]                          | Creates and returns a [DbCommand][12] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][18]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][19] collection. 
![Public method]![Static member]                | [CreateCommand(DbProviderFactory, String, Object[])][20]                     | Creates and returns a [DbCommand][12] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][18]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][19] collection. 
![Public method]![Static member]                | [CreateCommand(DbCommandBuilder, DbConnection, String, Object[])][21]        | Creates and returns a [DbCommand][12] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][18]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][19] collection. 
![Public method]![Static member]                | [CreateCommand(DbCommandBuilder, DbProviderFactory, String, Object[])][22]   | Creates and returns a [DbCommand][12] object using the provided *commandText* as a composite format string (as used on [Format(String, Object[])][18]), where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][19] collection. 
![Public method]![Static member]                | [CreateConnection][23]                                                       | Creates and returns a [DbConnection][24] object whose [ConnectionString][25] property is initialized with the *connectionString* parameter.                                                                                                                                                                                    
![Public method]![Static member]![Code example] | [EnsureOpen][26]                                                             | Opens the *connection* (if it's not open) and returns an [IDisposable][27] object you can use to close it (if it wasn't open).                                                                                                                                                                                                 
![Public method]![Static member]                | [Find(SqlSet, Object)][28]                                                   | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                  
![Public method]![Static member]                | [Find&lt;TResult>(SqlSet&lt;TResult>, Object)][29]                           | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                                                                                                  
![Public method]![Static member]                | [GetBoolean][30]                                                             | Gets the value of the specified column as a [Boolean][31].                                                                                                                                                                                                                                                                     
![Public method]![Static member]                | [GetByte][32]                                                                | Gets the value of the specified column as a [Byte][33].                                                                                                                                                                                                                                                                        
![Public method]![Static member]                | [GetChar][34]                                                                | Gets the value of the specified column as a [Char][35].                                                                                                                                                                                                                                                                        
![Public method]![Static member]                | [GetDateTime][36]                                                            | Gets the value of the specified column as a [DateTime][37].                                                                                                                                                                                                                                                                    
![Public method]![Static member]                | [GetDecimal][38]                                                             | Gets the value of the specified column as a [Decimal][39].                                                                                                                                                                                                                                                                     
![Public method]![Static member]                | [GetDouble][40]                                                              | Gets the value of the specified column as a [Double][41].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetFloat][42]                                                               | Gets the value of the specified column as a [Single][43].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetInt16][44]                                                               | Gets the value of the specified column as an [Int16][45].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetInt32][46]                                                               | Gets the value of the specified column as an [Int32][47].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetInt64][48]                                                               | Gets the value of the specified column as an [Int64][49].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetNullableBoolean(IDataRecord, Int32)][50]                                 | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Boolean][31].                                                                                                                                                                                                                                             
![Public method]![Static member]                | [GetNullableBoolean(IDataRecord, String)][52]                                | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Boolean][31].                                                                                                                                                                                                                                             
![Public method]![Static member]                | [GetNullableByte(IDataRecord, Int32)][53]                                    | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Byte][33].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableByte(IDataRecord, String)][54]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Byte][33].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableChar(IDataRecord, Int32)][55]                                    | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Char][35].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableChar(IDataRecord, String)][56]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Char][35].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableDateTime(IDataRecord, Int32)][57]                                | Gets the value of the specified column as a [Nullable&lt;T>][51] of [DateTime][37].                                                                                                                                                                                                                                            
![Public method]![Static member]                | [GetNullableDateTime(IDataRecord, String)][58]                               | Gets the value of the specified column as a [Nullable&lt;T>][51] of [DateTime][37].                                                                                                                                                                                                                                            
![Public method]![Static member]                | [GetNullableDecimal(IDataRecord, Int32)][59]                                 | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Decimal][39].                                                                                                                                                                                                                                             
![Public method]![Static member]                | [GetNullableDecimal(IDataRecord, String)][60]                                | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Decimal][39].                                                                                                                                                                                                                                             
![Public method]![Static member]                | [GetNullableDouble(IDataRecord, Int32)][61]                                  | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Double][41].                                                                                                                                                                                                                                              
![Public method]![Static member]                | [GetNullableDouble(IDataRecord, String)][62]                                 | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Double][41].                                                                                                                                                                                                                                              
![Public method]![Static member]                | [GetNullableFloat(IDataRecord, Int32)][63]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Single][43].                                                                                                                                                                                                                                              
![Public method]![Static member]                | [GetNullableFloat(IDataRecord, String)][64]                                  | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Single][43].                                                                                                                                                                                                                                              
![Public method]![Static member]                | [GetNullableGuid(IDataRecord, Int32)][65]                                    | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Guid][66].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableGuid(IDataRecord, String)][67]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Guid][66].                                                                                                                                                                                                                                                
![Public method]![Static member]                | [GetNullableInt16(IDataRecord, Int32)][68]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int16][45].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetNullableInt16(IDataRecord, String)][69]                                  | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int16][45].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetNullableInt32(IDataRecord, Int32)][70]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int32][47].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetNullableInt32(IDataRecord, String)][71]                                  | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int32][47].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetNullableInt64(IDataRecord, Int32)][72]                                   | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int64][49].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetNullableInt64(IDataRecord, String)][73]                                  | Gets the value of the specified column as a [Nullable&lt;T>][51] of [Int64][49].                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetProviderFactory][74]                                                     | Gets the [DbProviderFactory][75] associated with the connection.                                                                                                                                                                                                                                                               
![Public method]![Static member]                | [GetString][76]                                                              | Gets the value of the specified column as a [String][77].                                                                                                                                                                                                                                                                      
![Public method]![Static member]                | [GetStringOrNull(IDataRecord, Int32)][78]                                    | Gets the value of the specified column as a [String][77], or null (Nothing in Visual Basic).                                                                                                                                                                                                                                   
![Public method]![Static member]                | [GetStringOrNull(IDataRecord, String)][79]                                   | Gets the value of the specified column as a [String][77], or null (Nothing in Visual Basic).                                                                                                                                                                                                                                   
![Public method]![Static member]                | [GetValue][80]                                                               | Gets the value of the specified column.                                                                                                                                                                                                                                                                                        
![Public method]![Static member]                | [GetValueOrNull(IDataRecord, Int32)][81]                                     | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic).                                                                                                                                                                                                                                   
![Public method]![Static member]                | [GetValueOrNull(IDataRecord, String)][82]                                    | Gets the value of the specified column as an [Object][1], or null (Nothing in Visual Basic).                                                                                                                                                                                                                                   
![Public method]![Static member]                | [Include(SqlSet, String)][83]                                                | Specifies the related objects to include in the query results.                                                                                                                                                                                                                                                                 
![Public method]![Static member]                | [Include&lt;TResult>(SqlSet&lt;TResult>, String)][84]                        | Specifies the related objects to include in the query results.                                                                                                                                                                                                                                                                 
![Public method]![Static member]                | [Map(IDbCommand)][85]                                                        | Maps the results of the *command* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                          
![Public method]![Static member]                | [Map(IDbCommand, TextWriter)][86]                                            | Maps the results of the *command* to dynamic objects. The query is deferred-executed.                                                                                                                                                                                                                                          
![Public method]![Static member]                | [Map(IDbCommand, Type)][87]                                                  | Maps the results of the *command* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                  
![Public method]![Static member]                | [Map(IDbCommand, Type, TextWriter)][88]                                      | Maps the results of the *command* to objects of type specified by the *resultType* parameter. The query is deferred-executed.                                                                                                                                                                                                  
![Public method]![Static member]                | [Map&lt;TResult>(IDbCommand)][89]                                            | Maps the results of the *command* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                          
![Public method]![Static member]                | [Map&lt;TResult>(IDbCommand, Func&lt;IDataRecord, TResult>)][90]             | Maps the results of the *command* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                    
![Public method]![Static member]                | [Map&lt;TResult>(IDbCommand, TextWriter)][91]                                | Maps the results of the *command* to TResult objects. The query is deferred-executed.                                                                                                                                                                                                                                          
![Public method]![Static member]                | [Map&lt;TResult>(IDbCommand, Func&lt;IDataRecord, TResult>, TextWriter)][92] | Maps the results of the *command* to TResult objects, using the provided *mapper* delegate.                                                                                                                                                                                                                                    
![Public method]![Static member]                | [ToTraceString(IDbCommand)][93]                                              | Creates a string representation of *command* for logging and debugging purposes.                                                                                                                                                                                                                                               
![Public method]![Static member]                | [ToTraceString(IDbCommand, Int32)][94]                                       | Creates a string representation of *command* for logging and debugging purposes.                                                                                                                                                                                                                                               


See Also
--------

#### Reference
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: Affect.md
[4]: Affect_1.md
[5]: Affect_3.md
[6]: Affect_2.md
[7]: AffectOne.md
[8]: AffectOne_1.md
[9]: AffectOneOrNone.md
[10]: AffectOneOrNone_1.md
[11]: CreateCommand_2.md
[12]: http://msdn.microsoft.com/en-us/library/852d01k6
[13]: CreateCommand_3.md
[14]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[15]: CreateCommand_5.md
[16]: CreateCommand_6.md
[17]: CreateCommand_4.md
[18]: http://msdn.microsoft.com/en-us/library/b1csw23d
[19]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[20]: CreateCommand_7.md
[21]: CreateCommand.md
[22]: CreateCommand_1.md
[23]: CreateConnection.md
[24]: http://msdn.microsoft.com/en-us/library/c790zwhc
[25]: http://msdn.microsoft.com/en-us/library/f6hxc82w
[26]: EnsureOpen.md
[27]: http://msdn.microsoft.com/en-us/library/aax125c9
[28]: Find.md
[29]: Find__1.md
[30]: GetBoolean.md
[31]: http://msdn.microsoft.com/en-us/library/a28wyd50
[32]: GetByte.md
[33]: http://msdn.microsoft.com/en-us/library/yyb1w04y
[34]: GetChar.md
[35]: http://msdn.microsoft.com/en-us/library/k493b04s
[36]: GetDateTime.md
[37]: http://msdn.microsoft.com/en-us/library/03ybds8y
[38]: GetDecimal.md
[39]: http://msdn.microsoft.com/en-us/library/1k2e8atx
[40]: GetDouble.md
[41]: http://msdn.microsoft.com/en-us/library/643eft0t
[42]: GetFloat.md
[43]: http://msdn.microsoft.com/en-us/library/3www918f
[44]: GetInt16.md
[45]: http://msdn.microsoft.com/en-us/library/e07e6fds
[46]: GetInt32.md
[47]: http://msdn.microsoft.com/en-us/library/td2s409d
[48]: GetInt64.md
[49]: http://msdn.microsoft.com/en-us/library/6yy583ek
[50]: GetNullableBoolean.md
[51]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[52]: GetNullableBoolean_1.md
[53]: GetNullableByte.md
[54]: GetNullableByte_1.md
[55]: GetNullableChar.md
[56]: GetNullableChar_1.md
[57]: GetNullableDateTime.md
[58]: GetNullableDateTime_1.md
[59]: GetNullableDecimal.md
[60]: GetNullableDecimal_1.md
[61]: GetNullableDouble.md
[62]: GetNullableDouble_1.md
[63]: GetNullableFloat.md
[64]: GetNullableFloat_1.md
[65]: GetNullableGuid.md
[66]: http://msdn.microsoft.com/en-us/library/cey1zx63
[67]: GetNullableGuid_1.md
[68]: GetNullableInt16.md
[69]: GetNullableInt16_1.md
[70]: GetNullableInt32.md
[71]: GetNullableInt32_1.md
[72]: GetNullableInt64.md
[73]: GetNullableInt64_1.md
[74]: GetProviderFactory.md
[75]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[76]: GetString.md
[77]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[78]: GetStringOrNull.md
[79]: GetStringOrNull_1.md
[80]: GetValue.md
[81]: GetValueOrNull.md
[82]: GetValueOrNull_1.md
[83]: Include.md
[84]: Include__1.md
[85]: Map.md
[86]: Map_1.md
[87]: Map_2.md
[88]: Map_3.md
[89]: Map__1.md
[90]: Map__1_1.md
[91]: Map__1_3.md
[92]: Map__1_2.md
[93]: ToTraceString.md
[94]: ToTraceString_1.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"
[Code example]: ../../_icons/CodeExample.png "Code example"