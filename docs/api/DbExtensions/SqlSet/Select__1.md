SqlSet.Select&lt;TResult>(SqlSet.SqlFragmentHandler) Method
===========================================================
Projects each element of the set into a new form.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                                        | Description                                       |
| ---------------- | --------------------------------------------------------------------------- | ------------------------------------------------- |
| ![Public method] | [Select(SqlFragmentHandler)][2]                                             | Projects each element of the set into a new form. |
| ![Public method] | [Select(String)][3]                                                         | Projects each element of the set into a new form. |
| ![Public method] | [Select(SqlFragmentHandler, Type)][4]                                       | Projects each element of the set into a new form. |
| ![Public method] | [Select(String, Type)][5]                                                   | Projects each element of the set into a new form. |
| ![Public method] | **Select&lt;TResult>(SqlFragmentHandler)**                                  | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String)][6]                                             | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(SqlFragmentHandler, Func&lt;DbDataReader, TResult>)][7] | Projects each element of the set into a new form. |
| ![Public method] | [Select&lt;TResult>(String, Func&lt;DbDataReader, TResult>)][8]             | Projects each element of the set into a new form. |


Syntax
------

```csharp
public SqlSet<TResult> Select<TResult>(
	ref SqlFragmentHandler columnList
)

```

#### Parameters

##### *columnList*  SqlFragmentHandler
The list of columns that maps to properties on TResult.

#### Type Parameters

##### *TResult*
The type that *columnList* maps to.

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
[3]: Select_2.md
[4]: Select_1.md
[5]: Select_3.md
[6]: Select__1_2.md
[7]: Select__1_1.md
[8]: Select__1_3.md
[9]: ../SqlSet_1/README.md
[10]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"