SqlSet Class
============
Represents an immutable, connected SQL query. This class cannot be instantiated, to get an instance use the [From(String)][1] method.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SqlSet**  
    [DbExtensions.SqlSet&lt;TResult>][3]  
    [DbExtensions.SqlTable][4]  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public class SqlSet
```

The **SqlSet** type exposes the following members.


Properties
----------

                   | Name            | Description                                                      
------------------ | --------------- | ---------------------------------------------------------------- 
![Public property] | [ResultType][6] | The type of objects this set returns. This property can be null. 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                              
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [All][7]                                                                  | Determines whether all elements of the set satisfy a condition.                                                                                                                                          
![Public method] | [Any()][8]                                                                | Determines whether the set contains any elements.                                                                                                                                                        
![Public method] | [Any(String, Object[])][9]                                                | Determines whether any element of the set satisfies a condition.                                                                                                                                         
![Public method] | [AsEnumerable][10]                                                        | Gets all elements in the set. The query is deferred-executed.                                                                                                                                            
![Public method] | [Cast(Type)][11]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Cast&lt;TResult>()][12]                                                  | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Contains][13]                                                            | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       
![Public method] | [ContainsKey][14]                                                         | Checks the existance of an entity whose primary matches the *id* parameter.                                                                                                                              
![Public method] | [Count()][15]                                                             | Returns the number of elements in the set.                                                                                                                                                               
![Public method] | [Count(String, Object[])][16]                                             | Returns a number that represents how many elements in the set satisfy a condition.                                                                                                                       
![Public method] | [Find][17]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            
![Public method] | [First()][18]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String, Object[])][19]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][20]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][21]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][22]                                                    | Returns the SQL query that is the source of data for the set.                                                                                                                                            
![Public method] | [GetEnumerator][23]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [Include][24]                                                             | Specifies the related objects to include in the query results.                                                                                                                                           
![Public method] | [LongCount()][25]                                                         | Returns an [Int64][26] that represents the total number of elements in the set.                                                                                                                          
![Public method] | [LongCount(String, Object[])][27]                                         | Returns an [Int64][26] that represents how many elements in the set satisfy a condition.                                                                                                                 
![Public method] | [OrderBy][28]                                                             | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(String, Object[])][29]                                            | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select(Type, String, Object[])][30]                                      | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(String, Object[])][31]                                | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][32] | Projects each element of the set into a new form.                                                                                                                                                        
![Public method] | [Single()][33]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String, Object[])][34]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][35]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String, Object[])][36]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][37]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][38]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][39]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][40]                                                              | Creates a List&lt;object> from the set.                                                                                                                                                                  
![Public method] | [ToString][41]                                                            | Returns the SQL query of the set. (Overrides [Object.ToString()][42].)                                                                                                                                   
![Public method] | [Where][43]                                                               | Filters the set based on a predicate.                                                                                                                                                                    


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
[6]: ResultType.md
[7]: All.md
[8]: Any.md
[9]: Any_1.md
[10]: AsEnumerable.md
[11]: Cast.md
[12]: Cast__1.md
[13]: Contains.md
[14]: ContainsKey.md
[15]: Count.md
[16]: Count_1.md
[17]: Find.md
[18]: First.md
[19]: First_1.md
[20]: FirstOrDefault.md
[21]: FirstOrDefault_1.md
[22]: GetDefiningQuery.md
[23]: GetEnumerator.md
[24]: Include.md
[25]: LongCount.md
[26]: http://msdn.microsoft.com/en-us/library/6yy583ek
[27]: LongCount_1.md
[28]: OrderBy.md
[29]: Select.md
[30]: Select_1.md
[31]: Select__1_1.md
[32]: Select__1.md
[33]: Single.md
[34]: Single_1.md
[35]: SingleOrDefault.md
[36]: SingleOrDefault_1.md
[37]: Skip.md
[38]: Take.md
[39]: ToArray.md
[40]: ToList.md
[41]: ToString.md
[42]: http://msdn.microsoft.com/en-us/library/7bxwbwt2
[43]: Where.md
[44]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.gif "Public property"
[Public method]: ../../icons/pubmethod.gif "Public method"