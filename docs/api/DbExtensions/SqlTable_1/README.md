SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    [DbExtensions.SqlSet][1]&lt;**TEntity**>  
      **DbExtensions.SqlTable&lt;TEntity>**  
  
**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class SqlTable<TEntity> : SqlSet<TEntity>
where TEntity : class

```

#### Type Parameters

##### *TEntity*
The type of the entity.

The **SqlTable&lt;TEntity>** type exposes the following members.


Properties
----------

|                    | Name                | Description                                                                                        |
| ------------------ | ------------------- | -------------------------------------------------------------------------------------------------- |
| ![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                            |
| ![Public property] | [Name][8]           | Gets the name of the table.                                                                        |
| ![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. <br/>(Inherited from [SqlSet][4]) |


Methods
-------

|                  | Name                                                                            | Description                                                                                                                                                                                                                                            |
| ---------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ![Public method] | [Add][10]                                                                       | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                                   |
| ![Public method] | [AddRange(IEnumerable&lt;TEntity>)][11]                                         | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [AddRange(TEntity[])][12]                                                       | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                               |
| ![Public method] | [All(OperatorStringHandler)][13]                                                | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [All(String)][14]                                                               | Determines whether all elements of the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                      |
| ![Public method] | [Any()][15]                                                                     | Determines whether the set contains any elements. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Any(OperatorStringHandler)][16]                                                | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [Any(String)][17]                                                               | Determines whether any element of the set satisfies a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                                     |
| ![Public method] | [AsEnumerable][18]                                                              | Gets all TResult objects in the set. The query is deferred-executed. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                     |
| ![Public method] | [Cast(Type)][19]                                                                | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| ![Public method] | [Cast&lt;TResult>()][20]                                                        | Casts the elements of the set to the specified type. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                 |
| ![Public method] | [Contains(Object)][21]                                                          | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| ![Public method] | [Contains(TResult)][22]                                                         | Checks the existance of the *entity*, using the primary key value. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                       |
| ![Public method] | [ContainsKey][23]                                                               | Checks the existance of an entity whose primary matches the *id* parameter. <br/>(Inherited from [SqlSet][4])                                                                                                                                          |
| ![Public method] | [Count()][24]                                                                   | Returns the number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                           |
| ![Public method] | [Count(OperatorStringHandler)][25]                                              | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [Count(String)][26]                                                             | Returns a number that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                                   |
| ![Public method] | [Find][27]                                                                      | Gets the entity whose primary key matches the *id* parameter. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                            |
| ![Public method] | [First()][28]                                                                   | Returns the first element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| ![Public method] | [First(OperatorStringHandler)][29]                                              | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [First(String)][30]                                                             | Returns the first element in the set that satisfies a specified condition. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                               |
| ![Public method] | [FirstOrDefault()][31]                                                          | Returns the first element of the set, or a default value if the set contains no elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                |
| ![Public method] | [FirstOrDefault(OperatorStringHandler)][32]                                     | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [FirstOrDefault(String)][33]                                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                          |
| ![Public method] | [GetDefiningQuery][34]                                                          | Returns the SQL query that is the source of data for the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                        |
| ![Public method] | [GetEnumerator][35]                                                             | Returns an enumerator that iterates through the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                     |
| ![Public method] | [Include][36]                                                                   | Specifies the related objects to include in the query results. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                           |
| ![Public method] | [LongCount()][37]                                                               | Returns an [Int64][38] that represents the total number of elements in the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                      |
| ![Public method] | [LongCount(OperatorStringHandler)][39]                                          | Returns an [Int64][38] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [LongCount(String)][40]                                                         | Returns an [Int64][38] that represents how many elements in the set satisfy a condition. <br/>(Inherited from [SqlSet][4])                                                                                                                             |
| ![Public method] | [OrderBy(OperatorStringHandler)][41]                                            | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| ![Public method] | [OrderBy(String)][42]                                                           | Sorts the elements of the set according to the *columnList*. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                             |
| ![Public method] | [Refresh][43]                                                                   | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                             |
| ![Public method] | [Remove][44]                                                                    | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                                  |
| ![Public method] | [RemoveKey][45]                                                                 | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                                 |
| ![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][46]                                      | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [RemoveRange(TEntity[])][47]                                                    | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [Select(OperatorStringHandler, Type)][48]                                       | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select(String, Type)][49]                                                      | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler)][50]                                 | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(String)][51]                                                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][52] | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][53]                | Projects each element of the set into a new form. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                    |
| ![Public method] | [Single()][54]                                                                  | The single element of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [Single(OperatorStringHandler)][55]                                             | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [Single(String)][56]                                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                  |
| ![Public method] | [SingleOrDefault()][57]                                                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                               |
| ![Public method] | [SingleOrDefault(OperatorStringHandler)][58]                                    | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [SingleOrDefault(String)][59]                                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. <br/>(Inherited from [SqlSet&lt;TResult>][1]) |
| ![Public method] | [Skip][60]                                                                      | Bypasses a specified number of elements in the set and then returns the remaining elements. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                              |
| ![Public method] | [Take][61]                                                                      | Returns a specified number of contiguous elements from the start of the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                             |
| ![Public method] | [ToArray][62]                                                                   | Creates an array from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                           |
| ![Public method] | [ToList][63]                                                                    | Creates a List&lt;TResult> from the set. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                 |
| ![Public method] | [ToString][64]                                                                  | Returns the SQL query of the set. <br/>(Inherited from [SqlSet][4])                                                                                                                                                                                    |
| ![Public method] | [Update(TEntity)][65]                                                           | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [Update(TEntity, Object)][66]                                                   | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][67]                                      | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [UpdateRange(TEntity[])][68]                                                    | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                                 |
| ![Public method] | [Where(OperatorStringHandler)][69]                                              | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |
| ![Public method] | [Where(String)][70]                                                             | Filters the set based on a predicate. <br/>(Inherited from [SqlSet&lt;TResult>][1])                                                                                                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
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
[18]: ../SqlSet_1/AsEnumerable.md
[19]: ../SqlSet/Cast.md
[20]: ../SqlSet/Cast__1.md
[21]: ../SqlSet_1/Contains.md
[22]: ../SqlSet_1/Contains_1.md
[23]: ../SqlSet/ContainsKey.md
[24]: ../SqlSet/Count.md
[25]: ../SqlSet/Count_1.md
[26]: ../SqlSet/Count_2.md
[27]: ../SqlSet_1/Find.md
[28]: ../SqlSet_1/First.md
[29]: ../SqlSet_1/First_1.md
[30]: ../SqlSet_1/First_2.md
[31]: ../SqlSet_1/FirstOrDefault.md
[32]: ../SqlSet_1/FirstOrDefault_1.md
[33]: ../SqlSet_1/FirstOrDefault_2.md
[34]: ../SqlSet/GetDefiningQuery.md
[35]: ../SqlSet_1/GetEnumerator.md
[36]: ../SqlSet_1/Include.md
[37]: ../SqlSet/LongCount.md
[38]: https://learn.microsoft.com/dotnet/api/system.int64
[39]: ../SqlSet/LongCount_1.md
[40]: ../SqlSet/LongCount_2.md
[41]: ../SqlSet_1/OrderBy.md
[42]: ../SqlSet_1/OrderBy_1.md
[43]: Refresh.md
[44]: Remove.md
[45]: RemoveKey.md
[46]: RemoveRange.md
[47]: RemoveRange_1.md
[48]: ../SqlSet/Select_1.md
[49]: ../SqlSet/Select_3.md
[50]: ../SqlSet/Select__1.md
[51]: ../SqlSet/Select__1_2.md
[52]: ../SqlSet/Select__1_1.md
[53]: ../SqlSet/Select__1_3.md
[54]: ../SqlSet_1/Single.md
[55]: ../SqlSet_1/Single_1.md
[56]: ../SqlSet_1/Single_2.md
[57]: ../SqlSet_1/SingleOrDefault.md
[58]: ../SqlSet_1/SingleOrDefault_1.md
[59]: ../SqlSet_1/SingleOrDefault_2.md
[60]: ../SqlSet_1/Skip.md
[61]: ../SqlSet_1/Take.md
[62]: ../SqlSet_1/ToArray.md
[63]: ../SqlSet_1/ToList.md
[64]: ../SqlSet/ToString.md
[65]: Update.md
[66]: Update_1.md
[67]: UpdateRange.md
[68]: UpdateRange_1.md
[69]: ../SqlSet_1/Where.md
[70]: ../SqlSet_1/Where_1.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"