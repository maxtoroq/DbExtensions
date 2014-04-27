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
public class SqlSet : ISqlSet<SqlSet, Object>
```

The **SqlSet** type exposes the following members.


Constructors
------------

Name                                        | Description                                                                                                       
------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- 
[SqlSet(SqlBuilder)][5]                     | Initializes a new instance of the **SqlSet** class using the provided defining query.                             
[SqlSet(SqlBuilder, DbConnection)][6]       | Initializes a new instance of the **SqlSet** class using the provided defining query and connection.              
[SqlSet(SqlBuilder, Type)][7]               | Initializes a new instance of the **SqlSet** class using the provided defining query and result type.             
[SqlSet(SqlBuilder, Type, DbConnection)][8] | Initializes a new instance of the **SqlSet** class using the provided defining query, result type and connection. 


Methods
-------

Name                                                                      | Description                                                                                                                                                                                              
------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[All(String)][9]                                                          | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
[All(String, Object[])][10]                                               | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
[Any()][11]                                                               | Determines whether the set contains any elements.                                                                                                                                                        
[Any(String)][12]                                                         | Determines whether any element of the set satisfies a condition.                                                                                                                                         
[Any(String, Object[])][13]                                               | Determines whether any element of the set satisfies a condition.                                                                                                                                         
[AsEnumerable][14]                                                        | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            
[Cast(Type)][15]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
[Cast&lt;TResult>()][16]                                                  | Casts the elements of the set to the specified type.                                                                                                                                                     
[Count()][17]                                                             | Returns the number of elements in the set.                                                                                                                                                               
[Count(String)][18]                                                       | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
[Count(String, Object[])][19]                                             | Gets the number of elements in the set that matches the *predicate*.                                                                                                                                     
[Equals][20]                                                              | Returns whether the specified set is equal to the current set. (Overrides [Object.Equals(Object)][21].)                                                                                                  
[First()][22]                                                             | Returns the first element of the set.                                                                                                                                                                    
[First(String)][23]                                                       | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[First(String, Object[])][24]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[FirstOrDefault()][25]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
[FirstOrDefault(String)][26]                                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[FirstOrDefault(String, Object[])][27]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[GetDefiningQuery][28]                                                    | Returns the SQL query that is the source of data for the set.                                                                                                                                            
[GetEnumerator][29]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
[GetHashCode][30]                                                         | Returns the hash function for the current set. (Overrides [Object.GetHashCode()][31].)                                                                                                                   
[GetType][32]                                                             | Gets the type for the current set.                                                                                                                                                                       
[LongCount()][33]                                                         | Returns an [Int64][34] that represents the total number of elements in the set.                                                                                                                          
[LongCount(String)][35]                                                   | Returns an [Int64][34] that represents how many elements in the set satisfy a condition.                                                                                                                 
[LongCount(String, Object[])][36]                                         | Returns an [Int64][34] that represents how many elements in the set satisfy a condition.                                                                                                                 
[OrderBy(String)][37]                                                     | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[OrderBy(String, Object[])][38]                                           | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[Select(String)][39]                                                      | Projects each element of the set into a new form.                                                                                                                                                        
[Select(String, Object[])][40]                                            | Projects each element of the set into a new form.                                                                                                                                                        
[Select(Type, String)][41]                                                | Projects each element of the set into a new form.                                                                                                                                                        
[Select(Type, String, Object[])][42]                                      | Projects each element of the set into a new form.                                                                                                                                                        
[Select&lt;TResult>(String)][43]                                          | Projects each element of the set into a new form.                                                                                                                                                        
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String)][44]           | Projects each element of the set into a new form.                                                                                                                                                        
[Select&lt;TResult>(String, Object[])][45]                                | Projects each element of the set into a new form.                                                                                                                                                        
[Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][46] | Projects each element of the set into a new form.                                                                                                                                                        
[Single()][47]                                                            | The single element of the set.                                                                                                                                                                           
[Single(String)][48]                                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[Single(String, Object[])][49]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[SingleOrDefault()][50]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
[SingleOrDefault(String)][51]                                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[SingleOrDefault(String, Object[])][52]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[Skip][53]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
[Take][54]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
[ToArray][55]                                                             | Creates an array from the set.                                                                                                                                                                           
[ToList][56]                                                              | Creates a List&lt;object> from the set.                                                                                                                                                                  
[ToString][57]                                                            | Returns the SQL query of the set. (Overrides [Object.ToString()][58].)                                                                                                                                   
[Where(String)][59]                                                       | Filters the set based on a predicate.                                                                                                                                                                    
[Where(String, Object[])][60]                                             | Filters the set based on a predicate.                                                                                                                                                                    


Extension Methods
-----------------

Name          | Description                                                                                   
------------- | --------------------------------------------------------------------------------------------- 
[Find][61]    | Gets the entity whose primary key matches the *id* parameter. (Defined by [Extensions][62].)  
[Include][63] | Specifies the related objects to include in the query results. (Defined by [Extensions][62].) 


See Also
--------
[DbExtensions Namespace][4]  

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
[20]: Equals.md
[21]: http://msdn.microsoft.com/en-us/library/bsc2ak47
[22]: First.md
[23]: First_1.md
[24]: First_2.md
[25]: FirstOrDefault.md
[26]: FirstOrDefault_1.md
[27]: FirstOrDefault_2.md
[28]: GetDefiningQuery.md
[29]: GetEnumerator.md
[30]: GetHashCode.md
[31]: http://msdn.microsoft.com/en-us/library/zdee4b3y
[32]: GetType.md
[33]: LongCount.md
[34]: http://msdn.microsoft.com/en-us/library/6yy583ek
[35]: LongCount_1.md
[36]: LongCount_2.md
[37]: OrderBy.md
[38]: OrderBy_1.md
[39]: Select.md
[40]: Select_1.md
[41]: Select_2.md
[42]: Select_3.md
[43]: Select__1_2.md
[44]: Select__1.md
[45]: Select__1_3.md
[46]: Select__1_1.md
[47]: Single.md
[48]: Single_1.md
[49]: Single_2.md
[50]: SingleOrDefault.md
[51]: SingleOrDefault_1.md
[52]: SingleOrDefault_2.md
[53]: Skip.md
[54]: Take.md
[55]: ToArray.md
[56]: ToList.md
[57]: ToString.md
[58]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[59]: Where.md
[60]: Where_1.md
[61]: ../Extensions/Find.md
[62]: ../Extensions/README.md
[63]: ../Extensions/Include.md