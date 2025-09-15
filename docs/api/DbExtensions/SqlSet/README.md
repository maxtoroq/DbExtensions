SqlSet Class
============
Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][1] method.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet&lt;TResult>][3]  
    [DbExtensions.SqlTable][4]  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class SqlSet
```

The **SqlSet** type exposes the following members.


Properties
----------

|                    | Name            | Description                                                      |
| ------------------ | --------------- | ---------------------------------------------------------------- |
| ![Public property] | [ResultType][6] | The type of objects this set returns. This property can be null. |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                              |
| ---------------- | ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [All(OperatorStringHandler)][7]                                                 | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [All(String)][8]                                                                | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [AllAsync(OperatorStringHandler, CancellationToken)][9]                         | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [AllAsync(String, CancellationToken)][10]                                       | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [Any()][11]                                                                     | Determines whether the set contains any elements.                                                                                                                                                        |
| ![Public method] | [Any(OperatorStringHandler)][12]                                                | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [Any(String)][13]                                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [AnyAsync(CancellationToken)][14]                                               | Determines whether the set contains any elements.                                                                                                                                                        |
| ![Public method] | [AnyAsync(OperatorStringHandler, CancellationToken)][15]                        | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [AnyAsync(String, CancellationToken)][16]                                       | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [AsAsyncEnumerable][17]                                                         | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| ![Public method] | [AsEnumerable][18]                                                              | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| ![Public method] | [Cast(Type)][19]                                                                | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Cast&lt;TResult>()][20]                                                        | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Contains][21]                                                                  | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsAsync][22]                                                             | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsKey][23]                                                               | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| ![Public method] | [ContainsKeyAsync][24]                                                          | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| ![Public method] | [Count()][25]                                                                   | Returns the number of elements in the set.                                                                                                                                                               |
| ![Public method] | [Count(OperatorStringHandler)][26]                                              | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [Count(String)][27]                                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [CountAsync(CancellationToken)][28]                                             | Returns the number of elements in the set.                                                                                                                                                               |
| ![Public method] | [CountAsync(OperatorStringHandler, CancellationToken)][29]                      | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [CountAsync(String, CancellationToken)][30]                                     | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [Find][31]                                                                      | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [FindAsync][32]                                                                 | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [First()][33]                                                                   | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][34]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [First(String)][35]                                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstAsync(CancellationToken)][36]                                             | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [FirstAsync(OperatorStringHandler, CancellationToken)][37]                      | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstAsync(String, CancellationToken)][38]                                     | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstOrDefault()][39]                                                          | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][40]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefault(String)][41]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(CancellationToken)][42]                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)][43]             | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefaultAsync(String, CancellationToken)][44]                            | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [GetDefiningQuery][45]                                                          | Returns the SQL query that is the source of data for the set.                                                                                                                                            |
| ![Public method] | [GetEnumerator][46]                                                             | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| ![Public method] | [Include][47]                                                                   | Specifies the related objects to include in the query results.                                                                                                                                           |
| ![Public method] | [LongCount()][48]                                                               | Returns an [Int64][49] that represents the total number of elements in the set.                                                                                                                          |
| ![Public method] | [LongCount(OperatorStringHandler)][50]                                          | Returns an [Int64][49] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [LongCount(String)][51]                                                         | Returns an [Int64][49] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [LongCountAsync(CancellationToken)][52]                                         | Returns an [Int64][49] that represents the total number of elements in the set.                                                                                                                          |
| ![Public method] | [LongCountAsync(OperatorStringHandler, CancellationToken)][53]                  | Returns an [Int64][49] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [LongCountAsync(String, CancellationToken)][54]                                 | Returns an [Int64][49] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [OrderBy(OperatorStringHandler)][55]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [OrderBy(String)][56]                                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [Select(OperatorStringHandler)][57]                                             | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(String)][58]                                                            | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(OperatorStringHandler, Type)][59]                                       | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(String, Type)][60]                                                      | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][61]                                 | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String)][62]                                                | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][63] | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][64]                | Projects each element of the set into a new form.                                                                                                                                                        |
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
| ![Public method] | [ToList][81]                                                                    | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| ![Public method] | [ToListAsync][82]                                                               | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| ![Public method] | [ToString][83]                                                                  | Returns the SQL query of the set. <br/>(Overrides [Object.ToString()][84])                                                                                                                               |
| ![Public method] | [Where(OperatorStringHandler)][85]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| ![Public method] | [Where(String)][86]                                                             | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][87].

See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../Database/From_2.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: ../SqlSet_1/README.md
[4]: ../SqlTable/README.md
[5]: ../README.md
[6]: ResultType.md
[7]: All.md
[8]: All_1.md
[9]: AllAsync.md
[10]: AllAsync_1.md
[11]: Any.md
[12]: Any_1.md
[13]: Any_2.md
[14]: AnyAsync_2.md
[15]: AnyAsync.md
[16]: AnyAsync_1.md
[17]: AsAsyncEnumerable.md
[18]: AsEnumerable.md
[19]: Cast.md
[20]: Cast__1.md
[21]: Contains.md
[22]: ContainsAsync.md
[23]: ContainsKey.md
[24]: ContainsKeyAsync.md
[25]: Count.md
[26]: Count_1.md
[27]: Count_2.md
[28]: CountAsync_2.md
[29]: CountAsync.md
[30]: CountAsync_1.md
[31]: Find.md
[32]: FindAsync.md
[33]: First.md
[34]: First_1.md
[35]: First_2.md
[36]: FirstAsync_2.md
[37]: FirstAsync.md
[38]: FirstAsync_1.md
[39]: FirstOrDefault.md
[40]: FirstOrDefault_1.md
[41]: FirstOrDefault_2.md
[42]: FirstOrDefaultAsync_2.md
[43]: FirstOrDefaultAsync.md
[44]: FirstOrDefaultAsync_1.md
[45]: GetDefiningQuery.md
[46]: GetEnumerator.md
[47]: Include.md
[48]: LongCount.md
[49]: https://learn.microsoft.com/dotnet/api/system.int64
[50]: LongCount_1.md
[51]: LongCount_2.md
[52]: LongCountAsync_2.md
[53]: LongCountAsync.md
[54]: LongCountAsync_1.md
[55]: OrderBy.md
[56]: OrderBy_1.md
[57]: Select.md
[58]: Select_2.md
[59]: Select_1.md
[60]: Select_3.md
[61]: Select__1.md
[62]: Select__1_2.md
[63]: Select__1_1.md
[64]: Select__1_3.md
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
[83]: ToString.md
[84]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[85]: Where.md
[86]: Where_1.md
[87]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"