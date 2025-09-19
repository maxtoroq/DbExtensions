SqlBuilder.LEFT_JOIN(String) Method
===================================
Appends the LEFT JOIN clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                         | Description                                                                                                                                            |
| ------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [LEFT_JOIN()][2]                                             | Sets LEFT JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [LEFT_JOIN(SqlBuilder.ClauseStringHandler&lt;LEFT_JOIN>)][4] | Appends the LEFT JOIN clause using the provided interpolated string *handler*.                                                                         |
| **LEFT_JOIN(String)**                                        | Appends the LEFT JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder LEFT_JOIN(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the LEFT JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: LEFT_JOIN.md
[3]: _If.md
[4]: LEFT_JOIN_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md