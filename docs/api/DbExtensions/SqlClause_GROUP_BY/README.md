SqlClause.GROUP_BY Class
========================
The GROUP BY clause.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [DbExtensions.SqlClause][2]  
    **DbExtensions.SqlClause.GROUP_BY**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class GROUP_BY : SqlClause, 
	IEquatable<SqlClause.GROUP_BY>
```

The **SqlClause.GROUP_BY** type exposes the following members.


Constructors
------------

| Name                    | Description          |
| ----------------------- | -------------------- |
| [SqlClause.GROUP_BY][4] | The GROUP BY clause. |


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