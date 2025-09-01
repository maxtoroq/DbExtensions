Database(IDbConnection) Constructor
===================================
Initializes a new instance of the [Database][1] class using the provided connection.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                          | Description                                                                                                               |
| ---------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [Database()][3]               | Initializes a new instance of the [Database][1] class.                                                                    |
| ![Public method] | **Database(IDbConnection)**   | Initializes a new instance of the [Database][1] class using the provided connection.                                      |
| ![Public method] | [Database(String)][4]         | Initializes a new instance of the [Database][1] class using the provided connection string.                               |
| ![Public method] | [Database(String, String)][5] | Initializes a new instance of the [Database][1] class using the provided connection string and provider's invariant name. |


Syntax
------

```csharp
public Database(
	IDbConnection connection
)
```

#### Parameters

##### *connection*  [IDbConnection][6]
The connection.


See Also
--------

#### Reference
[Database Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_2.md
[5]: _ctor_3.md
[6]: https://learn.microsoft.com/dotnet/api/system.data.idbconnection
[Public method]: ../../icons/pubmethod.svg "Public method"