SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use one of the [Database.From&lt;TResult>(String)][1] overloads.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [DbExtensions.SqlSet][3]  
    **DbExtensions.SqlSet&lt;TResult>**  
      [DbExtensions.SqlTable&lt;TEntity>][4]  
  
**Namespace:** [DbExtensions][5]  
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
| [ResultType][6] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][3]) |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [All(OperatorStringHandler)][7]                                                 | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| [All(String)][8]                                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| [AllAsync(OperatorStringHandler, CancellationToken)][9]                         | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| [AllAsync(String, CancellationToken)][10]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| [Any()][11]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Any(OperatorStringHandler)][12]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| [Any(String)][13]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| [AnyAsync(CancellationToken)][14]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [AnyAsync(OperatorStringHandler, CancellationToken)][15]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| [AnyAsync(String, CancellationToken)][16]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| [AsAsyncEnumerable][17]                                                         | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [AsEnumerable][18]                                                              | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| [Cast(Type)][19]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][3])                                                                                                                   |
| [Cast&lt;TResult>()][20]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][3])                                                                                                                   |
| [Contains(Object)][21]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][3])                                                                                                     |
| [Contains(TResult)][22]                                                         | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsAsync(Object, CancellationToken)][23]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][3])                                                                                                     |
| [ContainsAsync(TResult, CancellationToken)][24]                                 | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsKey][25]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][3])                                                                                            |
| [ContainsKeyAsync][26]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][3])                                                                                            |
| [Count()][27]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                                                             |
| [Count(OperatorStringHandler)][28]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| [Count(String)][29]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| [CountAsync(CancellationToken)][30]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                                                             |
| [CountAsync(OperatorStringHandler, CancellationToken)][31]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| [CountAsync(String, CancellationToken)][32]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| [Find][33]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [FindAsync][34]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [First()][35]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| [First(OperatorStringHandler)][36]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [First(String)][37]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(CancellationToken)][38]                                             | Returns the first element of the set.                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][39]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(String, CancellationToken)][40]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstOrDefault()][41]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][42]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefault(String)][43]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][44]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][45]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][46]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [GetAsyncEnumerator][47]                                                        | Returns an async enumerator that iterates through the set.                                                                                                                                               |
| [GetDefiningQuery][48]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][3])                                                                                                          |
| [GetEnumerator][49]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| [Include][50]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| [LongCount()][51]                                                               | Returns an [Int64][52] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                        |
| [LongCount(OperatorStringHandler)][53]                                          | Returns an [Int64][52] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| [LongCount(String)][54]                                                         | Returns an [Int64][52] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| [LongCountAsync(CancellationToken)][55]                                         | Returns an [Int64][52] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                        |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][56]                  | Returns an [Int64][52] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| [LongCountAsync(String, CancellationToken)][57]                                 | Returns an [Int64][52] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| [OrderBy(OperatorStringHandler)][58]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [OrderBy(String)][59]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [Select(OperatorStringHandler, Type)][60]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Select(String, Type)][61]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler)][62]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Select&lt;TResult>(String)][63]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][64] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][65]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| [Single()][66]                                                                  | The single element of the set.                                                                                                                                                                           |
| [Single(OperatorStringHandler)][67]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [Single(String)][68]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(CancellationToken)][69]                                            | The single element of the set.                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][70]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(String, CancellationToken)][71]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleOrDefault()][72]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][73]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefault(String)][74]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(CancellationToken)][75]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][76]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(String, CancellationToken)][77]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [Skip][78]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| [Take][79]                                                                      | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| [ToArray][80]                                                                   | Creates an array from the set.                                                                                                                                                                           |
| [ToArrayAsync][81]                                                              | Creates an array from the set.                                                                                                                                                                           |
| [ToList][82]                                                                    | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToListAsync][83]                                                               | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| [ToString][84]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][3])                                                                                                                                      |
| [Where(OperatorStringHandler)][85]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| [Where(String)][86]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][87].

See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../Database/From__1_2.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: ../SqlSet/README.md
[4]: ../SqlTable_1/README.md
[5]: ../README.md
[6]: ../SqlSet/ResultType.md
[7]: ../SqlSet/All.md
[8]: ../SqlSet/All_1.md
[9]: ../SqlSet/AllAsync.md
[10]: ../SqlSet/AllAsync_1.md
[11]: ../SqlSet/Any.md
[12]: ../SqlSet/Any_1.md
[13]: ../SqlSet/Any_2.md
[14]: ../SqlSet/AnyAsync_2.md
[15]: ../SqlSet/AnyAsync.md
[16]: ../SqlSet/AnyAsync_1.md
[17]: AsAsyncEnumerable.md
[18]: AsEnumerable.md
[19]: ../SqlSet/Cast.md
[20]: ../SqlSet/Cast__1.md
[21]: ../SqlSet/Contains.md
[22]: Contains.md
[23]: ../SqlSet/ContainsAsync.md
[24]: ContainsAsync.md
[25]: ../SqlSet/ContainsKey.md
[26]: ../SqlSet/ContainsKeyAsync.md
[27]: ../SqlSet/Count.md
[28]: ../SqlSet/Count_1.md
[29]: ../SqlSet/Count_2.md
[30]: ../SqlSet/CountAsync_2.md
[31]: ../SqlSet/CountAsync.md
[32]: ../SqlSet/CountAsync_1.md
[33]: Find.md
[34]: FindAsync.md
[35]: First.md
[36]: First_1.md
[37]: First_2.md
[38]: FirstAsync_2.md
[39]: FirstAsync.md
[40]: FirstAsync_1.md
[41]: FirstOrDefault.md
[42]: FirstOrDefault_1.md
[43]: FirstOrDefault_2.md
[44]: FirstOrDefaultAsync_2.md
[45]: FirstOrDefaultAsync.md
[46]: FirstOrDefaultAsync_1.md
[47]: GetAsyncEnumerator.md
[48]: ../SqlSet/GetDefiningQuery.md
[49]: GetEnumerator.md
[50]: Include.md
[51]: ../SqlSet/LongCount.md
[52]: https://learn.microsoft.com/dotnet/api/system.int64
[53]: ../SqlSet/LongCount_1.md
[54]: ../SqlSet/LongCount_2.md
[55]: ../SqlSet/LongCountAsync_2.md
[56]: ../SqlSet/LongCountAsync.md
[57]: ../SqlSet/LongCountAsync_1.md
[58]: OrderBy.md
[59]: OrderBy_1.md
[60]: ../SqlSet/Select_1.md
[61]: ../SqlSet/Select_3.md
[62]: ../SqlSet/Select__1.md
[63]: ../SqlSet/Select__1_2.md
[64]: ../SqlSet/Select__1_1.md
[65]: ../SqlSet/Select__1_3.md
[66]: Single.md
[67]: Single_1.md
[68]: Single_2.md
[69]: SingleAsync_2.md
[70]: SingleAsync.md
[71]: SingleAsync_1.md
[72]: SingleOrDefault.md
[73]: SingleOrDefault_1.md
[74]: SingleOrDefault_2.md
[75]: SingleOrDefaultAsync_2.md
[76]: SingleOrDefaultAsync.md
[77]: SingleOrDefaultAsync_1.md
[78]: Skip.md
[79]: Take.md
[80]: ToArray.md
[81]: ToArrayAsync.md
[82]: ToList.md
[83]: ToListAsync.md
[84]: ../SqlSet/ToString.md
[85]: Where.md
[86]: Where_1.md
[87]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html