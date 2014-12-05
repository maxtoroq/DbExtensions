Extensions.EnsureOpen Method
============================
Opens the *connection* (if it's not open) and returns an [IDisposable][1] object you can use to close it (if it wasn't open).

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IDisposable EnsureOpen(
	this IDbConnection connection
)
```

### Parameters

#### *connection*
Type: [System.Data.IDbConnection][3]  
The connection.

### Return Value
Type: [IDisposable][1]  
An [IDisposable][1] object to close the connection.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbConnection][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Remarks
-------
 Use this method with the `using` statement in C# or Visual Basic to ensure that a block of code is always executed with an open connection. 

Examples
--------

```csharp
using (connection.EnsureOpen()) {
  // Execute commands.
}
```


See Also
--------

### Reference
[Extensions Class][6]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/aax125c9
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/bs16hf60
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: README.md