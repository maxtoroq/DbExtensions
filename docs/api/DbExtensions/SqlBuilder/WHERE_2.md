SqlBuilder.WHERE(String) Method
===============================
Appends the WHERE clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                 | Description                                                                                                                                        |
| ---------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| [WHERE()][2]                                         | Sets WHERE as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [WHERE(SqlBuilder.ClauseStringHandler&lt;WHERE>)][4] | Appends the WHERE clause using the provided interpolated string *handler*.                                                                         |
| **WHERE(String)**                                    | Appends the WHERE clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder WHERE(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the WHERE clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: WHERE.md
[3]: _If.md
[4]: WHERE_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md