SqlSet&lt;TResult>.Contains(TResult) Method
===========================================
Checks the existance of the *entity*, using the primary key value.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public bool Contains(
	TResult entity
)
```

#### Parameters

##### *entity*  [TResult][2]
The entity whose existance is to be checked.

#### Return Value
[Boolean][3]  
true if the primary key value exists in the database; otherwise false.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][4] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][2]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: README.md
[3]: https://learn.microsoft.com/dotnet/api/system.boolean
[4]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception