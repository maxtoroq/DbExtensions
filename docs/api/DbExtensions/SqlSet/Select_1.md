SqlSet.Select(SqlSet.OperatorStringHandler, Type) Method
========================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                           | Description                                       |
| ------------------------------------------------------------------------------ | ------------------------------------------------- |
| [Select(OperatorStringHandler)][2]                                             | Projects each element of the set into a new form. |
| [Select(String)][3]                                                            | Projects each element of the set into a new form. |
| **Select(OperatorStringHandler, Type)**                                        | Projects each element of the set into a new form. |
| [Select(String, Type)][4]                                                      | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler)][5]                                 | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String)][6]                                                | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][7] | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][8]                | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	ref OperatorStringHandler columnList,
	Type resultType
)
```

#### Parameters

##### *columnList*  OperatorStringHandler
The list of columns that maps to properties on *resultType*.

##### *resultType*  [Type][9]
The type that *columnList* maps to.

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
[3]: Select_2.md
[4]: Select_3.md
[5]: Select__1.md
[6]: Select__1_2.md
[7]: Select__1_1.md
[8]: Select__1_3.md
[9]: https://learn.microsoft.com/dotnet/api/system.type
[10]: README.md