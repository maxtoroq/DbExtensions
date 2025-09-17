SqlClause.LEFT_JOIN Class
=========================
The LEFT JOIN clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.LEFT_JOIN**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class LEFT_JOIN : SqlClause, 
	IEquatable<SqlClause.LEFT_JOIN>
```

The **SqlClause.LEFT_JOIN** type exposes the following members.


Constructors
------------

| Name                     | Description           |
| ------------------------ | --------------------- |
| [SqlClause.LEFT_JOIN][4] | The LEFT JOIN clause. |


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