SqlSet.Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[]) Method
=================================================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                    | Description                                       |
| ---------------- | ----------------------------------------------------------------------- | ------------------------------------------------- |
| ![Public method] | [Select(String, Object[])][2]                                           | Projects each element of the set into a new form. |
| ![Public method] | [Select(Type, String, Object[])][3]                                     | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Object[])][4]                               | Projects each element of the set into a new form. |
| ![Public method] | **Select&lt;TResult>(Func&lt;IDataRecord, TResult>, String, Object[])** | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	Func<IDataRecord, TResult> mapper,
	string columnList,
	params Object[] parameters
)

```

#### Parameters

##### *mapper*  [Func][5]&lt;[IDataRecord][6], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

##### *columnList*  [String][7]
The list of columns that are used by *mapper*.

##### *parameters*  [Object][8][]
The parameters to apply to the *columnList*.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
[SqlSet][9]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][9].

See Also
--------

#### Reference
[SqlSet Class][10]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_1.md
[4]: Select__1_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.func-2
[6]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[7]: https://learn.microsoft.com/dotnet/api/system.string
[8]: https://learn.microsoft.com/dotnet/api/system.object
[9]: ../SqlSet_1/README.md
[10]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"