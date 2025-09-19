SqlBuilder.DELETE_FROM(String) Method
=====================================
Appends the DELETE FROM clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                      |
| ---------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| [DELETE_FROM(SqlBuilder.ClauseStringHandler&lt;DELETE_FROM>)][2] | Appends the DELETE FROM clause using the provided interpolated string *handler*. |
| **DELETE_FROM(String)**                                          | Appends the DELETE FROM clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder DELETE_FROM(
	string? text
)
```

#### Parameters

##### *text*  [String][3]
The text that represents the body of the DELETE FROM clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: DELETE_FROM.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md