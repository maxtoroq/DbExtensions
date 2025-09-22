SqlBuilder.CreateStatic(String) Method
======================================
Initializes a new instance of the [SqlBuilder][1] class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][2] instead.
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                          | Description                                                                                                                                                                                                                  |
| ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [CreateStatic(SqlBuilder)][4] | Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][5] instead. |
| **CreateStatic(String)**      | Initializes a new instance of the [SqlBuilder][1] class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][2] instead.                             |


Syntax
------

```csharp
public static SqlBuilder CreateStatic(
	string? text
)
```

#### Parameters

##### *text*  [String][6]
The SQL string.

#### Return Value
[SqlBuilder][1]  
A new instance of [SqlBuilder][1] initialized with *text*.

See Also
--------

#### Reference
[SqlBuilder Class][1]  
[DbExtensions Namespace][3]  

[1]: README.md
[2]: Create_1.md
[3]: ../README.md
[4]: CreateStatic.md
[5]: Create.md
[6]: https://learn.microsoft.com/dotnet/api/system.string