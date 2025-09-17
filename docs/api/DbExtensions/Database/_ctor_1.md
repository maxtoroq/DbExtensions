Database(String, String) Constructor
====================================
Initializes a new instance of the [Database][1] class using the provided connection string and provider's invariant name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                         | Description                                                                                                               |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| [Database(DbConnection)][3]  | Initializes a new instance of the [Database][1] class using the provided connection.                                      |
| **Database(String, String)** | Initializes a new instance of the [Database][1] class using the provided connection string and provider's invariant name. |


Syntax
------

```csharp
public Database(
	string connectionString,
	string providerInvariantName
)
```

#### Parameters

##### *connectionString*  [String][4]
The connection string.

##### *providerInvariantName*  [String][4]
The provider's invariant name.


See Also
--------

#### Reference
[Database Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: _ctor.md
[4]: https://learn.microsoft.com/dotnet/api/system.string