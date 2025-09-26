Database.From&lt;TResult>(String) Method
========================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                         | Description                                                                      |
| ---------------------------- | -------------------------------------------------------------------------------- |
| [From(String)][3]            | Creates and returns a new [SqlSet][4] using the provided table name.             |
| [From(String, Type)][5]      | Creates and returns a new [SqlSet][4] using the provided table name.             |
| **From&lt;TResult>(String)** | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name. |


Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	string tableName
)

```

#### Parameters

##### *tableName*  [String][6]
The name of the table that will be the source of data for the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][7]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: From.md
[4]: ../SqlSet/README.md
[5]: From_1.md
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: README.md