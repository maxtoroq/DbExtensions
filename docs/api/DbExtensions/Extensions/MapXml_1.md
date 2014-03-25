Extensions.MapXml Method (DbConnection, SqlBuilder, XmlMappingSettings)
=======================================================================
Maps the results of the *query* to XML. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static XmlReader MapXml(
	this DbConnection connection,
	SqlBuilder query,
	XmlMappingSettings settings
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

### Return Value
Type: [XmlReader][5]  
An [XmlReader][5] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: ../XmlMappingSettings/README.md
[5]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md