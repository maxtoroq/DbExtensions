SqlSet.Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>) Method
========================================================================
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
| [Select(String, Type)][5]                                                      | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler)][6]                                 | Projects each element of the set into a new form. |
| [Select&lt;TResult>(String)][7]                                                | Projects each element of the set into a new form. |
| [Select&lt;TResult>(OperatorStringHandler, Func&lt;DbDataReader, TResult>)][8] | Projects each element of the set into a new form. |
| **Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)**                 | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	string columnList,
	Func<DbDataReader, TResult> mapper
)

```

#### Parameters

##### *columnList*  [String][9]
The list of columns that are used by *mapper*.

##### *mapper*  [Func][10]&lt;[DbDataReader][11], **TResult**>
A custom mapper function that creates TResult instances from the rows in the set.

#### Type Parameters

##### *TResult*
The type that *mapper* returns.

#### Return Value
[SqlSet][12]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][12].

See Also
--------

#### Reference
[SqlSet Class][13]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Select.md
[3]: Select_2.md
[4]: Select_1.md
[5]: Select_3.md
[6]: Select__1.md
[7]: Select__1_2.md
[8]: Select__1_1.md
[9]: https://learn.microsoft.com/dotnet/api/system.string
[10]: https://learn.microsoft.com/dotnet/api/system.func-2
[11]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[12]: ../SqlSet_1/README.md
[13]: README.md