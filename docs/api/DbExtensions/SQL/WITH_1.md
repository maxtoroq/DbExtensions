SQL.WITH Method (SqlSet, String)
================================
  Creates and returns a new [SqlBuilder][1] initialized by appending the WITH clause using the provided *subQuery* and *alias*.

  **Namespace:**  [DbExtensions][2]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlBuilder WITH(
	SqlSet subQuery,
	string alias
)
```

#### Parameters

##### *subQuery*
Type: [DbExtensions.SqlSet][3]  
The sub-query to use as the body of the WITH clause.

##### *alias*
Type: [System.String][4]  
The alias of the sub-query.

#### Return Value
Type: [SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [WITH(SqlSet, String)][5]. 

See Also
--------

#### Reference
[SQL Class][6]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: ../SqlSet/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../SqlBuilder/WITH_1.md
[6]: README.md