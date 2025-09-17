SqlClause.DELETE_FROM Class
===========================
The DELETE FROM clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.DELETE_FROM**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class DELETE_FROM : SqlClause, 
	IEquatable<SqlClause.DELETE_FROM>
```

The **SqlClause.DELETE_FROM** type exposes the following members.


Constructors
------------

| Name                       | Description             |
| -------------------------- | ----------------------- |
| [SqlClause.DELETE_FROM][4] | The DELETE FROM clause. |


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