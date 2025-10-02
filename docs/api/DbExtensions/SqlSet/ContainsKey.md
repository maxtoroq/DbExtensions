SqlSet.ContainsKey Method
=========================
Checks the existance of an entity whose primary matches the *id* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool ContainsKey(
	Object id
)
```

#### Parameters

##### *id*  [Object][2]
The primary key value.

#### Return Value
[Boolean][3]  
`true` if the primary key value exists in the database; otherwise, `false`.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.object
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[5]: README.md