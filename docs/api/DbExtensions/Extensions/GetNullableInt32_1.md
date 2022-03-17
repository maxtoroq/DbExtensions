Extensions.GetNullableInt32 Method (IDataRecord, String)
========================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Int32][2].

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static Nullable<int> GetNullableInt32(
	this IDataRecord record,
	string name
)
```

#### Parameters

##### *record*
Type: [System.Data.IDataRecord][4]  
The data record.

##### *name*
Type: [System.String][5]  
The name of the column to find.

#### Return Value
Type: [Nullable][1]&lt;[Int32][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][3]  

[1]: https://docs.microsoft.com/dotnet/api/system.nullable-1
[2]: https://docs.microsoft.com/dotnet/api/system.int32
[3]: ../README.md
[4]: https://docs.microsoft.com/dotnet/api/system.data.idatarecord
[5]: https://docs.microsoft.com/dotnet/api/system.string
[6]: https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods
[7]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[8]: README.md