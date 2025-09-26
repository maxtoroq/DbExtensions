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
| [ResultType][7] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [All(OperatorStringHandler)][8]                                                 | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [All(String)][9]                                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [AllAsync(OperatorStringHandler, CancellationToken)][10]                        | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [AllAsync(String, CancellationToken)][11]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                        |
| [Any()][12]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Any(OperatorStringHandler)][13]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [Any(String)][14]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AnyAsync(CancellationToken)][15]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [AnyAsync(OperatorStringHandler, CancellationToken)][16]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AnyAsync(String, CancellationToken)][17]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                       |
| [AsAsyncEnumerable][18]                                                         | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [AsEnumerable][19]                                                              | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [Cast(Type)][20]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                   |
| [Cast&lt;TResult>()][21]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                   |
| [Contains(Object)][22]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                     |
| [Contains(TResult)][23]                                                         | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][24]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                     |
| [ContainsAsync(TResult, CancellationToken)][25]                                 | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsKey][26]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                            |
| [ContainsKeyAsync][27]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                            |
| [Count()][28]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [Count(OperatorStringHandler)][29]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [Count(String)][30]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [CountAsync(CancellationToken)][31]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| [CountAsync(OperatorStringHandler, CancellationToken)][32]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [CountAsync(String, CancellationToken)][33]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                     |
| [Find][34]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [FindAsync][35]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [First()][36]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| [First(OperatorStringHandler)][37]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [First(String)][38]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(CancellationToken)][39]                                             | Returns the first element of the set.                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][40]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(String, CancellationToken)][41]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstOrDefault()][42]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][43]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefault(String)][44]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][45]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][46]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][47]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [GetAsyncEnumerator][48]                                                        | Returns an async enumerator that iterates through the set.                                                                                                                                               |
| [GetDefiningQuery][49]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                          |
| [GetEnumerator][50]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| [Include][51]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| [LongCount()][52]                                                               | Returns an [Int64][53] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                        |
| [LongCount(OperatorStringHandler)][54]                                          | Returns an [Int64][53] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCount(String)][55]                                                         | Returns an [Int64][53] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCountAsync(CancellationToken)][56]                                         | Returns an [Int64][53] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                        |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][57]                  | Returns an [Int64][53] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [LongCountAsync(String, CancellationToken)][58]                                 | Returns an [Int64][53] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                               |
| [OrderBy(OperatorStringHandler)][59]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [OrderBy(String)][60]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [Select(OperatorStringHandler, Type)][61]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select(String, Type)][62]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler)][63]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(String)][64]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][65] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][66]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                      |
| [Single()][67]                                                                  | The single element of the set.                                                                                                                                                                           |
| [Single(OperatorStringHandler)][68]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [Single(String)][69]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(CancellationToken)][70]                                            | The single element of the set.                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][71]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(String, CancellationToken)][72]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleOrDefault()][73]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][74]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefault(String)][75]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(CancellationToken)][76]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][77]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(String, CancellationToken)][78]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [Skip][79]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| [Take][80]                                                                      | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| [ToArray][81]                                                                   | Creates an array from the set.                                                                                                                                                                           |
| [ToArrayAsync][82]                                                              | Creates an array from the set.                                                                                                                                                                           |
| [ToList][83]                                                                    | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToListAsync][84]                                                               | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToString][85]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| [Where(OperatorStringHandler)][86]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| [Where(String)][87]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][88].

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
[7]: ../SqlSet/ResultType.md
[8]: ../SqlSet/All.md
[9]: ../SqlSet/All_1.md
[10]: ../SqlSet/AllAsync.md
[11]: ../SqlSet/AllAsync_1.md
[12]: ../SqlSet/Any.md
[13]: ../SqlSet/Any_1.md
[14]: ../SqlSet/Any_2.md
[15]: ../SqlSet/AnyAsync_2.md
[16]: ../SqlSet/AnyAsync.md
[17]: ../SqlSet/AnyAsync_1.md
[18]: AsAsyncEnumerable.md
[19]: AsEnumerable.md
[20]: ../SqlSet/Cast.md
[21]: ../SqlSet/Cast__1.md
[22]: ../SqlSet/Contains.md
[23]: Contains.md
[24]: ../SqlSet/ContainsAsync.md
[25]: ContainsAsync.md
[26]: ../SqlSet/ContainsKey.md
[27]: ../SqlSet/ContainsKeyAsync.md
[28]: ../SqlSet/Count.md
[29]: ../SqlSet/Count_1.md
[30]: ../SqlSet/Count_2.md
[31]: ../SqlSet/CountAsync_2.md
[32]: ../SqlSet/CountAsync.md
[33]: ../SqlSet/CountAsync_1.md
[34]: Find.md
[35]: FindAsync.md
[36]: First.md
[37]: First_1.md
[38]: First_2.md
[39]: FirstAsync_2.md
[40]: FirstAsync.md
[41]: FirstAsync_1.md
[42]: FirstOrDefault.md
[43]: FirstOrDefault_1.md
[44]: FirstOrDefault_2.md
[45]: FirstOrDefaultAsync_2.md
[46]: FirstOrDefaultAsync.md
[47]: FirstOrDefaultAsync_1.md
[48]: GetAsyncEnumerator.md
[49]: ../SqlSet/GetDefiningQuery.md
[50]: GetEnumerator.md
[51]: Include.md
[52]: ../SqlSet/LongCount.md
[53]: https://learn.microsoft.com/dotnet/api/system.int64
[54]: ../SqlSet/LongCount_1.md
[55]: ../SqlSet/LongCount_2.md
[56]: ../SqlSet/LongCountAsync_2.md
[57]: ../SqlSet/LongCountAsync.md
[58]: ../SqlSet/LongCountAsync_1.md
[59]: OrderBy.md
[60]: OrderBy_1.md
[61]: ../SqlSet/Select_1.md
[62]: ../SqlSet/Select_3.md
[63]: ../SqlSet/Select__1.md
[64]: ../SqlSet/Select__1_2.md
[65]: ../SqlSet/Select__1_1.md
[66]: ../SqlSet/Select__1_3.md
[67]: Single.md
[68]: Single_1.md
[69]: Single_2.md
[70]: SingleAsync_2.md
[71]: SingleAsync.md
[72]: SingleAsync_1.md
[73]: SingleOrDefault.md
[74]: SingleOrDefault_1.md
[75]: SingleOrDefault_2.md
[76]: SingleOrDefaultAsync_2.md
[77]: SingleOrDefaultAsync.md
[78]: SingleOrDefaultAsync_1.md
[79]: Skip.md
[80]: Take.md
[81]: ToArray.md
[82]: ToArrayAsync.md
[83]: ToList.md
[84]: ToListAsync.md
[85]: ../SqlSet/ToString.md
[86]: Where.md
[87]: Where_1.md
[88]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlSet.html