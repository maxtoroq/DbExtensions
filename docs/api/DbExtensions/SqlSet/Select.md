SqlSet.Select(SqlSet.OperatorStringHandler) Method
==================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                           | Description                                       |
| ------------------------------------------------------------------------------ | ------------------------------------------------- |
| **Select(OperatorStringHandler)**                                              | Projects each element of the set into a new form. |
| [Select(String)][2]                                                            | Projects each element of the set into a new form. |
| [Select(OperatorStringHandler, Type)][3]                                       | Projects each element of the set into a new form. |
| [Select(String, Type)][4]                                                      | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler)][5]                                 | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String)][6]                                                | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][7] | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][8]                | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet Select(
	ref OperatorStringHandler columnList
)
```

#### Parameters

##### *columnList*  OperatorStringHandler
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