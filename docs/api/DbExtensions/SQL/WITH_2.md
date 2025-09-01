SQL.WITH(String, Object[]) Method
=================================
Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                          | Description                                                                                                                   |
| -------------------------------- | ----------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [WITH(SqlBuilder, String)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*. |
| ![Public method]![Static member] | [WITH(SqlSet, String)][4]     | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*. |
| ![Public method]![Static member] | **WITH(String, Object[])**    | Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *format* and *args*.    |


Syntax
------

```csharp
public static SqlBuilder WITH(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][5]
The body of the WITH clause.

##### *args*  [Object][6][]
The parameters of the clause body.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(String, Object[])][7].

See Also
--------

#### Reference
[SQL Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: WITH.md
[4]: WITH_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: https://learn.microsoft.com/dotnet/api/system.object
[7]: ../SqlBuilder/WITH_2.md
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"