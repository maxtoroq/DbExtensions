SqlBuilder.JOIN(String) Method
==============================
Appends the JOIN clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                               | Description                                                                                                                                       |
| -------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| [JOIN()][2]                                        | Sets JOIN as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [JOIN(SqlBuilder.ClauseStringHandler&lt;JOIN>)][4] | Appends the JOIN clause using the provided interpolated string *handler*.                                                                         |
| **JOIN(String)**                                   | Appends the JOIN clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder JOIN(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the JOIN clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: JOIN.md
[3]: _If.md
[4]: JOIN_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md