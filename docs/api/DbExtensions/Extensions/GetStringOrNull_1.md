Extensions.GetStringOrNull Method (IDataRecord, String)
=======================================================
Gets the value of the specified column as a [String][1], or null (Nothing in Visual Basic).

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static string GetStringOrNull(
	this IDataRecord record,
	string name
)
```

### Parameters

#### *record*
Type: [System.Data.IDataRecord][3]  
The data record.

#### *name*
Type: [System.String][1]  
The name of the column to find.

### Return Value
Type: [String][1]  
The value of the column.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

See Also
--------
[Extensions Class][6]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/93wb1heh
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: README.md