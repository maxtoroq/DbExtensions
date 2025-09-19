SqlBuilder.UPDATE(String) Method
================================
Appends the UPDATE clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                   | Description                                                                 |
| ------------------------------------------------------ | --------------------------------------------------------------------------- |
| [UPDATE(SqlBuilder.ClauseStringHandler&lt;UPDATE>)][2] | Appends the UPDATE clause using the provided interpolated string *handler*. |
| **UPDATE(String)**                                     | Appends the UPDATE clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder UPDATE(
	string? text
)
```

#### Parameters

##### *text*  [String][3]
The text that represents the body of the UPDATE clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: UPDATE.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md