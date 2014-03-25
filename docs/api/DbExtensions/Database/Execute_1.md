Database.Execute Method (String)
================================
Creates and executes a [DbCommand][1] whose [CommandText][2] property is initialized with the *commandText* parameter.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public int Execute(
	string commandText
)
```

### Parameters

#### *commandText*
Type: [System.String][4]  
The command text.

### Return Value
Type: [Int32][5]  
The number of affected records.

See Also
--------
[Database Class][6]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/td2s409d
[6]: README.md