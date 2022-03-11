SqlBuilder.JoinSql Method (String, SqlBuilder[])
================================================
Concatenates a specified separator [String][1] between each element of a specified [SqlBuilder][2] array, yielding a single concatenated [SqlBuilder][2].

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public static SqlBuilder JoinSql(
	string separator,
	params SqlBuilder[] values
)
```

#### Parameters

##### *separator*
Type: [System.String][1]  
The string to use as a separator.

##### *values*
Type: [DbExtensions.SqlBuilder][2][]  
An array of [SqlBuilder][2].

#### Return Value
Type: [SqlBuilder][2]  
 A [SqlBuilder][2] consisting of the elements of *values* interspersed with the *separator* string. 

See Also
--------

#### Reference
[SqlBuilder Class][2]  
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[2]: README.md
[3]: ../README.md