SQL.List(IEnumerable) Method
============================
Returns a special parameter value that is expanded into a list of comma-separated placeholder items.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                  | Description                                                                                          |
| -------------------------------- | --------------------- | ---------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | **List(IEnumerable)** | Returns a special parameter value that is expanded into a list of comma-separated placeholder items. |
| ![Public method]![Static member] | [List(Object[])][2]   | Returns a special parameter value that is expanded into a list of comma-separated placeholder items. |


Syntax
------

```csharp
public static Object List(
	IEnumerable values
)
```

#### Parameters

##### *values*  [IEnumerable][3]
The values to expand into a list.

#### Return Value
[Object][4]  
A special object to be used as parameter in [SqlBuilder][5].

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
[2]: List_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.collections.ienumerable
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: ../SqlBuilder/README.md
[6]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"