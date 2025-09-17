Extensions.GetNullableDateTime(DbDataReader, String) Method
===========================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [DateTime][2].
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                          | Description                                                                       |
| --------------------------------------------- | --------------------------------------------------------------------------------- |
| [GetNullableDateTime(DbDataReader, Int32)][4] | Gets the value of the specified column as a [Nullable&lt;T>][1] of [DateTime][2]. |
| **GetNullableDateTime(DbDataReader, String)** | Gets the value of the specified column as a [Nullable&lt;T>][1] of [DateTime][2]. |


Syntax
------

```csharp
public static DateTime? GetNullableDateTime(
	this DbDataReader reader,
	string name
)
```

#### Parameters

##### *reader*  [DbDataReader][5]
The data reader.

##### *name*  [String][6]
The name of the column to find.

#### Return Value
[Nullable][1]&lt;[DateTime][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbDataReader][5]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------

#### Reference
[Extensions Class][9]  
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.nullable-1
[2]: https://learn.microsoft.com/dotnet/api/system.datetime
[3]: ../README.md
[4]: GetNullableDateTime.md
[5]: https://learn.microsoft.com/dotnet/api/system.data.common.dbdatareader
[6]: https://learn.microsoft.com/dotnet/api/system.string
[7]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[8]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[9]: README.md