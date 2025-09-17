SqlBuilder.JoinSql(String, IEnumerable&lt;SqlBuilder>) Method
=============================================================
Concatenates the members of a constructed [IEnumerable&lt;T>][1] collection of type [SqlBuilder][2], using the specified *separator* between each member.
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                            | Description                                                                                                                                               |
| ----------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [JoinSql(String, SqlBuilder[])][4]              | Concatenates a specified separator [String][5] between each element of a specified [SqlBuilder][2] array, yielding a single concatenated [SqlBuilder][2]. |
| **JoinSql(String, IEnumerable&lt;SqlBuilder>)** | Concatenates the members of a constructed [IEnumerable&lt;T>][1] collection of type [SqlBuilder][2], using the specified *separator* between each member. |


Syntax
------

```csharp
public static SqlBuilder JoinSql(
	string? separator,
	IEnumerable<SqlBuilder?> values
)
```

#### Parameters

##### *separator*  [String][5]
The string to use as a separator.

##### *values*  [IEnumerable][1]&lt;[SqlBuilder][2]>
A collection that contains the [SqlBuilder][2] objects to concatenate.

#### Return Value
[SqlBuilder][2]  
 A [SqlBuilder][2] that consists of the members of *values* delimited by the *separator* string. If *values* has no members, the method returns an empty [SqlBuilder][2].

See Also
--------

#### Reference
[SqlBuilder Class][2]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[2]: README.md
[3]: ../README.md
[4]: JoinSql.md
[5]: https://learn.microsoft.com/dotnet/api/system.string