SqlSet&lt;TResult>.Contains(Object) Method
==========================================
Checks the existance of the *entity*, using the primary key value.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                   | Description                                                        |
| ---------------- | ---------------------- | ------------------------------------------------------------------ |
| ![Public method] | **Contains(Object)**   | Checks the existance of the *entity*, using the primary key value. |
| ![Public method] | [Contains(TResult)][2] | Checks the existance of the *entity*, using the primary key value. |


Syntax
------

```csharp
public bool Contains(
	Object entity
)
```

#### Parameters

##### *entity*  [Object][3]
The entity whose existance is to be checked.

#### Return Value
[Boolean][4]  
true if the primary key value exists in the database; otherwise false.

Exceptions
----------

| Exception                      | Condition                                                                         |
| ------------------------------ | --------------------------------------------------------------------------------- |
| [InvalidOperationException][5] | This method can only be used on sets where the result type is an annotated class. |


See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Contains_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: https://learn.microsoft.com/dotnet/api/system.boolean
[5]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"