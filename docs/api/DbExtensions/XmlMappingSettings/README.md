XmlMappingSettings Class
========================
Provides settings for SQL to XML mapping.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.XmlMappingSettings**  

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public class XmlMappingSettings
```

The **XmlMappingSettings** type exposes the following members.


Constructors
------------

Name                    | Description                                                     
----------------------- | --------------------------------------------------------------- 
[XmlMappingSettings][3] | Initializes a new instance of the **XmlMappingSettings** class. 


Properties
----------

Name                | Description                                                                                                                                                                       
------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[CollectionName][4] | The qualified name of the outermost element. The default is 'table'.                                                                                                              
[ItemName][5]       | The local name of the elements that represent rows returned by the query. The elements inherit the namespace specified by the [CollectionName][4] property. The default is 'row'. 
[NullHandling][6]   | Specifies how to handle null fields. The default is [OmitElement][7].                                                                                                             
[TypeAnnotation][8] | Specifies what kind of type information to include. The default is [None][9].                                                                                                     


See Also
--------
[DbExtensions Namespace][2]  
[Extensions.MapXml(IDbCommand, XmlMappingSettings)][10]  
[Extensions.MapXml(DbConnection, SqlBuilder, XmlMappingSettings)][11]  
[SqlSet.AsXml(XmlMappingSettings)][12]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: CollectionName.md
[5]: ItemName.md
[6]: NullHandling.md
[7]: ../XmlNullHandling/README.md
[8]: TypeAnnotation.md
[9]: ../XmlTypeAnnotation/README.md
[10]: ../Extensions/MapXml_5.md
[11]: ../Extensions/MapXml_1.md
[12]: ../SqlSet/AsXml_1.md