SQL.ctor Method (String, Object[])
==================================
Creates and returns a new [SqlBuilder][1] initialized with *format* and *args*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Use SqlBuilder constructor instead.")]
public static SqlBuilder ctor(
	string format,
	params Object[] args
)
```

### Parameters

#### *format*
Type: [System.String][3]  
The SQL format string.

#### *args*
Type: [System.Object][4][]  
The array of parameters.

### Return Value
Type: [SqlBuilder][1]  
 A new [SqlBuilder][1] initialized with *format* and *args*. 

See Also
--------
[SQL Class][5]  
[DbExtensions Namespace][2]  
[SqlBuilder.SqlBuilder(String, Object[])][6]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: README.md
[6]: ../SqlBuilder/_ctor_2.md