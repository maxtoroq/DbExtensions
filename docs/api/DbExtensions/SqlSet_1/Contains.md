SqlSet&lt;TResult>.Contains(TResult) Method
===========================================
Checks the existance of the *entity*, using the primary key value.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                  | Description                                                        |
| --------------------- | ------------------------------------------------------------------ |
| [Contains(Object)][2] | Checks the existance of the *entity*, using the primary key value. |
| **Contains(TResult)** | Checks the existance of the *entity*, using the primary key value. |


Syntax
------

```csharp
public bool Contains(
	TResult entity
)
```

#### Parameters

##### *entity*  [TResult][3]
The entity whose existance is to be checked.

#### Return Value
[Boolean][4]  
`true` if the primary key value exists in the database; otherwise, `false`.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][5] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet/Contains.md
[3]: README.md
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception