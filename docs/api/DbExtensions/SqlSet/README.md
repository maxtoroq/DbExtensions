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
| [ResultType][7] | The type of objects this set returns. This property can be null. |


Methods
-------

| Name                                                                            | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [All(OperatorStringHandler)][8]                                                 | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [All(String)][9]                                                                | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [AllAsync(OperatorStringHandler, CancellationToken)][10]                        | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [AllAsync(String, CancellationToken)][11]                                       | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| [Any()][12]                                                                     | Determines whether the set contains any elements.                                                                                                                                                        |
| [Any(OperatorStringHandler)][13]                                                | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [Any(String)][14]                                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AnyAsync(CancellationToken)][15]                                               | Determines whether the set contains any elements.                                                                                                                                                        |
| [AnyAsync(OperatorStringHandler, CancellationToken)][16]                        | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AnyAsync(String, CancellationToken)][17]                                       | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| [AsAsyncEnumerable][18]                                                         | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| [AsEnumerable][19]                                                              | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| [Cast(Type)][20]                                                                | Casts the elements of the set to the specified type.                                                                                                                                                     |
| [Cast&lt;TResult>()][21]                                                        | Casts the elements of the set to the specified type.                                                                                                                                                     |
| [Contains][22]                                                                  | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsAsync][23]                                                             | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| [ContainsKey][24]                                                               | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| [ContainsKeyAsync][25]                                                          | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| [Count()][26]                                                                   | Returns the number of elements in the set.                                                                                                                                                               |
| [Count(OperatorStringHandler)][27]                                              | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [Count(String)][28]                                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [CountAsync(CancellationToken)][29]                                             | Returns the number of elements in the set.                                                                                                                                                               |
| [CountAsync(OperatorStringHandler, CancellationToken)][30]                      | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [CountAsync(String, CancellationToken)][31]                                     | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| [Find][32]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [FindAsync][33]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| [First()][34]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| [First(OperatorStringHandler)][35]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [First(String)][36]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(CancellationToken)][37]                                             | Returns the first element of the set.                                                                                                                                                                    |
| [FirstAsync(OperatorStringHandler, CancellationToken)][38]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstAsync(String, CancellationToken)][39]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| [FirstOrDefault()][40]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefault(OperatorStringHandler)][41]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefault(String)][42]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(CancellationToken)][43]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][44]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [FirstOrDefaultAsync(String, CancellationToken)][45]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| [GetAsyncEnumerator][46]                                                        | Returns an async enumerator that iterates through the set.                                                                                                                                               |
| [GetDefiningQuery][47]                                                          | Returns the SQL query that is the source of data for the set.                                                                                                                                            |
| [GetEnumerator][48]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| [Include][49]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| [LongCount()][50]                                                               | Returns an [Int64][51] that represents the total number of elements in the set.                                                                                                                          |
| [LongCount(OperatorStringHandler)][52]                                          | Returns an [Int64][51] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCount(String)][53]                                                         | Returns an [Int64][51] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCountAsync(CancellationToken)][54]                                         | Returns an [Int64][51] that represents the total number of elements in the set.                                                                                                                          |
| [LongCountAsync(OperatorStringHandler, CancellationToken)][55]                  | Returns an [Int64][51] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [LongCountAsync(String, CancellationToken)][56]                                 | Returns an [Int64][51] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| [OrderBy(OperatorStringHandler)][57]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [OrderBy(String)][58]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| [Select(OperatorStringHandler)][59]                                             | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(String)][60]                                                            | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(OperatorStringHandler, Type)][61]                                       | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select(String, Type)][62]                                                      | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler)][63]                                 | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(String)][64]                                                | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][65] | Projects each element of the set into a new form.                                                                                                                                                        |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][66]                | Projects each element of the set into a new form.                                                                                                                                                        |
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
| [ToList][83]                                                                    | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| [ToListAsync][84]                                                               | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| [ToString][85]                                                                  | Returns the SQL query of the set. <br/>(Overrides [Object.ToString()][86])                                                                                                                               |
| [Where(OperatorStringHandler)][87]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| [Where(String)][88]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][89].

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
[7]: ResultType.md
[8]: All.md
[9]: All_1.md
[10]: AllAsync.md
[11]: AllAsync_1.md
[12]: Any.md
[13]: Any_1.md
[14]: Any_2.md
[15]: AnyAsync_2.md
[16]: AnyAsync.md
[17]: AnyAsync_1.md
[18]: AsAsyncEnumerable.md
[19]: AsEnumerable.md
[20]: Cast.md
[21]: Cast__1.md
[22]: Contains.md
[23]: ContainsAsync.md
[24]: ContainsKey.md
[25]: ContainsKeyAsync.md
[26]: Count.md
[27]: Count_1.md
[28]: Count_2.md
[29]: CountAsync_2.md
[30]: CountAsync.md
[31]: CountAsync_1.md
[32]: Find.md
[33]: FindAsync.md
[34]: First.md
[35]: First_1.md
[36]: First_2.md
[37]: FirstAsync_2.md
[38]: FirstAsync.md
[39]: FirstAsync_1.md
[40]: FirstOrDefault.md
[41]: FirstOrDefault_1.md
[42]: FirstOrDefault_2.md
[43]: FirstOrDefaultAsync_2.md
[44]: FirstOrDefaultAsync.md
[45]: FirstOrDefaultAsync_1.md
[46]: GetAsyncEnumerator.md
[47]: GetDefiningQuery.md
[48]: GetEnumerator.md
[49]: Include.md
[50]: LongCount.md
[51]: https://learn.microsoft.com/dotnet/api/system.int64
[52]: LongCount_1.md
[53]: LongCount_2.md
[54]: LongCountAsync_2.md
[55]: LongCountAsync.md
[56]: LongCountAsync_1.md
[57]: OrderBy.md
[58]: OrderBy_1.md
[59]: Select.md
[60]: Select_2.md
[61]: Select_1.md
[62]: Select_3.md
[63]: Select__1.md
[64]: Select__1_2.md
[65]: Select__1_1.md
[66]: Select__1_3.md
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
[85]: ToString.md
[86]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[87]: Where.md
[88]: Where_1.md
[89]: https://maxtoroq.github.io/DbExtensions/docs/7/SqlSet.html