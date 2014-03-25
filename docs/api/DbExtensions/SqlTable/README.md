SqlTable Class
==============
A non-generic version of [SqlTable&lt;TEntity>][1] which can be used when the type of the entity is not known at build time. This class cannot be instantiated.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [DbExtensions.SqlSet][3]  
    **DbExtensions.SqlTable**  

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class SqlTable : SqlSet, 
	ISqlTable
```

The **SqlTable** type exposes the following members.


Methods
-------

Name                                                                      | Description                                                                                                                                                                                                                            
------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[All(String)][5]                                                          | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                                                          
[All(String, Object[])][6]                                                | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                                                          
[Any()][7]                                                                | Determines whether the set contains any elements. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Any(String)][8]                                                          | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][3].)                                                                                                                                         
[Any(String, Object[])][9]                                                | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][3].)                                                                                                                                         
[AsEnumerable][10]                                                        | Gets all elements in the set. The query is deferred-executed. (Inherited from [SqlSet][3].)                                                                                                                                            
[AsXml()][11]                                                             | Returns an [XmlReader][12] object that provides an XML view of the set's data. (Inherited from [SqlSet][3].)                                                                                                                           
[AsXml(XmlMappingSettings)][13]                                           | Returns an [XmlReader][12] object that provides an XML view of the set's data. (Inherited from [SqlSet][3].)                                                                                                                           
[Cast(Type)][14]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                                                   
[Cast&lt;TEntity>()][15]                                                  | Casts the current **SqlTable** to the generic [SqlTable&lt;TEntity>][1] instance.                                                                                                                                                      
[Contains(Object)][16]                                                    | Checks the existance of the *entity*, using the primary key value. Version members are ignored.                                                                                                                                        
[Contains(Object, Boolean)][17]                                           | Checks the existance of the *entity*, using the primary key and optionally version column.                                                                                                                                             
[ContainsKey][18]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                                                            
[Count()][19]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][3].)                                                                                                                                                               
[Count(String)][20]                                                       | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                                       
[Count(String, Object[])][21]                                             | Gets the number of elements in the set that matches the *predicate*. (Inherited from [SqlSet][3].)                                                                                                                                     
[CreateSet(SqlBuilder)][22]                                               | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                                             
[CreateSet(SqlBuilder, Type)][23]                                         | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                                             
[CreateSet&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][24]    | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                                             
[CreateSuperQuery()][25]                                                  | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                                             
[CreateSuperQuery(String, Object[])][26]                                  | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                                             
[Delete(Object)][27]                                                      | Executes a DELETE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                               
[Delete(Object, ConcurrencyConflictPolicy)][29]                           | Executes a DELETE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                              
[DeleteById(Object)][30]                                                  | **Obsolete.** Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][28].                                                                                
[DeleteById(Object, ConcurrencyConflictPolicy)][31]                       | **Obsolete.** Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                              
[DeleteKey(Object)][32]                                                   | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the default [ConcurrencyConflictPolicy][28].                                                                                              
[DeleteKey(Object, ConcurrencyConflictPolicy)][33]                        | Executes a DELETE command for the entity whose primary key matches the *id* parameter, using the provided *conflictPolicy*.                                                                                                            
[DeleteRange(IEnumerable&lt;Object>)][34]                                 | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                              
[DeleteRange(Object[])][35]                                               | Executes DELETE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                              
[DeleteRange(IEnumerable&lt;Object>, ConcurrencyConflictPolicy)][36]      | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                            
[DeleteRange(Object[], ConcurrencyConflictPolicy)][37]                    | Executes DELETE commands for the specified *entities*, using the provided *conflictPolicy*.                                                                                                                                            
[Equals][38]                                                              | Returns whether the specified set is equal to the current set. (Inherited from [SqlSet][3].)                                                                                                                                           
[Execute][39]                                                             | **Obsolete.** This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][3].)                                                                               
[Find][40]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                                                          
[First()][41]                                                             | Returns the first element of the set. (Inherited from [SqlSet][3].)                                                                                                                                                                    
[First(String)][42]                                                       | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][3].)                                                                                                                               
[First(String, Object[])][43]                                             | Returns the first element in the set that satisfies a specified condition. (Inherited from [SqlSet][3].)                                                                                                                               
[FirstOrDefault()][44]                                                    | Returns the first element of the set, or a default value if the set contains no elements. (Inherited from [SqlSet][3].)                                                                                                                
[FirstOrDefault(String)][45]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][3].)                                                                                          
[FirstOrDefault(String, Object[])][46]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found. (Inherited from [SqlSet][3].)                                                                                          
[GetDefiningQuery][47]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][3].)                                                                                                                                            
[GetEnumerator][48]                                                       | Returns an enumerator that iterates through the set. (Inherited from [SqlSet][3].)                                                                                                                                                     
[GetHashCode][49]                                                         | Returns the hash function for the current set. (Inherited from [SqlSet][3].)                                                                                                                                                           
[GetType][50]                                                             | Gets the type for the current set. (Inherited from [SqlSet][3].)                                                                                                                                                                       
[Initialize][51]                                                          | **Obsolete.** Sets all mapped members of *entity* to their default database values.                                                                                                                                                    
[Insert(Object)][52]                                                      | Executes an INSERT command for the specified *entity*.                                                                                                                                                                                 
[Insert(Object, Boolean)][53]                                             | Executes an INSERT command for the specified *entity*.                                                                                                                                                                                 
[InsertDeep][54]                                                          | **Obsolete.** Recursively executes INSERT commands for the specified *entity* and all its one-to-many associations.                                                                                                                    
[InsertRange(IEnumerable&lt;Object>)][55]                                 | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                 
[InsertRange(Object[])][56]                                               | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                 
[InsertRange(IEnumerable&lt;Object>, Boolean)][57]                        | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                 
[InsertRange(Object[], Boolean)][58]                                      | Executes INSERT commands for the specified *entities*.                                                                                                                                                                                 
[LongCount()][59]                                                         | Returns an [Int64][60] that represents the total number of elements in the set. (Inherited from [SqlSet][3].)                                                                                                                          
[LongCount(String)][61]                                                   | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                                 
[LongCount(String, Object[])][62]                                         | Returns an [Int64][60] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                                 
[OrderBy(String)][63]                                                     | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][3].)                                                                                                                                             
[OrderBy(String, Object[])][64]                                           | Sorts the elements of the set according to the *columnList*. (Inherited from [SqlSet][3].)                                                                                                                                             
[Refresh][65]                                                             | Sets all mapped members of *entity* to their most current persisted value.                                                                                                                                                             
[Select(Type, String)][66]                                                | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Select(Type, String, Object[])][67]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Select&lt;TResult>(String)][68]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][69]           | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Select&lt;TResult>(String, Object[])][70]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][71] | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                                                        
[Single()][72]                                                            | The single element of the set. (Inherited from [SqlSet][3].)                                                                                                                                                                           
[Single(String)][73]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][3].)                                                                  
[Single(String, Object[])][74]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists. (Inherited from [SqlSet][3].)                                                                  
[SingleOrDefault()][75]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set. (Inherited from [SqlSet][3].)                                               
[SingleOrDefault(String)][76]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][3].) 
[SingleOrDefault(String, Object[])][77]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. (Inherited from [SqlSet][3].) 
[Skip][78]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements. (Inherited from [SqlSet][3].)                                                                                                              
[Take][79]                                                                | Returns a specified number of contiguous elements from the start of the set. (Inherited from [SqlSet][3].)                                                                                                                             
[ToArray][80]                                                             | Creates an array from the set. (Inherited from [SqlSet][3].)                                                                                                                                                                           
[ToList][81]                                                              | Creates a List&lt;object> from the set. (Inherited from [SqlSet][3].)                                                                                                                                                                  
[ToString][82]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][3].)                                                                                                                                                                        
[Union][83]                                                               | Produces the set union of the current set with *otherSet*. (Inherited from [SqlSet][3].)                                                                                                                                               
[Update(Object)][84]                                                      | Executes an UPDATE command for the specified *entity*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                              
[Update(Object, ConcurrencyConflictPolicy)][85]                           | Executes an UPDATE command for the specified *entity* using the provided *conflictPolicy*.                                                                                                                                             
[UpdateRange(IEnumerable&lt;Object>)][86]                                 | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                              
[UpdateRange(Object[])][87]                                               | Executes UPDATE commands for the specified *entities*, using the default [ConcurrencyConflictPolicy][28].                                                                                                                              
[UpdateRange(IEnumerable&lt;Object>, ConcurrencyConflictPolicy)][88]      | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                             
[UpdateRange(Object[], ConcurrencyConflictPolicy)][89]                    | Executes UPDATE commands for the specified *entities* using the provided *conflictPolicy*.                                                                                                                                             
[Where(String)][90]                                                       | Filters the set based on a predicate. (Inherited from [SqlSet][3].)                                                                                                                                                                    
[Where(String, Object[])][91]                                             | Filters the set based on a predicate. (Inherited from [SqlSet][3].)                                                                                                                                                                    


Properties
----------

Name      | Description                                                              
--------- | ------------------------------------------------------------------------ 
[SQL][92] | Gets a [SqlCommandBuilder&lt;TEntity>][93] object for the current table. 


See Also
--------
[DbExtensions Namespace][4]  
[Database.Table(Type)][94]  

[1]: ../SqlTable_1/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../SqlSet/README.md
[4]: ../README.md
[5]: ../SqlSet/All.md
[6]: ../SqlSet/All_1.md
[7]: ../SqlSet/Any.md
[8]: ../SqlSet/Any_1.md
[9]: ../SqlSet/Any_2.md
[10]: ../SqlSet/AsEnumerable.md
[11]: ../SqlSet/AsXml.md
[12]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[13]: ../SqlSet/AsXml_1.md
[14]: Cast.md
[15]: Cast__1.md
[16]: Contains.md
[17]: Contains_1.md
[18]: ContainsKey.md
[19]: ../SqlSet/Count.md
[20]: ../SqlSet/Count_1.md
[21]: ../SqlSet/Count_2.md
[22]: ../SqlSet/CreateSet.md
[23]: ../SqlSet/CreateSet_1.md
[24]: ../SqlSet/CreateSet__1_1.md
[25]: ../SqlSet/CreateSuperQuery.md
[26]: ../SqlSet/CreateSuperQuery_1.md
[27]: Delete.md
[28]: ../ConcurrencyConflictPolicy/README.md
[29]: Delete_1.md
[30]: DeleteById.md
[31]: DeleteById_1.md
[32]: DeleteKey.md
[33]: DeleteKey_1.md
[34]: DeleteRange.md
[35]: DeleteRange_2.md
[36]: DeleteRange_1.md
[37]: DeleteRange_3.md
[38]: ../SqlSet/Equals.md
[39]: ../SqlSet/Execute.md
[40]: Find.md
[41]: ../SqlSet/First.md
[42]: ../SqlSet/First_1.md
[43]: ../SqlSet/First_2.md
[44]: ../SqlSet/FirstOrDefault.md
[45]: ../SqlSet/FirstOrDefault_1.md
[46]: ../SqlSet/FirstOrDefault_2.md
[47]: ../SqlSet/GetDefiningQuery.md
[48]: ../SqlSet/GetEnumerator.md
[49]: ../SqlSet/GetHashCode.md
[50]: ../SqlSet/GetType.md
[51]: Initialize.md
[52]: Insert.md
[53]: Insert_1.md
[54]: InsertDeep.md
[55]: InsertRange.md
[56]: InsertRange_2.md
[57]: InsertRange_1.md
[58]: InsertRange_3.md
[59]: ../SqlSet/LongCount.md
[60]: http://msdn.microsoft.com/en-us/library/6yy583ek
[61]: ../SqlSet/LongCount_1.md
[62]: ../SqlSet/LongCount_2.md
[63]: ../SqlSet/OrderBy.md
[64]: ../SqlSet/OrderBy_1.md
[65]: Refresh.md
[66]: ../SqlSet/Select.md
[67]: ../SqlSet/Select_1.md
[68]: ../SqlSet/Select__1_2.md
[69]: ../SqlSet/Select__1.md
[70]: ../SqlSet/Select__1_3.md
[71]: ../SqlSet/Select__1_1.md
[72]: ../SqlSet/Single.md
[73]: ../SqlSet/Single_1.md
[74]: ../SqlSet/Single_2.md
[75]: ../SqlSet/SingleOrDefault.md
[76]: ../SqlSet/SingleOrDefault_1.md
[77]: ../SqlSet/SingleOrDefault_2.md
[78]: ../SqlSet/Skip.md
[79]: ../SqlSet/Take.md
[80]: ../SqlSet/ToArray.md
[81]: ../SqlSet/ToList.md
[82]: ../SqlSet/ToString.md
[83]: ../SqlSet/Union.md
[84]: Update.md
[85]: Update_1.md
[86]: UpdateRange.md
[87]: UpdateRange_2.md
[88]: UpdateRange_1.md
[89]: UpdateRange_3.md
[90]: ../SqlSet/Where.md
[91]: ../SqlSet/Where_1.md
[92]: SQL.md
[93]: ../SqlCommandBuilder_1/README.md
[94]: ../Database/Table_1.md