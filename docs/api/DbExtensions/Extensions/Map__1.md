Extensions.Map&lt;TResult> Method (IDbCommand)
==============================================
Maps the results of the *command* to TResult objects. The query is deferred-executed.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static IEnumerable<TResult> Map<TResult>(
	this IDbCommand command
)

```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The query command.

### Type Parameters

#### *TResult*
The type of objects to map the results to.

### Return Value
Type: [IEnumerable][3]&lt;**TResult**>  
The results of the query as TResult objects.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

See Also
--------
[Extensions Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: README.md