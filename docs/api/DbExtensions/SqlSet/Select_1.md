SqlSet.Select(Type, String, Object[]) Method
============================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                     | Description                                       |
| ---------------- | ------------------------------------------------------------------------ | ------------------------------------------------- |
| ![Public method] | [Select(String, Object[])][2]                                            | Projects each element of the set into a new form. |
| ![Public method] | **Select(Type, String, Object[])**                                       | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Object[])][3]                                | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][4] | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	Type resultType,
	string columnList,
	params Object[] parameters
)
```

#### Parameters

##### *resultType*  [Type][5]
The type that *columnList* maps to.

##### *columnList*  [String][6]
The list of columns that maps to properties on *resultType*.

##### *parameters*  [Object][7][]
The parameters to apply to the *columnList*.

#### Return Value
[SqlSet][8]  
A new [SqlSet][8].

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select__1_1.md
[4]: Select__1.md
[5]: https://learn.microsoft.com/dotnet/api/system.type
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"