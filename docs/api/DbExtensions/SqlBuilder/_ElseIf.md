SqlBuilder._ElseIf Method
=========================
Appends *format* to the current clause if *condition* is true and an antecedent call to [_If(Boolean, String, Object[])][1] or **_ElseIf(Boolean, String, Object[])** used a false condition.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _ElseIf(
	bool condition,
	string format,
	params Object[] args
)
```

#### Parameters

##### *condition*
Type: [System.Boolean][3]  
true to append *format* to the current clause; otherwise, false.

##### *format*
Type: [System.String][4]  
The format string that represents the body of the current clause.

##### *args*
Type: [System.Object][5][]  
The parameters of the clause body.

#### Return Value
Type: [SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][2]  

[1]: _If.md
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.boolean
[4]: https://docs.microsoft.com/dotnet/api/system.string
[5]: https://docs.microsoft.com/dotnet/api/system.object
[6]: README.md