SqlClause.INNER_JOIN Class
==========================
The INNER JOIN clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.INNER_JOIN**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class INNER_JOIN : SqlClause, 
	IEquatable<SqlClause.INNER_JOIN>
```

The **SqlClause.INNER_JOIN** type exposes the following members.


Constructors
------------

| Name                      | Description            |
| ------------------------- | ---------------------- |
| [SqlClause.INNER_JOIN][4] | The INNER JOIN clause. |


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