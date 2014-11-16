Extensions.Map Method (IDbCommand, TextWriter)
==============================================
Maps the results of the *command* to dynamic objects. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<Object> Map(
	this IDbCommand command,
	TextWriter logger
)
```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The query command.

#### *logger*
Type: [System.IO.TextWriter][3]  
A [TextWriter][3] used to log when the command is executed.

### Return Value
Type: [IEnumerable][4]&lt;[Object][5]>  
The results of the query as dynamic objects.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/ywxh2328
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md