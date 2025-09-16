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

|                    | Name                | Description                                                                                        |
| ------------------ | ------------------- | -------------------------------------------------------------------------------------------------- |
| ![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                            |
| ![Public property] | [Name][8]           | Gets the name of the table.                                                                        |
| ![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                                                                            |
| ---------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| ![Public method] | [AddAsync][11]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| ![Public method] | [AddRange(IEnumerable&lt;TEntity>)][12]                                         | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [AddRange(TEntity[])][13]                                                       | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [AddRangeAsync(TEntity[])][14]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][15]                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [All(OperatorStringHandler)][16]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [All(String)][17]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [AllAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [AllAsync(String, CancellationToken)][19]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [Any()][20]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Any(OperatorStringHandler)][21]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Any(String)][22]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [AnyAsync(CancellationToken)][23]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [AnyAsync(OperatorStringHandler, CancellationToken)][24]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [AnyAsync(String, CancellationToken)][25]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [AsAsyncEnumerable][26]                                                         | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| ![Public method] | [AsEnumerable][27]                                                              | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| ![Public method] | [Cast(Type)][28]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| ![Public method] | [Cast&lt;TResult>()][29]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| ![Public method] | [Contains(Object)][30]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| ![Public method] | [Contains(TResult)][31]                                                         | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| ![Public method] | [ContainsAsync(Object, CancellationToken)][32]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| ![Public method] | [ContainsAsync(TResult, CancellationToken)][33]                                 | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| ![Public method] | [ContainsKey][34]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [ContainsKeyAsync][35]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [Count()][36]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [Count(OperatorStringHandler)][37]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [Count(String)][38]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [CountAsync(CancellationToken)][39]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [CountAsync(OperatorStringHandler, CancellationToken)][40]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [CountAsync(String, CancellationToken)][41]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [Find][42]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| ![Public method] | [FindAsync][43]                                                                 | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| ![Public method] | [First()][44]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][45]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [First(String)][46]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [FirstAsync(CancellationToken)][47]                                             | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| ![Public method] | [FirstAsync(OperatorStringHandler, CancellationToken)][48]                      | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [FirstAsync(String, CancellationToken)][49]                                     | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [FirstOrDefault()][50]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][51]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [FirstOrDefault(String)][52]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(CancellationToken)][53]                                    | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| ![Public method] | [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][54]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(String, CancellationToken)][55]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [GetDefiningQuery][56]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [GetEnumerator][57]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                     |
| ![Public method] | [Include][58]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| ![Public method] | [LongCount()][59]                                                               | Returns an [Int64][60] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| ![Public method] | [LongCount(OperatorStringHandler)][61]                                          | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [LongCount(String)][62]                                                         | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [LongCountAsync(CancellationToken)][63]                                         | Returns an [Int64][60] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| ![Public method] | [LongCountAsync(OperatorStringHandler, CancellationToken)][64]                  | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [LongCountAsync(String, CancellationToken)][65]                                 | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [OrderBy(OperatorStringHandler)][66]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| ![Public method] | [OrderBy(String)][67]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| ![Public method] | [Refresh][68]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| ![Public method] | [RefreshAsync][69]                                                              | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| ![Public method] | [Remove][70]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| ![Public method] | [RemoveAsync][71]                                                               | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| ![Public method] | [RemoveKey][72]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| ![Public method] | [RemoveKeyAsync][73]                                                            | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| ![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][74]                                      | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [RemoveRange(TEntity[])][75]                                                    | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [RemoveRangeAsync(TEntity[])][76]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][77]              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [Select(OperatorStringHandler, Type)][78]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select(String, Type)][79]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][80]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(String)][81]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][82] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][83]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Single()][84]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [Single(OperatorStringHandler)][85]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [Single(String)][86]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [SingleAsync(CancellationToken)][87]                                            | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [SingleAsync(OperatorStringHandler, CancellationToken)][88]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [SingleAsync(String, CancellationToken)][89]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [SingleOrDefault()][90]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| ![Public method] | [SingleOrDefault(OperatorStringHandler)][91]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [SingleOrDefault(String)][92]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [SingleOrDefaultAsync(CancellationToken)][93]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| ![Public method] | [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][94]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [SingleOrDefaultAsync(String, CancellationToken)][95]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [Skip][96]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                              |
| ![Public method] | [Take][97]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                             |
| ![Public method] | [ToArray][98]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [ToArrayAsync][99]                                                              | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [ToList][100]                                                                   | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| ![Public method] | [ToListAsync][101]                                                              | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| ![Public method] | [ToString][102]                                                                 | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                                    |
| ![Public method] | [Update(TEntity)][103]                                                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [Update(TEntity, Object)][104]                                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateAsync(TEntity, CancellationToken)][105]                                  | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateAsync(TEntity, Object, CancellationToken)][106]                          | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][107]                                     | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRange(TEntity[])][108]                                                   | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRangeAsync(TEntity[])][109]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][110]             | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [Where(OperatorStringHandler)][111]                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| ![Public method] | [Where(String)][112]                                                            | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
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
[56]: ../SqlSet/GetDefiningQuery.md
[57]: ../SqlSet_1/GetEnumerator.md
[58]: ../SqlSet_1/Include.md
[59]: ../SqlSet/LongCount.md
[60]: https://learn.microsoft.com/dotnet/api/system.int64
[61]: ../SqlSet/LongCount_1.md
[62]: ../SqlSet/LongCount_2.md
[63]: ../SqlSet/LongCountAsync_2.md
[64]: ../SqlSet/LongCountAsync.md
[65]: ../SqlSet/LongCountAsync_1.md
[66]: ../SqlSet_1/OrderBy.md
[67]: ../SqlSet_1/OrderBy_1.md
[68]: Refresh.md
[69]: RefreshAsync.md
[70]: Remove.md
[71]: RemoveAsync.md
[72]: RemoveKey.md
[73]: RemoveKeyAsync.md
[74]: RemoveRange.md
[75]: RemoveRange_1.md
[76]: RemoveRangeAsync_1.md
[77]: RemoveRangeAsync.md
[78]: ../SqlSet/Select_1.md
[79]: ../SqlSet/Select_3.md
[80]: ../SqlSet/Select__1.md
[81]: ../SqlSet/Select__1_2.md
[82]: ../SqlSet/Select__1_1.md
[83]: ../SqlSet/Select__1_3.md
[84]: ../SqlSet_1/Single.md
[85]: ../SqlSet_1/Single_1.md
[86]: ../SqlSet_1/Single_2.md
[87]: ../SqlSet_1/SingleAsync_2.md
[88]: ../SqlSet_1/SingleAsync.md
[89]: ../SqlSet_1/SingleAsync_1.md
[90]: ../SqlSet_1/SingleOrDefault.md
[91]: ../SqlSet_1/SingleOrDefault_1.md
[92]: ../SqlSet_1/SingleOrDefault_2.md
[93]: ../SqlSet_1/SingleOrDefaultAsync_2.md
[94]: ../SqlSet_1/SingleOrDefaultAsync.md
[95]: ../SqlSet_1/SingleOrDefaultAsync_1.md
[96]: ../SqlSet_1/Skip.md
[97]: ../SqlSet_1/Take.md
[98]: ../SqlSet_1/ToArray.md
[99]: ../SqlSet_1/ToArrayAsync.md
[100]: ../SqlSet_1/ToList.md
[101]: ../SqlSet_1/ToListAsync.md
[102]: ../SqlSet/ToString.md
[103]: Update.md
[104]: Update_1.md
[105]: UpdateAsync_1.md
[106]: UpdateAsync.md
[107]: UpdateRange.md
[108]: UpdateRange_1.md
[109]: UpdateRangeAsync_1.md
[110]: UpdateRangeAsync.md
[111]: ../SqlSet_1/Where.md
[112]: ../SqlSet_1/Where_1.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"