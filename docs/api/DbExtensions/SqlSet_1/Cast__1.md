SqlSet&lt;TResult>.Cast&lt;T> Method
====================================
Casts the elements of the set to the specified type.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name             | Description                                          |
| ---------------- | ---------------- | ---------------------------------------------------- |
| ![Public method] | [Cast(Type)][2]  | Casts the elements of the set to the specified type. |
| ![Public method] | **Cast&lt;T>()** | Casts the elements of the set to the specified type. |


Syntax
------

```csharp
public SqlSet<T> Cast<T>()

```

#### Type Parameters

##### *T*
The type to cast the elements of the set to.

#### Return Value
[SqlSet][3]&lt;**T**>  
A new [SqlSet&lt;TResult>][3] that contains each element of the current set cast to the specified type.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Cast.md
[3]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"