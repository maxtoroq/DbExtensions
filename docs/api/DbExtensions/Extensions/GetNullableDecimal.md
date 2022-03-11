Extensions.GetNullableDecimal Method (IDataRecord, Int32)
=========================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [Decimal][2].

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static Nullable<decimal> GetNullableDecimal(
	this IDataRecord record,
	int i
)
```

#### Parameters

##### *record*
Type: [System.Data.IDataRecord][4]  
The data record.

##### *i*
Type: [System.Int32][5]  
The zero-based column ordinal.

#### Return Value
Type: [Nullable][1]&lt;[Decimal][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[2]: http://msdn.microsoft.com/en-us/library/1k2e8atx
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/93wb1heh
[5]: http://msdn.microsoft.com/en-us/library/td2s409d
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md