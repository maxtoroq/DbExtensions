Database.Execute Method (SqlBuilder)
====================================
Executes the *nonQuery* command.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Execute(
	SqlBuilder nonQuery
)
```

### Parameters

#### *nonQuery*
Type: [DbExtensions.SqlBuilder][2]  
The non-query command to execute.

### Return Value
Type: [Int32][3]  
The number of affected records.

See Also
--------
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: README.md