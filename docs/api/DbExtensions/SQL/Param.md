SQL.Param Method
================
Wraps an array parameter to be used with [SqlBuilder][1].

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static Object Param(
	Array value
)
```

### Parameters

#### *value*
Type: [System.Array][3]  
The array parameter.

### Return Value
Type: [Object][4]  
An object to use as parameter with [SqlBuilder][1].

Remarks
-------

By default, [SqlBuilder][1] treats array parameters as a list of individual parameters. For example:

```csharp
var query = new SqlBuilder("SELECT {0} IN ({1})", "a", new string[] { "a", "b", "c" });

Console.WriteLine(query.ToString());
```

The above code outputs: `SELECT {0} IN ({1}, {2}, {3})`

Use this method if you need to workaround this behavior. A common scenario is working with binary data, usually represented by [Byte][5] array parameters. For example:

```csharp
byte[] imageData = GetImageData();

var update = SQL
   .UPDATE("images")
   .SET("content = {0}", SQL.Param(imageData))
   .WHERE("id = {0}", id);
```

NOTE: Use only if you are explicitly specifying the format string, don't use with methods that do not take a format string, like [VALUES(Object[])][6]. Also, don't use if you are already including the parameter inside an array for the default list behavior.


See Also
--------
[SQL Class][7]  
[DbExtensions Namespace][2]  

[1]: ../SqlBuilder/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/czz5hkty
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: http://msdn.microsoft.com/en-us/library/yyb1w04y
[6]: ../SqlBuilder/VALUES.md
[7]: README.md