SqlBuilder.SetNextClause Method
===============================
  Sets *clauseName* as the next SQL clause.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public SqlBuilder SetNextClause(
	string clauseName,
	string separator
)
```

#### Parameters

##### *clauseName*
Type: [System.String][2]  
The SQL clause.

##### *separator*
Type: [System.String][2]  
The clause body separator, used for consecutive appends to the same clause.

#### Return Value
Type: [SqlBuilder][3]  
A reference to this instance after the operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][3]  
[DbExtensions Namespace][1]  
[SqlBuilder.NextClause][4]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: NextClause.md