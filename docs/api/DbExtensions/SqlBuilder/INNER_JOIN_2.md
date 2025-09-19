SqlBuilder.INNER_JOIN(String) Method
====================================
Appends the INNER JOIN clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                           | Description                                                                                                                                             |
| -------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [INNER_JOIN()][2]                                              | Sets INNER JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [INNER_JOIN(SqlBuilder.ClauseStringHandler&lt;INNER_JOIN>)][4] | Appends the INNER JOIN clause using the provided interpolated string *handler*.                                                                         |
| **INNER_JOIN(String)**                                         | Appends the INNER JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder INNER_JOIN(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the INNER JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: INNER_JOIN.md
[3]: _If.md
[4]: INNER_JOIN_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md