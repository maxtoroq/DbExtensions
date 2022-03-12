SqlTable Class
==============
A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated, to get an instance use the [Table(Type)][2] method.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [DbExtensions.SqlSet][4]  
    **DbExtensions.SqlTable**  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:** DbExtensions.dll

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
![Public property] | [Name][8]           | Gets the name of the table.                                                                    
![Public property] | [ResultType][9]     | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][4].) 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                                                            
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [Add][10]                                                                 | Recursively executes INSERT commands for the specified *entity* and all its one-to-one and one-to-many associations.                                                                                                                   
![Public method] | [AddRange(IEnumerable&lt;Object>)][11]                                    | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [AddRange(Object[])][12]                                                  | Recursively executes INSERT commands for the specified *entities* and all their one-to-one and one-to-many associations.                                                                                                               
![Public method] | [All][13]                                                                 | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                          
![Public method] | [Any()][14]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Any(String, Object[])][15]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                         
![Public method] | [AsEnumerable][16]                                                        | Gets all elements in the set. The query is deferred-executed. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [Cast(Type)][17]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                                                   
![Public method] | [Cast&lt;TEntity>()][18]                                                  | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                      
![Public method] | [Contains][19]                                                            | Checks the existance of the *entity*, using the primary key value.                                                                                                                                                                     
![Public method] | [ContainsKey][20]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                            
![Public method] | [Count()][21]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                               
![Public method] | [Count(String, Object[])][22]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                       
![Public method] | [Find][23]                                                                | Gets the entity whose primary key matches the *id* parameter. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [First()][24]                                                             | Returns the first element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                    
![Public method] | [First(String, Object[])][25]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][4].)                                                                                                                               
![Public method] | [FirstOrDefault()][26]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet][4].)                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][27]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][4].)                                                                                          
![Public method] | [GetDefiningQuery][28]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                            
![Public method] | [GetEnumerator][29]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet][4].)                                                                                                                                                     
![Public method] | [Include][30]                                                             | Specifies the related objects to include in the query results. (Inherited from [SqlSet][4].)                                                                                                                                           
![Public method] | [LongCount()][31]                                                         | Returns an [Int64][32] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                          
![Public method] | [LongCount(String, Object[])][33]                                         | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                 
![Public method] | [OrderBy][34]                                                             | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][4].)                                                                                                                                             
![Public method] | [Refresh][35]                                                             | Sets all column members of *entity* to their most current persisted value.                                                                                                                                                             
![Public method] | [Remove][36]                                                              | Executes a DELETE command for the specified *entity*.                                                                                                                                                                                  
![Public method] | [RemoveKey][37]                                                           | Executes a DELETE command for the entity whose primary key matches the *id* parameter.                                                                                                                                                 
![Public method] | [RemoveRange(IEnumerable&lt;Object>)][38]                                 | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [RemoveRange(Object[])][39]                                               | Executes DELETE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Select(Type, String, Object[])][40]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][41]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][42] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                        
![Public method] | [Single()][43]                                                            | The single element of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [Single(String, Object[])][44]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][4].)                                                                  
![Public method] | [SingleOrDefault()][45]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet][4].)                                               
![Public method] | [SingleOrDefault(String, Object[])][46]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][4].) 
![Public method] | [Skip][47]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet][4].)                                                                                                              
![Public method] | [Take][48]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet][4].)                                                                                                                             
![Public method] | [ToArray][49]                                                             | Creates an array from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
![Public method] | [ToList][50]                                                              | Creates a List&lt;object> from the set. (Inherited from [SqlSet][4].)                                                                                                                                                                  
![Public method] | [ToString][51]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                        
![Public method] | [Update(Object)][52]                                                      | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [Update(Object, Object)][53]                                              | Executes an UPDATE command for the specified *entity*.                                                                                                                                                                                 
![Public method] | [UpdateRange(IEnumerable&lt;Object>)][54]                                 | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [UpdateRange(Object[])][55]                                               | Executes UPDATE commands for the specified *entities*.                                                                                                                                                                                 
![Public method] | [Where][56]                                                               | Filters the set based on a predicate. (Inherited from [SqlSet][4].)                                                                                                                                                                    


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
[8]: Name.md
[9]: ../SqlSet/ResultType.md
[10]: Add.md
[11]: AddRange.md
[12]: AddRange_1.md
[13]: ../SqlSet/All.md
[14]: ../SqlSet/Any.md
[15]: ../SqlSet/Any_1.md
[16]: ../SqlSet/AsEnumerable.md
[17]: Cast.md
[18]: Cast__1.md
[19]: Contains.md
[20]: ContainsKey.md
[21]: ../SqlSet/Count.md
[22]: ../SqlSet/Count_1.md
[23]: ../SqlSet/Find.md
[24]: ../SqlSet/First.md
[25]: ../SqlSet/First_1.md
[26]: ../SqlSet/FirstOrDefault.md
[27]: ../SqlSet/FirstOrDefault_1.md
[28]: ../SqlSet/GetDefiningQuery.md
[29]: ../SqlSet/GetEnumerator.md
[30]: ../SqlSet/Include.md
[31]: ../SqlSet/LongCount.md
[32]: http://msdn.microsoft.com/en-us/library/6yy583ek
[33]: ../SqlSet/LongCount_1.md
[34]: ../SqlSet/OrderBy.md
[35]: Refresh.md
[36]: Remove.md
[37]: RemoveKey.md
[38]: RemoveRange.md
[39]: RemoveRange_1.md
[40]: ../SqlSet/Select_1.md
[41]: ../SqlSet/Select__1_1.md
[42]: ../SqlSet/Select__1.md
[43]: ../SqlSet/Single.md
[44]: ../SqlSet/Single_1.md
[45]: ../SqlSet/SingleOrDefault.md
[46]: ../SqlSet/SingleOrDefault_1.md
[47]: ../SqlSet/Skip.md
[48]: ../SqlSet/Take.md
[49]: ../SqlSet/ToArray.md
[50]: ../SqlSet/ToList.md
[51]: ../SqlSet/ToString.md
[52]: Update.md
[53]: Update_1.md
[54]: UpdateRange.md
[55]: UpdateRange_1.md
[56]: ../SqlSet/Where.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Public method]: ../../icons/pubmethod.svg "Public method"