SqlSet&lt;TResult>.Cast(Type) Method
====================================
Casts the elements of the set to the specified type.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name              | Description                                          |
| ---------------- | ----------------- | ---------------------------------------------------- |
| ![Public method] | **Cast(Type)**    | Casts the elements of the set to the specified type. |
| ![Public method] | [Cast&lt;T>()][2] | Casts the elements of the set to the specified type. |


Syntax
------

```csharp
public SqlSet Cast(
	Type resultType
)
```

#### Parameters

##### *resultType*  [Type][3]
The type to cast the elements of the set to.

#### Return Value
[SqlSet][4]  
A new [SqlSet][4] that contains each element of the current set cast to the specified type.

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Cast__1.md
[3]: https://learn.microsoft.com/dotnet/api/system.type
[4]: ../SqlSet/README.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"