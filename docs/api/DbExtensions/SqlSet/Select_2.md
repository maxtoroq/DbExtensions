SqlSet.Select(String) Method
============================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                        | Description                                       |
| ---------------- | --------------------------------------------------------------------------- | ------------------------------------------------- |
| ![Public method] | [Select(SqlFragmentHandler)][2]                                             | Projects each element of the set into a new form. |
| ![Public method] | **Select(String)**                                                          | Projects each element of the set into a new form. |
| ![Public method] | [Select(SqlFragmentHandler, Type)][3]                                       | Projects each element of the set into a new form. |
| ![Public method] | [Select(String, Type)][4]                                                   | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler)][5]                                 | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String)][6]                                             | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler, Func&lt;DbDataReader, TResult>)][7] | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][8]             | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	string columnList
)
```

#### Parameters

##### *columnList*  [String][9]
The list of columns to select.

#### Return Value
[SqlSet][10]  
A new [SqlSet][10].

See Also
--------

#### Reference
[SqlSet Class][10]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_1.md
[4]: Select_3.md
[5]: Select__1.md
[6]: Select__1_2.md
[7]: Select__1_1.md
[8]: Select__1_3.md
[9]: https://learn.microsoft.com/dotnet/api/system.string
[10]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"