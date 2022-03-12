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

                   | Name                | Description                                                                                    
------------------ | ------------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [CommandBuilder][6] | Gets a [SqlCommandBuilder&lt;TEntity>][7] object for the current table.                        
![Public property] | [Name][8]           | Gets the name of the table.                                                                    
![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                                        
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][10]                                                                 | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                               
![Public method] | [AddRange(IEnumerable&lt;TEntity>)][11]                                   | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [AddRange(TEntity[])][12]                                                 | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                                           
![Public method] | [All][13]                                                                 | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                                      
![Public method] | [Any()][14]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Any(String, Object[])][15]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [AsEnumerable][16]                                                        | Gets all TResult objects in the set. The query is deferred-executed. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                     
![Public method] | [Cast(Type)][17]                                                          | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Cast&lt;T>()][18]                                                        | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Contains(Object)][19]                                                    | Checks the existance of the *entity*, using the primary key value. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                       
![Public method] | [Contains(TEntity)][20]                                                   | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                                 
![Public method] | [ContainsKey][21]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                        
![Public method] | [Count()][22]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Count(String, Object[])][23]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                   
![Public method] | [Find][24]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                            
![Public method] | [First()][25]                                                             | Returns the first element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][26]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
![Public method] | [FirstOrDefault()][27]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][28]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
![Public method] | [GetDefiningQuery][29]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [GetEnumerator][30]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
![Public method] | [Include][31]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                           
![Public method] | [LongCount()][32]                                                         | Returns an [Int64][33] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                      
![Public method] | [LongCount(String, Object[])][34]                                         | Returns an [Int64][33] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [OrderBy][35]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
![Public method] | [Refresh][36]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                                         
![Public method] | [Remove][37]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                              
![Public method] | [RemoveKey][38]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                             
![Public method] | [RemoveRange(IEnumerable&lt;TEntity>)][39]                                | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [RemoveRange(TEntity[])][40]                                              | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Select(Type, String, Object[])][41]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(String, Object[])][42]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][43] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [Single()][44]                                                            | The single element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][45]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
![Public method] | [SingleOrDefault()][46]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet&lt;TResult>][1].)                                               
![Public method] | [SingleOrDefault(String, Object[])][47]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
![Public method] | [Skip][48]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                              
![Public method] | [Take][49]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                             
![Public method] | [ToArray][50]                                                             | Creates an array from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
![Public method] | [ToList][51]                                                              | Creates a List&lt;TResult> from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                 
![Public method] | [ToString][52]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                                    
![Public method] | [Update(TEntity)][53]                                                     | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [Update(TEntity, Object)][54]                                             | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                             
![Public method] | [UpdateRange(IEnumerable&lt;TEntity>)][55]                                | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [UpdateRange(TEntity[])][56]                                              | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                             
![Public method] | [Where][57]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    


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
[8]: Name.md
[9]: ../SqlSet/ResultType.md
[10]: Add.md
[11]: AddRange.md
[12]: AddRange_1.md
[13]: ../SqlSet/All.md
[14]: ../SqlSet/Any.md
[15]: ../SqlSet/Any_1.md
[16]: ../SqlSet_1/AsEnumerable.md
[17]: ../SqlSet_1/Cast.md
[18]: ../SqlSet_1/Cast__1.md
[19]: ../SqlSet_1/Contains.md
[20]: Contains.md
[21]: ContainsKey.md
[22]: ../SqlSet/Count.md
[23]: ../SqlSet/Count_1.md
[24]: ../SqlSet_1/Find.md
[25]: ../SqlSet_1/First.md
[26]: ../SqlSet_1/First_1.md
[27]: ../SqlSet_1/FirstOrDefault.md
[28]: ../SqlSet_1/FirstOrDefault_1.md
[29]: ../SqlSet/GetDefiningQuery.md
[30]: ../SqlSet_1/GetEnumerator.md
[31]: ../SqlSet_1/Include.md
[32]: ../SqlSet/LongCount.md
[33]: http://msdn.microsoft.com/en-us/library/6yy583ek
[34]: ../SqlSet/LongCount_1.md
[35]: ../SqlSet_1/OrderBy.md
[36]: Refresh.md
[37]: Remove.md
[38]: RemoveKey.md
[39]: RemoveRange.md
[40]: RemoveRange_1.md
[41]: ../SqlSet/Select_1.md
[42]: ../SqlSet/Select__1_1.md
[43]: ../SqlSet/Select__1.md
[44]: ../SqlSet_1/Single.md
[45]: ../SqlSet_1/Single_1.md
[46]: ../SqlSet_1/SingleOrDefault.md
[47]: ../SqlSet_1/SingleOrDefault_1.md
[48]: ../SqlSet_1/Skip.md
[49]: ../SqlSet_1/Take.md
[50]: ../SqlSet_1/ToArray.md
[51]: ../SqlSet_1/ToList.md
[52]: ../SqlSet/ToString.md
[53]: Update.md
[54]: Update_1.md
[55]: UpdateRange.md
[56]: UpdateRange_1.md
[57]: ../SqlSet_1/Where.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"