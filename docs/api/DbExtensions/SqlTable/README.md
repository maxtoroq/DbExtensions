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
![Public method] | [Add][6]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][7] to false.                                         
![Public method] | [AddRange(IEnumerable&lt;Object>)][8]                                     | Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][7] to false.                                       
![Public method] | [AddRange(Object[])][9]                                                   | Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][7] to false.                                       
![Public method] | [All(String)][10]                                                         | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                          
![Public method] | [All(String, Object[])][11]                                               | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                          
![Public method] | [Any()][12]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Any(String)][13]                                                         | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                         
![Public method] | [Any(String, Object[])][14]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                         
![Public method] | [AsEnumerable][15]                                                        | Gets all elements in the set. The query is deferred-executed. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [Cast(Type)][16]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                                                   
![Public method] | [Cast&lt;TEntity>()][17]                                                  | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                      
![Public method] | [Contains(Object)][18]                                                    | Checks the existance of the *entity*, using the primary key value. Version members are ignored.                                                                                                                                        
![Public method] | [Contains(Object, Boolean)][19]                                           | Checks the existance of the *entity*, using the primary key and optionally version column.                                                                                                                                             
![Public method] | [ContainsKey][20]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                            
![Public method] | [Count()][21]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                               
![Public method] | [Count(String)][22]                                                       | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                       
![Public method] | [Count(String, Object[])][23]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                       
![Public method] | [Find][24]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                          
![Public method] | [First()][25]                                                             | Returns the first element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [First(String)][26]                                                       | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][4].)                                                                                                                               
![Public method] | [First(String, Object[])][27]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][4].)                                                                                                                               
![Public method] | [FirstOrDefault()][28]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet][4].)                                                                                                                
![Public method] | [FirstOrDefault(String)][29]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][4].)                                                                                          
![Public method] | [FirstOrDefault(String, Object[])][30]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][4].)                                                                                          
![Public method] | [GetDefiningQuery][31]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [GetEnumerator][32]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [LongCount()][33]                                                         | Returns an [Int64][34] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                          
![Public method] | [LongCount(String)][35]                                                   | Returns an [Int64][34] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                 
![Public method] | [LongCount(String, Object[])][36]                                         | Returns an [Int64][34] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                 
![Public method] | [OrderBy(String)][37]                                                     | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][4].)                                                                                                                                             
![Public method] | [OrderBy(String, Object[])][38]                                           | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][4].)                                                                                                                                             
![Public method] | [Refresh][39]                                                             | Sets all mapped members of *entity* to their most current persisted value.                                                                                                                                                             
![Public method] | [Remove(Object)][40]                                                      | Executes a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                               
![Public method] | [Remove(Object, ConcurrencyConflictPolicy)][42]                           | Executes a DELETE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                              
![Public method] | [RemoveKey(Object)][43]                                                   | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][41].                                                                                              
![Public method] | [RemoveKey(Object, ConcurrencyConflictPolicy)][44]                        | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                                            
![Public method] | [RemoveRange(IEnumerable&lt;Object>)][45]                                 | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                              
![Public method] | [RemoveRange(Object[])][46]                                               | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                              
![Public method] | [RemoveRange(IEnumerable&lt;Object>, ConcurrencyConflictPolicy)][47]      | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                            
![Public method] | [RemoveRange(Object[], ConcurrencyConflictPolicy)][48]                    | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                            
![Public method] | [Select(Type, String)][49]                                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select(Type, String, Object[])][50]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String)][51]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][52]           | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][53]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][54] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Single()][55]                                                            | The single element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Single(String)][56]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][4].)                                                                  
![Public method] | [Single(String, Object[])][57]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][4].)                                                                  
![Public method] | [SingleOrDefault()][58]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet][4].)                                               
![Public method] | [SingleOrDefault(String)][59]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][4].) 
![Public method] | [SingleOrDefault(String, Object[])][60]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][4].) 
![Public method] | [Skip][61]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet][4].)                                                                                                              
![Public method] | [Take][62]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [ToArray][63]                                                             | Creates an array from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [ToList][64]                                                              | Creates a List&lt;object> from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                  
![Public method] | [ToString][65]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                        
![Public method] | [Update(Object)][66]                                                      | Executes an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                              
![Public method] | [Update(Object, ConcurrencyConflictPolicy)][67]                           | Executes an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                             
![Public method] | [UpdateRange(IEnumerable&lt;Object>)][68]                                 | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                              
![Public method] | [UpdateRange(Object[])][69]                                               | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][41].                                                                                                                              
![Public method] | [UpdateRange(IEnumerable&lt;Object>, ConcurrencyConflictPolicy)][70]      | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                             
![Public method] | [UpdateRange(Object[], ConcurrencyConflictPolicy)][71]                    | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                             
![Public method] | [Where(String)][72]                                                       | Filters the set based on a predicate. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Where(String, Object[])][73]                                             | Filters the set based on a predicate. (Inherited from [SqlSet][4].)                                                                                                                                                                    


