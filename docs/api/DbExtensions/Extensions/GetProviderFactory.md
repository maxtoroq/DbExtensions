Extensions.GetProviderFactory Method
====================================
Gets the [DbProviderFactory][1] associated with the connection.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static DbProviderFactory GetProviderFactory(
	this DbConnection connection
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][3]  
The connection.

### Return Value
Type: [DbProviderFactory][1]  
The [DbProviderFactory][1] associated with the connection.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

See Also
--------

### Reference
[Extensions Class][6]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/c790zwhc
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: README.md