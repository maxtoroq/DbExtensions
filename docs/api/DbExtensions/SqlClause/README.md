SqlClause Class
===============
Provides information about a SQL clause. Used by [SqlBuilder][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.SqlClause**  
  
**Namespace:** [DbExtensions][3]  
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
| [SqlClause][4] | Provides information about a SQL clause. Used by [SqlBuilder][1]. |


Properties
----------

| Name           | Description                              |
| -------------- | ---------------------------------------- |
| [Name][5]      | The name of the clause.                  |
| [Separator][6] | The string to use for consecutive calls. |


Methods
-------

| Name                      | Description                                                    |
| ------------------------- | -------------------------------------------------------------- |
| [Instance&lt;TClause>][7] | Gets a singleton instance of the clause identified by TClause. |


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: ../SqlBuilder/README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: ../README.md
[4]: _ctor.md
[5]: Name.md
[6]: Separator.md
[7]: Instance__1.md