Extension Methods
-----------------

                           | Name          | Description                                                                                   
-------------------------- | ------------- | --------------------------------------------------------------------------------------------- 
![Public Extension Method] | [Include][74] | Specifies the related objects to include in the query results. (Defined by [Extensions][75].) 


Properties
----------

                   | Name      | Description                                                              
------------------ | --------- | ------------------------------------------------------------------------ 
![Public property] | [SQL][76] | Gets a [SqlCommandBuilder&lt;TEntity>][77] object for the current table. 


See Also
--------

#### Reference
[DbExtensions Namespace][5]  
[Database.Table(Type)][2]  

[1]: ../SqlTable_1/README.md
[2]: ../Database/Table_1.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: Add.md
[7]: ../DatabaseConfiguration/EnableInsertRecursion.md
[8]: AddRange.md
[9]: AddRange_1.md
[10]: ../SqlSet/All.md
[11]: ../SqlSet/All_1.md
[12]: ../SqlSet/Any.md
[13]: ../SqlSet/Any_1.md
[14]: ../SqlSet/Any_2.md
[15]: ../SqlSet/AsEnumerable.md
[16]: Cast.md
[17]: Cast__1.md
[18]: Contains.md
[19]: Contains_1.md
[20]: ContainsKey.md
[21]: ../SqlSet/Count.md
[22]: ../SqlSet/Count_1.md
[23]: ../SqlSet/Count_2.md
[24]: Find.md
[25]: ../SqlSet/First.md
[26]: ../SqlSet/First_1.md
[27]: ../SqlSet/First_2.md
[28]: ../SqlSet/FirstOrDefault.md
[29]: ../SqlSet/FirstOrDefault_1.md
[30]: ../SqlSet/FirstOrDefault_2.md
[31]: ../SqlSet/GetDefiningQuery.md
[32]: ../SqlSet/GetEnumerator.md
[33]: ../SqlSet/LongCount.md
[34]: http://msdn.microsoft.com/en-us/library/6yy583ek
[35]: ../SqlSet/LongCount_1.md
[36]: ../SqlSet/LongCount_2.md
[37]: ../SqlSet/OrderBy.md
[38]: ../SqlSet/OrderBy_1.md
[39]: Refresh.md
[40]: Remove.md
[41]: ../ConcurrencyConflictPolicy/README.md
[42]: Remove_1.md
[43]: RemoveKey.md
[44]: RemoveKey_1.md
[45]: RemoveRange.md
[46]: RemoveRange_2.md
[47]: RemoveRange_1.md
[48]: RemoveRange_3.md
[49]: ../SqlSet/Select_2.md
[50]: ../SqlSet/Select_3.md
[51]: ../SqlSet/Select__1_2.md
[52]: ../SqlSet/Select__1.md
[53]: ../SqlSet/Select__1_3.md
[54]: ../SqlSet/Select__1_1.md
[55]: ../SqlSet/Single.md
[56]: ../SqlSet/Single_1.md
[57]: ../SqlSet/Single_2.md
[58]: ../SqlSet/SingleOrDefault.md
[59]: ../SqlSet/SingleOrDefault_1.md
[60]: ../SqlSet/SingleOrDefault_2.md
[61]: ../SqlSet/Skip.md
[62]: ../SqlSet/Take.md
[63]: ../SqlSet/ToArray.md
[64]: ../SqlSet/ToList.md
[65]: ../SqlSet/ToString.md
[66]: Update.md
[67]: Update_1.md
[68]: UpdateRange.md
[69]: UpdateRange_2.md
[70]: UpdateRange_1.md
[71]: UpdateRange_3.md
[72]: ../SqlSet/Where.md
[73]: ../SqlSet/Where_1.md
[74]: ../Extensions/Include.md
[75]: ../Extensions/README.md
[76]: SQL.md
[77]: ../SqlCommandBuilder_1/README.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public Extension Method]: ../../_icons/pubextension.gif "Public Extension Method"
[Public property]: ../../_icons/pubproperty.gif "Public property"