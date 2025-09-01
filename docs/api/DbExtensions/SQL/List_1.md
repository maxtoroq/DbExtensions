SQL.List(Object[]) Method
=========================
Returns a special parameter value that is expanded into a list of comma-separated placeholder items.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                   | Description                                                                                          |
| -------------------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | [List(IEnumerable)][2] | Returns a special parameter value that is expanded into a list of comma-separated placeholder items. |
| ![Public method]![Static member] | **List(Object[])**     | Returns a special parameter value that is expanded into a list of comma-separated placeholder items. |


Syntax
------

```csharp
public static Object List(
	params Object[] values
)
```

#### Parameters

##### *values*  [Object][3][]
The values to expand into a list.

#### Return Value
[Object][3]  
A special object to be used as parameter in [SqlBuilder][4].

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
[SQL Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: List.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../SqlBuilder/README.md
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"