SqlBuilder.JoinSql Method (String, IEnumerable&lt;SqlBuilder>)
==============================================================
Concatenates the members of a constructed [IEnumerable<T>][1] collection of type [SqlBuilder][2], using the specified *separator* between each member.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlBuilder JoinSql(
	string separator,
	IEnumerable<SqlBuilder> values
)
```

### Parameters

#### *separator*
Type: [System.String][4]  
The string to use as a separator.

#### *values*
Type: [System.Collections.Generic.IEnumerable][1]&lt;[SqlBuilder][2]>  
A collection that contains the [SqlBuilder][2] objects to concatenate.

### Return Value
Type: [SqlBuilder][2]  
 A [SqlBuilder][2] that consists of the members of *values* delimited by the *separator* string. If *values* has no members, the method returns an empty [SqlBuilder][2]. 

See Also
--------
[SqlBuilder Class][2]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/9eekhta0
[2]: README.md
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf