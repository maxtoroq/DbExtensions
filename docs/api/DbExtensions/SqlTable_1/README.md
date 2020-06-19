SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides CRUD (Create, Read, Update, Delete) operations for annotated classes. This class cannot be instantiated, to get an instance use the [Table&lt;TEntity>()][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    [DbExtensions.SqlSet][1]&lt;**TEntity**>  
      **DbExtensions.SqlTable&lt;TEntity>**  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

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

                   | Name                | Description                                                                                    
------------------ | ------------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                        
![Public property] | [ResultType][8]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                                        
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][9]                                                                  | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                               
![Public method] | [AddRange(IEnumerable&lt;TEntity>)][10]                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [AddRange(TEntity[])][11]                                                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [All][12]                                                                 | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                                      
![Public method] | [Any()][13]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Any(String, Object[])][14]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [AsEnumerable][15]                                                        | Gets all TResult objects in the set. The query is deferred-executed. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                     
![Public method] | [Cast(Type)][16]                                                          | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Cast&lt;T>()][17]                                                        | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Contains(Object)][18]                                                    | Checks the existance of the *entity*, using the primary key value. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                       
![Public method] | [Contains(TEntity)][19]                                                   | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                                 
![Public method] | [ContainsKey][20]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                        
![Public method] | [Count()][21]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Count(String, Object[])][22]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                   
![Public method] | [Find][23]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                            
![Public method] | [First()][24]                                                             | Returns the first element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][25]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
![Public method] | [FirstOrDefault()][26]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][27]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
![Public method] | [GetDefiningQuery][28]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [GetEnumerator][29]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Include][30]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                           
![Public method] | [LongCount()][31]                                                         | Returns an [Int64][32] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                      
![Public method] | [LongCount(String, Object[])][33]                                         | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [OrderBy][34]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
![Public method] | [Refresh][35]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                         
![Public method] | [Remove][36]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                              
![Public method] | [RemoveKey][37]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                             
![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][38]                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [RemoveRange(TEntity[])][39]                                              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Select(Type, String, Object[])][40]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(String, Object[])][41]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][42] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Single()][43]                                                            | The single element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][44]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
![Public method] | [SingleOrDefault()][45]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet&lt;TResult>][1].)                                               
![Public method] | [SingleOrDefault(String, Object[])][46]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
![Public method] | [Skip][47]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                              
![Public method] | [Take][48]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                             
![Public method] | [ToArray][49]                                                             | Creates an array from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [ToList][50]                                                              | Creates a List&lt;TResult> from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                 
![Public method] | [ToString][51]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                                    
![Public method] | [Update(TEntity)][52]                                                     | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [Update(TEntity, Object)][53]                                             | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][54]                                | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [UpdateRange(TEntity[])][55]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Where][56]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    


See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../SqlSet_1/README.md
[2]: ../Database/Table__1.md
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
[15]: ../SqlSet_1/AsEnumerable.md
[16]: ../SqlSet_1/Cast.md
[17]: ../SqlSet_1/Cast__1.md
[18]: ../SqlSet_1/Contains.md
[19]: Contains.md
[20]: ContainsKey.md
[21]: ../SqlSet/Count.md
[22]: ../SqlSet/Count_1.md
[23]: ../SqlSet_1/Find.md
[24]: ../SqlSet_1/First.md
[25]: ../SqlSet_1/First_1.md
[26]: ../SqlSet_1/FirstOrDefault.md
[27]: ../SqlSet_1/FirstOrDefault_1.md
[28]: ../SqlSet/GetDefiningQuery.md
[29]: ../SqlSet_1/GetEnumerator.md
[30]: ../SqlSet_1/Include.md
[31]: ../SqlSet/LongCount.md
[32]: http://msdn.microsoft.com/en-us/library/6yy583ek
[33]: ../SqlSet/LongCount_1.md
[34]: ../SqlSet_1/OrderBy.md
[35]: Refresh.md
[36]: Remove.md
[37]: RemoveKey.md
[38]: RemoveRange.md
[39]: RemoveRange_1.md
[40]: ../SqlSet/Select_1.md
[41]: ../SqlSet/Select__1_1.md
[42]: ../SqlSet/Select__1.md
[43]: ../SqlSet_1/Single.md
[44]: ../SqlSet_1/Single_1.md
[45]: ../SqlSet_1/SingleOrDefault.md
[46]: ../SqlSet_1/SingleOrDefault_1.md
[47]: ../SqlSet_1/Skip.md
[48]: ../SqlSet_1/Take.md
[49]: ../SqlSet_1/ToArray.md
[50]: ../SqlSet_1/ToList.md
[51]: ../SqlSet/ToString.md
[52]: Update.md
[53]: Update_1.md
[54]: UpdateRange.md
[55]: UpdateRange_1.md
[56]: ../SqlSet_1/Where.md
[Public property]: ../../icons/pubproperty.gif "Public property"
[Public method]: ../../icons/pubmethod.gif "Public method"