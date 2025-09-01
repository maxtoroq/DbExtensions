SqlBuilder._ForEach&lt;T> Method
================================
Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with *separator*.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _ForEach<T>(
	IEnumerable<T> items,
	string format,
	string itemFormat,
	string separator,
	Func<T, Object[]> parametersFactory
)

```

#### Parameters

##### *items*  [IEnumerable][2]&lt;**T**>
The collection of objects that contain parameters.

##### *format*  [String][3]
The clause body format string, which must contain a {0} placeholder. This parameter can be null.

##### *itemFormat*  [String][3]
The item format.

##### *separator*  [String][3]
The string to use as separator between each item format.

##### *parametersFactory*  [Func][4]&lt;**T**, [Object][5][]>
The delegate that extract parameters for each element in *items*. This parameter can be null.

#### Type Parameters

##### *T*
The type of elements in *items*.

#### Return Value
[SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.func-2
[5]: https://learn.microsoft.com/dotnet/api/system.object
[6]: README.md