SQL.WITH Method (String)
========================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *body*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlBuilder WITH(
	string body
)
```

### Parameters

#### *body*
Type: [System.String][3]  
The body of the WITH clause.

### Return Value
Type: [SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String)][4]. 

See Also
--------
[SQL Class][5]  
[DbExtensions Namespace][2]  
[SqlBuilder.WITH(String)][4]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../SqlBuilder/WITH_1.md
[5]: README.md