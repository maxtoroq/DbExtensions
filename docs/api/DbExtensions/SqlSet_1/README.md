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

|                  | Name                                                                         | Description                                                                                                                                                                                              |
| ---------------- | ---------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [All(SqlFragmentHandler)][7]                                                 | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [All(String)][8]                                                             | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                                        |
| ![Public method] | [Any()][9]                                                                   | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Any(SqlFragmentHandler)][10]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [Any(String)][11]                                                            | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][3])                                                                                                       |
| ![Public method] | [AsEnumerable][12]                                                           | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     |
| ![Public method] | [Cast(Type)][13]                                                             | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Cast&lt;T>()][14]                                                           | Casts the elements of the set to the specified type.                                                                                                                                                     |
| ![Public method] | [Contains(Object)][15]                                                       | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [Contains(TResult)][16]                                                      | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       |
| ![Public method] | [ContainsKey][17]                                                            | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][3])                                                                                            |
| ![Public method] | [Count()][18]                                                                | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                                                             |
| ![Public method] | [Count(SqlFragmentHandler)][19]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [Count(String)][20]                                                          | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                                     |
| ![Public method] | [Find][21]                                                                   | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            |
| ![Public method] | [First()][22]                                                                | Returns the first element of the set.                                                                                                                                                                    |
| ![Public method] | [First(SqlFragmentHandler)][23]                                              | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [First(String)][24]                                                          | Returns the first element in the set that satisfies a specified condition.                                                                                                                               |
| ![Public method] | [FirstOrDefault()][25]                                                       | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                |
| ![Public method] | [FirstOrDefault(SqlFragmentHandler)][26]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [FirstOrDefault(String)][27]                                                 | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          |
| ![Public method] | [GetDefiningQuery][28]                                                       | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][3])                                                                                                          |
| ![Public method] | [GetEnumerator][29]                                                          | Returns an enumerator that iterates through the set.                                                                                                                                                     |
| ![Public method] | [Include][30]                                                                | Specifies the related objects to include in the query results.                                                                                                                                           |
| ![Public method] | [LongCount()][31]                                                            | Returns an [Int64][32] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][3])                                                                                        |
| ![Public method] | [LongCount(SqlFragmentHandler)][33]                                          | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [LongCount(String)][34]                                                      | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][3])                                                                               |
| ![Public method] | [OrderBy(SqlFragmentHandler)][35]                                            | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [OrderBy(String)][36]                                                        | Sorts the elements of the set according to the *columnList*.                                                                                                                                             |
| ![Public method] | [Select(SqlFragmentHandler, Type)][37]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select(String, Type)][38]                                                   | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler)][39]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(String)][40]                                             | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler, Func&lt;DbDataReader, TResult>)][41] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][42]             | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][3])                                                                                                                      |
| ![Public method] | [Single()][43]                                                               | The single element of the set.                                                                                                                                                                           |
| ![Public method] | [Single(SqlFragmentHandler)][44]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [Single(String)][45]                                                         | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  |
| ![Public method] | [SingleOrDefault()][46]                                                      | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| ![Public method] | [SingleOrDefault(SqlFragmentHandler)][47]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [SingleOrDefault(String)][48]                                                | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| ![Public method] | [Skip][49]                                                                   | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              |
| ![Public method] | [Take][50]                                                                   | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             |
| ![Public method] | [ToArray][51]                                                                | Creates an array from the set.                                                                                                                                                                           |
| ![Public method] | [ToList][52]                                                                 | Creates a List&lt;TResult> from the set.                                                                                                                                                                 |
| ![Public method] | [ToString][53]                                                               | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][3])                                                                                                                                      |
| ![Public method] | [Where(SqlFragmentHandler)][54]                                              | Filters the set based on a predicate.                                                                                                                                                                    |
| ![Public method] | [Where(String)][55]                                                          | Filters the set based on a predicate.                                                                                                                                                                    |


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][56].

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
[9]: ../SqlSet/Any.md
[10]: ../SqlSet/Any_1.md
[11]: ../SqlSet/Any_2.md
[12]: AsEnumerable.md
[13]: Cast.md
[14]: Cast__1.md
[15]: Contains.md
[16]: Contains_1.md
[17]: ../SqlSet/ContainsKey.md
[18]: ../SqlSet/Count.md
[19]: ../SqlSet/Count_1.md
[20]: ../SqlSet/Count_2.md
[21]: Find.md
[22]: First.md
[23]: First_1.md
[24]: First_2.md
[25]: FirstOrDefault.md
[26]: FirstOrDefault_1.md
[27]: FirstOrDefault_2.md
[28]: ../SqlSet/GetDefiningQuery.md
[29]: GetEnumerator.md
[30]: Include.md
[31]: ../SqlSet/LongCount.md
[32]: https://learn.microsoft.com/dotnet/api/system.int64
[33]: ../SqlSet/LongCount_1.md
[34]: ../SqlSet/LongCount_2.md
[35]: OrderBy.md
[36]: OrderBy_1.md
[37]: ../SqlSet/Select_1.md
[38]: ../SqlSet/Select_3.md
[39]: ../SqlSet/Select__1.md
[40]: ../SqlSet/Select__1_2.md
[41]: ../SqlSet/Select__1_1.md
[42]: ../SqlSet/Select__1_3.md
[43]: Single.md
[44]: Single_1.md
[45]: Single_2.md
[46]: SingleOrDefault.md
[47]: SingleOrDefault_1.md
[48]: SingleOrDefault_2.md
[49]: Skip.md
[50]: Take.md
[51]: ToArray.md
[52]: ToList.md
[53]: ../SqlSet/ToString.md
[54]: Where.md
[55]: Where_1.md
[56]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"