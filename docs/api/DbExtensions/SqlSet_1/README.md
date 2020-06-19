SqlSet&lt;TResult> Class
========================
Represents an immutable, connected SQL query that maps to TResult objects. This class cannot be instantiated, to get an instance use the [From&lt;TResult>(String)][1] method.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [DbExtensions.SqlSet][3]  
    **DbExtensions.SqlSet&lt;TResult>**  
      [DbExtensions.SqlTable&lt;TEntity>][4]  

  **Namespace:**  [DbExtensions][5]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class SqlSet<TResult> : SqlSet

```

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

The **SqlSet&lt;TResult>** type exposes the following members.


Properties
----------

                   | Name            | Description                                                                                    
------------------ | --------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [ResultType][6] | The type of objects this set returns. This property can be null. (Inherited from [SqlSet][3].) 


Methods
-------

                 | Name                                                                      | Description                                                                                                                                                                                              
---------------- | ------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [All][7]                                                                  | Determines whether all elements of the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                                            
![Public method] | [Any()][8]                                                                | Determines whether the set contains any elements. (Inherited from [SqlSet][3].)                                                                                                                          
![Public method] | [Any(String, Object[])][9]                                                | Determines whether any element of the set satisfies a condition. (Inherited from [SqlSet][3].)                                                                                                           
![Public method] | [AsEnumerable][10]                                                        | Gets all TResult objects in the set. The query is deferred-executed.                                                                                                                                     
![Public method] | [Cast(Type)][11]                                                          | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Cast&lt;T>()][12]                                                        | Casts the elements of the set to the specified type.                                                                                                                                                     
![Public method] | [Contains(Object)][13]                                                    | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       
![Public method] | [Contains(TResult)][14]                                                   | Checks the existance of the *entity*, using the primary key value.                                                                                                                                       
![Public method] | [ContainsKey][15]                                                         | Checks the existance of an entity whose primary matches the *id* parameter. (Inherited from [SqlSet][3].)                                                                                                
![Public method] | [Count()][16]                                                             | Returns the number of elements in the set. (Inherited from [SqlSet][3].)                                                                                                                                 
![Public method] | [Count(String, Object[])][17]                                             | Returns a number that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                         
![Public method] | [Find][18]                                                                | Gets the entity whose primary key matches the *id* parameter.                                                                                                                                            
![Public method] | [First()][19]                                                             | Returns the first element of the set.                                                                                                                                                                    
![Public method] | [First(String, Object[])][20]                                             | Returns the first element in the set that satisfies a specified condition.                                                                                                                               
![Public method] | [FirstOrDefault()][21]                                                    | Returns the first element of the set, or a default value if the set contains no elements.                                                                                                                
![Public method] | [FirstOrDefault(String, Object[])][22]                                    | Returns the first element of the set that satisfies a condition or a default value if no such element is found.                                                                                          
![Public method] | [GetDefiningQuery][23]                                                    | Returns the SQL query that is the source of data for the set. (Inherited from [SqlSet][3].)                                                                                                              
![Public method] | [GetEnumerator][24]                                                       | Returns an enumerator that iterates through the set.                                                                                                                                                     
![Public method] | [Include][25]                                                             | Specifies the related objects to include in the query results.                                                                                                                                           
![Public method] | [LongCount()][26]                                                         | Returns an [Int64][27] that represents the total number of elements in the set. (Inherited from [SqlSet][3].)                                                                                            
![Public method] | [LongCount(String, Object[])][28]                                         | Returns an [Int64][27] that represents how many elements in the set satisfy a condition. (Inherited from [SqlSet][3].)                                                                                   
![Public method] | [OrderBy][29]                                                             | Sorts the elements of the set according to the *columnList*.                                                                                                                                             
![Public method] | [Select(Type, String, Object[])][30]                                      | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                          
![Public method] | [Select&lt;TResult>(String, Object[])][31]                                | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                          
![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][32] | Projects each element of the set into a new form. (Inherited from [SqlSet][3].)                                                                                                                          
![Public method] | [Single()][33]                                                            | The single element of the set.                                                                                                                                                                           
![Public method] | [Single(String, Object[])][34]                                            | Returns the only element of the set that satisfies a specified condition, and throws an exception if more than one such element exists.                                                                  
![Public method] | [SingleOrDefault()][35]                                                   | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               
![Public method] | [SingleOrDefault(String, Object[])][36]                                   | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. 
![Public method] | [Skip][37]                                                                | Bypasses a specified number of elements in the set and then returns the remaining elements.                                                                                                              
![Public method] | [Take][38]                                                                | Returns a specified number of contiguous elements from the start of the set.                                                                                                                             
![Public method] | [ToArray][39]                                                             | Creates an array from the set.                                                                                                                                                                           
![Public method] | [ToList][40]                                                              | Creates a List&lt;TResult> from the set.                                                                                                                                                                 
![Public method] | [ToString][41]                                                            | Returns the SQL query of the set. (Inherited from [SqlSet][3].)                                                                                                                                          
![Public method] | [Where][42]                                                               | Filters the set based on a predicate.                                                                                                                                                                    


Remarks
-------
For information on how to use SqlSet see [SqlSet Tutorial][43].

See Also
--------

#### Reference
[DbExtensions Namespace][5]  

[1]: ../Database/From__1_2.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../SqlSet/README.md
[4]: ../SqlTable_1/README.md
[5]: ../README.md
[6]: ../SqlSet/ResultType.md
[7]: ../SqlSet/All.md
[8]: ../SqlSet/Any.md
[9]: ../SqlSet/Any_1.md
[10]: AsEnumerable.md
[11]: Cast.md
[12]: Cast__1.md
[13]: Contains.md
[14]: Contains_1.md
[15]: ../SqlSet/ContainsKey.md
[16]: ../SqlSet/Count.md
[17]: ../SqlSet/Count_1.md
[18]: Find.md
[19]: First.md
[20]: First_1.md
[21]: FirstOrDefault.md
[22]: FirstOrDefault_1.md
[23]: ../SqlSet/GetDefiningQuery.md
[24]: GetEnumerator.md
[25]: Include.md
[26]: ../SqlSet/LongCount.md
[27]: http://msdn.microsoft.com/en-us/library/6yy583ek
[28]: ../SqlSet/LongCount_1.md
[29]: OrderBy.md
[30]: ../SqlSet/Select_1.md
[31]: ../SqlSet/Select__1_1.md
[32]: ../SqlSet/Select__1.md
[33]: Single.md
[34]: Single_1.md
[35]: SingleOrDefault.md
[36]: SingleOrDefault_1.md
[37]: Skip.md
[38]: Take.md
[39]: ToArray.md
[40]: ToList.md
[41]: ../SqlSet/ToString.md
[42]: Where.md
[43]: http://maxtoroq.github.io/DbExtensions/docs/SqlSet.html
[Public property]: ../../icons/pubproperty.gif "Public property"
[Public method]: ../../icons/pubmethod.gif "Public method"