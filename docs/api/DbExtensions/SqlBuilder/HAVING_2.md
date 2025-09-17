SqlBuilder.HAVING(String) Method
================================
Appends the HAVING clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                                         |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| [HAVING()][2]                                                    | Sets HAVING as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [HAVING(SqlBuilder.ClauseStringHandler&lt;SqlClause.HAVING>)][4] | Appends the HAVING clause using the provided interpolated string *handler*.                                                                         |
| **HAVING(String)**                                               | Appends the HAVING clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder HAVING(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the HAVING clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: HAVING.md
[3]: _If.md
[4]: HAVING_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md