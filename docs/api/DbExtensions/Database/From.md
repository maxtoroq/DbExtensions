Database.From(String) Method
============================
Creates and returns a new [SqlSet][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                          | Description                                                                      |
| ----------------------------- | -------------------------------------------------------------------------------- |
| **From(String)**              | Creates and returns a new [SqlSet][1] using the provided table name.             |
| [From(String, Type)][3]       | Creates and returns a new [SqlSet][1] using the provided table name.             |
| [From&lt;TResult>(String)][4] | Creates and returns a new [SqlSet&lt;TResult>][5] using the provided table name. |


Syntax
------

```csharp
public SqlSet From(
	string tableName
)
```

#### Parameters

##### *tableName*  [String][6]
The name of the table that will be the source of data for the set.

#### Return Value
[SqlSet][1]  
A new [SqlSet][1] object.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet/README.md
[2]: ../README.md
[3]: From_1.md
[4]: From__1.md
[5]: ../SqlSet_1/README.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: README.md