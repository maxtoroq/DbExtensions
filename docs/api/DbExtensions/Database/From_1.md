Database.From(String, Type) Method
==================================
Creates and returns a new [SqlSet][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                          | Description                                                                      |
| ----------------------------- | -------------------------------------------------------------------------------- |
| [From(String)][3]             | Creates and returns a new [SqlSet][1] using the provided table name.             |
| **From(String, Type)**        | Creates and returns a new [SqlSet][1] using the provided table name.             |
| [From&lt;TResult>(String)][4] | Creates and returns a new [SqlSet&lt;TResult>][5] using the provided table name. |


Syntax
------

```csharp
public SqlSet From(
	string tableName,
	Type? resultType
)
```

#### Parameters

##### *tableName*  [String][6]
The name of the table that will be the source of data for the set.

##### *resultType*  [Type][7]
The type of objects to map the results to.

#### Return Value
[SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][8]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: From.md
[4]: From__1.md
[5]: ../SqlSet_1/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://learn.microsoft.com/dotnet/api/system.type
[8]: README.md