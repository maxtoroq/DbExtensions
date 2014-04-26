Extensions.Include&lt;TResult> Method (SqlSet&lt;TResult>, String)
==================================================================
Specifies the related objects to include in the query results.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlSet<TResult> Include<TResult>(
	this SqlSet<TResult> source,
	string path
)
```

### Parameters

#### *source*
Type: [DbExtensions.SqlSet][2]&lt;**TResult**>  
The source set.

#### *path*
Type: [System.String][3]  
Dot-separated list of related objects to return in the query results.


Type Parameters
---------------

#### *TResult*
The type of the elements in the *source* set.

### Return Value
Type: [SqlSet][2]&lt;**TResult**>  
A new [SqlSet&lt;TResult>][2] with the defined query path.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [SqlSet][2]&lt;**TResult**>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Remarks
-------
 This method can only be used on mapped sets created by [Database][6]. 

See Also
--------
[Extensions Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet_1/README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: ../Database/README.md
[7]: README.md