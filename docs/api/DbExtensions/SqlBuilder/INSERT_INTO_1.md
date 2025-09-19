SqlBuilder.INSERT_INTO(String) Method
=====================================
Appends the INSERT INTO clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                      |
| ---------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| [INSERT_INTO(SqlBuilder.ClauseStringHandler&lt;INSERT_INTO>)][2] | Appends the INSERT INTO clause using the provided interpolated string *handler*. |
| **INSERT_INTO(String)**                                          | Appends the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public SqlBuilder INSERT_INTO(
	string? text
)
```

#### Parameters

##### *text*  [String][3]
The text that represents the body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: INSERT_INTO.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: README.md