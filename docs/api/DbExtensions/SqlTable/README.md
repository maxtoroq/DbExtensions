SqlTable Class
==============
  A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlTable**  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlTable : SqlSet
```

The **SqlTable** type exposes the following members.


Properties
----------

                   | Name                | Description                                                                                    
------------------ | ------------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                        
![Public property] | [ResultType][8]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                            
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][9]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                   
![Public method] | [AddRange(IEnumerable&lt;Object>)][10]                                    | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [AddRange(Object[])][11]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [All][12]                                                                 | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                          
![Public method] | [Any()][13]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Any(String, Object[])][14]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                         
![Public method] | [AsEnumerable][15]                                                        | Gets all elements in the set. The query is deferred-executed. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [Cast(Type)][16]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                                                   
![Public method] | [Cast&lt;TEntity>()][17]                                                  | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                      
![Public method] | [Contains][18]                                                            | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                     
![Public method] | [ContainsKey][19]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                            
![Public method] | [Count()][20]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                               
![Public method] | [Count(String, Object[])][21]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                       
![Public method] | [Find][22]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [First()][23]                                                             | Returns the first element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][24]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][4].)                                                                                                                               
![Public method] | [FirstOrDefault()][25]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet][4].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][26]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][4].)                                                                                          
![Public method] | [GetDefiningQuery][27]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [GetEnumerator][28]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [Include][29]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet][4].)                                                                                                                                           
![Public method] | [LongCount()][30]                                                         | Returns an [Int64][31] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                          
![Public method] | [LongCount(String, Object[])][32]                                         | Returns an [Int64][31] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                 
![Public method] | [OrderBy][33]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][4].)                                                                                                                                             
![Public method] | [Refresh][34]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                             
![Public method] | [Remove][35]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                  
![Public method] | [RemoveKey][36]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                 
![Public method] | [RemoveRange(IEnumerable&lt;Object>)][37]                                 | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [RemoveRange(Object[])][38]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Select(Type, String, Object[])][39]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][40]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][41] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Single()][42]                                                            | The single element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][43]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][4].)                                                                  
![Public method] | [SingleOrDefault()][44]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet][4].)                                               
![Public method] | [SingleOrDefault(String, Object[])][45]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][4].) 
![Public method] | [Skip][46]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet][4].)                                                                                                              
![Public method] | [Take][47]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [ToArray][48]                                                             | Creates an array from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [ToList][49]                                                              | Creates a List&lt;object> from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                  
![Public method] | [ToString][50]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                        
![Public method] | [Update(Object)][51]                                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [Update(Object, Object)][52]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [UpdateRange(IEnumerable&lt;Object>)][53]                                 | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [UpdateRange(Object[])][54]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Where][55]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet][4].)                                                                                                                                                                    


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: CommandBuilder.md
[7]: ../SqlCommandBuilder_1/README.md
[8]: ../SqlSet/ResultType.md
[9]: Add.md
[10]: AddRange.md
[11]: AddRange_1.md
[12]: ../SqlSet/All.md
[13]: ../SqlSet/Any.md
[14]: ../SqlSet/Any_1.md
[15]: ../SqlSet/AsEnumerable.md
[16]: Cast.md
[17]: Cast__1.md
[18]: Contains.md
[19]: ContainsKey.md
[20]: ../SqlSet/Count.md
[21]: ../SqlSet/Count_1.md
[22]: ../SqlSet/Find.md
[23]: ../SqlSet/First.md
[24]: ../SqlSet/First_1.md
[25]: ../SqlSet/FirstOrDefault.md
[26]: ../SqlSet/FirstOrDefault_1.md
[27]: ../SqlSet/GetDefiningQuery.md
[28]: ../SqlSet/GetEnumerator.md
[29]: ../SqlSet/Include.md
[30]: ../SqlSet/LongCount.md
[31]: http://msdn.microsoft.com/en-us/library/6yy583ek
[32]: ../SqlSet/LongCount_1.md
[33]: ../SqlSet/OrderBy.md
[34]: Refresh.md
[35]: Remove.md
[36]: RemoveKey.md
[37]: RemoveRange.md
[38]: RemoveRange_1.md
[39]: ../SqlSet/Select_1.md
[40]: ../SqlSet/Select__1_1.md
[41]: ../SqlSet/Select__1.md
[42]: ../SqlSet/Single.md
[43]: ../SqlSet/Single_1.md
[44]: ../SqlSet/SingleOrDefault.md
[45]: ../SqlSet/SingleOrDefault_1.md
[46]: ../SqlSet/Skip.md
[47]: ../SqlSet/Take.md
[48]: ../SqlSet/ToArray.md
[49]: ../SqlSet/ToList.md
[50]: ../SqlSet/ToString.md
[51]: Update.md
[52]: Update_1.md
[53]: UpdateRange.md
[54]: UpdateRange_1.md
[55]: ../SqlSet/Where.md
[Public property]: ../../icons/pubproperty.gif "Public property"
[Public method]: ../../icons/pubmethod.gif "Public method"