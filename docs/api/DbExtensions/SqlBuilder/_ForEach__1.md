SqlBuilder._ForEach&lt;T> Method
================================
Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder _ForEach<T>(
	IEnumerable<T> items,
	string format,
	string itemFormat,
	string separator,
	Func<T, Object[]> parametersFactory
)
```

### Parameters

#### *items*
Type: [System.Collections.Generic.IEnumerable][2]&lt;**T**>  
The collection of objects that contain parameters.

#### *format*
Type: [System.String][3]  
The clause body format string, which must contain a {0} placeholder. This parameter can be null.

#### *itemFormat*
Type: [System.String][3]  
The item format.

#### *separator*
Type: [System.String][3]  
The string to use as separator between each item format.

#### *parametersFactory*
Type: [System.Func][4]&lt;**T**, [Object][5][]>  
The delegate that extract parameters for each element in *items*. This parameter can be null.


Type Parameters
---------------

#### *T*
The type of elements in *items*.

### Return Value
Type: [SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/bb549151
[5]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[6]: README.md