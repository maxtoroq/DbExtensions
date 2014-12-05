SqlBuilder._If Method (Boolean, String)
=======================================
Appends *body* to the current clause if *condition* is true.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder _If(
	bool condition,
	string body
)
```

### Parameters

#### *condition*
Type: [System.Boolean][2]  
true to append *body* to the current clause; otherwise, false.

#### *body*
Type: [System.String][3]  
The body of the current clause.

### Return Value
Type: [SqlBuilder][4]  
A reference to this instance after the append operation has completed.

See Also
--------

### Reference
[SqlBuilder Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: README.md