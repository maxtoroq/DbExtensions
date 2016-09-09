SqlSet Class
============
Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][1] method.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet&lt;TResult>][3]  
    [DbExtensions.SqlTable][4]  

**Namespace:** [DbExtensions][5]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlSet : ISqlSet<SqlSet, Object>
```

The **SqlSet** type exposes the following members.


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                              
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [All][6]                                                                  | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
![Public method] | [Any()][7]                                                                | Determines whether the set contains any elements.                                                                                                                                                        
![Public method] | [Any(String, Object[])][8]                                                | Determines whether any element of the set satisfies a condition.                                                                                                                                         
![Public method] | [AsEnumerable][9]                                                         | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            
![Public method] | [Cast(Type)][10]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Cast&lt;TResult>()][11]                                                  | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Count()][12]                                                             | Returns the number of elements in the set.                                                                                                                                                               
![Public method] | [Count(String, Object[])][13]                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
![Public method] | [Find][14]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            
![Public method] | [First()][15]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String, Object[])][16]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][17]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][18]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][19]                                                    | Returns the SQL query that is the source of data for the set.                                                                                                                                            
![Public method] | [GetEnumerator][20]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [Include][21]                                                             | Specifies the related objects to include in the query results.                                                                                                                                           
![Public method] | [LongCount()][22]                                                         | Returns an [Int64][23] that represents the total number of elements in the set.                                                                                                                          
![Public method] | [LongCount(String, Object[])][24]                                         | Returns an [Int64][23] that represents how many elements in the set satisfy a condition.                                                                                                                 
![Public method] | [OrderBy][25]                                                             | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(String, Object[])][26]                                            | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(Type, String, Object[])][27]                                      | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][28]                                | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][29] | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Single()][30]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String, Object[])][31]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][32]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String, Object[])][33]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][34]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][35]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][36]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][37]                                                              | Creates a List&lt;object> from the set.                                                                                                                                                                  
![Public method] | [ToString][38]                                                            | Returns the SQL query of the set. (Overrides [Object.ToString()][39].)                                                                                                                                   
![Public method] | [Where][40]                                                               | Filters the set based on a predicate.                                                                                                                                                                    


Properties
----------

                   | Name             | Description                                                      
------------------ | ---------------- | ---------------------------------------------------------------- 
![Public property] | [ResultType][41] | The type of objects this set returns. This property can be null. 


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][42].

See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../Database/From_2.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../SqlSet_1/README.md
[4]: ../SqlTable/README.md
[5]: ../README.md
[6]: All.md
[7]: Any.md
[8]: Any_1.md
[9]: AsEnumerable.md
[10]: Cast.md
[11]: Cast__1.md
[12]: Count.md
[13]: Count_1.md
[14]: Find.md
[15]: First.md
[16]: First_1.md
[17]: FirstOrDefault.md
[18]: FirstOrDefault_1.md
[19]: GetDefiningQuery.md
[20]: GetEnumerator.md
[21]: Include.md
[22]: LongCount.md
[23]: http://msdn.microsoft.com/en-us/library/6yy583ek
[24]: LongCount_1.md
[25]: OrderBy.md
[26]: Select.md
[27]: Select_1.md
[28]: Select__1_1.md
[29]: Select__1.md
[30]: Single.md
[31]: Single_1.md
[32]: SingleOrDefault.md
[33]: SingleOrDefault_1.md
[34]: Skip.md
[35]: Take.md
[36]: ToArray.md
[37]: ToList.md
[38]: ToString.md
[39]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[40]: Where.md
[41]: ResultType.md
[42]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"