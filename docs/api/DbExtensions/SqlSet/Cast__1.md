SqlSet.Cast&lt;TResult> Method
==============================
Casts the elements of the set to the specified type.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                   | Description                                          |
| ---------------- | ---------------------- | ---------------------------------------------------- |
| ![Public method] | [Cast(Type)][2]        | Casts the elements of the set to the specified type. |
| ![Public method] | **Cast&lt;TResult>()** | Casts the elements of the set to the specified type. |


Syntax
------

```csharp
public SqlSet<TResult> Cast<TResult>()

```

#### Type Parameters

##### *TResult*
The type to cast the elements of the set to.

#### Return Value
[SqlSet][3]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][3] that contains each element of the current set cast to the specified type.

See Also
--------

#### Reference
[SqlSet Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Cast.md
[3]: ../SqlSet_1/README.md
[4]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"