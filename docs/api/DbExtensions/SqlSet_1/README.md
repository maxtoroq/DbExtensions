SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use the [From&lt;TResult>(String)][1] method.


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

|                    | Name            | Description                                                                                        |
| ------------------ | --------------- | -------------------------------------------------------------------------------------------------- |
| ![Public property] | [ResultType][6] | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][3]) |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                              |
| ---------------- | ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [All(OperatorStringHandler)][7]                                                 | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [All(String)][8]                                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [AllAsync(OperatorStringHandler, CancellationToken)][9]                         | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [AllAsync(String, CancellationToken)][10]                                       | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [Any()][11]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Any(OperatorStringHandler)][12]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [Any(String)][13]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [AnyAsync(CancellationToken)][14]                                               | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [AnyAsync(OperatorStringHandler, CancellationToken)][15]                        | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [AnyAsync(String, CancellationToken)][16]                                       | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [AsAsyncEnumerable][17]                                                         | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| ![Public method] | [AsEnumerable][18]                                                              | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| ![Public method] | [Cast(Type)][19]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][3])                                                                                                                   |
| ![Public method] | [Cast&lt;TResult>()][20]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][3])                                                                                                                   |
| ![Public method] | [Contains(Object)][21]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][3])                                                                                                     |
| ![Public method] | [Contains(TResult)][22]                                                         | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsAsync(Object, CancellationToken)][23]                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][3])                                                                                                     |
| ![Public method] | [ContainsAsync(TResult, CancellationToken)][24]                                 | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsKey][25]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][3])                                                                                            |
| ![Public method] | [ContainsKeyAsync][26]                                                          | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][3])                                                                                            |
| ![Public method] | [Count()][27]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                                                             |
| ![Public method] | [Count(OperatorStringHandler)][28]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [Count(String)][29]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [CountAsync(CancellationToken)][30]                                             | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                                                             |
| ![Public method] | [CountAsync(OperatorStringHandler, CancellationToken)][31]                      | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [CountAsync(String, CancellationToken)][32]                                     | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [Find][33]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [FindAsync][34]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [First()][35]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][36]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [First(String)][37]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstAsync(CancellationToken)][38]                                             | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [FirstAsync(OperatorStringHandler, CancellationToken)][39]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstAsync(String, CancellationToken)][40]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstOrDefault()][41]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][42]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefault(String)][43]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(CancellationToken)][44]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][45]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(String, CancellationToken)][46]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [GetDefiningQuery][47]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][3])                                                                                                          |
| ![Public method] | [GetEnumerator][48]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| ![Public method] | [Include][49]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| ![Public method] | [LongCount()][50]                                                               | Returns an [Int64][51] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                        |
| ![Public method] | [LongCount(OperatorStringHandler)][52]                                          | Returns an [Int64][51] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [LongCount(String)][53]                                                         | Returns an [Int64][51] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [LongCountAsync(CancellationToken)][54]                                         | Returns an [Int64][51] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                        |
| ![Public method] | [LongCountAsync(OperatorStringHandler, CancellationToken)][55]                  | Returns an [Int64][51] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [LongCountAsync(String, CancellationToken)][56]                                 | Returns an [Int64][51] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [OrderBy(OperatorStringHandler)][57]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [OrderBy(String)][58]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [Select(OperatorStringHandler, Type)][59]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select(String, Type)][60]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][61]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(String)][62]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][63] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][64]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Single()][65]                                                                  | The single element of the set.                                                                                                                                                                           |
| ![Public method] | [Single(OperatorStringHandler)][66]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [Single(String)][67]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [SingleAsync(CancellationToken)][68]                                            | The single element of the set.                                                                                                                                                                           |
| ![Public method] | [SingleAsync(OperatorStringHandler, CancellationToken)][69]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [SingleAsync(String, CancellationToken)][70]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [SingleOrDefault()][71]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| ![Public method] | [SingleOrDefault(OperatorStringHandler)][72]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [SingleOrDefault(String)][73]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [SingleOrDefaultAsync(CancellationToken)][74]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| ![Public method] | [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][75]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [SingleOrDefaultAsync(String, CancellationToken)][76]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [Skip][77]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| ![Public method] | [Take][78]                                                                      | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| ![Public method] | [ToArray][79]                                                                   | Creates an array from the set.                                                                                                                                                                           |
| ![Public method] | [ToArrayAsync][80]                                                              | Creates an array from the set.                                                                                                                                                                           |
| ![Public method] | [ToList][81]                                                                    | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| ![Public method] | [ToListAsync][82]                                                               | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| ![Public method] | [ToString][83]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][3])                                                                                                                                      |
| ![Public method] | [Where(OperatorStringHandler)][84]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| ![Public method] | [Where(String)][85]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][86].

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
[47]: ../SqlSet/GetDefiningQuery.md
[48]: GetEnumerator.md
[49]: Include.md
[50]: ../SqlSet/LongCount.md
[51]: https://learn.microsoft.com/dotnet/api/system.int64
[52]: ../SqlSet/LongCount_1.md
[53]: ../SqlSet/LongCount_2.md
[54]: ../SqlSet/LongCountAsync_2.md
[55]: ../SqlSet/LongCountAsync.md
[56]: ../SqlSet/LongCountAsync_1.md
[57]: OrderBy.md
[58]: OrderBy_1.md
[59]: ../SqlSet/Select_1.md
[60]: ../SqlSet/Select_3.md
[61]: ../SqlSet/Select__1.md
[62]: ../SqlSet/Select__1_2.md
[63]: ../SqlSet/Select__1_1.md
[64]: ../SqlSet/Select__1_3.md
[65]: Single.md
[66]: Single_1.md
[67]: Single_2.md
[68]: SingleAsync_2.md
[69]: SingleAsync.md
[70]: SingleAsync_1.md
[71]: SingleOrDefault.md
[72]: SingleOrDefault_1.md
[73]: SingleOrDefault_2.md
[74]: SingleOrDefaultAsync_2.md
[75]: SingleOrDefaultAsync.md
[76]: SingleOrDefaultAsync_1.md
[77]: Skip.md
[78]: Take.md
[79]: ToArray.md
[80]: ToArrayAsync.md
[81]: ToList.md
[82]: ToListAsync.md
[83]: ../SqlSet/ToString.md
[84]: Where.md
[85]: Where_1.md
[86]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"