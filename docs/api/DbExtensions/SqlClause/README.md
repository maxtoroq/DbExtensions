SqlClause Class
===============
Provides information about a SQL clause. Used by [SqlBuilder][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SqlClause**  
    [More][3]  
**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public abstract class SqlClause : IEquatable<SqlClause>
```

The **SqlClause** type exposes the following members.


Constructors
------------

| Name           | Description                                                       |
| -------------- | ----------------------------------------------------------------- |
| [SqlClause][5] | Provides information about a SQL clause. Used by [SqlBuilder][1]. |


Properties
----------

| Name           | Description                              |
| -------------- | ---------------------------------------- |
| [Name][6]      | The name of the clause.                  |
| [Separator][7] | The string to use for consecutive calls. |


Methods
-------

| Name                      | Description                                                    |
| ------------------------- | -------------------------------------------------------------- |
| [Instance&lt;TClause>][8] | Gets a singleton instance of the clause identified by TClause. |


See Also
--------

#### Reference
[DbExtensions Namespace][4]  


Inheritance Hierarchy (Continued)
---------------------------------
[System.Object][2]  
  **DbExtensions.SqlClause**  
    [DbExtensions.SqlClause.CROSS_JOIN][9]  
    [DbExtensions.SqlClause.Current][10]  
    [DbExtensions.SqlClause.DELETE_FROM][11]  
    [DbExtensions.SqlClause.FROM][12]  
    [DbExtensions.SqlClause.GROUP_BY][13]  
    [DbExtensions.SqlClause.HAVING][14]  
    [DbExtensions.SqlClause.INNER_JOIN][15]  
    [DbExtensions.SqlClause.INSERT_INTO][16]  
    [DbExtensions.SqlClause.JOIN][17]  
    [DbExtensions.SqlClause.LEFT_JOIN][18]  
    [DbExtensions.SqlClause.LIMIT][19]  
    [DbExtensions.SqlClause.OFFSET][20]  
    [DbExtensions.SqlClause.ORDER_BY][21]  
    [DbExtensions.SqlClause.RIGHT_JOIN][22]  
    [DbExtensions.SqlClause.SELECT][23]  
    [DbExtensions.SqlClause.SET][24]  
    [DbExtensions.SqlClause.UNION][25]  
    [DbExtensions.SqlClause.UPDATE][26]  
    [DbExtensions.SqlClause.VALUES][27]  
    [DbExtensions.SqlClause.WHERE][28]  
    [DbExtensions.SqlClause.WITH][29]  

[1]: ../SqlBuilder/README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: #inheritance-hierarchy-continued
[4]: ../README.md
[5]: _ctor.md
[6]: Name.md
[7]: Separator.md
[8]: Instance__1.md
[9]: ../SqlClause_CROSS_JOIN/README.md
[10]: ../SqlClause_Current/README.md
[11]: ../SqlClause_DELETE_FROM/README.md
[12]: ../SqlClause_FROM/README.md
[13]: ../SqlClause_GROUP_BY/README.md
[14]: ../SqlClause_HAVING/README.md
[15]: ../SqlClause_INNER_JOIN/README.md
[16]: ../SqlClause_INSERT_INTO/README.md
[17]: ../SqlClause_JOIN/README.md
[18]: ../SqlClause_LEFT_JOIN/README.md
[19]: ../SqlClause_LIMIT/README.md
[20]: ../SqlClause_OFFSET/README.md
[21]: ../SqlClause_ORDER_BY/README.md
[22]: ../SqlClause_RIGHT_JOIN/README.md
[23]: ../SqlClause_SELECT/README.md
[24]: ../SqlClause_SET/README.md
[25]: ../SqlClause_UNION/README.md
[26]: ../SqlClause_UPDATE/README.md
[27]: ../SqlClause_VALUES/README.md
[28]: ../SqlClause_WHERE/README.md
[29]: ../SqlClause_WITH/README.md