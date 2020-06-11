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
![Public method] | [Contains][12]                                                            | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       
![Public method] | [ContainsKey][13]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              
![Public method] | [Count()][14]                                                             | Returns the number of elements in the set.                                                                                                                                                               
![Public method] | [Count(String, Object[])][15]                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
![Public method] | [Find][16]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            
![Public method] | [First()][17]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String, Object[])][18]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][19]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][20]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][21]                                                    | Returns the SQL query that is the source of data for the set.                                                                                                                                            
![Public method] | [GetEnumerator][22]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [Include][23]                                                             | Specifies the related objects to include in the query results.                                                                                                                                           
![Public method] | [LongCount()][24]                                                         | Returns an [Int64][25] that represents the total number of elements in the set.                                                                                                                          
![Public method] | [LongCount(String, Object[])][26]                                         | Returns an [Int64][25] that represents how many elements in the set satisfy a condition.                                                                                                                 
![Public method] | [OrderBy][27]                                                             | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(String, Object[])][28]                                            | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(Type, String, Object[])][29]                                      | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][30]                                | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][31] | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Single()][32]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String, Object[])][33]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][34]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String, Object[])][35]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][36]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][37]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][38]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][39]                                                              | Creates a List&lt;object> from the set.                                                                                                                                                                  
![Public method] | [ToString][40]                                                            | Returns the SQL query of the set. (Overrides [Object.ToString()][41].)                                                                                                                                   
![Public method] | [Where][42]                                                               | Filters the set based on a predicate.                                                                                                                                                                    


Properties
----------

                   | Name             | Description                                                      
------------------ | ---------------- | ---------------------------------------------------------------- 
![Public property] | [ResultType][43] | The type of objects this set returns. This property can be null. 


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][44].

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
[12]: Contains.md
[13]: ContainsKey.md
[14]: Count.md
[15]: Count_1.md
[16]: Find.md
[17]: First.md
[18]: First_1.md
[19]: FirstOrDefault.md
[20]: FirstOrDefault_1.md
[21]: GetDefiningQuery.md
[22]: GetEnumerator.md
[23]: Include.md
[24]: LongCount.md
[25]: http://msdn.microsoft.com/en-us/library/6yy583ek
[26]: LongCount_1.md
[27]: OrderBy.md
[28]: Select.md
[29]: Select_1.md
[30]: Select__1_1.md
[31]: Select__1.md
[32]: Single.md
[33]: Single_1.md
[34]: SingleOrDefault.md
[35]: SingleOrDefault_1.md
[36]: Skip.md
[37]: Take.md
[38]: ToArray.md
[39]: ToList.md
[40]: ToString.md
[41]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[42]: Where.md
[43]: ResultType.md
[44]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public method]: ../../icons/pubmethod.gif "Public method"
[Public property]: ../../icons/pubproperty.gif "Public property"