SqlSet Class
============
Represents an immutable, connected SQL query.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet&lt;TResult>][2]  
    [DbExtensions.SqlTable][3]  

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlSet : ISqlSet<SqlSet, Object>
```

The **SqlSet** type exposes the following members.


Constructors
------------

                 | Name                                        | Description                                                                                                       
---------------- | ------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- 
![Public method] | [SqlSet(SqlBuilder)][5]                     | Initializes a new instance of the **SqlSet** class using the provided defining query.                             
![Public method] | [SqlSet(SqlBuilder, DbConnection)][6]       | Initializes a new instance of the **SqlSet** class using the provided defining query and connection.              
![Public method] | [SqlSet(SqlBuilder, Type)][7]               | Initializes a new instance of the **SqlSet** class using the provided defining query and result type.             
![Public method] | [SqlSet(SqlBuilder, Type, DbConnection)][8] | Initializes a new instance of the **SqlSet** class using the provided defining query, result type and connection. 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                              
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [All(String)][9]                                                          | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
![Public method] | [All(String, Object[])][10]                                               | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
![Public method] | [Any()][11]                                                               | Determines whether the set contains any elements.                                                                                                                                                        
![Public method] | [Any(String)][12]                                                         | Determines whether any element of the set satisfies a condition.                                                                                                                                         
![Public method] | [Any(String, Object[])][13]                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         
![Public method] | [AsEnumerable][14]                                                        | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            
![Public method] | [Cast(Type)][15]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Cast&lt;TResult>()][16]                                                  | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Count()][17]                                                             | Returns the number of elements in the set.                                                                                                                                                               
![Public method] | [Count(String)][18]                                                       | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
![Public method] | [Count(String, Object[])][19]                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
![Public method] | [First()][20]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String)][21]                                                       | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [First(String, Object[])][22]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][23]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String)][24]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [FirstOrDefault(String, Object[])][25]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][26]                                                    | Returns the SQL query that is the source of data for the set.                                                                                                                                            
![Public method] | [GetEnumerator][27]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [LongCount()][28]                                                         | Returns an [Int64][29] that represents the total number of elements in the set.                                                                                                                          
![Public method] | [LongCount(String)][30]                                                   | Returns an [Int64][29] that represents how many elements in the set satisfy a condition.                                                                                                                 
![Public method] | [LongCount(String, Object[])][31]                                         | Returns an [Int64][29] that represents how many elements in the set satisfy a condition.                                                                                                                 
![Public method] | [OrderBy(String)][32]                                                     | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [OrderBy(String, Object[])][33]                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(String)][34]                                                      | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(String, Object[])][35]                                            | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(Type, String)][36]                                                | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(Type, String, Object[])][37]                                      | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String)][38]                                          | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][39]           | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][40]                                | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][41] | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Single()][42]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String)][43]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [Single(String, Object[])][44]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][45]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String)][46]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [SingleOrDefault(String, Object[])][47]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][48]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][49]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][50]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][51]                                                              | Creates a List&lt;object> from the set.                                                                                                                                                                  
![Public method] | [ToString][52]                                                            | Returns the SQL query of the set. (Overrides [Object.ToString()][53].)                                                                                                                                   
![Public method] | [Where(String)][54]                                                       | Filters the set based on a predicate.                                                                                                                                                                    
![Public method] | [Where(String, Object[])][55]                                             | Filters the set based on a predicate.                                                                                                                                                                    


Extension Methods
-----------------

                           | Name          | Description                                                                                   
-------------------------- | ------------- | --------------------------------------------------------------------------------------------- 
![Public Extension Method] | [Find][56]    | Gets the entity whose primary key matches the *id* parameter. (Defined by [Extensions][57].)  
![Public Extension Method] | [Include][58] | Specifies the related objects to include in the query results. (Defined by [Extensions][57].) 


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

#### Other Resources
[SqlSet Tutorial][59]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../SqlSet_1/README.md
[3]: ../SqlTable/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: _ctor_1.md
[7]: _ctor_2.md
[8]: _ctor_3.md
[9]: All.md
[10]: All_1.md
[11]: Any.md
[12]: Any_1.md
[13]: Any_2.md
[14]: AsEnumerable.md
[15]: Cast.md
[16]: Cast__1.md
[17]: Count.md
[18]: Count_1.md
[19]: Count_2.md
[20]: First.md
[21]: First_1.md
[22]: First_2.md
[23]: FirstOrDefault.md
[24]: FirstOrDefault_1.md
[25]: FirstOrDefault_2.md
[26]: GetDefiningQuery.md
[27]: GetEnumerator.md
[28]: LongCount.md
[29]: http://msdn.microsoft.com/en-us/library/6yy583ek
[30]: LongCount_1.md
[31]: LongCount_2.md
[32]: OrderBy.md
[33]: OrderBy_1.md
[34]: Select.md
[35]: Select_1.md
[36]: Select_2.md
[37]: Select_3.md
[38]: Select__1_2.md
[39]: Select__1.md
[40]: Select__1_3.md
[41]: Select__1_1.md
[42]: Single.md
[43]: Single_1.md
[44]: Single_2.md
[45]: SingleOrDefault.md
[46]: SingleOrDefault_1.md
[47]: SingleOrDefault_2.md
[48]: Skip.md
[49]: Take.md
[50]: ToArray.md
[51]: ToList.md
[52]: ToString.md
[53]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[54]: Where.md
[55]: Where_1.md
[56]: ../Extensions/Find.md
[57]: ../Extensions/README.md
[58]: ../Extensions/Include.md
[59]: ../../../SqlSet.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public Extension Method]: ../../_icons/pubextension.gif "Public Extension Method"