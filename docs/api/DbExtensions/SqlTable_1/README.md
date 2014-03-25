SqlTable&lt;TEntity> Class
==========================
A [SqlSet&lt;TResult>][1] that provides additional methods for CRUD (Create, Read, Update, Delete) operations for TEntity, mapped using the [System.Data.Linq.Mapping][2] API. This class cannot be instantiated.


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

Name                                                                      | Description                                                                                                                                                                                                                                        
------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[All(String)][6]                                                          | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                                      
[All(String, Object[])][7]                                                | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                                      
[Any()][8]                                                                | Determines whether the set contains any elements. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Any(String)][9]                                                          | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                                     
[Any(String, Object[])][10]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][4].)                                                                                                                                                     
[AsEnumerable][11]                                                        | Gets all TResult objects in the set. The query is deferred-executed. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                     
[AsXml()][12]                                                             | Returns an [XmlReader][13] object that provides an XML view of the set's data. (Inherited from [SqlSet][4].)                                                                                                                                       
[AsXml(XmlMappingSettings)][14]                                           | Returns an [XmlReader][13] object that provides an XML view of the set's data. (Inherited from [SqlSet][4].)                                                                                                                                       
[Cast(Type)][15]                                                          | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
[Cast&lt;T>()][16]                                                        | Casts the elements of the set to the specified type. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
[Contains(TEntity)][17]                                                   | Checks the existance of the *entity*, using the primary key value. Version members are ignored.                                                                                                                                                    
[Contains(TEntity, Boolean)][18]                                          | Checks the existance of the *entity*, using the primary key and optionally version column.                                                                                                                                                         
[ContainsKey][19]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                                        
[Count()][20]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                                                           
[Count(String)][21]                                                       | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                                   
[Count(String, Object[])][22]                                             | Gets the number of elements in the set that matches the *predicate*. (Inherited from [SqlSet][4].)                                                                                                                                                 
[CreateSet(SqlBuilder)][23]                                               | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                             
[CreateSet(SqlBuilder, Type)][24]                                         | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][4].)                                                                                                         
[CreateSet&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][25]    | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][4].)                                                                                                         
[CreateSuperQuery()][26]                                                  | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][4].)                                                                                                         
[CreateSuperQuery(String, Object[])][27]                                  | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][4].)                                                                                                         
[Delete(TEntity)][28]                                                     | Executes a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                           
[Delete(TEntity, ConcurrencyConflictPolicy)][30]                          | Executes a DELETE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                                          
[DeleteById(Object)][31]                                                  | **Obsolete.** Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][29].                                                                                            
[DeleteById(Object, ConcurrencyConflictPolicy)][32]                       | **Obsolete.** Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                                          
[DeleteKey(Object)][33]                                                   | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][29].                                                                                                          
[DeleteKey(Object, ConcurrencyConflictPolicy)][34]                        | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                                                        
[DeleteRange(IEnumerable&lt;TEntity>)][35]                                | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                          
[DeleteRange(TEntity[])][36]                                              | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                          
[DeleteRange(IEnumerable&lt;TEntity>, ConcurrencyConflictPolicy)][37]     | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                                        
[DeleteRange(TEntity[], ConcurrencyConflictPolicy)][38]                   | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                                        
[Equals][39]                                                              | Returns whether the specified set is equal to the current set. (Inherited from [SqlSet][4].)                                                                                                                                                       
[Execute][40]                                                             | **Obsolete.** This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet&lt;TResult>][1].)                                                                               
[Find][41]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                                      
[First()][42]                                                             | Returns the first element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
[First(String)][43]                                                       | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
[First(String, Object[])][44]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                               
[FirstOrDefault()][45]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                
[FirstOrDefault(String)][46]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
[FirstOrDefault(String, Object[])][47]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                          
[GetDefiningQuery][48]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][4].)                                                                                                                                                        
[GetEnumerator][49]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                     
[GetHashCode][50]                                                         | Returns the hash function for the current set. (Inherited from [SqlSet][4].)                                                                                                                                                                       
[GetType][51]                                                             | Gets the type for the current set. (Inherited from [SqlSet][4].)                                                                                                                                                                                   
[Initialize][52]                                                          | **Obsolete.** Sets all mapped members of *entity* to their default database values.                                                                                                                                                                
[Insert(TEntity)][53]                                                     | Executes an INSERT command for the specified *entity*.                                                                                                                                                                                             
[Insert(TEntity, Boolean)][54]                                            | Executes an INSERT command for the specified *entity*.                                                                                                                                                                                             
[InsertDeep][55]                                                          | **Obsolete.** Recursively executes INSERT commands for the specified *entity* and all its one-to-many associations.                                                                                                                                
[InsertRange(IEnumerable&lt;TEntity>)][56]                                | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                             
[InsertRange(TEntity[])][57]                                              | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                             
[InsertRange(IEnumerable&lt;TEntity>, Boolean)][58]                       | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                             
[InsertRange(TEntity[], Boolean)][59]                                     | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                             
[LongCount()][60]                                                         | Returns an [Int64][61] that represents the total number of elements in the set. (Inherited from [SqlSet][4].)                                                                                                                                      
[LongCount(String)][62]                                                   | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                             
[LongCount(String, Object[])][63]                                         | Returns an [Int64][61] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][4].)                                                                                                                             
[OrderBy(String)][64]                                                     | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
[OrderBy(String, Object[])][65]                                           | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                             
[Refresh][66]                                                             | Sets all mapped members of *entity* to their most current persisted value.                                                                                                                                                                         
[Select(Type, String)][67]                                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Select(Type, String, Object[])][68]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Select&lt;TResult>(String)][69]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][70]           | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Select&lt;TResult>(String, Object[])][71]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][72] | Projects each element of the set into a new form. (Inherited from [SqlSet][4].)                                                                                                                                                                    
[Single()][73]                                                            | The single element of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
[Single(String)][74]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
[Single(String, Object[])][75]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet&lt;TResult>][1].)                                                                  
[SingleOrDefault()][76]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet&lt;TResult>][1].)                                               
[SingleOrDefault(String)][77]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
[SingleOrDefault(String, Object[])][78]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet&lt;TResult>][1].) 
[Skip][79]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                              
[Take][80]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                             
[ToArray][81]                                                             | Creates an array from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                           
[ToList][82]                                                              | Creates a List&lt;TResult> from the set. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                 
[ToString][83]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][4].)                                                                                                                                                                                    
[Union(SqlSet)][84]                                                       | Produces the set union of the current set with *otherSet*. (Inherited from [SqlSet][4].)                                                                                                                                                           
[Union(SqlSet&lt;TResult>)][85]                                           | Produces the set union of the current set with *otherSet*. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                               
[Update(TEntity)][86]                                                     | Executes an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                          
[Update(TEntity, ConcurrencyConflictPolicy)][87]                          | Executes an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                                         
[UpdateRange(IEnumerable&lt;TEntity>)][88]                                | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                          
[UpdateRange(TEntity[])][89]                                              | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][29].                                                                                                                                          
[UpdateRange(IEnumerable&lt;TEntity>, ConcurrencyConflictPolicy)][90]     | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                                         
[UpdateRange(TEntity[], ConcurrencyConflictPolicy)][91]                   | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                                         
[Where(String)][92]                                                       | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    
[Where(String, Object[])][93]                                             | Filters the set based on a predicate. (Inherited from [SqlSet&lt;TResult>][1].)                                                                                                                                                                    


