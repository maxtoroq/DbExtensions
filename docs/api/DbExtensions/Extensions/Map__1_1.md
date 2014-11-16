Extensions.Map&lt;TResult> Method (IDbCommand, Func&lt;IDataRecord, TResult>)
=============================================================================
Maps the results of the *command* to TResult objects, using the provided *mapper* delegate.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<TResult> Map<TResult>(
	this IDbCommand command,
	Func<IDataRecord, TResult> mapper
)

```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The query command.

#### *mapper*
Type: [System.Func][3]&lt;[IDataRecord][4], **TResult**>  
The delegate for creating TResult objects from an [IDataRecord][4] object.

### Type Parameters

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [IEnumerable][5]&lt;**TResult**>  
The results of the query as TResult objects.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/bb549151
[4]: http://msdn.microsoft.com/en-us/library/93wb1heh
[5]: http://msdn.microsoft.com/en-us/library/9eekhta0
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md