Extensions.GetNullableDateTime Method (IDataRecord, String)
===========================================================
Gets the value of the specified column as a [Nullable&lt;T>][1] of [DateTime][2].

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static Nullable<DateTime> GetNullableDateTime(
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
Type: [Nullable][1]&lt;[DateTime][2]>  
The value of the column.
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IDataRecord][4]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[2]: http://msdn.microsoft.com/en-us/library/03ybds8y
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/93wb1heh
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md