Properties
----------

Name      | Description                                                              
--------- | ------------------------------------------------------------------------ 
[SQL][94] | Gets a [SqlCommandBuilder&lt;TEntity>][95] object for the current table. 


See Also
--------
[DbExtensions Namespace][5]  
[Database.Table&lt;TEntity>()][96]  

[1]: ../SqlSet_1/README.md
[2]: http://msdn.microsoft.com/en-us/library/bb515105
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlSet/README.md
[5]: ../README.md
[6]: ../SqlSet/All.md
[7]: ../SqlSet/All_1.md
[8]: ../SqlSet/Any.md
[9]: ../SqlSet/Any_1.md
[10]: ../SqlSet/Any_2.md
[11]: ../SqlSet_1/AsEnumerable.md
[12]: ../SqlSet/AsXml.md
[13]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[14]: ../SqlSet/AsXml_1.md
[15]: ../SqlSet_1/Cast.md
[16]: ../SqlSet_1/Cast__1.md
[17]: Contains.md
[18]: Contains_1.md
[19]: ContainsKey.md
[20]: ../SqlSet/Count.md
[21]: ../SqlSet/Count_1.md
[22]: ../SqlSet/Count_2.md
[23]: ../SqlSet_1/CreateSet.md
[24]: ../SqlSet/CreateSet_1.md
[25]: ../SqlSet/CreateSet__1_1.md
[26]: ../SqlSet/CreateSuperQuery.md
[27]: ../SqlSet/CreateSuperQuery_1.md
[28]: Delete.md
[29]: ../ConcurrencyConflictPolicy/README.md
[30]: Delete_1.md
[31]: DeleteById.md
[32]: DeleteById_1.md
[33]: DeleteKey.md
[34]: DeleteKey_1.md
[35]: DeleteRange.md
[36]: DeleteRange_2.md
[37]: DeleteRange_1.md
[38]: DeleteRange_3.md
[39]: ../SqlSet/Equals.md
[40]: ../SqlSet_1/Execute.md
[41]: Find.md
[42]: ../SqlSet_1/First.md
[43]: ../SqlSet_1/First_1.md
[44]: ../SqlSet_1/First_2.md
[45]: ../SqlSet_1/FirstOrDefault.md
[46]: ../SqlSet_1/FirstOrDefault_1.md
[47]: ../SqlSet_1/FirstOrDefault_2.md
[48]: ../SqlSet/GetDefiningQuery.md
[49]: ../SqlSet_1/GetEnumerator.md
[50]: ../SqlSet/GetHashCode.md
[51]: ../SqlSet/GetType.md
[52]: Initialize.md
[53]: Insert.md
[54]: Insert_1.md
[55]: InsertDeep.md
[56]: InsertRange.md
[57]: InsertRange_2.md
[58]: InsertRange_1.md
[59]: InsertRange_3.md
[60]: ../SqlSet/LongCount.md
[61]: http://msdn.microsoft.com/en-us/library/6yy583ek
[62]: ../SqlSet/LongCount_1.md
[63]: ../SqlSet/LongCount_2.md
[64]: ../SqlSet_1/OrderBy.md
[65]: ../SqlSet_1/OrderBy_1.md
[66]: Refresh.md
[67]: ../SqlSet/Select.md
[68]: ../SqlSet/Select_1.md
[69]: ../SqlSet/Select__1_2.md
[70]: ../SqlSet/Select__1.md
[71]: ../SqlSet/Select__1_3.md
[72]: ../SqlSet/Select__1_1.md
[73]: ../SqlSet_1/Single.md
[74]: ../SqlSet_1/Single_1.md
[75]: ../SqlSet_1/Single_2.md
[76]: ../SqlSet_1/SingleOrDefault.md
[77]: ../SqlSet_1/SingleOrDefault_1.md
[78]: ../SqlSet_1/SingleOrDefault_2.md
[79]: ../SqlSet_1/Skip.md
[80]: ../SqlSet_1/Take.md
[81]: ../SqlSet_1/ToArray.md
[82]: ../SqlSet_1/ToList.md
[83]: ../SqlSet/ToString.md
[84]: ../SqlSet/Union.md
[85]: ../SqlSet_1/Union.md
[86]: Update.md
[87]: Update_1.md
[88]: UpdateRange.md
[89]: UpdateRange_2.md
[90]: UpdateRange_1.md
[91]: UpdateRange_3.md
[92]: ../SqlSet_1/Where.md
[93]: ../SqlSet_1/Where_1.md
[94]: SQL.md
[95]: ../SqlCommandBuilder_1/README.md
[96]: ../Database/Table__1.md