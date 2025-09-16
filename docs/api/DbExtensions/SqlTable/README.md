SqlTable Class
==============
A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Database.Table(Type)][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlTable**  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class SqlTable : SqlSet
```

The **SqlTable** type exposes the following members.


Properties
----------

|                    | Name                | Description                                                                                        |
| ------------------ | ------------------- | -------------------------------------------------------------------------------------------------- |
| ![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                            |
| ![Public property] | [Name][8]           | Gets the name of the table.                                                                        |
| ![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                                                                |
| ---------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| ![Public method] | [AddAsync][11]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| ![Public method] | [AddRange(IEnumerable&lt;Object>)][12]                                          | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [AddRange(Object[])][13]                                                        | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [AddRangeAsync(Object[])][14]                                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [AddRangeAsync(IEnumerable&lt;Object>, CancellationToken)][15]                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [All(OperatorStringHandler)][16]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [All(String)][17]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [AllAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [AllAsync(String, CancellationToken)][19]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [Any()][20]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Any(OperatorStringHandler)][21]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [Any(String)][22]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [AnyAsync(CancellationToken)][23]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [AnyAsync(OperatorStringHandler, CancellationToken)][24]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [AnyAsync(String, CancellationToken)][25]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [AsAsyncEnumerable][26]                                                         | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [AsEnumerable][27]                                                              | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [Cast(Type)][28]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Cast&lt;TEntity>()][29]                                                        | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                          |
| ![Public method] | [Contains][30]                                                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| ![Public method] | [ContainsAsync][31]                                                             | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| ![Public method] | [ContainsKey][32]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| ![Public method] | [ContainsKeyAsync][33]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| ![Public method] | [Count()][34]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| ![Public method] | [Count(OperatorStringHandler)][35]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [Count(String)][36]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [CountAsync(CancellationToken)][37]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| ![Public method] | [CountAsync(OperatorStringHandler, CancellationToken)][38]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [CountAsync(String, CancellationToken)][39]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [Find][40]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [FindAsync][41]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [First()][42]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][43]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [First(String)][44]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [FirstAsync(CancellationToken)][45]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [FirstAsync(OperatorStringHandler, CancellationToken)][46]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [FirstAsync(String, CancellationToken)][47]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [FirstOrDefault()][48]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][49]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [FirstOrDefault(String)][50]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(CancellationToken)][51]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| ![Public method] | [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][52]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(String, CancellationToken)][53]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [GetDefiningQuery][54]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [GetEnumerator][55]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Include][56]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet][4])                                                                                                                                           |
| ![Public method] | [LongCount()][57]                                                               | Returns an [Int64][58] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| ![Public method] | [LongCount(OperatorStringHandler)][59]                                          | Returns an [Int64][58] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [LongCount(String)][60]                                                         | Returns an [Int64][58] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [LongCountAsync(CancellationToken)][61]                                         | Returns an [Int64][58] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| ![Public method] | [LongCountAsync(OperatorStringHandler, CancellationToken)][62]                  | Returns an [Int64][58] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [LongCountAsync(String, CancellationToken)][63]                                 | Returns an [Int64][58] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [OrderBy(OperatorStringHandler)][64]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| ![Public method] | [OrderBy(String)][65]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| ![Public method] | [Refresh][66]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| ![Public method] | [RefreshAsync][67]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| ![Public method] | [Remove][68]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| ![Public method] | [RemoveAsync][69]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| ![Public method] | [RemoveKey][70]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| ![Public method] | [RemoveKeyAsync][71]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| ![Public method] | [RemoveRange(IEnumerable&lt;Object>)][72]                                       | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [RemoveRange(Object[])][73]                                                     | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [RemoveRangeAsync(Object[])][74]                                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken)][75]               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [Select(OperatorStringHandler, Type)][76]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select(String, Type)][77]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][78]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String)][79]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][80] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][81]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Single()][82]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [Single(OperatorStringHandler)][83]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [Single(String)][84]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [SingleAsync(CancellationToken)][85]                                            | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [SingleAsync(OperatorStringHandler, CancellationToken)][86]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [SingleAsync(String, CancellationToken)][87]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [SingleOrDefault()][88]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| ![Public method] | [SingleOrDefault(OperatorStringHandler)][89]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [SingleOrDefault(String)][90]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [SingleOrDefaultAsync(CancellationToken)][91]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| ![Public method] | [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][92]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [SingleOrDefaultAsync(String, CancellationToken)][93]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [Skip][94]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet][4])                                                                                                              |
| ![Public method] | [Take][95]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [ToArray][96]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [ToArrayAsync][97]                                                              | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [ToList][98]                                                                    | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| ![Public method] | [ToListAsync][99]                                                               | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| ![Public method] | [ToString][100]                                                                 | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                        |
| ![Public method] | [Update(Object)][101]                                                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [Update(Object, Object)][102]                                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [UpdateAsync(Object, CancellationToken)][103]                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [UpdateAsync(Object, Object, CancellationToken)][104]                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRange(IEnumerable&lt;Object>)][105]                                      | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRange(Object[])][106]                                                    | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRangeAsync(Object[])][107]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken)][108]              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [Where(OperatorStringHandler)][109]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Where(String)][110]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: CommandBuilder.md
[7]: ../SqlCommandBuilder_1/README.md
[8]: Name.md
[9]: ../SqlSet/ResultType.md
[10]: Add.md
[11]: AddAsync.md
[12]: AddRange.md
[13]: AddRange_1.md
[14]: AddRangeAsync_1.md
[15]: AddRangeAsync.md
[16]: ../SqlSet/All.md
[17]: ../SqlSet/All_1.md
[18]: ../SqlSet/AllAsync.md
[19]: ../SqlSet/AllAsync_1.md
[20]: ../SqlSet/Any.md
[21]: ../SqlSet/Any_1.md
[22]: ../SqlSet/Any_2.md
[23]: ../SqlSet/AnyAsync_2.md
[24]: ../SqlSet/AnyAsync.md
[25]: ../SqlSet/AnyAsync_1.md
[26]: ../SqlSet/AsAsyncEnumerable.md
[27]: ../SqlSet/AsEnumerable.md
[28]: ../SqlSet/Cast.md
[29]: Cast__1.md
[30]: ../SqlSet/Contains.md
[31]: ../SqlSet/ContainsAsync.md
[32]: ../SqlSet/ContainsKey.md
[33]: ../SqlSet/ContainsKeyAsync.md
[34]: ../SqlSet/Count.md
[35]: ../SqlSet/Count_1.md
[36]: ../SqlSet/Count_2.md
[37]: ../SqlSet/CountAsync_2.md
[38]: ../SqlSet/CountAsync.md
[39]: ../SqlSet/CountAsync_1.md
[40]: ../SqlSet/Find.md
[41]: ../SqlSet/FindAsync.md
[42]: ../SqlSet/First.md
[43]: ../SqlSet/First_1.md
[44]: ../SqlSet/First_2.md
[45]: ../SqlSet/FirstAsync_2.md
[46]: ../SqlSet/FirstAsync.md
[47]: ../SqlSet/FirstAsync_1.md
[48]: ../SqlSet/FirstOrDefault.md
[49]: ../SqlSet/FirstOrDefault_1.md
[50]: ../SqlSet/FirstOrDefault_2.md
[51]: ../SqlSet/FirstOrDefaultAsync_2.md
[52]: ../SqlSet/FirstOrDefaultAsync.md
[53]: ../SqlSet/FirstOrDefaultAsync_1.md
[54]: ../SqlSet/GetDefiningQuery.md
[55]: ../SqlSet/GetEnumerator.md
[56]: ../SqlSet/Include.md
[57]: ../SqlSet/LongCount.md
[58]: https://learn.microsoft.com/dotnet/api/system.int64
[59]: ../SqlSet/LongCount_1.md
[60]: ../SqlSet/LongCount_2.md
[61]: ../SqlSet/LongCountAsync_2.md
[62]: ../SqlSet/LongCountAsync.md
[63]: ../SqlSet/LongCountAsync_1.md
[64]: ../SqlSet/OrderBy.md
[65]: ../SqlSet/OrderBy_1.md
[66]: Refresh.md
[67]: RefreshAsync.md
[68]: Remove.md
[69]: RemoveAsync.md
[70]: RemoveKey.md
[71]: RemoveKeyAsync.md
[72]: RemoveRange.md
[73]: RemoveRange_1.md
[74]: RemoveRangeAsync_1.md
[75]: RemoveRangeAsync.md
[76]: ../SqlSet/Select_1.md
[77]: ../SqlSet/Select_3.md
[78]: ../SqlSet/Select__1.md
[79]: ../SqlSet/Select__1_2.md
[80]: ../SqlSet/Select__1_1.md
[81]: ../SqlSet/Select__1_3.md
[82]: ../SqlSet/Single.md
[83]: ../SqlSet/Single_1.md
[84]: ../SqlSet/Single_2.md
[85]: ../SqlSet/SingleAsync_2.md
[86]: ../SqlSet/SingleAsync.md
[87]: ../SqlSet/SingleAsync_1.md
[88]: ../SqlSet/SingleOrDefault.md
[89]: ../SqlSet/SingleOrDefault_1.md
[90]: ../SqlSet/SingleOrDefault_2.md
[91]: ../SqlSet/SingleOrDefaultAsync_2.md
[92]: ../SqlSet/SingleOrDefaultAsync.md
[93]: ../SqlSet/SingleOrDefaultAsync_1.md
[94]: ../SqlSet/Skip.md
[95]: ../SqlSet/Take.md
[96]: ../SqlSet/ToArray.md
[97]: ../SqlSet/ToArrayAsync.md
[98]: ../SqlSet/ToList.md
[99]: ../SqlSet/ToListAsync.md
[100]: ../SqlSet/ToString.md
[101]: Update.md
[102]: Update_1.md
[103]: UpdateAsync_1.md
[104]: UpdateAsync.md
[105]: UpdateRange.md
[106]: UpdateRange_1.md
[107]: UpdateRangeAsync_1.md
[108]: UpdateRangeAsync.md
[109]: ../SqlSet/Where.md
[110]: ../SqlSet/Where_1.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"