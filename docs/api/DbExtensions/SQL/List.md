SQL.List Method (IEnumerable)
=============================
Returns a special parameter value that is expanded into a list of comma-separated placeholder items.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static Object List(
	IEnumerable values
)
```

#### Parameters

##### *values*
Type: [System.Collections.IEnumerable][2]  
The values to expand into a list.

#### Return Value
Type: [Object][3]  
A special object to be used as parameter in [SqlBuilder][4].

Exceptions
----------

Exception                  | Condition                 
-------------------------- | ------------------------- 
[ArgumentNullException][5] | *values* cannot be null.  
[ArgumentException][6]     | *values* cannot be empty. 


Remarks
-------

For example:

```csharp
var query = SQL
   .SELECT("{0} IN ({1})", "a", SQL.List("a", "b", "c"));

Console.WriteLine(query.ToString());
```

The above code outputs: `SELECT {0} IN ({1}, {2}, {3})`


See Also
--------

#### Reference
[SQL Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/h1x9x1b1
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../SqlBuilder/README.md
[5]: http://msdn.microsoft.com/en-us/library/27426hcy
[6]: http://msdn.microsoft.com/en-us/library/3w1b3114
[7]: README.md