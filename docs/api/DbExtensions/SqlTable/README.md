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
| [Name][6]       | Gets the name of the table.                                                                        |
| [ResultType][7] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                                                                |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [Add][8]                                                                        | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| [AddAsync][9]                                                                   | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| [AddRange(IEnumerable&lt;Object>)][10]                                          | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRange(Object[])][11]                                                        | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRangeAsync(Object[])][12]                                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [AddRangeAsync(IEnumerable&lt;Object>, CancellationToken)][13]                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| [All(OperatorStringHandler)][14]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [All(String)][15]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [AllAsync(OperatorStringHandler, CancellationToken)][16]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [AllAsync(String, CancellationToken)][17]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [Any()][18]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Any(OperatorStringHandler)][19]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [Any(String)][20]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AnyAsync(CancellationToken)][21]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [AnyAsync(OperatorStringHandler, CancellationToken)][22]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AnyAsync(String, CancellationToken)][23]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| [AsAsyncEnumerable][24]                                                         | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [AsEnumerable][25]                                                              | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [Cast(Type)][26]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Cast&lt;TEntity>()][27]                                                        | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                          |
| [Contains][28]                                                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| [ContainsAsync][29]                                                             | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| [ContainsKey][30]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| [ContainsKeyAsync][31]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| [Count()][32]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| [Count(OperatorStringHandler)][33]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [Count(String)][34]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [CountAsync(CancellationToken)][35]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| [CountAsync(OperatorStringHandler, CancellationToken)][36]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [CountAsync(String, CancellationToken)][37]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| [Find][38]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [FindAsync][39]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [First()][40]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [First(OperatorStringHandler)][41]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [First(String)][42]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstAsync(CancellationToken)][43]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][44]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstAsync(String, CancellationToken)][45]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| [FirstOrDefault()][46]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][47]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefault(String)][48]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][49]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][50]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][51]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| [GetAsyncEnumerator][52]                                                        | Returns an async enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                               |
| [GetDefiningQuery][53]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| [GetEnumerator][54]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Include][55]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet][4])                                                                                                                                           |
| [LongCount()][56]                                                               | Returns an [Int64][57] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| [LongCount(OperatorStringHandler)][58]                                          | Returns an [Int64][57] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCount(String)][59]                                                         | Returns an [Int64][57] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCountAsync(CancellationToken)][60]                                         | Returns an [Int64][57] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][61]                  | Returns an [Int64][57] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [LongCountAsync(String, CancellationToken)][62]                                 | Returns an [Int64][57] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| [OrderBy(OperatorStringHandler)][63]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| [OrderBy(String)][64]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| [Refresh][65]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| [RefreshAsync][66]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| [Remove][67]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| [RemoveAsync][68]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| [RemoveKey][69]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| [RemoveKeyAsync][70]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| [RemoveRange(IEnumerable&lt;Object>)][71]                                       | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRange(Object[])][72]                                                     | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRangeAsync(Object[])][73]                                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [RemoveRangeAsync(IEnumerable&lt;Object>, CancellationToken)][74]               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| [Select(OperatorStringHandler, Type)][75]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select(String, Type)][76]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler)][77]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(String)][78]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][79] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][80]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [Single()][81]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [Single(OperatorStringHandler)][82]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [Single(String)][83]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleAsync(CancellationToken)][84]                                            | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][85]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleAsync(String, CancellationToken)][86]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| [SingleOrDefault()][87]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| [SingleOrDefault(OperatorStringHandler)][88]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefault(String)][89]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefaultAsync(CancellationToken)][90]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][91]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [SingleOrDefaultAsync(String, CancellationToken)][92]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| [Skip][93]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet][4])                                                                                                              |
| [Take][94]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [ToArray][95]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [ToArrayAsync][96]                                                              | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [ToList][97]                                                                    | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| [ToListAsync][98]                                                               | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| [ToString][99]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                        |
| [Update(Object)][100]                                                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [Update(Object, Object)][101]                                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateAsync(Object, CancellationToken)][102]                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateAsync(Object, Object, CancellationToken)][103]                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| [UpdateRange(IEnumerable&lt;Object>)][104]                                      | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRange(Object[])][105]                                                    | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRangeAsync(Object[])][106]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [UpdateRangeAsync(IEnumerable&lt;Object>, CancellationToken)][107]              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| [Where(OperatorStringHandler)][108]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Where(String)][109]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: Name.md
[7]: ../SqlSet/ResultType.md
[8]: Add.md
[9]: AddAsync.md
[10]: AddRange.md
[11]: AddRange_1.md
[12]: AddRangeAsync_1.md
[13]: AddRangeAsync.md
[14]: ../SqlSet/All.md
[15]: ../SqlSet/All_1.md
[16]: ../SqlSet/AllAsync.md
[17]: ../SqlSet/AllAsync_1.md
[18]: ../SqlSet/Any.md
[19]: ../SqlSet/Any_1.md
[20]: ../SqlSet/Any_2.md
[21]: ../SqlSet/AnyAsync_2.md
[22]: ../SqlSet/AnyAsync.md
[23]: ../SqlSet/AnyAsync_1.md
[24]: ../SqlSet/AsAsyncEnumerable.md
[25]: ../SqlSet/AsEnumerable.md
[26]: ../SqlSet/Cast.md
[27]: Cast__1.md
[28]: ../SqlSet/Contains.md
[29]: ../SqlSet/ContainsAsync.md
[30]: ../SqlSet/ContainsKey.md
[31]: ../SqlSet/ContainsKeyAsync.md
[32]: ../SqlSet/Count.md
[33]: ../SqlSet/Count_1.md
[34]: ../SqlSet/Count_2.md
[35]: ../SqlSet/CountAsync_2.md
[36]: ../SqlSet/CountAsync.md
[37]: ../SqlSet/CountAsync_1.md
[38]: ../SqlSet/Find.md
[39]: ../SqlSet/FindAsync.md
[40]: ../SqlSet/First.md
[41]: ../SqlSet/First_1.md
[42]: ../SqlSet/First_2.md
[43]: ../SqlSet/FirstAsync_2.md
[44]: ../SqlSet/FirstAsync.md
[45]: ../SqlSet/FirstAsync_1.md
[46]: ../SqlSet/FirstOrDefault.md
[47]: ../SqlSet/FirstOrDefault_1.md
[48]: ../SqlSet/FirstOrDefault_2.md
[49]: ../SqlSet/FirstOrDefaultAsync_2.md
[50]: ../SqlSet/FirstOrDefaultAsync.md
[51]: ../SqlSet/FirstOrDefaultAsync_1.md
[52]: ../SqlSet/GetAsyncEnumerator.md
[53]: ../SqlSet/GetDefiningQuery.md
[54]: ../SqlSet/GetEnumerator.md
[55]: ../SqlSet/Include.md
[56]: ../SqlSet/LongCount.md
[57]: https://learn.microsoft.com/dotnet/api/system.int64
[58]: ../SqlSet/LongCount_1.md
[59]: ../SqlSet/LongCount_2.md
[60]: ../SqlSet/LongCountAsync_2.md
[61]: ../SqlSet/LongCountAsync.md
[62]: ../SqlSet/LongCountAsync_1.md
[63]: ../SqlSet/OrderBy.md
[64]: ../SqlSet/OrderBy_1.md
[65]: Refresh.md
[66]: RefreshAsync.md
[67]: Remove.md
[68]: RemoveAsync.md
[69]: RemoveKey.md
[70]: RemoveKeyAsync.md
[71]: RemoveRange.md
[72]: RemoveRange_1.md
[73]: RemoveRangeAsync_1.md
[74]: RemoveRangeAsync.md
[75]: ../SqlSet/Select_1.md
[76]: ../SqlSet/Select_3.md
[77]: ../SqlSet/Select__1.md
[78]: ../SqlSet/Select__1_2.md
[79]: ../SqlSet/Select__1_1.md
[80]: ../SqlSet/Select__1_3.md
[81]: ../SqlSet/Single.md
[82]: ../SqlSet/Single_1.md
[83]: ../SqlSet/Single_2.md
[84]: ../SqlSet/SingleAsync_2.md
[85]: ../SqlSet/SingleAsync.md
[86]: ../SqlSet/SingleAsync_1.md
[87]: ../SqlSet/SingleOrDefault.md
[88]: ../SqlSet/SingleOrDefault_1.md
[89]: ../SqlSet/SingleOrDefault_2.md
[90]: ../SqlSet/SingleOrDefaultAsync_2.md
[91]: ../SqlSet/SingleOrDefaultAsync.md
[92]: ../SqlSet/SingleOrDefaultAsync_1.md
[93]: ../SqlSet/Skip.md
[94]: ../SqlSet/Take.md
[95]: ../SqlSet/ToArray.md
[96]: ../SqlSet/ToArrayAsync.md
[97]: ../SqlSet/ToList.md
[98]: ../SqlSet/ToListAsync.md
[99]: ../SqlSet/ToString.md
[100]: Update.md
[101]: Update_1.md
[102]: UpdateAsync_1.md
[103]: UpdateAsync.md
[104]: UpdateRange.md
[105]: UpdateRange_1.md
[106]: UpdateRangeAsync_1.md
[107]: UpdateRangeAsync.md
[108]: ../SqlSet/Where.md
[109]: ../SqlSet/Where_1.md