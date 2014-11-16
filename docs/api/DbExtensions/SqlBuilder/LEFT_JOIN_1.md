SqlBuilder.LEFT_JOIN Method (String, Object[])
==============================================
Appends the LEFT JOIN clause using the provided *format* string and parameters.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder LEFT_JOIN(
	string format,
	params Object[] args
)
```

### Parameters

#### *format*
Type: [System.String][2]  
The format string that represents the body of the LEFT JOIN clause.

#### *args*
Type: [System.Object][3][]  
The parameters of the clause body.

### Return Value
Type: [SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md