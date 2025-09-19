SqlBuilder.CROSS_JOIN(String) Method
====================================
Appends the CROSS JOIN clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                           | Description                                                                                                                                             |
| -------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [CROSS_JOIN()][2]                                              | Sets CROSS JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [CROSS_JOIN(SqlBuilder.ClauseStringHandler&lt;CROSS_JOIN>)][4] | Appends the CROSS JOIN clause using the provided interpolated string *handler*.                                                                         |
| **CROSS_JOIN(String)**                                         | Appends the CROSS JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder CROSS_JOIN(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the CROSS JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: CROSS_JOIN.md
[3]: _If.md
[4]: CROSS_JOIN_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md