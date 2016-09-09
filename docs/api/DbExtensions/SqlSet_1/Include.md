SqlSet&lt;TResult>.Include Method
=================================
Specifies the related objects to include in the query results.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlSet<TResult> Include(
	string path
)
```

#### Parameters

##### *path*
Type: [System.String][2]  
Dot-separated list of related objects to return in the query results.

#### Return Value
Type: [SqlSet][3]&lt;[TResult][3]>  
A new [SqlSet&lt;TResult>][3] with the defined query path.

Remarks
-------
 This method can only be used on mapped sets created by [Database][4]. 

See Also
--------

#### Reference
[SqlSet&lt;TResult> Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../Database/README.md