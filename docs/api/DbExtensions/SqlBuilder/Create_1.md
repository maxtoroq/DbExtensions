SqlBuilder.Create(String) Method
================================
Initializes a new instance of the [SqlBuilder][1] class using the provided text.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                             | Description                                                                                     |
| -------------------------------- | ----------------------------------------------------------------------------------------------- |
| [Create(AppendStringHandler)][3] | Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string. |
| **Create(String)**               | Initializes a new instance of the [SqlBuilder][1] class using the provided text.                |


Syntax
------

```csharp
public static SqlBuilder Create(
	string? text
)
```

#### Parameters

##### *text*  [String][4]
The SQL string.

#### Return Value
[SqlBuilder][1]  
A new instance of [SqlBuilder][1] initialized with *text*.

See Also
--------

#### Reference
[SqlBuilder Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: Create.md
[4]: https://learn.microsoft.com/dotnet/api/system.string