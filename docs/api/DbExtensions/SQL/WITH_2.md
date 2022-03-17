SQL.WITH Method (String, Object[])
==================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder WITH(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*
Type: [System.String][3]  
The body of the WITH clause.

##### *args*
Type: [System.Object][4][]  
The parameters of the clause body.

#### Return Value
Type: [SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String, Object[])][5]. 

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.object
[5]: ../SqlBuilder/WITH_2.md
[6]: README.md