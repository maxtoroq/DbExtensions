Database.From&lt;TResult>(SqlBuilder) Method
============================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlSet<TResult> From<TResult>(
	SqlBuilder definingQuery
)

```

#### Parameters

##### *definingQuery*  [SqlBuilder][3]
The SQL query that will be the source of data for the set.

#### Type Parameters

##### *TResult*
The type of objects to map the results to.

#### Return Value
[SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.

See Also
--------

#### Reference
[Database Class][4]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: README.md