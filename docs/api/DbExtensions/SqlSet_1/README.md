SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlSet][2]  
    **DbExtensions.SqlSet<TResult>**  
      [DbExtensions.SqlTable&lt;TEntity>][3]  

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlSet<TResult> : SqlSet, ISqlSet<SqlSet<TResult>, TResult>

```

### Type Parameters

#### *TResult*
The type of objects to map the results to.

The **SqlSet<TResult>** type exposes the following members.


Constructors
------------

                 | Name                                                                             | Description                                                                                                           
---------------- | -------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- 
![Public method] | [SqlSet&lt;TResult>(SqlBuilder)][5]                                              | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query.                        
![Public method] | [SqlSet&lt;TResult>(SqlBuilder, DbConnection)][6]                                | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query and connection.         
![Public method] | [SqlSet&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][7]               | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query and mapper.             
![Public method] | [SqlSet&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>, DbConnection)][8] | Initializes a new instance of the **SqlSet<TResult>** class using the provided defining query, mapper and connection. 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                              
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [All(String)][9]                                                          | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                                            
![Public method] | [All(String, Object[])][10]                                               | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                                            
![Public method] | [Any()][11]                                                               | Determines whether the set contains any elements. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Any(String)][12]                                                         | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][2].)                                                                                                           
![Public method] | [Any(String, Object[])][13]                                               | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][2].)                                                                                                           
![Public method] | [AsEnumerable][14]                                                        | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     
![Public method] | [Cast(Type)][15]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Cast&lt;T>()][16]                                                        | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Count()][17]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][2].)                                                                                                                                 
![Public method] | [Count(String)][18]                                                       | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                         
![Public method] | [Count(String, Object[])][19]                                             | Gets the number of elements in the set that matches the *predicate*. (Inherited from [SqlSet][2].)                                                                                                       
![Public method] | [Equals][20]                                                              | Returns whether the specified set is equal to the current set. (Inherited from [SqlSet][2].)                                                                                                             
![Public method] | [First()][21]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String)][22]                                                       | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [First(String, Object[])][23]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][24]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String)][25]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [FirstOrDefault(String, Object[])][26]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][27]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][2].)                                                                                                              
![Public method] | [GetEnumerator][28]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [GetHashCode][29]                                                         | Returns the hash function for the current set. (Inherited from [SqlSet][2].)                                                                                                                             
![Public method] | [GetType][30]                                                             | Gets the type for the current set. (Inherited from [SqlSet][2].)                                                                                                                                         
![Public method] | [LongCount()][31]                                                         | Returns an [Int64][32] that represents the total number of elements in the set. (Inherited from [SqlSet][2].)                                                                                            
![Public method] | [LongCount(String)][33]                                                   | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                   
![Public method] | [LongCount(String, Object[])][34]                                         | Returns an [Int64][32] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][2].)                                                                                   
![Public method] | [OrderBy(String)][35]                                                     | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [OrderBy(String, Object[])][36]                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(Type, String)][37]                                                | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Select(Type, String, Object[])][38]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Select&lt;TResult>(String)][39]                                          | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][40]           | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Select&lt;TResult>(String, Object[])][41]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][42] | Projects each element of the set into a new form. (Inherited from [SqlSet][2].)                                                                                                                          
![Public method] | [Single()][43]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String)][44]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [Single(String, Object[])][45]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][46]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String)][47]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [SingleOrDefault(String, Object[])][48]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][49]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][50]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][51]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][52]                                                              | Creates a List&lt;TResult> from the set.                                                                                                                                                                 
![Public method] | [ToString][53]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][2].)                                                                                                                                          
![Public method] | [Where(String)][54]                                                       | Filters the set based on a predicate.                                                                                                                                                                    
![Public method] | [Where(String, Object[])][55]                                             | Filters the set based on a predicate.                                                                                                                                                                    


Extension Methods
-----------------

                           | Name                              | Description                                                                                               
-------------------------- | --------------------------------- | --------------------------------------------------------------------------------------------------------- 
![Public Extension Method] | [Find(Object)][56]                | Overloaded. Gets the entity whose primary key matches the *id* parameter. (Defined by [Extensions][57].)  
![Public Extension Method] | [Find&lt;TResult>(Object)][58]    | Overloaded. Gets the entity whose primary key matches the *id* parameter. (Defined by [Extensions][57].)  
![Public Extension Method] | [Include(String)][59]             | Overloaded. Specifies the related objects to include in the query results. (Defined by [Extensions][57].) 
![Public Extension Method] | [Include&lt;TResult>(String)][60] | Overloaded. Specifies the related objects to include in the query results. (Defined by [Extensions][57].) 


See Also
--------
[DbExtensions Namespace][4]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../SqlSet/README.md
[3]: ../SqlTable_1/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: _ctor_1.md
[7]: _ctor_2.md
[8]: _ctor_3.md
[9]: ../SqlSet/All.md
[10]: ../SqlSet/All_1.md
[11]: ../SqlSet/Any.md
[12]: ../SqlSet/Any_1.md
[13]: ../SqlSet/Any_2.md
[14]: AsEnumerable.md
[15]: Cast.md
[16]: Cast__1.md
[17]: ../SqlSet/Count.md
[18]: ../SqlSet/Count_1.md
[19]: ../SqlSet/Count_2.md
[20]: ../SqlSet/Equals.md
[21]: First.md
[22]: First_1.md
[23]: First_2.md
[24]: FirstOrDefault.md
[25]: FirstOrDefault_1.md
[26]: FirstOrDefault_2.md
[27]: ../SqlSet/GetDefiningQuery.md
[28]: GetEnumerator.md
[29]: ../SqlSet/GetHashCode.md
[30]: ../SqlSet/GetType.md
[31]: ../SqlSet/LongCount.md
[32]: http://msdn.microsoft.com/en-us/library/6yy583ek
[33]: ../SqlSet/LongCount_1.md
[34]: ../SqlSet/LongCount_2.md
[35]: OrderBy.md
[36]: OrderBy_1.md
[37]: ../SqlSet/Select_2.md
[38]: ../SqlSet/Select_3.md
[39]: ../SqlSet/Select__1_2.md
[40]: ../SqlSet/Select__1.md
[41]: ../SqlSet/Select__1_3.md
[42]: ../SqlSet/Select__1_1.md
[43]: Single.md
[44]: Single_1.md
[45]: Single_2.md
[46]: SingleOrDefault.md
[47]: SingleOrDefault_1.md
[48]: SingleOrDefault_2.md
[49]: Skip.md
[50]: Take.md
[51]: ToArray.md
[52]: ToList.md
[53]: ../SqlSet/ToString.md
[54]: Where.md
[55]: Where_1.md
[56]: ../Extensions/Find.md
[57]: ../Extensions/README.md
[58]: ../Extensions/Find__1.md
[59]: ../Extensions/Include.md
[60]: ../Extensions/Include__1.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public Extension Method]: ../../_icons/pubextension.gif "Public Extension Method"