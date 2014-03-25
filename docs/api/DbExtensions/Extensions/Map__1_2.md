Extensions.Map&lt;TResult> Method (DbConnection, SqlBuilder, Func&lt;IDataRecord, TResult>, TextWriter)
=======================================================================================================
Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<TResult> Map<TResult>(
	this DbConnection connection,
	SqlBuilder query,
	Func<IDataRecord, TResult> mapper,
	TextWriter logger
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][2]  
The connection.

#### *query*
Type: [DbExtensions.SqlBuilder][3]  
The query.

#### *mapper*
Type: [System.Func][4]&lt;[IDataRecord][5], **TResult**>  
The delegate for creating TResult objects from an [IDataRecord][5] object.

#### *logger*
Type: [System.IO.TextWriter][6]  
A [TextWriter][6] used to log when the command is executed.


Type Parameters
---------------

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [IEnumerable][7]&lt;**TResult**>  
The results of the query as TResult objects.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][8] or [Extension Methods (C# Programming Guide)][9].

See Also
--------
[Extensions Class][10]  
[DbExtensions Namespace][1]  
[Extensions.Map&lt;TResult>(IDbCommand, Func&lt;IDataRecord, TResult>, TextWriter)][11]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/c790zwhc
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/bb549151
[5]: http://msdn.microsoft.com/en-us/library/93wb1heh
[6]: http://msdn.microsoft.com/en-us/library/ywxh2328
[7]: http://msdn.microsoft.com/en-us/library/9eekhta0
[8]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[9]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[10]: README.md
[11]: Map__1_6.md