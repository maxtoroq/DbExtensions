SqlBuilder.ORDER_BY(String) Method
==================================
Appends the ORDER BY clause using the provided *text*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                 | Description                                                                                                                                           |
| -------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| [ORDER_BY()][2]                                                      | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [ORDER_BY(SqlBuilder.ClauseStringHandler&lt;SqlClause.ORDER_BY>)][4] | Appends the ORDER BY clause using the provided interpolated string *handler*.                                                                         |
| **ORDER_BY(String)**                                                 | Appends the ORDER BY clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder ORDER_BY(
	string? text
)
```

#### Parameters

##### *text*  [String][5]
The text that represents the body of the ORDER BY clause.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ORDER_BY.md
[3]: _If.md
[4]: ORDER_BY_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: README.md