AffectedRecordsPolicy Enumeration
=================================
Indicates how to validate the affected records value returned by a non-query command.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public enum AffectedRecordsPolicy
```


Members
-------

Member name            | Value | Description                                                                         
---------------------- | ----- | ----------------------------------------------------------------------------------- 
**MustMatchAffecting** | 0     | The affected records value must be equal as the affecting records value.            
**AllowLower**         | 1     | The affected records value must be equal or lower than the affecting records value. 
**AllowAny**           | 2     | The affected records value is ignored.                                              


See Also
--------

#### Reference
[DbExtensions Namespace][1]  

[1]: ../README.md