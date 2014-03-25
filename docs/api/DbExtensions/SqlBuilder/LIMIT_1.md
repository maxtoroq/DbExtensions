SqlBuilder.LIMIT Method (Int32)
===============================
Appends the LIMIT clause using the string representation of *maxRecords* as body.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder LIMIT(
	int maxRecords
)
```

### Parameters

#### *maxRecords*
Type: [System.Int32][2]  
The value to use as the body of the LIMIT clause.

### Return Value
Type: [SqlBuilder][3]  
A reference to this instance after the append operation has completed.

See Also
--------
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/td2s409d
[3]: README.md