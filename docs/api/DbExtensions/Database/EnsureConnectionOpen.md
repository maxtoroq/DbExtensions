Database.EnsureConnectionOpen Method
====================================
  Opens [Connection][1] (if it's not open) and returns an [IDisposable][2] object you can use to close it (if it wasn't open).

  **Namespace:**  [DbExtensions][3]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public IDisposable EnsureConnectionOpen()
```

#### Return Value
Type: [IDisposable][2]  
An [IDisposable][2] object to close the connection.

Remarks
-------
 Use this method with the `using` statement in C# or Visual Basic to ensure that a block of code is always executed with an open connection. 

Examples
--------

```csharp
using (db.EnsureConnectionOpen()) {
  // Execute commands.
}
```


See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][3]  

[1]: Connection.md
[2]: http://msdn.microsoft.com/en-us/library/aax125c9
[3]: ../README.md
[4]: README.md