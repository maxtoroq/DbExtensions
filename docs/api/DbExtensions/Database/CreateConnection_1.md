Database.CreateConnection Method (String)
=========================================
Creates a connection using the provided connection string. If the connection string is a named connection string (e.g. "name=Northwind"), then the name is used to locate the connection string in the connectionStrings configuration section, else the default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName" key in the appSettings configuration section).

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static DbConnection CreateConnection(
	string connectionString
)
```

### Parameters

#### *connectionString*
Type: [System.String][2]  
The connection string.

### Return Value
Type: [DbConnection][3]  
The requested connection.

See Also
--------
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/c790zwhc
[4]: README.md