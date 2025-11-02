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

| Name            | Description                                                                                        |
| --------------- | -------------------------------------------------------------------------------------------------- |
| [Database][6]   | The [Database][7] this set is connected to. <br/>(Inherited from [SqlSet][4])                      |
| [Name][8]       | Gets the name of the table.                                                                        |
| [ResultType][9] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                                                                |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| [AddAsync][11]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| [AddRange(IEnumerable&lt;Object>)][12]                                          | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRange(Object[])][13]                                                        | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRangeAsync(Object[])][14]                                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRangeAsync(IEnumerable&lt;Object>, CancellationToken)][15]                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [All(OperatorStringHandler)][16]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [All(String)][17]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [AllAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [AllAsync(String, CancellationToken)][19]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [Any()][20]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Any(OperatorStringHandler)][21]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [Any(String)][22]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AnyAsync(CancellationToken)][23]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [AnyAsync(OperatorStringHandler, CancellationToken)][24]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AnyAsync(String, CancellationToken)][25]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AsAsyncEnumerable][26]                                                         | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [AsEnumerable][27]                                                              | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [Cast(Type)][28]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Cast&lt;TEntity>()][29]                                                        | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                          |
| [Contains][30]                                                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| [ContainsAsync][31]                                                             | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| [ContainsKey][32]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| [ContainsKeyAsync][33]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| [Count()][34]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| [Count(OperatorStringHandler)][35]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [Count(String)][36]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [CountAsync(CancellationToken)][37]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| [CountAsync(OperatorStringHandler, CancellationToken)][38]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [CountAsync(String, CancellationToken)][39]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [Find][40]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [FindAsync][41]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [First()][42]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [First(OperatorStringHandler)][43]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [First(String)][44]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstAsync(CancellationToken)][45]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][46]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstAsync(String, CancellationToken)][47]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstOrDefault()][48]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][49]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefault(String)][50]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][51]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][52]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][53]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [GetAsyncEnumerator][54]                                                        | Returns an async enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                               |
| [GetDefiningQuery][55]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [GetEnumerator][56]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Include][57]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet][4])                                                                                                                                           |
| [LongCount()][58]                                                               | Returns an [Int64][59] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| [LongCount(OperatorStringHandler)][60]                                          | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCount(String)][61]                                                         | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCountAsync(CancellationToken)][62]                                         | Returns an [Int64][59] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][63]                  | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCountAsync(String, CancellationToken)][64]                                 | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [OrderBy(OperatorStringHandler)][65]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| [OrderBy(String)][66]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| [Refresh][67]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| [RefreshAsync][68]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| [Remove][69]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| [RemoveAsync][70]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| [RemoveKey][71]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| [RemoveKeyAsync][72]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| [RemoveRange(IEnumerable&lt;Object>)][73]                                       | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRange(Object[])][74]                                                     | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRangeAsync(Object[])][75]                                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken)][76]               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [Select(OperatorStringHandler, Type)][77]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select(String, Type)][78]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler)][79]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(String)][80]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][81] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][82]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Single()][83]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [Single(OperatorStringHandler)][84]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [Single(String)][85]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleAsync(CancellationToken)][86]                                            | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][87]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleAsync(String, CancellationToken)][88]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleOrDefault()][89]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| [SingleOrDefault(OperatorStringHandler)][90]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefault(String)][91]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefaultAsync(CancellationToken)][92]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][93]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefaultAsync(String, CancellationToken)][94]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [Skip][95]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet][4])                                                                                                              |
| [Take][96]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [ToArray][97]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [ToArrayAsync][98]                                                              | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [ToList][99]                                                                    | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| [ToListAsync][100]                                                              | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| [ToString][101]                                                                 | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                        |
| [Update(Object)][102]                                                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [Update(Object, Object)][103]                                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateAsync(Object, CancellationToken)][104]                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateAsync(Object, Object, CancellationToken)][105]                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateRange(IEnumerable&lt;Object>)][106]                                      | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRange(Object[])][107]                                                    | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRangeAsync(Object[])][108]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken)][109]              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [Where(OperatorStringHandler)][110]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Where(String)][111]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: ../SqlSet/Database.md
[7]: ../Database/README.md
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
[54]: ../SqlSet/GetAsyncEnumerator.md
[55]: ../SqlSet/GetDefiningQuery.md
[56]: ../SqlSet/GetEnumerator.md
[57]: ../SqlSet/Include.md
[58]: ../SqlSet/LongCount.md
[59]: https://learn.microsoft.com/dotnet/api/system.int64
[60]: ../SqlSet/LongCount_1.md
[61]: ../SqlSet/LongCount_2.md
[62]: ../SqlSet/LongCountAsync_2.md
[63]: ../SqlSet/LongCountAsync.md
[64]: ../SqlSet/LongCountAsync_1.md
[65]: ../SqlSet/OrderBy.md
[66]: ../SqlSet/OrderBy_1.md
[67]: Refresh.md
[68]: RefreshAsync.md
[69]: Remove.md
[70]: RemoveAsync.md
[71]: RemoveKey.md
[72]: RemoveKeyAsync.md
[73]: RemoveRange.md
[74]: RemoveRange_1.md
[75]: RemoveRangeAsync_1.md
[76]: RemoveRangeAsync.md
[77]: ../SqlSet/Select_1.md
[78]: ../SqlSet/Select_3.md
[79]: ../SqlSet/Select__1.md
[80]: ../SqlSet/Select__1_2.md
[81]: ../SqlSet/Select__1_1.md
[82]: ../SqlSet/Select__1_3.md
[83]: ../SqlSet/Single.md
[84]: ../SqlSet/Single_1.md
[85]: ../SqlSet/Single_2.md
[86]: ../SqlSet/SingleAsync_2.md
[87]: ../SqlSet/SingleAsync.md
[88]: ../SqlSet/SingleAsync_1.md
[89]: ../SqlSet/SingleOrDefault.md
[90]: ../SqlSet/SingleOrDefault_1.md
[91]: ../SqlSet/SingleOrDefault_2.md
[92]: ../SqlSet/SingleOrDefaultAsync_2.md
[93]: ../SqlSet/SingleOrDefaultAsync.md
[94]: ../SqlSet/SingleOrDefaultAsync_1.md
[95]: ../SqlSet/Skip.md
[96]: ../SqlSet/Take.md
[97]: ../SqlSet/ToArray.md
[98]: ../SqlSet/ToArrayAsync.md
[99]: ../SqlSet/ToList.md
[100]: ../SqlSet/ToListAsync.md
[101]: ../SqlSet/ToString.md
[102]: Update.md
[103]: Update_1.md
[104]: UpdateAsync_1.md
[105]: UpdateAsync.md
[106]: UpdateRange.md
[107]: UpdateRange_1.md
[108]: UpdateRangeAsync_1.md
[109]: UpdateRangeAsync.md
[110]: ../SqlSet/Where.md
[111]: ../SqlSet/Where_1.md