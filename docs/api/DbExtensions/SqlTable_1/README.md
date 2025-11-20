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

| Name                                                                                                                                  | Description                                                                                                                                                                                                                                            |
| ------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [Add][10]                                                                                                                             | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddAsync][11]                                                                                                                        | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| [AddRange(IEnumerable&lt;TEntity>)][12]                                                                                               | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRange(TEntity[])][13]                                                                                                             | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(TEntity[])][14]                                                                                                        | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [AddRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][15]                                                                       | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| [All(OperatorStringHandler)][16]                                                                                                      | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [All(String)][17]                                                                                                                     | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(OperatorStringHandler, CancellationToken)][18]                                                                              | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [AllAsync(String, CancellationToken)][19]                                                                                             | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| [Any()][20]                                                                                                                           | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Any(OperatorStringHandler)][21]                                                                                                      | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [Any(String)][22]                                                                                                                     | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(CancellationToken)][23]                                                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [AnyAsync(OperatorStringHandler, CancellationToken)][24]                                                                              | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AnyAsync(String, CancellationToken)][25]                                                                                             | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| [AsAsyncEnumerable][26]                                                                                                               | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [AsEnumerable][27]                                                                                                                    | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| [Cast(Type)][28]                                                                                                                      | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Cast&lt;TResult>()][29]                                                                                                              | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| [Contains(Object)][30]                                                                                                                | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [Contains(TResult)][31]                                                                                                               | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][32]                                                                                        | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                                   |
| [ContainsAsync(TResult, CancellationToken)][33]                                                                                       | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| [ContainsKey][34]                                                                                                                     | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [ContainsKeyAsync][35]                                                                                                                | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| [Count()][36]                                                                                                                         | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [Count(OperatorStringHandler)][37]                                                                                                    | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Count(String)][38]                                                                                                                   | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(CancellationToken)][39]                                                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| [CountAsync(OperatorStringHandler, CancellationToken)][40]                                                                            | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [CountAsync(String, CancellationToken)][41]                                                                                           | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| [Find][42]                                                                                                                            | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [FindAsync][43]                                                                                                                       | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| [First()][44]                                                                                                                         | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [First(OperatorStringHandler)][45]                                                                                                    | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [First(String)][46]                                                                                                                   | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(CancellationToken)][47]                                                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][48]                                                                            | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstAsync(String, CancellationToken)][49]                                                                                           | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| [FirstOrDefault()][50]                                                                                                                | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][51]                                                                                           | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefault(String)][52]                                                                                                          | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][53]                                                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][54]                                                                   | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][55]                                                                                  | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| [GetAsyncEnumerator][56]                                                                                                              | Returns an async enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                               |
| [GetDefiningQuery][57]                                                                                                                | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| [GetEnumerator][58]                                                                                                                   | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                     |
| [Include(String)][59]                                                                                                                 | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| [Include(Func&lt;TResult, Object>, String)][60]                                                                                       | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| [IncludeMany(String, Func&lt;SqlSet, SqlSet>)][61]                                                                                    | Specifies which collections to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [IncludeMany&lt;TElement>(Func&lt;TResult, ICollection&lt;TElement>>, Func&lt;SqlSet&lt;TElement>, SqlSet&lt;TElement>>, String)][62] | Specifies which collections to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [LongCount()][63]                                                                                                                     | Returns an [Int64][64] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCount(OperatorStringHandler)][65]                                                                                                | Returns an [Int64][64] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCount(String)][66]                                                                                                               | Returns an [Int64][64] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(CancellationToken)][67]                                                                                               | Returns an [Int64][64] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][68]                                                                        | Returns an [Int64][64] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [LongCountAsync(String, CancellationToken)][69]                                                                                       | Returns an [Int64][64] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [OrderBy(OperatorStringHandler)][70]                                                                                                  | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [OrderBy(String)][71]                                                                                                                 | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| [Refresh][72]                                                                                                                         | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [RefreshAsync][73]                                                                                                                    | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| [Remove][74]                                                                                                                          | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveAsync][75]                                                                                                                     | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| [RemoveKey][76]                                                                                                                       | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveKeyAsync][77]                                                                                                                  | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| [RemoveRange(IEnumerable&lt;TEntity>)][78]                                                                                            | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRange(TEntity[])][79]                                                                                                          | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(TEntity[])][80]                                                                                                     | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [RemoveRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][81]                                                                    | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Select(OperatorStringHandler, Type)][82]                                                                                             | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select(String, Type)][83]                                                                                                            | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler)][84]                                                                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String)][85]                                                                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][86]                                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][87]                                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| [Single()][88]                                                                                                                        | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [Single(OperatorStringHandler)][89]                                                                                                   | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [Single(String)][90]                                                                                                                  | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(CancellationToken)][91]                                                                                                  | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][92]                                                                           | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleAsync(String, CancellationToken)][93]                                                                                          | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| [SingleOrDefault()][94]                                                                                                               | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefault(OperatorStringHandler)][95]                                                                                          | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefault(String)][96]                                                                                                         | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(CancellationToken)][97]                                                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][98]                                                                  | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [SingleOrDefaultAsync(String, CancellationToken)][99]                                                                                 | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| [Skip][100]                                                                                                                           | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                              |
| [Take][101]                                                                                                                           | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                             |
| [ToArray][102]                                                                                                                        | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToArrayAsync][103]                                                                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| [ToList][104]                                                                                                                         | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToListAsync][105]                                                                                                                    | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| [ToString][106]                                                                                                                       | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                                    |
| [Update(TEntity)][107]                                                                                                                | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [Update(TEntity, Object)][108]                                                                                                        | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, CancellationToken)][109]                                                                                        | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateAsync(TEntity, Object, CancellationToken)][110]                                                                                | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| [UpdateRange(IEnumerable&lt;TEntity>)][111]                                                                                           | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRange(TEntity[])][112]                                                                                                         | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(TEntity[])][113]                                                                                                    | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [UpdateRangeAsync(IEnumerable&lt;TEntity>, CancellationToken)][114]                                                                   | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| [Where(OperatorStringHandler)][115]                                                                                                   | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| [Where(String)][116]                                                                                                                  | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |


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
[59]: ../SqlSet_1/Include_1.md
[60]: ../SqlSet_1/Include.md
[61]: ../SqlSet_1/IncludeMany.md
[62]: ../SqlSet_1/IncludeMany__1.md
[63]: ../SqlSet/LongCount.md
[64]: https://learn.microsoft.com/dotnet/api/system.int64
[65]: ../SqlSet/LongCount_1.md
[66]: ../SqlSet/LongCount_2.md
[67]: ../SqlSet/LongCountAsync_2.md
[68]: ../SqlSet/LongCountAsync.md
[69]: ../SqlSet/LongCountAsync_1.md
[70]: ../SqlSet_1/OrderBy.md
[71]: ../SqlSet_1/OrderBy_1.md
[72]: Refresh.md
[73]: RefreshAsync.md
[74]: Remove.md
[75]: RemoveAsync.md
[76]: RemoveKey.md
[77]: RemoveKeyAsync.md
[78]: RemoveRange.md
[79]: RemoveRange_1.md
[80]: RemoveRangeAsync_1.md
[81]: RemoveRangeAsync.md
[82]: ../SqlSet/Select_1.md
[83]: ../SqlSet/Select_3.md
[84]: ../SqlSet/Select__1.md
[85]: ../SqlSet/Select__1_2.md
[86]: ../SqlSet/Select__1_1.md
[87]: ../SqlSet/Select__1_3.md
[88]: ../SqlSet_1/Single.md
[89]: ../SqlSet_1/Single_1.md
[90]: ../SqlSet_1/Single_2.md
[91]: ../SqlSet_1/SingleAsync_2.md
[92]: ../SqlSet_1/SingleAsync.md
[93]: ../SqlSet_1/SingleAsync_1.md
[94]: ../SqlSet_1/SingleOrDefault.md
[95]: ../SqlSet_1/SingleOrDefault_1.md
[96]: ../SqlSet_1/SingleOrDefault_2.md
[97]: ../SqlSet_1/SingleOrDefaultAsync_2.md
[98]: ../SqlSet_1/SingleOrDefaultAsync.md
[99]: ../SqlSet_1/SingleOrDefaultAsync_1.md
[100]: ../SqlSet_1/Skip.md
[101]: ../SqlSet_1/Take.md
[102]: ../SqlSet_1/ToArray.md
[103]: ../SqlSet_1/ToArrayAsync.md
[104]: ../SqlSet_1/ToList.md
[105]: ../SqlSet_1/ToListAsync.md
[106]: ../SqlSet/ToString.md
[107]: Update.md
[108]: Update_1.md
[109]: UpdateAsync_1.md
[110]: UpdateAsync.md
[111]: UpdateRange.md
[112]: UpdateRange_1.md
[113]: UpdateRangeAsync_1.md
[114]: UpdateRangeAsync.md
[115]: ../SqlSet_1/Where.md
[116]: ../SqlSet_1/Where_1.md