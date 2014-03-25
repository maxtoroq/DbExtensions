SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlSet][2]  
    **DbExtensions.SqlSet<TResult>**  
      [DbExtensions.SqlTable<TEntity>][3]  

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult>
```


Type Parameters
---------------

#### *TResult*
The type of objects to map the results to.

The **SqlSet<TResult>** type exposes the following members.


Constructors
------------

Name                                                                                    | Description                                                                                                                   
--------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- 
[SqlSet<TResult>(SqlBuilder)][5]                                                        | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query.                                
[SqlSet<TResult>(SqlBuilder, DbConnection)][6]                                          | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query and connection.                 
[SqlSet<TResult>(SqlBuilder, Func<IDataRecord, TResult>)][7]                            | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query and mapper.                     
[SqlSet<TResult>(SqlSet<TResult>, SqlBuilder)][8]                                       | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                  
[SqlSet<TResult>(SqlBuilder, DbConnection, TextWriter)][9]                              | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query, connection and logger.         
[SqlSet<TResult>(SqlBuilder, Func<IDataRecord, TResult>, DbConnection)][10]             | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query, mapper and connection.         
[SqlSet<TResult>(SqlBuilder, Func<IDataRecord, TResult>, DbConnection, TextWriter)][11] | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query, mapper, connection and logger. 


Methods
-------

Name                                                                | Description                                                                                                                                                                                              
------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[All(String)][12]                                                   | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                                            
[All(String, Object[])][13]                                         | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                                            
[Any()][14]                                                         | Determines whether the set contains any elements. (Inherited from [SqlSet][2].)                                                                                                                          
[Any(String)][15]                                                   | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][2].)                                                                                                           
[Any(String, Object[])][16]                                         | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][2].)                                                                                                           
[AsEnumerable][17]                                                  | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     
[AsXml()][18]                                                       | Returns an [XmlReader][19] object that provides an XML view of the set's data. (Inherited from [SqlSet][2].)                                                                                             
[AsXml(XmlMappingSettings)][20]                                     | Returns an [XmlReader][19] object that provides an XML view of the set's data. (Inherited from [SqlSet][2].)                                                                                             
[Cast(Type)][21]                                                    | Casts the elements of the set to the specified type.                                                                                                                                                     
[Cast<T>()][22]                                                     | Casts the elements of the set to the specified type.                                                                                                                                                     
[Count()][23]                                                       | Returns the number of elements in the set. (Inherited from [SqlSet][2].)                                                                                                                                 
[Count(String)][24]                                                 | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                         
[Count(String, Object[])][25]                                       | Gets the number of elements in the set that matches the *predicate*. (Inherited from [SqlSet][2].)                                                                                                       
[CreateSet(SqlBuilder)][26]                                         | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Overrides [SqlSet.CreateSet(SqlBuilder)][27].)                                             
[CreateSet(SqlBuilder, Type)][28]                                   | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][2].)                                                               
[CreateSet<T>(SqlBuilder)][29]                                      | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Overrides [SqlSet.CreateSet(SqlBuilder)][27].)                                             
[CreateSet<TResult>(SqlBuilder, Func<IDataRecord, TResult>)][30]    | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][2].)                                                               
[CreateSuperQuery()][31]                                            | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][2].)                                                               
[CreateSuperQuery(String, Object[])][32]                            | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Inherited from [SqlSet][2].)                                                               
[Equals][33]                                                        | Returns whether the specified set is equal to the current set. (Inherited from [SqlSet][2].)                                                                                                             
[Execute][34]                                                       | **Obsolete.** This member supports the DbExtensions infrastructure and is not intended to be used directly from your code. (Overrides [SqlSet.Execute(DbCommand)][35].)                                  
[First()][36]                                                       | Returns the first element of the set.                                                                                                                                                                    
[First(String)][37]                                                 | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[First(String, Object[])][38]                                       | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[FirstOrDefault()][39]                                              | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
[FirstOrDefault(String)][40]                                        | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[FirstOrDefault(String, Object[])][41]                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[GetDefiningQuery][42]                                              | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][2].)                                                                                                              
[GetEnumerator][43]                                                 | Returns an enumerator that iterates through the set.                                                                                                                                                     
[GetHashCode][44]                                                   | Returns the hash function for the current set. (Inherited from [SqlSet][2].)                                                                                                                             
[GetType][45]                                                       | Gets the type for the current set. (Inherited from [SqlSet][2].)                                                                                                                                         
[LongCount()][46]                                                   | Returns an [Int64][47] that represents the total number of elements in the set. (Inherited from [SqlSet][2].)                                                                                            
[LongCount(String)][48]                                             | Returns an [Int64][47] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                   
[LongCount(String, Object[])][49]                                   | Returns an [Int64][47] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                   
[OrderBy(String)][50]                                               | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[OrderBy(String, Object[])][51]                                     | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[Select(Type, String)][52]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Select(Type, String, Object[])][53]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Select<TResult>(String)][54]                                       | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Select<TResult>(Func<IDataRecord, TResult>, String)][55]           | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Select<TResult>(String, Object[])][56]                             | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Select<TResult>(Func<IDataRecord, TResult>, String, Object[])][57] | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
[Single()][58]                                                      | The single element of the set.                                                                                                                                                                           
[Single(String)][59]                                                | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[Single(String, Object[])][60]                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[SingleOrDefault()][61]                                             | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
[SingleOrDefault(String)][62]                                       | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[SingleOrDefault(String, Object[])][63]                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[Skip][64]                                                          | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
[Take][65]                                                          | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
[ToArray][66]                                                       | Creates an array from the set.                                                                                                                                                                           
[ToList][67]                                                        | Creates a List&lt;TResult> from the set.                                                                                                                                                                 
[ToString][68]                                                      | Returns the SQL query of the set. (Inherited from [SqlSet][2].)                                                                                                                                          
[Union(SqlSet)][69]                                                 | Produces the set union of the current set with *otherSet*. (Inherited from [SqlSet][2].)                                                                                                                 
[Union(SqlSet<TResult>)][70]                                        | Produces the set union of the current set with *otherSet*.                                                                                                                                               
[Where(String)][71]                                                 | Filters the set based on a predicate.                                                                                                                                                                    
[Where(String, Object[])][72]                                       | Filters the set based on a predicate.                                                                                                                                                                    


See Also
--------
[DbExtensions Namespace][4]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../SqlSet/README.md
[3]: ../SqlTable_1/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: _ctor_1.md
[7]: _ctor_3.md
[8]: _ctor_6.md
[9]: _ctor_2.md
[10]: _ctor_4.md
[11]: _ctor_5.md
[12]: ../SqlSet/All.md
[13]: ../SqlSet/All_1.md
[14]: ../SqlSet/Any.md
[15]: ../SqlSet/Any_1.md
[16]: ../SqlSet/Any_2.md
[17]: AsEnumerable.md
[18]: ../SqlSet/AsXml.md
[19]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[20]: ../SqlSet/AsXml_1.md
[21]: Cast.md
[22]: Cast__1.md
[23]: ../SqlSet/Count.md
[24]: ../SqlSet/Count_1.md
[25]: ../SqlSet/Count_2.md
[26]: CreateSet.md
[27]: ../SqlSet/CreateSet.md
[28]: ../SqlSet/CreateSet_1.md
[29]: CreateSet__1.md
[30]: ../SqlSet/CreateSet__1_1.md
[31]: ../SqlSet/CreateSuperQuery.md
[32]: ../SqlSet/CreateSuperQuery_1.md
[33]: ../SqlSet/Equals.md
[34]: Execute.md
[35]: ../SqlSet/Execute.md
[36]: First.md
[37]: First_1.md
[38]: First_2.md
[39]: FirstOrDefault.md
[40]: FirstOrDefault_1.md
[41]: FirstOrDefault_2.md
[42]: ../SqlSet/GetDefiningQuery.md
[43]: GetEnumerator.md
[44]: ../SqlSet/GetHashCode.md
[45]: ../SqlSet/GetType.md
[46]: ../SqlSet/LongCount.md
[47]: http://msdn.microsoft.com/en-us/library/6yy583ek
[48]: ../SqlSet/LongCount_1.md
[49]: ../SqlSet/LongCount_2.md
[50]: OrderBy.md
[51]: OrderBy_1.md
[52]: ../SqlSet/Select.md
[53]: ../SqlSet/Select_1.md
[54]: ../SqlSet/Select__1_2.md
[55]: ../SqlSet/Select__1.md
[56]: ../SqlSet/Select__1_3.md
[57]: ../SqlSet/Select__1_1.md
[58]: Single.md
[59]: Single_1.md
[60]: Single_2.md
[61]: SingleOrDefault.md
[62]: SingleOrDefault_1.md
[63]: SingleOrDefault_2.md
[64]: Skip.md
[65]: Take.md
[66]: ToArray.md
[67]: ToList.md
[68]: ../SqlSet/ToString.md
[69]: ../SqlSet/Union.md
[70]: Union.md
[71]: Where.md
[72]: Where_1.md