SQL.WITH(SqlSet, String) Method
===============================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                          | Description                                                                                                                   |
| -------------------------------- | ----------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [WITH(SqlBuilder, String)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*. |
| ![Public method]![Static member] | **WITH(SqlSet, String)**      | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*. |
| ![Public method]![Static member] | [WITH(String, Object[])][4]   | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.    |


Syntax
------

```csharp
public static SqlBuilder WITH(
	SqlSet subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*  [SqlSet][5]
The sub-query to use as the body of the WITH clause.

##### *alias*  [String][6]
The alias of the sub-query.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(SqlSet, String)][7].

See Also
--------

#### Reference
[SQL Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH.md
[4]: WITH_2.md
[5]: ../SqlSet/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: ../SqlBuilder/WITH_1.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"