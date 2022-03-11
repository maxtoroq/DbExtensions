SQL Class
=========
Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][1] instances.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SQL**  

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static class SQL
```

The **SQL** type exposes the following members.


Methods
-------

                                 | Name                           | Description                                                                                                                       
-------------------------------- | ------------------------------ | --------------------------------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [DELETE_FROM][4]               | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *format* and *args*. 
![Public method]![Static member] | [INSERT_INTO][5]               | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *format* and *args*. 
![Public method]![Static member] | [List(IEnumerable)][6]         | Returns a special parameter value that is expanded into a list of comma-separated placeholder items.                              
![Public method]![Static member] | [List(Object[])][7]            | Returns a special parameter value that is expanded into a list of comma-separated placeholder items.                              
![Public method]![Static member] | [SELECT][8]                    | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *format* and *args*.      
![Public method]![Static member] | [UPDATE][9]                    | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *format* and *args*.      
![Public method]![Static member] | [WITH(String, Object[])][10]   | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.        
![Public method]![Static member] | [WITH(SqlBuilder, String)][11] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.     
![Public method]![Static member] | [WITH(SqlSet, String)][12]     | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.     


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: ../SqlBuilder/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: DELETE_FROM.md
[5]: INSERT_INTO.md
[6]: List.md
[7]: List_1.md
[8]: SELECT.md
[9]: UPDATE.md
[10]: WITH_2.md
[11]: WITH.md
[12]: WITH_1.md
[Public method]: ../../icons/pubmethod.gif "Public method"
[Static member]: ../../icons/static.gif "Static member"