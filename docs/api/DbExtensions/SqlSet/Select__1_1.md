SqlSet.Select&lt;TResult>(SqlSet.SqlFragmentHandler, Func&lt;IDataRecord, TResult>) Method
==========================================================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                  | Description                                       |
| ---------------- | --------------------------------------------------------------------- | ------------------------------------------------- |
| ![Public method] | [Select(SqlFragmentHandler)][2]                                       | Projects each element of the set into a new form. |
| ![Public method] | [Select(String)][3]                                                   | Projects each element of the set into a new form. |
| ![Public method] | [Select(SqlFragmentHandler, Type)][4]                                 | Projects each element of the set into a new form. |
| ![Public method] | [Select(String, Type)][5]                                             | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler)][6]                           | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String)][7]                                       | Projects each element of the set into a new form. |
| ![Public method] | Select&lt;TResult>(SqlFragmentHandler, Func&lt;IDataRecord, TResult>) | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;IDataRecord, TResult>)][8]        | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	ref SqlFragmentHandler columnList,
	Func<IDataRecord, TResult> mapper
)

```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns that are used by *mapper*.

##### *mapper*  [Func][9]&lt;[IDataRecord][10], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
[SqlSet][11]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][11].

See Also
--------

#### Reference
[SqlSet Class][12]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_2.md
[4]: Select_1.md
[5]: Select_3.md
[6]: Select__1.md
[7]: Select__1_2.md
[8]: Select__1_3.md
[9]: https://learn.microsoft.com/dotnet/api/system.func-2
[10]: https://learn.microsoft.com/dotnet/api/system.data.idatarecord
[11]: ../SqlSet_1/README.md
[12]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"