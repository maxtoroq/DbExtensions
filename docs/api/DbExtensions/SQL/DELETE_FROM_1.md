SQL.DELETE_FROM Method (String, Object[])
=========================================
Creates and returns a new [SqlBuilder][1] initialized by appending the DELETE FROM clause using the provided *format* and *args*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static SqlBuilder DELETE_FROM(
	string format,
	params Object[] args
)
```

### Parameters

#### *format*
Type: [System.String][3]  
The body of the DELETE FROM clause.

#### *args*
Type: [System.Object][4][]  
The parameters of the clause body.

### Return Value
Type: [SqlBuilder][1]  
 A new [SqlBuilder][1] after calling [DELETE_FROM(String, Object[])][5]. 

See Also
--------
[SQL Class][6]  
[DbExtensions Namespace][2]  
[SqlBuilder.DELETE_FROM(String, Object[])][5]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: ../SqlBuilder/DELETE_FROM_1.md
[6]: README.md