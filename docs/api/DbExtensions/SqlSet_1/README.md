SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use one of the [Database.From&lt;TResult>(String)][1] or [Database.FromQuery&lt;TResult>(SqlBuilder)][2] overloads.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlSet&lt;TResult>**  
      [DbExtensions.SqlTable&lt;TEntity>][5]  
  
**Namespace:** [DbExtensions][6]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class SqlSet<TResult> : SqlSet

```

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

The **SqlSet&lt;TResult>** type exposes the following members.


Properties
----------

| Name            | Description                                                                                        |
| --------------- | -------------------------------------------------------------------------------------------------- |
| [Database][7]   | The [Database][8] this set is connected to. <br/>(Inherited from [SqlSet][4])                      |
| [ResultType][9] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [All(OperatorStringHandler)][10]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [All(String)][11]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [AllAsync(OperatorStringHandler, CancellationToken)][12]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [AllAsync(String, CancellationToken)][13]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [Any()][14]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Any(OperatorStringHandler)][15]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [Any(String)][16]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AnyAsync(CancellationToken)][17]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [AnyAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AnyAsync(String, CancellationToken)][19]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AsAsyncEnumerable][20]                                                         | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [AsEnumerable][21]                                                              | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [Cast(Type)][22]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                   |
| [Cast&lt;TResult>()][23]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                   |
| [Contains(Object)][24]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                     |
| [Contains(TResult)][25]                                                         | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][26]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                     |
| [ContainsAsync(TResult, CancellationToken)][27]                                 | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsKey][28]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                            |
| [ContainsKeyAsync][29]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                            |
| [Count()][30]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [Count(OperatorStringHandler)][31]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [Count(String)][32]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [CountAsync(CancellationToken)][33]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [CountAsync(OperatorStringHandler, CancellationToken)][34]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [CountAsync(String, CancellationToken)][35]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [Find][36]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [FindAsync][37]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [First()][38]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| [First(OperatorStringHandler)][39]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [First(String)][40]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(CancellationToken)][41]                                             | Returns the first element of the set.                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][42]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(String, CancellationToken)][43]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstOrDefault()][44]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][45]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefault(String)][46]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][47]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][48]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][49]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [GetAsyncEnumerator][50]                                                        | Returns an async enumerator that iterates through the set.                                                                                                                                               |
| [GetDefiningQuery][51]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                          |
| [GetEnumerator][52]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| [Include][53]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| [LongCount()][54]                                                               | Returns an [Int64][55] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                        |
| [LongCount(OperatorStringHandler)][56]                                          | Returns an [Int64][55] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCount(String)][57]                                                         | Returns an [Int64][55] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCountAsync(CancellationToken)][58]                                         | Returns an [Int64][55] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                        |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][59]                  | Returns an [Int64][55] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCountAsync(String, CancellationToken)][60]                                 | Returns an [Int64][55] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [OrderBy(OperatorStringHandler)][61]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [OrderBy(String)][62]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [Select(OperatorStringHandler, Type)][63]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select(String, Type)][64]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler)][65]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(String)][66]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][67] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][68]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Single()][69]                                                                  | The single element of the set.                                                                                                                                                                           |
| [Single(OperatorStringHandler)][70]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [Single(String)][71]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(CancellationToken)][72]                                            | The single element of the set.                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][73]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(String, CancellationToken)][74]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleOrDefault()][75]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][76]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefault(String)][77]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(CancellationToken)][78]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][79]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(String, CancellationToken)][80]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [Skip][81]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| [Take][82]                                                                      | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| [ToArray][83]                                                                   | Creates an array from the set.                                                                                                                                                                           |
| [ToArrayAsync][84]                                                              | Creates an array from the set.                                                                                                                                                                           |
| [ToList][85]                                                                    | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToListAsync][86]                                                               | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToString][87]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [Where(OperatorStringHandler)][88]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| [Where(String)][89]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][90].

See Also
--------

#### Reference
[DbExtensions Namespace][6]  

[1]: ../Database/From__1.md
[2]: ../Database/FromQuery__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet/README.md
[5]: ../SqlTable_1/README.md
[6]: ../README.md
[7]: ../SqlSet/Database.md
[8]: ../Database/README.md
[9]: ../SqlSet/ResultType.md
[10]: ../SqlSet/All.md
[11]: ../SqlSet/All_1.md
[12]: ../SqlSet/AllAsync.md
[13]: ../SqlSet/AllAsync_1.md
[14]: ../SqlSet/Any.md
[15]: ../SqlSet/Any_1.md
[16]: ../SqlSet/Any_2.md
[17]: ../SqlSet/AnyAsync_2.md
[18]: ../SqlSet/AnyAsync.md
[19]: ../SqlSet/AnyAsync_1.md
[20]: AsAsyncEnumerable.md
[21]: AsEnumerable.md
[22]: ../SqlSet/Cast.md
[23]: ../SqlSet/Cast__1.md
[24]: ../SqlSet/Contains.md
[25]: Contains.md
[26]: ../SqlSet/ContainsAsync.md
[27]: ContainsAsync.md
[28]: ../SqlSet/ContainsKey.md
[29]: ../SqlSet/ContainsKeyAsync.md
[30]: ../SqlSet/Count.md
[31]: ../SqlSet/Count_1.md
[32]: ../SqlSet/Count_2.md
[33]: ../SqlSet/CountAsync_2.md
[34]: ../SqlSet/CountAsync.md
[35]: ../SqlSet/CountAsync_1.md
[36]: Find.md
[37]: FindAsync.md
[38]: First.md
[39]: First_1.md
[40]: First_2.md
[41]: FirstAsync_2.md
[42]: FirstAsync.md
[43]: FirstAsync_1.md
[44]: FirstOrDefault.md
[45]: FirstOrDefault_1.md
[46]: FirstOrDefault_2.md
[47]: FirstOrDefaultAsync_2.md
[48]: FirstOrDefaultAsync.md
[49]: FirstOrDefaultAsync_1.md
[50]: GetAsyncEnumerator.md
[51]: ../SqlSet/GetDefiningQuery.md
[52]: GetEnumerator.md
[53]: Include.md
[54]: ../SqlSet/LongCount.md
[55]: https://learn.microsoft.com/dotnet/api/system.int64
[56]: ../SqlSet/LongCount_1.md
[57]: ../SqlSet/LongCount_2.md
[58]: ../SqlSet/LongCountAsync_2.md
[59]: ../SqlSet/LongCountAsync.md
[60]: ../SqlSet/LongCountAsync_1.md
[61]: OrderBy.md
[62]: OrderBy_1.md
[63]: ../SqlSet/Select_1.md
[64]: ../SqlSet/Select_3.md
[65]: ../SqlSet/Select__1.md
[66]: ../SqlSet/Select__1_2.md
[67]: ../SqlSet/Select__1_1.md
[68]: ../SqlSet/Select__1_3.md
[69]: Single.md
[70]: Single_1.md
[71]: Single_2.md
[72]: SingleAsync_2.md
[73]: SingleAsync.md
[74]: SingleAsync_1.md
[75]: SingleOrDefault.md
[76]: SingleOrDefault_1.md
[77]: SingleOrDefault_2.md
[78]: SingleOrDefaultAsync_2.md
[79]: SingleOrDefaultAsync.md
[80]: SingleOrDefaultAsync_1.md
[81]: Skip.md
[82]: Take.md
[83]: ToArray.md
[84]: ToArrayAsync.md
[85]: ToList.md
[86]: ToListAsync.md
[87]: ../SqlSet/ToString.md
[88]: Where.md
[89]: Where_1.md
[90]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlSet.html