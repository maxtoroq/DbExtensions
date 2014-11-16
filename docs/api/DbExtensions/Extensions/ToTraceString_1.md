Extensions.ToTraceString Method (IDbCommand, Int32)
===================================================
Creates a string representation of *command* for logging and debugging purposes.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static string ToTraceString(
	this IDbCommand command,
	int affectedRecords
)
```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The command.

#### *affectedRecords*
Type: [System.Int32][3]  
The number of affected records that the command returned.

### Return Value
Type: [String][4]  
The string representation of *command*.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------
[Extensions Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: README.md