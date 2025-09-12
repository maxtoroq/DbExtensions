SqlTable Class
==============
A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlTable**  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class SqlTable : SqlSet
```

The **SqlTable** type exposes the following members.


Properties
----------

|                    | Name                | Description                                                                                        |
| ------------------ | ------------------- | -------------------------------------------------------------------------------------------------- |
| ![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                            |
| ![Public property] | [Name][8]           | Gets the name of the table.                                                                        |
| ![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                                                                |
| ---------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                       |
| ![Public method] | [AddRange(IEnumerable&lt;Object>)][11]                                          | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [AddRange(Object[])][12]                                                        | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                   |
| ![Public method] | [All(OperatorStringHandler)][13]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [All(String)][14]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [Any()][15]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Any(OperatorStringHandler)][16]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [Any(String)][17]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                         |
| ![Public method] | [AsEnumerable][18]                                                              | Gets all elements in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [Cast(Type)][19]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Cast&lt;TResult>()][20]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Contains][21]                                                                  | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet][4])                                                                                                                                       |
| ![Public method] | [ContainsKey][22]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                              |
| ![Public method] | [Count()][23]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                               |
| ![Public method] | [Count(OperatorStringHandler)][24]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [Count(String)][25]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                       |
| ![Public method] | [Find][26]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [First()][27]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][28]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [First(String)][29]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet][4])                                                                                                                               |
| ![Public method] | [FirstOrDefault()][30]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet][4])                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][31]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [FirstOrDefault(String)][32]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet][4])                                                                                          |
| ![Public method] | [GetDefiningQuery][33]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                            |
| ![Public method] | [GetEnumerator][34]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Include][35]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet][4])                                                                                                                                           |
| ![Public method] | [LongCount()][36]                                                               | Returns an [Int64][37] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                          |
| ![Public method] | [LongCount(OperatorStringHandler)][38]                                          | Returns an [Int64][37] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [LongCount(String)][39]                                                         | Returns an [Int64][37] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                 |
| ![Public method] | [OrderBy(OperatorStringHandler)][40]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| ![Public method] | [OrderBy(String)][41]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet][4])                                                                                                                                             |
| ![Public method] | [Refresh][42]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                 |
| ![Public method] | [Remove][43]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                      |
| ![Public method] | [RemoveKey][44]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                     |
| ![Public method] | [RemoveRange(IEnumerable&lt;Object>)][45]                                       | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [RemoveRange(Object[])][46]                                                     | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [Select(OperatorStringHandler, Type)][47]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select(String, Type)][48]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][49]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String)][50]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][51] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][52]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [Single()][53]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [Single(OperatorStringHandler)][54]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [Single(String)][55]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet][4])                                                                  |
| ![Public method] | [SingleOrDefault()][56]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet][4])                                               |
| ![Public method] | [SingleOrDefault(OperatorStringHandler)][57]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [SingleOrDefault(String)][58]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet][4]) |
| ![Public method] | [Skip][59]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet][4])                                                                                                              |
| ![Public method] | [Take][60]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [ToArray][61]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [ToList][62]                                                                    | Creates a List&lt;object> from the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                  |
| ![Public method] | [ToString][63]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                        |
| ![Public method] | [Update(Object)][64]                                                            | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [Update(Object, Object)][65]                                                    | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRange(IEnumerable&lt;Object>)][66]                                       | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [UpdateRange(Object[])][67]                                                     | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                     |
| ![Public method] | [Where(OperatorStringHandler)][68]                                              | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Where(String)][69]                                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: CommandBuilder.md
[7]: ../SqlCommandBuilder_1/README.md
[8]: Name.md
[9]: ../SqlSet/ResultType.md
[10]: Add.md
[11]: AddRange.md
[12]: AddRange_1.md
[13]: ../SqlSet/All.md
[14]: ../SqlSet/All_1.md
[15]: ../SqlSet/Any.md
[16]: ../SqlSet/Any_1.md
[17]: ../SqlSet/Any_2.md
[18]: ../SqlSet/AsEnumerable.md
[19]: ../SqlSet/Cast.md
[20]: ../SqlSet/Cast__1.md
[21]: ../SqlSet/Contains.md
[22]: ../SqlSet/ContainsKey.md
[23]: ../SqlSet/Count.md
[24]: ../SqlSet/Count_1.md
[25]: ../SqlSet/Count_2.md
[26]: ../SqlSet/Find.md
[27]: ../SqlSet/First.md
[28]: ../SqlSet/First_1.md
[29]: ../SqlSet/First_2.md
[30]: ../SqlSet/FirstOrDefault.md
[31]: ../SqlSet/FirstOrDefault_1.md
[32]: ../SqlSet/FirstOrDefault_2.md
[33]: ../SqlSet/GetDefiningQuery.md
[34]: ../SqlSet/GetEnumerator.md
[35]: ../SqlSet/Include.md
[36]: ../SqlSet/LongCount.md
[37]: https://learn.microsoft.com/dotnet/api/system.int64
[38]: ../SqlSet/LongCount_1.md
[39]: ../SqlSet/LongCount_2.md
[40]: ../SqlSet/OrderBy.md
[41]: ../SqlSet/OrderBy_1.md
[42]: Refresh.md
[43]: Remove.md
[44]: RemoveKey.md
[45]: RemoveRange.md
[46]: RemoveRange_1.md
[47]: ../SqlSet/Select_1.md
[48]: ../SqlSet/Select_3.md
[49]: ../SqlSet/Select__1.md
[50]: ../SqlSet/Select__1_2.md
[51]: ../SqlSet/Select__1_1.md
[52]: ../SqlSet/Select__1_3.md
[53]: ../SqlSet/Single.md
[54]: ../SqlSet/Single_1.md
[55]: ../SqlSet/Single_2.md
[56]: ../SqlSet/SingleOrDefault.md
[57]: ../SqlSet/SingleOrDefault_1.md
[58]: ../SqlSet/SingleOrDefault_2.md
[59]: ../SqlSet/Skip.md
[60]: ../SqlSet/Take.md
[61]: ../SqlSet/ToArray.md
[62]: ../SqlSet/ToList.md
[63]: ../SqlSet/ToString.md
[64]: Update.md
[65]: Update_1.md
[66]: UpdateRange.md
[67]: UpdateRange_1.md
[68]: ../SqlSet/Where.md
[69]: ../SqlSet/Where_1.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"