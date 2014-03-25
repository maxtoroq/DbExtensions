SqlSet Class
============
Represents an immutable, connected SQL query.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet<TResult>][2]  
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

Name                                                     | Description                                                                                                               
-------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- 
[SqlSet(SqlBuilder)][5]                                  | Initializes a new instance of the **SqlSet** class using the provided defining query.                                     
[SqlSet(SqlBuilder, DbConnection)][6]                    | Initializes a new instance of the **SqlSet** class using the provided defining query and connection.                      
[SqlSet(SqlBuilder, Type)][7]                            | Initializes a new instance of the **SqlSet** class using the provided defining query and result type.                     
[SqlSet(SqlSet, SqlBuilder)][8]                          | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.              
[SqlSet(SqlBuilder, DbConnection, TextWriter)][9]        | Initializes a new instance of the **SqlSet** class using the provided defining query, connection and logger.              
[SqlSet(SqlBuilder, Type, DbConnection)][10]             | Initializes a new instance of the **SqlSet** class using the provided defining query, result type and connection.         
[SqlSet(SqlSet, SqlBuilder, Type)][11]                   | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.              
[SqlSet(SqlBuilder, Type, DbConnection, TextWriter)][12] | Initializes a new instance of the **SqlSet** class using the provided defining query, result type, connection and logger. 


Methods
-------

Name                                                                | Description                                                                                                                                                                                              
------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[All(String)][13]                                                   | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
[All(String, Object[])][14]                                         | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
[Any()][15]                                                         | Determines whether the set contains any elements.                                                                                                                                                        
[Any(String)][16]                                                   | Determines whether any element of the set satisfies a condition.                                                                                                                                         
[Any(String, Object[])][17]                                         | Determines whether any element of the set satisfies a condition.                                                                                                                                         
[AsEnumerable][18]                                                  | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            
[AsXml()][19]                                                       | Returns an [XmlReader][20] object that provides an XML view of the set's data.                                                                                                                           
[AsXml(XmlMappingSettings)][21]                                     | Returns an [XmlReader][20] object that provides an XML view of the set's data.                                                                                                                           
[Cast(Type)][22]                                                    | Casts the elements of the set to the specified type.                                                                                                                                                     
[Cast<TResult>()][23]                                               | Casts the elements of the set to the specified type.                                                                                                                                                     
[Count()][24]                                                       | Returns the number of elements in the set.                                                                                                                                                               
[Count(String)][25]                                                 | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
[Count(String, Object[])][26]                                       | Gets the number of elements in the set that matches the *predicate*.                                                                                                                                     
[CreateSet(SqlBuilder)][27]                                         | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[CreateSet(SqlBuilder, Type)][28]                                   | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[CreateSet<TResult>(SqlBuilder)][29]                                | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[CreateSet<TResult>(SqlBuilder, Func<IDataRecord, TResult>)][30]    | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[CreateSuperQuery()][31]                                            | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[CreateSuperQuery(String, Object[])][32]                            | This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                                             
[Equals][33]                                                        | Returns whether the specified set is equal to the current set. (Overrides [Object.Equals(Object)][34].)                                                                                                  
[Execute][35]                                                       | **Obsolete.** This member supports the DbExtensions infrastructure and is not intended to be used directly from your code.                                                                               
[First()][36]                                                       | Returns the first element of the set.                                                                                                                                                                    
[First(String)][37]                                                 | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[First(String, Object[])][38]                                       | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
[FirstOrDefault()][39]                                              | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
[FirstOrDefault(String)][40]                                        | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[FirstOrDefault(String, Object[])][41]                              | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
[GetDefiningQuery][42]                                              | Returns the SQL query that is the source of data for the set.                                                                                                                                            
[GetEnumerator][43]                                                 | Returns an enumerator that iterates through the set.                                                                                                                                                     
[GetHashCode][44]                                                   | Returns the hash function for the current set. (Overrides [Object.GetHashCode()][45].)                                                                                                                   
[GetType][46]                                                       | Gets the type for the current set.                                                                                                                                                                       
[LongCount()][47]                                                   | Returns an [Int64][48] that represents the total number of elements in the set.                                                                                                                          
[LongCount(String)][49]                                             | Returns an [Int64][48] that represents how many elements in the set satisfy a condition.                                                                                                                 
[LongCount(String, Object[])][50]                                   | Returns an [Int64][48] that represents how many elements in the set satisfy a condition.                                                                                                                 
[OrderBy(String)][51]                                               | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[OrderBy(String, Object[])][52]                                     | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
[Select(Type, String)][53]                                          | Projects each element of the set into a new form.                                                                                                                                                        
[Select(Type, String, Object[])][54]                                | Projects each element of the set into a new form.                                                                                                                                                        
[Select<TResult>(String)][55]                                       | Projects each element of the set into a new form.                                                                                                                                                        
[Select<TResult>(Func<IDataRecord, TResult>, String)][56]           | Projects each element of the set into a new form.                                                                                                                                                        
[Select<TResult>(String, Object[])][57]                             | Projects each element of the set into a new form.                                                                                                                                                        
[Select<TResult>(Func<IDataRecord, TResult>, String, Object[])][58] | Projects each element of the set into a new form.                                                                                                                                                        
[Single()][59]                                                      | The single element of the set.                                                                                                                                                                           
[Single(String)][60]                                                | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[Single(String, Object[])][61]                                      | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
[SingleOrDefault()][62]                                             | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
[SingleOrDefault(String)][63]                                       | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[SingleOrDefault(String, Object[])][64]                             | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
[Skip][65]                                                          | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
[Take][66]                                                          | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
[ToArray][67]                                                       | Creates an array from the set.                                                                                                                                                                           
[ToList][68]                                                        | Creates a List&lt;object> from the set.                                                                                                                                                                  
[ToString][69]                                                      | Returns the SQL query of the set. (Overrides [Object.ToString()][70].)                                                                                                                                   
[Union][71]                                                         | Produces the set union of the current set with *otherSet*.                                                                                                                                               
[Where(String)][72]                                                 | Filters the set based on a predicate.                                                                                                                                                                    
[Where(String, Object[])][73]                                       | Filters the set based on a predicate.                                                                                                                                                                    


