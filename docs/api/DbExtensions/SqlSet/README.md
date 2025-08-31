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

|                  | Name                                                                        | Description                                                                                                                                                                                              |
| ---------------- | --------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [All(SqlFragmentHandler)][7]                                                | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [All(String)][8]                                                            | Determines whether all elements of the set satisfy a condition.                                                                                                                                          |
| ![Public method] | [Any()][9]                                                                  | Determines whether the set contains any elements.                                                                                                                                                        |
| ![Public method] | [Any(SqlFragmentHandler)][10]                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [Any(String)][11]                                                           | Determines whether any element of the set satisfies a condition.                                                                                                                                         |
| ![Public method] | [AsEnumerable][12]                                                          | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            |
| ![Public method] | [Cast(Type)][13]                                                            | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Cast&lt;TResult>()][14]                                                    | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Contains][15]                                                              | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsKey][16]                                                           | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              |
| ![Public method] | [Count()][17]                                                               | Returns the number of elements in the set.                                                                                                                                                               |
| ![Public method] | [Count(SqlFragmentHandler)][18]                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [Count(String)][19]                                                         | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       |
| ![Public method] | [Find][20]                                                                  | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [First()][21]                                                               | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [First(SqlFragmentHandler)][22]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [First(String)][23]                                                         | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstOrDefault()][24]                                                      | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefault(SqlFragmentHandler)][25]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefault(String)][26]                                                | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [GetDefiningQuery][27]                                                      | Returns the SQL query that is the source of data for the set.                                                                                                                                            |
| ![Public method] | [GetEnumerator][28]                                                         | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| ![Public method] | [Include][29]                                                               | Specifies the related objects to include in the query results.                                                                                                                                           |
| ![Public method] | [LongCount()][30]                                                           | Returns an [Int64][31] that represents the total number of elements in the set.                                                                                                                          |
| ![Public method] | [LongCount(SqlFragmentHandler)][32]                                         | Returns an [Int64][31] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [LongCount(String)][33]                                                     | Returns an [Int64][31] that represents how many elements in the set satisfy a condition.                                                                                                                 |
| ![Public method] | [OrderBy(SqlFragmentHandler)][34]                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [OrderBy(String)][35]                                                       | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [Select(SqlFragmentHandler)][36]                                            | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(String)][37]                                                        | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(SqlFragmentHandler, Type)][38]                                      | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select(String, Type)][39]                                                  | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler)][40]                                | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String)][41]                                            | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler, Func&lt;IDataRecord, TResult>)][42] | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;IDataRecord, TResult>)][43]             | Projects each element of the set into a new form.                                                                                                                                                        |
| ![Public method] | [Single()][44]                                                              | The single element of the set.                                                                                                                                                                           |
| ![Public method] | [Single(SqlFragmentHandler)][45]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [Single(String)][46]                                                        | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [SingleOrDefault()][47]                                                     | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| ![Public method] | [SingleOrDefault(SqlFragmentHandler)][48]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [SingleOrDefault(String)][49]                                               | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [Skip][50]                                                                  | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| ![Public method] | [Take][51]                                                                  | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| ![Public method] | [ToArray][52]                                                               | Creates an array from the set.                                                                                                                                                                           |
| ![Public method] | [ToList][53]                                                                | Creates a List&lt;object> from the set.                                                                                                                                                                  |
| ![Public method] | [ToString][54]                                                              | Returns the SQL query of the set. <br/>(Overrides [Object.ToString()][55])                                                                                                                               |
| ![Public method] | [Where(SqlFragmentHandler)][56]                                             | Filters the set based on a predicate.                                                                                                                                                                    |
| ![Public method] | [Where(String)][57]                                                         | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][58].

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
[9]: Any.md
[10]: Any_1.md
[11]: Any_2.md
[12]: AsEnumerable.md
[13]: Cast.md
[14]: Cast__1.md
[15]: Contains.md
[16]: ContainsKey.md
[17]: Count.md
[18]: Count_1.md
[19]: Count_2.md
[20]: Find.md
[21]: First.md
[22]: First_1.md
[23]: First_2.md
[24]: FirstOrDefault.md
[25]: FirstOrDefault_1.md
[26]: FirstOrDefault_2.md
[27]: GetDefiningQuery.md
[28]: GetEnumerator.md
[29]: Include.md
[30]: LongCount.md
[31]: https://learn.microsoft.com/dotnet/api/system.int64
[32]: LongCount_1.md
[33]: LongCount_2.md
[34]: OrderBy.md
[35]: OrderBy_1.md
[36]: Select.md
[37]: Select_2.md
[38]: Select_1.md
[39]: Select_3.md
[40]: Select__1.md
[41]: Select__1_2.md
[42]: Select__1_1.md
[43]: Select__1_3.md
[44]: Single.md
[45]: Single_1.md
[46]: Single_2.md
[47]: SingleOrDefault.md
[48]: SingleOrDefault_1.md
[49]: SingleOrDefault_2.md
[50]: Skip.md
[51]: Take.md
[52]: ToArray.md
[53]: ToList.md
[54]: ToString.md
[55]: https://learn.microsoft.com/dotnet/api/system.object.tostring
[56]: Where.md
[57]: Where_1.md
[58]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"