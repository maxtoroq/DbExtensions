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
| [Name][6]       | Gets the name of the table.                                                                        |
| [ResultType][7] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                                                                            |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [Add][8]                                                                        | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddAsync][9]                                                                   | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddRange(IEnumerable&lt;TEntity>)][10]                                         | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRange(TEntity[])][11]                                                       | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(TEntity[])][12]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][13]                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [All(OperatorStringHandler)][14]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [All(String)][15]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(OperatorStringHandler, CancellationToken)][16]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(String, CancellationToken)][17]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [Any()][18]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Any(OperatorStringHandler)][19]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Any(String)][20]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(CancellationToken)][21]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [AnyAsync(OperatorStringHandler, CancellationToken)][22]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(String, CancellationToken)][23]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AsAsyncEnumerable][24]                                                         | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [AsEnumerable][25]                                                              | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [Cast(Type)][26]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Cast&lt;TResult>()][27]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Contains(Object)][28]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [Contains(TResult)][29]                                                         | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][30]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [ContainsAsync(TResult, CancellationToken)][31]                                 | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsKey][32]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [ContainsKeyAsync][33]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [Count()][34]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [Count(OperatorStringHandler)][35]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Count(String)][36]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(CancellationToken)][37]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [CountAsync(OperatorStringHandler, CancellationToken)][38]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(String, CancellationToken)][39]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Find][40]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [FindAsync][41]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [First()][42]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [First(OperatorStringHandler)][43]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [First(String)][44]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(CancellationToken)][45]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][46]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(String, CancellationToken)][47]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstOrDefault()][48]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][49]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefault(String)][50]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][51]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][52]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][53]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [GetAsyncEnumerator][54]                                                        | Returns an async enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                               |
| [GetDefiningQuery][55]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [GetEnumerator][56]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                     |
| [Include][57]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| [LongCount()][58]                                                               | Returns an [Int64][59] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCount(OperatorStringHandler)][60]                                          | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCount(String)][61]                                                         | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(CancellationToken)][62]                                         | Returns an [Int64][59] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][63]                  | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(String, CancellationToken)][64]                                 | Returns an [Int64][59] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [OrderBy(OperatorStringHandler)][65]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [OrderBy(String)][66]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [Refresh][67]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [RefreshAsync][68]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [Remove][69]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveAsync][70]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveKey][71]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveKeyAsync][72]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveRange(IEnumerable&lt;TEntity>)][73]                                      | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRange(TEntity[])][74]                                                    | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(TEntity[])][75]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][76]              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Select(OperatorStringHandler, Type)][77]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select(String, Type)][78]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler)][79]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String)][80]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][81] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][82]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Single()][83]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [Single(OperatorStringHandler)][84]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [Single(String)][85]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(CancellationToken)][86]                                            | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][87]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(String, CancellationToken)][88]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleOrDefault()][89]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefault(OperatorStringHandler)][90]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefault(String)][91]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(CancellationToken)][92]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][93]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(String, CancellationToken)][94]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [Skip][95]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                              |
| [Take][96]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                             |
| [ToArray][97]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToArrayAsync][98]                                                              | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToList][99]                                                                    | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToListAsync][100]                                                              | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToString][101]                                                                 | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                                    |
| [Update(TEntity)][102]                                                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [Update(TEntity, Object)][103]                                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, CancellationToken)][104]                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, Object, CancellationToken)][105]                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateRange(IEnumerable&lt;TEntity>)][106]                                     | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRange(TEntity[])][107]                                                   | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(TEntity[])][108]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][109]             | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Where(OperatorStringHandler)][110]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [Where(String)][111]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
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
[24]: ../SqlSet_1/AsAsyncEnumerable.md
[25]: ../SqlSet_1/AsEnumerable.md
[26]: ../SqlSet/Cast.md
[27]: ../SqlSet/Cast__1.md
[28]: ../SqlSet/Contains.md
[29]: ../SqlSet_1/Contains.md
[30]: ../SqlSet/ContainsAsync.md
[31]: ../SqlSet_1/ContainsAsync.md
[32]: ../SqlSet/ContainsKey.md
[33]: ../SqlSet/ContainsKeyAsync.md
[34]: ../SqlSet/Count.md
[35]: ../SqlSet/Count_1.md
[36]: ../SqlSet/Count_2.md
[37]: ../SqlSet/CountAsync_2.md
[38]: ../SqlSet/CountAsync.md
[39]: ../SqlSet/CountAsync_1.md
[40]: ../SqlSet_1/Find.md
[41]: ../SqlSet_1/FindAsync.md
[42]: ../SqlSet_1/First.md
[43]: ../SqlSet_1/First_1.md
[44]: ../SqlSet_1/First_2.md
[45]: ../SqlSet_1/FirstAsync_2.md
[46]: ../SqlSet_1/FirstAsync.md
[47]: ../SqlSet_1/FirstAsync_1.md
[48]: ../SqlSet_1/FirstOrDefault.md
[49]: ../SqlSet_1/FirstOrDefault_1.md
[50]: ../SqlSet_1/FirstOrDefault_2.md
[51]: ../SqlSet_1/FirstOrDefaultAsync_2.md
[52]: ../SqlSet_1/FirstOrDefaultAsync.md
[53]: ../SqlSet_1/FirstOrDefaultAsync_1.md
[54]: ../SqlSet_1/GetAsyncEnumerator.md
[55]: ../SqlSet/GetDefiningQuery.md
[56]: ../SqlSet_1/GetEnumerator.md
[57]: ../SqlSet_1/Include.md
[58]: ../SqlSet/LongCount.md
[59]: https://learn.microsoft.com/dotnet/api/system.int64
[60]: ../SqlSet/LongCount_1.md
[61]: ../SqlSet/LongCount_2.md
[62]: ../SqlSet/LongCountAsync_2.md
[63]: ../SqlSet/LongCountAsync.md
[64]: ../SqlSet/LongCountAsync_1.md
[65]: ../SqlSet_1/OrderBy.md
[66]: ../SqlSet_1/OrderBy_1.md
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
[83]: ../SqlSet_1/Single.md
[84]: ../SqlSet_1/Single_1.md
[85]: ../SqlSet_1/Single_2.md
[86]: ../SqlSet_1/SingleAsync_2.md
[87]: ../SqlSet_1/SingleAsync.md
[88]: ../SqlSet_1/SingleAsync_1.md
[89]: ../SqlSet_1/SingleOrDefault.md
[90]: ../SqlSet_1/SingleOrDefault_1.md
[91]: ../SqlSet_1/SingleOrDefault_2.md
[92]: ../SqlSet_1/SingleOrDefaultAsync_2.md
[93]: ../SqlSet_1/SingleOrDefaultAsync.md
[94]: ../SqlSet_1/SingleOrDefaultAsync_1.md
[95]: ../SqlSet_1/Skip.md
[96]: ../SqlSet_1/Take.md
[97]: ../SqlSet_1/ToArray.md
[98]: ../SqlSet_1/ToArrayAsync.md
[99]: ../SqlSet_1/ToList.md
[100]: ../SqlSet_1/ToListAsync.md
[101]: ../SqlSet/ToString.md
[102]: Update.md
[103]: Update_1.md
[104]: UpdateAsync_1.md
[105]: UpdateAsync.md
[106]: UpdateRange.md
[107]: UpdateRange_1.md
[108]: UpdateRangeAsync_1.md
[109]: UpdateRangeAsync.md
[110]: ../SqlSet_1/Where.md
[111]: ../SqlSet_1/Where_1.md