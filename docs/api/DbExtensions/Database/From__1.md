Database.From&lt;TResult>(String) Method
========================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                  | Description                                                                                      |
| --------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------ |
| [From(String)][3]                                                     | Creates and returns a new [SqlSet][4] using the provided table name.                             |
| [From(String, Type)][5]                                               | Creates and returns a new [SqlSet][4] using the provided table name.                             |
| **From&lt;TResult>(String)**                                          | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name.                 |
| [From&lt;TResult>(String, String)][6]                                 | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name and column list. |
| [From&lt;TResult>(String, String, Func&lt;DbDataReader, TResult>)][7] | Creates and returns a new [SqlSet&lt;TResult>][1] using the provided table name and column list. |


Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	string tableName
)

```

#### Parameters

##### *tableName*  [String][8]
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
[Database Class][9]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: From.md
[4]: ../SqlSet/README.md
[5]: From_1.md
[6]: From__1_1.md
[7]: From__1_2.md
[8]: https://learn.microsoft.com/dotnet/api/system.string
[9]: README.md