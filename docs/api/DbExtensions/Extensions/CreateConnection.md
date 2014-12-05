Extensions.CreateConnection Method
==================================
Creates and returns a [DbConnection][1] object whose [ConnectionString][2] property is initialized with the *connectionString* parameter.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static DbConnection CreateConnection(
	this DbProviderFactory factory,
	string connectionString
)
```

#### Parameters

##### *factory*
Type: [System.Data.Common.DbProviderFactory][4]  
The provider factory used to create the connection.

##### *connectionString*
Type: [System.String][5]  
The connection string for the connection.

#### Return Value
Type: [DbConnection][1]  
 A new [DbConnection][1] object whose [ConnectionString][2] property is initialized with the *connectionString* parameter. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbProviderFactory][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][3]  
[DbProviderFactory.CreateConnection()][9]  

[1]: http://msdn.microsoft.com/en-us/library/c790zwhc
[2]: http://msdn.microsoft.com/en-us/library/f6hxc82w
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md
[9]: http://msdn.microsoft.com/en-us/library/bdab3bc9