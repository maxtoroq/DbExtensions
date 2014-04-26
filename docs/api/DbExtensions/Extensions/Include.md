Extensions.Include Method (SqlSet, String)
==========================================
Specifies the related objects to include in the query results.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlSet Include(
	this SqlSet source,
	string path
)
```

### Parameters

#### *source*
Type: [DbExtensions.SqlSet][2]  
The source set.

#### *path*
Type: [System.String][3]  
Dot-separated list of related objects to return in the query results.

### Return Value
Type: [SqlSet][2]  
A new [SqlSet][2] with the defined query path.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [SqlSet][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Remarks
-------
 This method can only be used on mapped sets created by [Database][6]. 

See Also
--------
[Extensions Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet/README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: ../Database/README.md
[7]: README.md