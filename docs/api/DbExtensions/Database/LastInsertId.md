Database.LastInsertId Method
============================
Gets the identity value of the last inserted record.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public virtual Object LastInsertId()
```

#### Return Value
Type: [Object][2]  
The identity value of the last inserted record.

Remarks
-------
 It is very important to keep the connection open between the last command and this one, or else you might get the wrong value. 

See Also
--------

#### Reference
[Database Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.object
[3]: README.md