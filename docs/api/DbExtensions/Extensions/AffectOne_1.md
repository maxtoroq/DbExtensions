Extensions.AffectOne Method (IDbCommand, TextWriter)
====================================================
Executes the *command* in a new or existing transaction, and validates that the affected records value is equal to one before comitting.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int AffectOne(
	this IDbCommand command,
	TextWriter logger
)
```

### Parameters

#### *command*
Type: [System.Data.IDbCommand][2]  
The non-query command to execute.

#### *logger*
Type: [System.IO.TextWriter][3]  
A [TextWriter][3] for logging the whole process.

### Return Value
Type: [Int32][4]  
The number of affected records.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDbCommand][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

Exceptions
----------

Exception                   | Condition                                           
--------------------------- | --------------------------------------------------- 
[DBConcurrencyException][7] | The number of affected records is not equal to one. 


See Also
--------
[Extensions Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bt2afddc
[3]: http://msdn.microsoft.com/en-us/library/ywxh2328
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[8]: README.md