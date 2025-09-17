SqlSet.Select(String, Type) Method
==================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                           | Description                                       |
| ------------------------------------------------------------------------------ | ------------------------------------------------- |
| [Select(OperatorStringHandler)][2]                                             | Projects each element of the set into a new form. |
| [Select(String)][3]                                                            | Projects each element of the set into a new form. |
| [Select(OperatorStringHandler, Type)][4]                                       | Projects each element of the set into a new form. |
| **Select(String, Type)**                                                       | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler)][5]                                 | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String)][6]                                                | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][7] | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][8]                | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	string columnList,
	Type resultType
)
```

#### Parameters

##### *columnList*  [String][9]
The list of columns that maps to properties on *resultType*.

##### *resultType*  [Type][10]
The type that *columnList* maps to.

#### Return Value
[SqlSet][11]  
A new [SqlSet][11].

See Also
--------

#### Reference
[SqlSet Class][11]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_2.md
[4]: Select_1.md
[5]: Select__1.md
[6]: Select__1_2.md
[7]: Select__1_1.md
[8]: Select__1_3.md
[9]: https://learn.microsoft.com/dotnet/api/system.string
[10]: https://learn.microsoft.com/dotnet/api/system.type
[11]: README.md