SqlSet Class
============
Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use one of the [Database.From][1] or [Database.FromQuery][2] overloads.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet&lt;TResult>][4]  
    [DbExtensions.SqlTable][5]  
  
**Namespace:** [DbExtensions][6]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class SqlSet
```

The **SqlSet** type exposes the following members.


Properties
----------

| Name            | Description                                                      |
| --------------- | ---------------------------------------------------------------- |
| [Database][7]   | The [Database][8] this set is connected to.                      |
| [ResultType][9] | The type of objects this set returns. This property can be null. |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [All(OperatorStringHandler)][10]                                                | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [All(String)][11]                                                               | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [AllAsync(OperatorStringHandler, CancellationToken)][12]                        | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [AllAsync(String, CancellationToken)][13]                                       | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [Any()][14]                                                                     | Determines whether the set contains any elements.                                                                                                                                                        |
| [Any(OperatorStringHandler)][15]                                                | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [Any(String)][16]                                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AnyAsync(CancellationToken)][17]                                               | Determines whether the set contains any elements.                                                                                                                                                        |
| [AnyAsync(OperatorStringHandler, CancellationToken)][18]                        | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AnyAsync(String, CancellationToken)][19]                                       | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AsAsyncEnumerable][20]                                                         | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| [AsEnumerable][21]                                                              | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| [Cast(Type)][22]                                                                | Casts the elements of the set to the specified type.                                                                                                                                                     |
| [Cast&lt;TResult>()][23]                                                        | Casts the elements of the set to the specified type.                                                                                                                                                     |
| [Contains][24]                                                                  | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsAsync][25]                                                             | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsKey][26]                                                               | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| [ContainsKeyAsync][27]                                                          | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| [Count()][28]                                                                   | Returns the number of elements in the set.                                                                                                                                                               |
| [Count(OperatorStringHandler)][29]                                              | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [Count(String)][30]                                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [CountAsync(CancellationToken)][31]                                             | Returns the number of elements in the set.                                                                                                                                                               |
| [CountAsync(OperatorStringHandler, CancellationToken)][32]                      | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [CountAsync(String, CancellationToken)][33]                                     | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
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
| [GetDefiningQuery][49]                                                          | Returns the SQL query that is the source of data for the set.                                                                                                                                            |
| [GetEnumerator][50]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| [Include][51]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| [IncludeMany][52]                                                               | Specifies which collections to include in the query results.                                                                                                                                             |
| [LongCount()][53]                                                               | Returns an [Int64][54] that represents the total number of elements in the set.                                                                                                                          |
| [LongCount(OperatorStringHandler)][55]                                          | Returns an [Int64][54] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCount(String)][56]                                                         | Returns an [Int64][54] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCountAsync(CancellationToken)][57]                                         | Returns an [Int64][54] that represents the total number of elements in the set.                                                                                                                          |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][58]                  | Returns an [Int64][54] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCountAsync(String, CancellationToken)][59]                                 | Returns an [Int64][54] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [OrderBy(OperatorStringHandler)][60]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [OrderBy(String)][61]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [Select(OperatorStringHandler)][62]                                             | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(String)][63]                                                            | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(OperatorStringHandler, Type)][64]                                       | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(String, Type)][65]                                                      | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler)][66]                                 | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(String)][67]                                                | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][68] | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][69]                | Projects each element of the set into a new form.                                                                                                                                                        |
| [Single()][70]                                                                  | The single element of the set.                                                                                                                                                                           |
| [Single(OperatorStringHandler)][71]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [Single(String)][72]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(CancellationToken)][73]                                            | The single element of the set.                                                                                                                                                                           |
| [SingleAsync(OperatorStringHandler, CancellationToken)][74]                     | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleAsync(String, CancellationToken)][75]                                    | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| [SingleOrDefault()][76]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefault(OperatorStringHandler)][77]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefault(String)][78]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(CancellationToken)][79]                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][80]            | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(String, CancellationToken)][81]                           | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [Skip][82]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| [Take][83]                                                                      | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| [ToArray][84]                                                                   | Creates an array from the set.                                                                                                                                                                           |
| [ToArrayAsync][85]                                                              | Creates an array from the set.                                                                                                                                                                           |
| [ToList][86]                                                                    | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| [ToListAsync][87]                                                               | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| [ToString][88]                                                                  | Returns the SQL query of the set. <br/>(Overrides [Object.ToString()][89])                                                                                                                               |
| [Where(OperatorStringHandler)][90]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| [Where(String)][91]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][92].

See Also
--------

#### Reference
[DbExtensions Namespace][6]  

[1]: ../Database/From.md
[2]: ../Database/FromQuery.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet_1/README.md
[5]: ../SqlTable/README.md
[6]: ../README.md
[7]: Database.md
[8]: ../Database/README.md
[9]: ResultType.md
[10]: All.md
[11]: All_1.md
[12]: AllAsync.md
[13]: AllAsync_1.md
[14]: Any.md
[15]: Any_1.md
[16]: Any_2.md
[17]: AnyAsync_2.md
[18]: AnyAsync.md
[19]: AnyAsync_1.md
[20]: AsAsyncEnumerable.md
[21]: AsEnumerable.md
[22]: Cast.md
[23]: Cast__1.md
[24]: Contains.md
[25]: ContainsAsync.md
[26]: ContainsKey.md
[27]: ContainsKeyAsync.md
[28]: Count.md
[29]: Count_1.md
[30]: Count_2.md
[31]: CountAsync_2.md
[32]: CountAsync.md
[33]: CountAsync_1.md
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
[49]: GetDefiningQuery.md
[50]: GetEnumerator.md
[51]: Include.md
[52]: IncludeMany.md
[53]: LongCount.md
[54]: https://learn.microsoft.com/dotnet/api/system.int64
[55]: LongCount_1.md
[56]: LongCount_2.md
[57]: LongCountAsync_2.md
[58]: LongCountAsync.md
[59]: LongCountAsync_1.md
[60]: OrderBy.md
[61]: OrderBy_1.md
[62]: Select.md
[63]: Select_2.md
[64]: Select_1.md
[65]: Select_3.md
[66]: Select__1.md
[67]: Select__1_2.md
[68]: Select__1_1.md
[69]: Select__1_3.md
[70]: Single.md
[71]: Single_1.md
[72]: Single_2.md
[73]: SingleAsync_2.md
[74]: SingleAsync.md
[75]: SingleAsync_1.md
[76]: SingleOrDefault.md
[77]: SingleOrDefault_1.md
[78]: SingleOrDefault_2.md
[79]: SingleOrDefaultAsync_2.md
[80]: SingleOrDefaultAsync.md
[81]: SingleOrDefaultAsync_1.md
[82]: Skip.md
[83]: Take.md
[84]: ToArray.md
[85]: ToArrayAsync.md
[86]: ToList.md
[87]: ToListAsync.md
[88]: ToString.md
[89]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[90]: Where.md
[91]: Where_1.md
[92]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlSet.html