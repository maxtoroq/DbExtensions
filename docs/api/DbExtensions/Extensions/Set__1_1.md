Extensions.Set&lt;TResult> Method (DbConnection, SqlBuilder, Func&lt;IDataRecord, TResult>)
===========================================================================================
Creates and returns a new [SqlSet&lt;TResult>][1] using the provided defining query and mapper.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Please use From<TResult>(SqlBuilder, Func<IDataRecord, TResult>) instead.")]
public static SqlSet<TResult> Set<TResult>(
	this DbConnection connection,
	SqlBuilder definingQuery,
	Func<IDataRecord, TResult> mapper
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][3]  
The connection that the set is bound to.

#### *definingQuery*
Type: [DbExtensions.SqlBuilder][4]  
The SQL query that will be the source of data for the set.

#### *mapper*
Type: [System.Func][5]&lt;[IDataRecord][6], **TResult**>  
A custom mapper function that creates TResult instances from the rows in the set.


Type Parameters
---------------

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [SqlSet][1]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][1] object.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------
[Extensions Class][9]  
[DbExtensions Namespace][2]  

[1]: ../SqlSet_1/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/c790zwhc
[4]: ../SqlBuilder/README.md
[5]: http://msdn.microsoft.com/en-us/library/bb549151
[6]: http://msdn.microsoft.com/en-us/library/93wb1heh
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md