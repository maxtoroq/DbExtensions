SqlBuilder.Append Method (String, Object[])
===========================================
Appends *format* to this instance.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder Append(
	string format,
	params Object[] args
)
```

### Parameters

#### *format*
Type: [System.String][2]  
A SQL format string.

#### *args*
Type: [System.Object][3][]  
The array of parameters.

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