SqlClause.CROSS_JOIN Class
==========================
The CROSS JOIN clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.CROSS_JOIN**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class CROSS_JOIN : SqlClause, 
	IEquatable<SqlClause.CROSS_JOIN>
```

The **SqlClause.CROSS_JOIN** type exposes the following members.


Constructors
------------

| Name                      | Description            |
| ------------------------- | ---------------------- |
| [SqlClause.CROSS_JOIN][4] | The CROSS JOIN clause. |


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