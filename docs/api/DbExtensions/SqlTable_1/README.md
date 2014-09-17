SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for entities mapped using the [System.Data.Linq.Mapping][2] API. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][3] method.


Inheritance Hierarchy
---------------------
[System.Object][4]  
  [DbExtensions.SqlSet][5]  
    [DbExtensions.SqlSet][1]&lt;**TEntity**>  
      **DbExtensions.SqlTable<TEntity>**  

**Namespace:** [DbExtensions][6]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlTable<TEntity> : SqlSet<TEntity>, 
	ISqlTable 
where TEntity : class
```


Type Parameters
---------------

#### *TEntity*
The type of the entity.

The **SqlTable<TEntity>** type exposes the following members.


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                                        
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][7]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][8] to false.                                                     
![Public method] | [AddRange(IEnumerable&lt;TEntity>)][9]                                    | Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][8] to false.                                                   
![Public method] | [AddRange(TEntity[])][10]                                                 | Recursively executes INSERT commands for the specified *entities* and all its one-to-one and one-to-many associations. Recursion can be disabled by setting [EnableInsertRecursion][8] to false.                                                   
![Public method] | [All(String)][11]                                                         | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][5].)                                                                                                                                                      
![Public method] | [All(String, Object[])][12]                                               | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][5].)                                                                                                                                                      
![Public method] | [Any()][13]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Any(String)][14]                                                         | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][5].)                                                                                                                                                     
![Public method] | [Any(String, Object[])][15]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][5].)                                                                                                                                                     
![Public method] | [AsEnumerable][16]                                                        | Gets all TResult objects in the set. The query is deferred-executed. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                     
![Public method] | [Cast(Type)][17]                                                          | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Cast&lt;T>()][18]                                                        | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Contains(TEntity)][19]                                                   | Checks the existance of the *entity*, using the primary key value. Version members are ignored.                                                                                                                                                    
![Public method] | [Contains(TEntity, Boolean)][20]                                          | Checks the existance of the *entity*, using the primary key and optionally version column.                                                                                                                                                         
![Public method] | [ContainsKey][21]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                        
![Public method] | [Count()][22]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][5].)                                                                                                                                                                           
![Public method] | [Count(String)][23]                                                       | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][5].)                                                                                                                                   
![Public method] | [Count(String, Object[])][24]                                             | Gets the number of elements in the set that matches the *predicate*. (Inherited from [SqlSet][5].)                                                                                                                                                 
![Public method] | [Equals][25]                                                              | Returns whether the specified set is equal to the current set. (Inherited from [SqlSet][5].)                                                                                                                                                       
![Public method] | [Find][26]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                      
![Public method] | [First()][27]                                                             | Returns the first element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
![Public method] | [First(String)][28]                                                       | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
![Public method] | [First(String, Object[])][29]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
![Public method] | [FirstOrDefault()][30]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                
![Public method] | [FirstOrDefault(String)][31]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
![Public method] | [FirstOrDefault(String, Object[])][32]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
![Public method] | [GetDefiningQuery][33]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][5].)                                                                                                                                                        
![Public method] | [GetEnumerator][34]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [GetHashCode][35]                                                         | Returns the hash function for the current set. (Inherited from [SqlSet][5].)                                                                                                                                                                       
![Public method] | [GetType][36]                                                             | Gets the type for the current set. (Inherited from [SqlSet][5].)                                                                                                                                                                                   
![Public method] | [LongCount()][37]                                                         | Returns an [Int64][38] that represents the total number of elements in the set. (Inherited from [SqlSet][5].)                                                                                                                                      
![Public method] | [LongCount(String)][39]                                                   | Returns an [Int64][38] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][5].)                                                                                                                             
![Public method] | [LongCount(String, Object[])][40]                                         | Returns an [Int64][38] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][5].)                                                                                                                             
![Public method] | [OrderBy(String)][41]                                                     | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
![Public method] | [OrderBy(String, Object[])][42]                                           | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
![Public method] | [Refresh][43]                                                             | Sets all mapped members of *entity* to their most current persisted value.                                                                                                                                                                         
![Public method] | [Remove(TEntity)][44]                                                     | Executes a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                           
![Public method] | [Remove(TEntity, ConcurrencyConflictPolicy)][46]                          | Executes a DELETE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                                          
![Public method] | [RemoveKey(Object)][47]                                                   | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][45].                                                                                                          
![Public method] | [RemoveKey(Object, ConcurrencyConflictPolicy)][48]                        | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                                                        
![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][49]                                | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                          
![Public method] | [RemoveRange(TEntity[])][50]                                              | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                          
![Public method] | [RemoveRange(IEnumerable&lt;TEntity>, ConcurrencyConflictPolicy)][51]     | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                                        
![Public method] | [RemoveRange(TEntity[], ConcurrencyConflictPolicy)][52]                   | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                                        
![Public method] | [Select(Type, String)][53]                                                | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Select(Type, String, Object[])][54]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(String)][55]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][56]           | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(String, Object[])][57]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][58] | Projects each element of the set into a new form. (Inherited from [SqlSet][5].)                                                                                                                                                                    
![Public method] | [Single()][59]                                                            | The single element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [Single(String)][60]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
![Public method] | [Single(String, Object[])][61]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
![Public method] | [SingleOrDefault()][62]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet&lt;TResult>][1].)                                               
![Public method] | [SingleOrDefault(String)][63]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
![Public method] | [SingleOrDefault(String, Object[])][64]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
![Public method] | [Skip][65]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                              
![Public method] | [Take][66]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                             
![Public method] | [ToArray][67]                                                             | Creates an array from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [ToList][68]                                                              | Creates a List&lt;TResult> from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                 
![Public method] | [ToString][69]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][5].)                                                                                                                                                                                    
![Public method] | [Update(TEntity)][70]                                                     | Executes an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                          
![Public method] | [Update(TEntity, ConcurrencyConflictPolicy)][71]                          | Executes an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                                         
![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][72]                                | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                          
![Public method] | [UpdateRange(TEntity[])][73]                                              | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][45].                                                                                                                                          
![Public method] | [UpdateRange(IEnumerable&lt;TEntity>, ConcurrencyConflictPolicy)][74]     | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                                         
![Public method] | [UpdateRange(TEntity[], ConcurrencyConflictPolicy)][75]                   | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                                         
![Public method] | [Where(String)][76]                                                       | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
![Public method] | [Where(String, Object[])][77]                                             | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    


Extension Methods
-----------------

                           | Name                              | Description                                                                                               
-------------------------- | --------------------------------- | --------------------------------------------------------------------------------------------------------- 
![Public Extension Method] | [Find&lt;TEntity>][78]            | Gets the entity whose primary key matches the *id* parameter. (Defined by [Extensions][79].)              
![Public Extension Method] | [Include(String)][80]             | Overloaded. Specifies the related objects to include in the query results. (Defined by [Extensions][79].) 
![Public Extension Method] | [Include&lt;TEntity>(String)][81] | Overloaded. Specifies the related objects to include in the query results. (Defined by [Extensions][79].) 


Properties
----------

                   | Name      | Description                                                              
------------------ | --------- | ------------------------------------------------------------------------ 
![Public property] | [SQL][82] | Gets a [SqlCommandBuilder&lt;TEntity>][83] object for the current table. 


See Also
--------
[DbExtensions Namespace][6]  
[Database.Table&lt;TEntity>()][3]  

[1]: ../SqlSet_1/README.md
[2]: http://msdn.microsoft.com/en-us/library/bb515105
[3]: ../Database/Table__1.md
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: ../SqlSet/README.md
[6]: ../README.md
[7]: Add.md
[8]: ../DatabaseConfiguration/EnableInsertRecursion.md
[9]: AddRange.md
[10]: AddRange_1.md
[11]: ../SqlSet/All.md
[12]: ../SqlSet/All_1.md
[13]: ../SqlSet/Any.md
[14]: ../SqlSet/Any_1.md
[15]: ../SqlSet/Any_2.md
[16]: ../SqlSet_1/AsEnumerable.md
[17]: ../SqlSet_1/Cast.md
[18]: ../SqlSet_1/Cast__1.md
[19]: Contains.md
[20]: Contains_1.md
[21]: ContainsKey.md
[22]: ../SqlSet/Count.md
[23]: ../SqlSet/Count_1.md
[24]: ../SqlSet/Count_2.md
[25]: ../SqlSet/Equals.md
[26]: Find.md
[27]: ../SqlSet_1/First.md
[28]: ../SqlSet_1/First_1.md
[29]: ../SqlSet_1/First_2.md
[30]: ../SqlSet_1/FirstOrDefault.md
[31]: ../SqlSet_1/FirstOrDefault_1.md
[32]: ../SqlSet_1/FirstOrDefault_2.md
[33]: ../SqlSet/GetDefiningQuery.md
[34]: ../SqlSet_1/GetEnumerator.md
[35]: ../SqlSet/GetHashCode.md
[36]: ../SqlSet/GetType.md
[37]: ../SqlSet/LongCount.md
[38]: http://msdn.microsoft.com/en-us/library/6yy583ek
[39]: ../SqlSet/LongCount_1.md
[40]: ../SqlSet/LongCount_2.md
[41]: ../SqlSet_1/OrderBy.md
[42]: ../SqlSet_1/OrderBy_1.md
[43]: Refresh.md
[44]: Remove.md
[45]: ../ConcurrencyConflictPolicy/README.md
[46]: Remove_1.md
[47]: RemoveKey.md
[48]: RemoveKey_1.md
[49]: RemoveRange.md
[50]: RemoveRange_2.md
[51]: RemoveRange_1.md
[52]: RemoveRange_3.md
[53]: ../SqlSet/Select_2.md
[54]: ../SqlSet/Select_3.md
[55]: ../SqlSet/Select__1_2.md
[56]: ../SqlSet/Select__1.md
[57]: ../SqlSet/Select__1_3.md
[58]: ../SqlSet/Select__1_1.md
[59]: ../SqlSet_1/Single.md
[60]: ../SqlSet_1/Single_1.md
[61]: ../SqlSet_1/Single_2.md
[62]: ../SqlSet_1/SingleOrDefault.md
[63]: ../SqlSet_1/SingleOrDefault_1.md
[64]: ../SqlSet_1/SingleOrDefault_2.md
[65]: ../SqlSet_1/Skip.md
[66]: ../SqlSet_1/Take.md
[67]: ../SqlSet_1/ToArray.md
[68]: ../SqlSet_1/ToList.md
[69]: ../SqlSet/ToString.md
[70]: Update.md
[71]: Update_1.md
[72]: UpdateRange.md
[73]: UpdateRange_2.md
[74]: UpdateRange_1.md
[75]: UpdateRange_3.md
[76]: ../SqlSet_1/Where.md
[77]: ../SqlSet_1/Where_1.md
[78]: ../Extensions/Find__1.md
[79]: ../Extensions/README.md
[80]: ../Extensions/Include.md
[81]: ../Extensions/Include__1.md
[82]: SQL.md
[83]: ../SqlCommandBuilder_1/README.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public Extension Method]: ../../_icons/pubextension.gif "Public Extension Method"
[Public property]: ../../_icons/pubproperty.gif "Public property"