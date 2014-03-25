XmlNullHandling Enumeration
===========================
Specifies how to handle null fields.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public enum XmlNullHandling
```


Members
-------

Member name             | Value | Description                                             
----------------------- | ----- | ------------------------------------------------------- 
**OmitElement**         | 0     | Omits the element.                                      
**IncludeNilAttribute** | 1     | Adds an empty element with an xsi:nil="true" attribute. 


See Also
--------
[DbExtensions Namespace][1]  
[DbExtensions.XmlMappingSettings][2]  

[1]: ../README.md
[2]: ../XmlMappingSettings/README.md