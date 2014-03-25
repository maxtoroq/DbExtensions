Extensions.MapXml Method (DbConnection, SqlBuilder, XmlMappingSettings, TextWriter)
===================================================================================
Maps the results of the *query* to XML. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static XmlReader MapXml(
	this DbConnection connection,
	SqlBuilder query,
	XmlMappingSettings settings,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query.

#### *settings*
Type: [DbExtensions.XmlMappingSettings][4]  
An [XmlMappingSettings][4] object that customizes the mapping.

#### *logger*
Type: [System.IO.TextWriter][5]  
A [TextWriter][5] used to log when the command is executed.

### Return Value
Type: [XmlReader][6]  
An [XmlReader][6] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------
[Extensions Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: ../XmlMappingSettings/README.md
[5]: http://msdn.microsoft.com/en-us/library/ywxh2328
[6]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md