SQL.INSERT_INTO(String) Method
==============================
Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *text*.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                                                     | Description                                                                                                                                 |
| -------------------------------- | ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [INSERT_INTO(SqlInterpolatedStringHandler&lt;SqlClause.INSERT_INTO>)][3] | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided string interpolated *handler*. |
| ![Public method]![Static member] | INSERT_INTO(String)                                                      | Creates and returns a new [SqlBuilder][1] initialized by appending the INSERT INTO clause using the provided *text*.                        |


Syntax
------

```csharp
public static SqlBuilder INSERT_INTO(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The body of the INSERT INTO clause.

#### Return Value
[SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [INSERT_INTO(String)][5].

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: INSERT_INTO.md
[4]: https://learn.microsoft.com/dotnet/api/system.string
[5]: ../SqlBuilder/INSERT_INTO_1.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"