Database.MapXml Method (SqlBuilder, XmlMappingSettings)
=======================================================
Maps the results of the *query* to XML. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public XmlReader MapXml(
	SqlBuilder query,
	XmlMappingSettings settings
)
```

### Parameters

#### *query*
Type: [DbExtensions.SqlBuilder][2]  
The query.

#### *settings*
Type: [DbExtensions.XmlMappingSettings][3]  
An [XmlMappingSettings][3] object that customizes the mapping.

### Return Value
Type: [XmlReader][4]  
An [XmlReader][4] object.

See Also
--------
[Database Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlBuilder/README.md
[3]: ../XmlMappingSettings/README.md
[4]: http://msdn.microsoft.com/en-us/library/b8a5e1s5
[5]: README.md