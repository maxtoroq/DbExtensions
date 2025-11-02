SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Database.Table&lt;TEntity>()][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    [DbExtensions.SqlSet][1]&lt;**TEntity**>  
      **DbExtensions.SqlTable&lt;TEntity>**  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class SqlTable<TEntity> : SqlSet<TEntity>
where TEntity : class

```

#### Type Parameters

##### *TEntity*
The type of the entity.

The **SqlTable&lt;TEntity>** type exposes the following members.


Properties
----------

| Name            | Description                                                                                        |
| --------------- | -------------------------------------------------------------------------------------------------- |
| [Database][6]   | The [Database][7] this set is connected to. <br/>(Inherited from [SqlSet][4])                      |
| [Name][8]       | Gets the name of the table.                                                                        |
| [ResultType][9] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                                                                            |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddAsync][11]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddRange(IEnumerable&lt;TEntity>)][12]                                         | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRange(TEntity[])][13]                                                       | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(TEntity[])][14]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][15]                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [All(OperatorStringHandler)][16]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [All(String)][17]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(String, CancellationToken)][19]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [Any()][20]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Any(OperatorStringHandler)][21]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Any(String)][22]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(CancellationToken)][23]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [AnyAsync(OperatorStringHandler, CancellationToken)][24]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(String, CancellationToken)][25]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AsAsyncEnumerable][26]                                                         | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [AsEnumerable][27]                                                              | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [Cast(Type)][28]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Cast&lt;TResult>()][29]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Contains(Object)][30]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [Contains(TResult)][31]                                                         | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][32]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [ContainsAsync(TResult, CancellationToken)][33]                                 | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsKey][34]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [ContainsKeyAsync][35]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [Count()][36]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [Count(OperatorStringHandler)][37]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Count(String)][38]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(CancellationToken)][39]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [CountAsync(OperatorStringHandler, CancellationToken)][40]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(String, CancellationToken)][41]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Find][42]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [FindAsync][43]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [First()][44]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [First(OperatorStringHandler)][45]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [First(String)][46]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(CancellationToken)][47]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][48]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(String, CancellationToken)][49]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstOrDefault()][50]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][51]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefault(String)][52]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][53]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][54]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][55]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [GetAsyncEnumerator][56]                                                        | Returns an async enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                               |
| [GetDefiningQuery][57]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [GetEnumerator][58]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                     |
| [Include][59]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| [LongCount()][60]                                                               | Returns an [Int64][61] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCount(OperatorStringHandler)][62]                                          | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCount(String)][63]                                                         | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(CancellationToken)][64]                                         | Returns an [Int64][61] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][65]                  | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(String, CancellationToken)][66]                                 | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [OrderBy(OperatorStringHandler)][67]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [OrderBy(String)][68]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [Refresh][69]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [RefreshAsync][70]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [Remove][71]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveAsync][72]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveKey][73]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveKeyAsync][74]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveRange(IEnumerable&lt;TEntity>)][75]                                      | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRange(TEntity[])][76]                                                    | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(TEntity[])][77]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][78]              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Select(OperatorStringHandler, Type)][79]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select(String, Type)][80]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler)][81]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String)][82]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][83] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][84]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Single()][85]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [Single(OperatorStringHandler)][86]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [Single(String)][87]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(CancellationToken)][88]                                            | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][89]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(String, CancellationToken)][90]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleOrDefault()][91]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefault(OperatorStringHandler)][92]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefault(String)][93]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(CancellationToken)][94]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][95]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(String, CancellationToken)][96]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [Skip][97]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                              |
| [Take][98]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                             |
| [ToArray][99]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToArrayAsync][100]                                                             | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToList][101]                                                                   | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToListAsync][102]                                                              | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToString][103]                                                                 | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                                    |
| [Update(TEntity)][104]                                                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [Update(TEntity, Object)][105]                                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, CancellationToken)][106]                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, Object, CancellationToken)][107]                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateRange(IEnumerable&lt;TEntity>)][108]                                     | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRange(TEntity[])][109]                                                   | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(TEntity[])][110]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][111]             | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Where(OperatorStringHandler)][112]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [Where(String)][113]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
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
[26]: ../SqlSet_1/AsAsyncEnumerable.md
[27]: ../SqlSet_1/AsEnumerable.md
[28]: ../SqlSet/Cast.md
[29]: ../SqlSet/Cast__1.md
[30]: ../SqlSet/Contains.md
[31]: ../SqlSet_1/Contains.md
[32]: ../SqlSet/ContainsAsync.md
[33]: ../SqlSet_1/ContainsAsync.md
[34]: ../SqlSet/ContainsKey.md
[35]: ../SqlSet/ContainsKeyAsync.md
[36]: ../SqlSet/Count.md
[37]: ../SqlSet/Count_1.md
[38]: ../SqlSet/Count_2.md
[39]: ../SqlSet/CountAsync_2.md
[40]: ../SqlSet/CountAsync.md
[41]: ../SqlSet/CountAsync_1.md
[42]: ../SqlSet_1/Find.md
[43]: ../SqlSet_1/FindAsync.md
[44]: ../SqlSet_1/First.md
[45]: ../SqlSet_1/First_1.md
[46]: ../SqlSet_1/First_2.md
[47]: ../SqlSet_1/FirstAsync_2.md
[48]: ../SqlSet_1/FirstAsync.md
[49]: ../SqlSet_1/FirstAsync_1.md
[50]: ../SqlSet_1/FirstOrDefault.md
[51]: ../SqlSet_1/FirstOrDefault_1.md
[52]: ../SqlSet_1/FirstOrDefault_2.md
[53]: ../SqlSet_1/FirstOrDefaultAsync_2.md
[54]: ../SqlSet_1/FirstOrDefaultAsync.md
[55]: ../SqlSet_1/FirstOrDefaultAsync_1.md
[56]: ../SqlSet_1/GetAsyncEnumerator.md
[57]: ../SqlSet/GetDefiningQuery.md
[58]: ../SqlSet_1/GetEnumerator.md
[59]: ../SqlSet_1/Include.md
[60]: ../SqlSet/LongCount.md
[61]: https://learn.microsoft.com/dotnet/api/system.int64
[62]: ../SqlSet/LongCount_1.md
[63]: ../SqlSet/LongCount_2.md
[64]: ../SqlSet/LongCountAsync_2.md
[65]: ../SqlSet/LongCountAsync.md
[66]: ../SqlSet/LongCountAsync_1.md
[67]: ../SqlSet_1/OrderBy.md
[68]: ../SqlSet_1/OrderBy_1.md
[69]: Refresh.md
[70]: RefreshAsync.md
[71]: Remove.md
[72]: RemoveAsync.md
[73]: RemoveKey.md
[74]: RemoveKeyAsync.md
[75]: RemoveRange.md
[76]: RemoveRange_1.md
[77]: RemoveRangeAsync_1.md
[78]: RemoveRangeAsync.md
[79]: ../SqlSet/Select_1.md
[80]: ../SqlSet/Select_3.md
[81]: ../SqlSet/Select__1.md
[82]: ../SqlSet/Select__1_2.md
[83]: ../SqlSet/Select__1_1.md
[84]: ../SqlSet/Select__1_3.md
[85]: ../SqlSet_1/Single.md
[86]: ../SqlSet_1/Single_1.md
[87]: ../SqlSet_1/Single_2.md
[88]: ../SqlSet_1/SingleAsync_2.md
[89]: ../SqlSet_1/SingleAsync.md
[90]: ../SqlSet_1/SingleAsync_1.md
[91]: ../SqlSet_1/SingleOrDefault.md
[92]: ../SqlSet_1/SingleOrDefault_1.md
[93]: ../SqlSet_1/SingleOrDefault_2.md
[94]: ../SqlSet_1/SingleOrDefaultAsync_2.md
[95]: ../SqlSet_1/SingleOrDefaultAsync.md
[96]: ../SqlSet_1/SingleOrDefaultAsync_1.md
[97]: ../SqlSet_1/Skip.md
[98]: ../SqlSet_1/Take.md
[99]: ../SqlSet_1/ToArray.md
[100]: ../SqlSet_1/ToArrayAsync.md
[101]: ../SqlSet_1/ToList.md
[102]: ../SqlSet_1/ToListAsync.md
[103]: ../SqlSet/ToString.md
[104]: Update.md
[105]: Update_1.md
[106]: UpdateAsync_1.md
[107]: UpdateAsync.md
[108]: UpdateRange.md
[109]: UpdateRange_1.md
[110]: UpdateRangeAsync_1.md
[111]: UpdateRangeAsync.md
[112]: ../SqlSet_1/Where.md
[113]: ../SqlSet_1/Where_1.md