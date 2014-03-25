Extensions.MapXml Method (IDbCommand, TextWriter)
=================================================
Maps the results of the *command* to XML. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static XmlReader MapXml(
	this IDbCommand command,
	TextWriter logger
)
```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The query command.

#### *logger*
Type: [System.IO.TextWriter][3]  
A [TextWriter][3] used to log when the command is executed.

### Return Value
Type: [XmlReader][4]  
An [XmlReader][4] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------
[Extensions Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/ywxh2328
[4]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: README.md