See Also
--------
[DbExtensions Namespace][4]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../SqlSet_1/README.md
[3]: ../SqlTable/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: _ctor_1.md
[7]: _ctor_3.md
[8]: _ctor_6.md
[9]: _ctor_2.md
[10]: _ctor_4.md
[11]: _ctor_7.md
[12]: _ctor_5.md
[13]: All.md
[14]: All_1.md
[15]: Any.md
[16]: Any_1.md
[17]: Any_2.md
[18]: AsEnumerable.md
[19]: AsXml.md
[20]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[21]: AsXml_1.md
[22]: Cast.md
[23]: Cast__1.md
[24]: Count.md
[25]: Count_1.md
[26]: Count_2.md
[27]: CreateSet.md
[28]: CreateSet_1.md
[29]: CreateSet__1.md
[30]: CreateSet__1_1.md
[31]: CreateSuperQuery.md
[32]: CreateSuperQuery_1.md
[33]: Equals.md
[34]: http://msdn.microsoft.com/en-us/library/bsc2ak47
[35]: Execute.md
[36]: First.md
[37]: First_1.md
[38]: First_2.md
[39]: FirstOrDefault.md
[40]: FirstOrDefault_1.md
[41]: FirstOrDefault_2.md
[42]: GetDefiningQuery.md
[43]: GetEnumerator.md
[44]: GetHashCode.md
[45]: http://msdn.microsoft.com/en-us/library/zdee4b3y
[46]: GetType.md
[47]: LongCount.md
[48]: http://msdn.microsoft.com/en-us/library/6yy583ek
[49]: LongCount_1.md
[50]: LongCount_2.md
[51]: OrderBy.md
[52]: OrderBy_1.md
[53]: Select.md
[54]: Select_1.md
[55]: Select__1_2.md
[56]: Select__1.md
[57]: Select__1_3.md
[58]: Select__1_1.md
[59]: Single.md
[60]: Single_1.md
[61]: Single_2.md
[62]: SingleOrDefault.md
[63]: SingleOrDefault_1.md
[64]: SingleOrDefault_2.md
[65]: Skip.md
[66]: Take.md
[67]: ToArray.md
[68]: ToList.md
[69]: ToString.md
[70]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[71]: Union.md
[72]: Where.md
[73]: Where_1.md