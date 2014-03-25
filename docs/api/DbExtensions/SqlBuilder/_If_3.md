SqlBuilder._If Method (Boolean, String, Object[])
=================================================
Appends *format* to the current clause if *condition* is true.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder _If(
	bool condition,
	string format,
	params Object[] args
)
```

### Parameters

#### *condition*
Type: [System.Boolean][2]  
true to append *format* to the current clause; otherwise, false.

#### *format*
Type: [System.String][3]  
The format string that represents the body of the current clause.

#### *args*
Type: [System.Object][4][]  
The parameters of the clause body.

### Return Value
Type: [SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: README.md