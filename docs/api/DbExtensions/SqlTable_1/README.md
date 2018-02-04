SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    [DbExtensions.SqlSet][1]&lt;**TEntity**>  
      **DbExtensions.SqlTable<TEntity>**  

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlTable<TEntity> : SqlSet<TEntity>, 
	ISqlTable
where TEntity : class

```

#### Type Parameters

##### *TEntity*
The type of the entity.

The **SqlTable<TEntity>** type exposes the following members.


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                                        
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][6]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                               
![Public method] | [AddRange(IEnumerable&lt;TEntity>)][7]                                    | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [AddRange(TEntity[])][8]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [All][9]                                                                  | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                                      
![Public method] | [Any()][10]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Any(String, Object[])][11]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [AsEnumerable][12]                                                        | Gets all TResult objects in the set. The query is deferred-executed. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                     
![Public method] | [Cast(Type)][13]                                                          | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Cast&lt;T>()][14]                                                        | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Contains(Object)][15]                                                    | Checks the existance of the *entity*, using the primary key value. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                       
![Public method] | [Contains(TEntity)][16]                                                   | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                                 
![Public method] | [ContainsKey][17]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                        
![Public method] | [Count()][18]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Count(String, Object[])][19]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                   
![Public method] | [Find][20]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                            
![Public method] | [First()][21]                                                             | Returns the first element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][22]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
![Public method] | [FirstOrDefault()][23]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][24]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
![Public method] | [GetDefiningQuery][25]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [GetEnumerator][26]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Include][27]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                           
![Public method] | [LongCount()][28]                                                         | Returns an [Int64][29] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                      
![Public method] | [LongCount(String, Object[])][30]                                         | Returns an [Int64][29] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [OrderBy][31]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
![Public method] | [Refresh][32]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                         
![Public method] | [Remove][33]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                              
![Public method] | [RemoveKey][34]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                             
![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][35]                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [RemoveRange(TEntity[])][36]                                              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Select(Type, String, Object[])][37]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(String, Object[])][38]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][39] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Single()][40]                                                            | The single element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][41]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
![Public method] | [SingleOrDefault()][42]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet&lt;TResult>][1].)                                               
![Public method] | [SingleOrDefault(String, Object[])][43]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
![Public method] | [Skip][44]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                              
![Public method] | [Take][45]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                             
![Public method] | [ToArray][46]                                                             | Creates an array from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [ToList][47]                                                              | Creates a List&lt;TResult> from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                 
![Public method] | [ToString][48]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                                    
![Public method] | [Update(TEntity)][49]                                                     | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [Update(TEntity, Object)][50]                                             | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][51]                                | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [UpdateRange(TEntity[])][52]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Where][53]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    


Properties
----------

                   | Name                 | Description                                                                                    
------------------ | -------------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [CommandBuilder][54] | Gets a [SqlCommandBuilder&lt;TEntity>][55] object for the current table.                       
![Public property] | [ResultType][56]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: Add.md
[7]: AddRange.md
[8]: AddRange_1.md
[9]: ../SqlSet/All.md
[10]: ../SqlSet/Any.md
[11]: ../SqlSet/Any_1.md
[12]: ../SqlSet_1/AsEnumerable.md
[13]: ../SqlSet_1/Cast.md
[14]: ../SqlSet_1/Cast__1.md
[15]: ../SqlSet_1/Contains.md
[16]: Contains.md
[17]: ContainsKey.md
[18]: ../SqlSet/Count.md
[19]: ../SqlSet/Count_1.md
[20]: ../SqlSet_1/Find.md
[21]: ../SqlSet_1/First.md
[22]: ../SqlSet_1/First_1.md
[23]: ../SqlSet_1/FirstOrDefault.md
[24]: ../SqlSet_1/FirstOrDefault_1.md
[25]: ../SqlSet/GetDefiningQuery.md
[26]: ../SqlSet_1/GetEnumerator.md
[27]: ../SqlSet_1/Include.md
[28]: ../SqlSet/LongCount.md
[29]: http://msdn.microsoft.com/en-us/library/6yy583ek
[30]: ../SqlSet/LongCount_1.md
[31]: ../SqlSet_1/OrderBy.md
[32]: Refresh.md
[33]: Remove.md
[34]: RemoveKey.md
[35]: RemoveRange.md
[36]: RemoveRange_1.md
[37]: ../SqlSet/Select_1.md
[38]: ../SqlSet/Select__1_1.md
[39]: ../SqlSet/Select__1.md
[40]: ../SqlSet_1/Single.md
[41]: ../SqlSet_1/Single_1.md
[42]: ../SqlSet_1/SingleOrDefault.md
[43]: ../SqlSet_1/SingleOrDefault_1.md
[44]: ../SqlSet_1/Skip.md
[45]: ../SqlSet_1/Take.md
[46]: ../SqlSet_1/ToArray.md
[47]: ../SqlSet_1/ToList.md
[48]: ../SqlSet/ToString.md
[49]: Update.md
[50]: Update_1.md
[51]: UpdateRange.md
[52]: UpdateRange_1.md
[53]: ../SqlSet_1/Where.md
[54]: CommandBuilder.md
[55]: ../SqlCommandBuilder_1/README.md
[56]: ../SqlSet/ResultType.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"