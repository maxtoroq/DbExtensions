DbFactory Class
===============
Provides a set of static (Shared in Visual Basic) methods for the creation and location of common ADO.NET objects.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **DbExtensions.DbFactory**  

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static class DbFactory
```

The **DbFactory** type exposes the following members.


Methods
-------

Name                          | Description                                                                                                                                                                                                                                                                                                                                                                                                                  
----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[CreateConnection()][3]       | **Obsolete.** Creates a connection using the default connection name specified by the "DbExtensions:DefaultConnectionName" key in the appSettings configuration section, which is used to locate a connection string in the connectionStrings configuration section.                                                                                                                                                         
[CreateConnection(String)][4] | **Obsolete.** Creates a connection using the provided connection string. If the connection string is a named connection string (e.g. "name=Northwind"), then the name is used to locate the connection string in the connectionStrings configuration section, else the default provider is used to create the connection (specified by the "DbExtensions:DefaultProviderName" key in the appSettings configuration section). 
[GetProviderFactory][5]       | **Obsolete.** Locates a [DbProviderFactory][6] using [GetFactory(String)][7] and caches the result.                                                                                                                                                                                                                                                                                                                          


See Also
--------
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: CreateConnection.md
[4]: CreateConnection_1.md
[5]: GetProviderFactory.md
[6]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[7]: http://msdn.microsoft.com/en-us/library/h508h681