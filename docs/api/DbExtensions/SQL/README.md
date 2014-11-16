SQL Class
=========
Provides a set of static (Shared in Visual Basic) methods to create [SqlBuilder][1] instances.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SQL**  

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static class SQL
```

The **SQL** type exposes the following members.


Methods
-------

                                 | Name                               | Description                                                                                                                       
-------------------------------- | ---------------------------------- | --------------------------------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [DELETE_FROM(String)][4]           | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *body*.              
![Public method]![Static member] | [DELETE_FROM(String, Object[])][5] | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *format* and *args*. 
![Public method]![Static member] | [Equals][6]                        | Determines whether the specified object instances are considered equal.                                                           
![Public method]![Static member] | [INSERT_INTO(String)][7]           | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *body*.              
![Public method]![Static member] | [INSERT_INTO(String, Object[])][8] | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *format* and *args*. 
![Public method]![Static member] | [Param][9]                         | Wraps an array parameter to be used with [SqlBuilder][1].                                                                         
![Public method]![Static member] | [ReferenceEquals][10]              | Determines whether the specified System.Object instances are the same instance.                                                   
![Public method]![Static member] | [SELECT(String)][11]               | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *body*.                   
![Public method]![Static member] | [SELECT(String, Object[])][12]     | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *format* and *args*.      
![Public method]![Static member] | [UPDATE(String)][13]               | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *body*.                   
![Public method]![Static member] | [UPDATE(String, Object[])][14]     | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *format* and *args*.      
![Public method]![Static member] | [WITH(String)][15]                 | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *body*.                     
![Public method]![Static member] | [WITH(String, Object[])][16]       | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.        
![Public method]![Static member] | [WITH(SqlBuilder, String)][17]     | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.     


See Also
--------
[DbExtensions Namespace][3]  

[1]: ../SqlBuilder/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: DELETE_FROM.md
[5]: DELETE_FROM_1.md
[6]: Equals.md
[7]: INSERT_INTO.md
[8]: INSERT_INTO_1.md
[9]: Param.md
[10]: ReferenceEquals.md
[11]: SELECT.md
[12]: SELECT_1.md
[13]: UPDATE.md
[14]: UPDATE_1.md
[15]: WITH_1.md
[16]: WITH_2.md
[17]: WITH.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"