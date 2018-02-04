SqlTable Class
==============
A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlTable**  

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlTable : SqlSet, 
	ISqlTable
```

The **SqlTable** type exposes the following members.


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                            
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][6]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                   
![Public method] | [AddRange(IEnumerable&lt;Object>)][7]                                     | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [AddRange(Object[])][8]                                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [All][9]                                                                  | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                          
![Public method] | [Any()][10]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Any(String, Object[])][11]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                         
![Public method] | [AsEnumerable][12]                                                        | Gets all elements in the set. The query is deferred-executed. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [Cast(Type)][13]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                                                   
![Public method] | [Cast&lt;TEntity>()][14]                                                  | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                      
![Public method] | [Contains][15]                                                            | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                     
![Public method] | [ContainsKey][16]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                            
![Public method] | [Count()][17]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                               
![Public method] | [Count(String, Object[])][18]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                       
![Public method] | [Find][19]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [First()][20]                                                             | Returns the first element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][21]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][4].)                                                                                                                               
![Public method] | [FirstOrDefault()][22]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet][4].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][23]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][4].)                                                                                          
![Public method] | [GetDefiningQuery][24]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [GetEnumerator][25]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [Include][26]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet][4].)                                                                                                                                           
![Public method] | [LongCount()][27]                                                         | Returns an [Int64][28] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                          
![Public method] | [LongCount(String, Object[])][29]                                         | Returns an [Int64][28] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                 
![Public method] | [OrderBy][30]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][4].)                                                                                                                                             
![Public method] | [Refresh][31]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                             
![Public method] | [Remove][32]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                  
![Public method] | [RemoveKey][33]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                 
![Public method] | [RemoveRange(IEnumerable&lt;Object>)][34]                                 | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [RemoveRange(Object[])][35]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Select(Type, String, Object[])][36]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][37]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][38] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Single()][39]                                                            | The single element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][40]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][4].)                                                                  
![Public method] | [SingleOrDefault()][41]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet][4].)                                               
![Public method] | [SingleOrDefault(String, Object[])][42]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][4].) 
![Public method] | [Skip][43]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet][4].)                                                                                                              
![Public method] | [Take][44]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [ToArray][45]                                                             | Creates an array from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [ToList][46]                                                              | Creates a List&lt;object> from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                  
![Public method] | [ToString][47]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                        
![Public method] | [Update(Object)][48]                                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [Update(Object, Object)][49]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [UpdateRange(IEnumerable&lt;Object>)][50]                                 | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [UpdateRange(Object[])][51]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Where][52]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet][4].)                                                                                                                                                                    


Properties
----------

                   | Name                 | Description                                                                                    
------------------ | -------------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [CommandBuilder][53] | Gets a [SqlCommandBuilder&lt;TEntity>][54] object for the current table.                       
![Public property] | [ResultType][55]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: Add.md
[7]: AddRange.md
[8]: AddRange_1.md
[9]: ../SqlSet/All.md
[10]: ../SqlSet/Any.md
[11]: ../SqlSet/Any_1.md
[12]: ../SqlSet/AsEnumerable.md
[13]: Cast.md
[14]: Cast__1.md
[15]: Contains.md
[16]: ContainsKey.md
[17]: ../SqlSet/Count.md
[18]: ../SqlSet/Count_1.md
[19]: ../SqlSet/Find.md
[20]: ../SqlSet/First.md
[21]: ../SqlSet/First_1.md
[22]: ../SqlSet/FirstOrDefault.md
[23]: ../SqlSet/FirstOrDefault_1.md
[24]: ../SqlSet/GetDefiningQuery.md
[25]: ../SqlSet/GetEnumerator.md
[26]: ../SqlSet/Include.md
[27]: ../SqlSet/LongCount.md
[28]: http://msdn.microsoft.com/en-us/library/6yy583ek
[29]: ../SqlSet/LongCount_1.md
[30]: ../SqlSet/OrderBy.md
[31]: Refresh.md
[32]: Remove.md
[33]: RemoveKey.md
[34]: RemoveRange.md
[35]: RemoveRange_1.md
[36]: ../SqlSet/Select_1.md
[37]: ../SqlSet/Select__1_1.md
[38]: ../SqlSet/Select__1.md
[39]: ../SqlSet/Single.md
[40]: ../SqlSet/Single_1.md
[41]: ../SqlSet/SingleOrDefault.md
[42]: ../SqlSet/SingleOrDefault_1.md
[43]: ../SqlSet/Skip.md
[44]: ../SqlSet/Take.md
[45]: ../SqlSet/ToArray.md
[46]: ../SqlSet/ToList.md
[47]: ../SqlSet/ToString.md
[48]: Update.md
[49]: Update_1.md
[50]: UpdateRange.md
[51]: UpdateRange_1.md
[52]: ../SqlSet/Where.md
[53]: CommandBuilder.md
[54]: ../SqlCommandBuilder_1/README.md
[55]: ../SqlSet/ResultType.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"