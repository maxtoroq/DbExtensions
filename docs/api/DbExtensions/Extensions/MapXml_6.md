Extensions.MapXml Method (IDbCommand, XmlMappingSettings, TextWriter)
=====================================================================
Maps the results of the *command* to XML. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static XmlReader MapXml(
	this IDbCommand command,
	XmlMappingSettings settings,
	TextWriter logger
)
```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The query command.

#### *settings*
Type: [DbExtensions.XmlMappingSettings][3]  
An [XmlMappingSettings][3] object that customizes the mapping.

#### *logger*
Type: [System.IO.TextWriter][4]  
A [TextWriter][4] used to log when the command is executed.

### Return Value
Type: [XmlReader][5]  
An [XmlReader][5] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: ../XmlMappingSettings/README.md
[4]: http://msdn.microsoft.com/en-us/library/ywxh2328
[5]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md