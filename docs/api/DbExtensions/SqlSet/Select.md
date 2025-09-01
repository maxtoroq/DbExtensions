SqlSet.Select(SqlSet.SqlFragmentHandler) Method
===============================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                       | Description                                       |
| ---------------- | -------------------------------------------------------------------------- | ------------------------------------------------- |
| ![Public method] | Select(SqlFragmentHandler)                                                 | Projects each element of the set into a new form. |
| ![Public method] | [Select(String)][2]                                                        | Projects each element of the set into a new form. |
| ![Public method] | [Select(SqlFragmentHandler, Type)][3]                                      | Projects each element of the set into a new form. |
| ![Public method] | [Select(String, Type)][4]                                                  | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler)][5]                                | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String)][6]                                            | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler, Func&lt;IDataRecord, TResult>)][7] | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;IDataRecord, TResult>)][8]             | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	ref SqlFragmentHandler columnList
)
```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns to select.

#### Return Value
[SqlSet][9]  
A new [SqlSet][9].

See Also
--------

#### Reference
[SqlSet Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select_2.md
[3]: Select_1.md
[4]: Select_3.md
[5]: Select__1.md
[6]: Select__1_2.md
[7]: Select__1_1.md
[8]: Select__1_3.md
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"