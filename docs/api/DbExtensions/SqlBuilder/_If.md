SqlBuilder._If Method
=====================
Appends *format* to the current clause if *condition* is true.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _If(
	bool condition,
	string format,
	params Object[] args
)
```

#### Parameters

##### *condition*
Type: [System.Boolean][2]  
true to append *format* to the current clause; otherwise, false.

##### *format*
Type: [System.String][3]  
The format string that represents the body of the current clause.

##### *args*
Type: [System.Object][4][]  
The parameters of the clause body.

#### Return Value
Type: [SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.boolean
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: README.md