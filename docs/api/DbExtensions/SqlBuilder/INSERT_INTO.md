SqlBuilder.INSERT_INTO Method
=============================
Appends the INSERT INTO clause using the provided *format* string and parameters.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder INSERT_INTO(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*
Type: [System.String][2]  
The format string that represents the body of the INSERT INTO clause.

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
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: README.md