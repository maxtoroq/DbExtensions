Database Constructor (IDbConnection, MetaModel)
===============================================
Initializes a new instance of the [Database][1] class using the provided connection and meta model.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public Database(
	IDbConnection connection,
	MetaModel mapping
)
```

#### Parameters

##### *connection*
Type: [System.Data.IDbConnection][3]  
The connection.

##### *mapping*
Type: [System.Data.Linq.Mapping.MetaModel][4]  
The meta model.


See Also
--------

#### Reference
[Database Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/bs16hf60
[4]: http://msdn.microsoft.com/en-us/library/bb534568