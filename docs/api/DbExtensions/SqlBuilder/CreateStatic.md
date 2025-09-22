SqlBuilder.CreateStatic(SqlBuilder) Method
==========================================
Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][2] instead.
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                         | Description                                                                                                                                                                                                                  |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **CreateStatic(SqlBuilder)** | Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(AppendStringHandler)][2] instead. |
| [CreateStatic(String)][4]    | Initializes a new instance of the [SqlBuilder][1] class using the provided text. Use this method if you don't expect to modify the returned builder; otherwise, use [Create(String)][5] instead.                             |


Syntax
------

```csharp
public static SqlBuilder CreateStatic(
	SqlBuilder sql
)
```

#### Parameters

##### *sql*  [SqlBuilder][1]
The interpolated string.

#### Return Value
[SqlBuilder][1]  
The provided *sql* unmodified.

See Also
--------

#### Reference
[SqlBuilder Class][1]  
[DbExtensions Namespace][3]  

[1]: README.md
[2]: Create.md
[3]: ../README.md
[4]: CreateStatic_1.md
[5]: Create_1.md