SQL.List Method (Object[])
==========================
Returns a special parameter value that is expanded into a list of comma-separated placeholder items.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static Object List(
	params Object[] values
)
```

#### Parameters

##### *values*
Type: [System.Object][2][]  
The values to expand into a list.

#### Return Value
Type: [Object][2]  
A special object to be used as parameter in [SqlBuilder][3].

Exceptions
----------

Exception                  | Condition                 
-------------------------- | ------------------------- 
[ArgumentNullException][4] | *values* cannot be null.  
[ArgumentException][5]     | *values* cannot be empty. 


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
[SQL Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/27426hcy
[5]: http://msdn.microsoft.com/en-us/library/3w1b3114
[6]: README.md