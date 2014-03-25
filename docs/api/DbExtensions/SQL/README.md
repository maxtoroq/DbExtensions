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
public static class SQL
```

The **SQL** type exposes the following members.


Methods
-------

Name                                | Description                                                                                                                       
----------------------------------- | --------------------------------------------------------------------------------------------------------------------------------- 
[ctor()][4]                         | **Obsolete.** Creates and returns a new [SqlBuilder][1].                                                                          
[ctor(String)][5]                   | **Obsolete.** Creates and returns a new [SqlBuilder][1] initialized with *sql*.                                                   
[ctor(String, Object[])][6]         | **Obsolete.** Creates and returns a new [SqlBuilder][1] initialized with *format* and *args*.                                     
[DELETE_FROM(String)][7]            | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *body*.              
[DELETE_FROM(String, Object[])][8]  | Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *format* and *args*. 
[Equals][9]                         | Determines whether the specified object instances are considered equal.                                                           
[INSERT_INTO(String)][10]           | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *body*.              
[INSERT_INTO(String, Object[])][11] | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *format* and *args*. 
[Param][12]                         | Wraps an array parameter to be used with [SqlBuilder][1].                                                                         
[ReferenceEquals][13]               | Determines whether the specified System.Object instances are the same instance.                                                   
[SELECT(String)][14]                | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *body*.                   
[SELECT(String, Object[])][15]      | Creates and returns a new [SqlBuilder][1] initialized by appending the SELECT clause using the provided *format* and *args*.      
[UPDATE(String)][16]                | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *body*.                   
[UPDATE(String, Object[])][17]      | Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *format* and *args*.      
[WITH(String)][18]                  | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *body*.                     
[WITH(String, Object[])][19]        | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.        
[WITH(SqlBuilder, String)][20]      | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.     


See Also
--------
[DbExtensions Namespace][3]  

[1]: ../SqlBuilder/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: ctor.md
[5]: ctor_1.md
[6]: ctor_2.md
[7]: DELETE_FROM.md
[8]: DELETE_FROM_1.md
[9]: Equals.md
[10]: INSERT_INTO.md
[11]: INSERT_INTO_1.md
[12]: Param.md
[13]: ReferenceEquals.md
[14]: SELECT.md
[15]: SELECT_1.md
[16]: UPDATE.md
[17]: UPDATE_1.md
[18]: WITH_1.md
[19]: WITH_2.md
[20]: WITH.md