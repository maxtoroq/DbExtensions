SqlBuilder.ORDER_BY Method (String, Object[])
=============================================
Appends the ORDER BY clause using the provided *format* string and parameters.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder ORDER_BY(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*
Type: [System.String][2]  
The format string that represents the body of the ORDER BY clause.

##### *args*
Type: [System.Object][3][]  
The parameters of the clause body.

#### Return Value
Type: [SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.string
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: README.md