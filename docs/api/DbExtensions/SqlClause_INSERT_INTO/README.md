SqlClause.INSERT_INTO Class
===========================
The INSERT INTO clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.INSERT_INTO**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class INSERT_INTO : SqlClause, 
	IEquatable<SqlClause.INSERT_INTO>
```

The **SqlClause.INSERT_INTO** type exposes the following members.


Constructors
------------

| Name                       | Description             |
| -------------------------- | ----------------------- |
| [SqlClause.INSERT_INTO][4] | The INSERT INTO clause. |


Properties
----------

| Name           | Description                                                                  |
| -------------- | ---------------------------------------------------------------------------- |
| [Name][5]      | The name of the clause.<br/>(Inherited from [SqlClause][2])                  |
| [Separator][6] | The string to use for consecutive calls.<br/>(Inherited from [SqlClause][2]) |


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.object
[2]: ../SqlClause/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: ../SqlClause/Name.md
[6]: ../SqlClause/Separator.md