SqlBuilder._OR&lt;T> Method
===========================
Appends to the current clause the string made by concatenating an *itemFormat* for each element in *items*, interspersed with the OR operator.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public SqlBuilder _OR<T>(
	IEnumerable<T> items,
	string itemFormat,
	Func<T, Object[]> parametersFactory
)

```

#### Parameters

##### *items*
Type: [System.Collections.Generic.IEnumerable][2]&lt;**T**>  
The collection of objects that contain parameters.

##### *itemFormat*
Type: [System.String][3]  
The format string.

##### *parametersFactory*
Type: [System.Func][4]&lt;**T**, [Object][5][]>  
The delegate that extract parameters for each element in *items*.

#### Type Parameters

##### *T*
The type of elements in *items*.

#### Return Value
Type: [SqlBuilder][6]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[3]: https://docs.microsoft.com/dotnet/api/system.string
[4]: https://docs.microsoft.com/dotnet/api/system.func-2
[5]: https://docs.microsoft.com/dotnet/api/system.object
[6]: README.md