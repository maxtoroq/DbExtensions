SqlSet.Select&lt;TResult>(String, Object[]) Method
==================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                     | Description                                       |
| ---------------- | ------------------------------------------------------------------------ | ------------------------------------------------- |
| ![Public method] | [Select(String, Object[])][2]                                            | Projects each element of the set into a new form. |
| ![Public method] | [Select(Type, String, Object[])][3]                                      | Projects each element of the set into a new form. |
| ![Public method] | **Select&lt;TResult>(String, Object[])**                                 | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])][4] | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList,
	params Object[] parameters
)

```

#### Parameters

##### *columnList*  [String][5]
The list of columns that maps to properties on TResult.

##### *parameters*  [Object][6][]
The parameters to apply to the *columnList*.

#### Type Parameters

##### *TResult*
The type that *columnList* maps to.

#### Return Value
[SqlSet][7]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][7].

See Also
--------

#### Reference
[SqlSet Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_1.md
[4]: Select__1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: https://learn.microsoft.com/dotnet/api/system.object
[7]: ../SqlSet_1/README.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"