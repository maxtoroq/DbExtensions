SqlBuilder.AppendClause&lt;TClause>(String) Method
==================================================
Appends the SQL clause identified by TClause and appends the *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder AppendClause<TClause>(
	string? text
)
where TClause : new(), SqlClause

```

#### Parameters

##### *text*  [String][2]
The text to append.

#### Type Parameters

##### *TClause*
The type of the SQL clause.

#### Return Value
[SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.string
[3]: README.md