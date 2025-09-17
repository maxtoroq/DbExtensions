SqlBuilder.LIMIT(Int32) Method
==============================
Appends the LIMIT clause using the provided *maxRecords* parameter.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                           | Description                                                                                                                                        |
| -------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| [LIMIT()][2]                                                   | Sets LIMIT as the next clause, to be used by subsequent calls to clause continuation methods, such as [_If(Boolean, ConditionalStringHandler)][3]. |
| [LIMIT(SqlBuilder.ClauseStringHandler&lt;SqlClause.LIMIT>)][4] | Appends the LIMIT clause using the provided interpolated string *handler*.                                                                         |
| **LIMIT(Int32)**                                               | Appends the LIMIT clause using the provided *maxRecords* parameter.                                                                                |
| [LIMIT(String)][5]                                             | Appends the LIMIT clause using the provided *text*.                                                                                                |


Syntax
------

```csharp
public SqlBuilder LIMIT(
	int maxRecords
)
```

#### Parameters

##### *maxRecords*  [Int32][6]
The value to use as parameter.

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: LIMIT.md
[3]: _If.md
[4]: LIMIT_1.md
[5]: LIMIT_3.md
[6]: https://learn.microsoft.com/dotnet/api/system.int32
[7]: README.md