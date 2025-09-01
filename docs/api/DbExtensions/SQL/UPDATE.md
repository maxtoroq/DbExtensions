SQL.UPDATE Method
=================
Creates and returns a new [SqlBuilder][1] initialized by appending the UPDATE clause using the provided *format* and *args*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder UPDATE(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][3]
The body of the UPDATE clause.

##### *args*  [Object][4][]
The parameters of the clause body.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [UPDATE(String, Object[])][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: ../SqlBuilder/UPDATE.md
[6]: README.md