Database.CreateCommand Method (SqlBuilder)
==========================================
Creates and returns a [DbCommand][1] object from the specified *sqlBuilder*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public DbCommand CreateCommand(
	SqlBuilder sqlBuilder
)
```

### Parameters

#### *sqlBuilder*
Type: [DbExtensions.SqlBuilder][3]  
The [SqlBuilder][3] that provides the command's text and parameters.

### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][4] property is initialized with the *sqlBuilder* string representation, and whose [Parameters][5] property is initialized with the values from the [ParameterValues][6] property of the *sqlBuilder* parameter. 

Remarks
-------
[Transaction][7] is associated with all new commands created using this method. 

See Also
--------
[Database Class][8]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: ../README.md
[3]: ../SqlBuilder/README.md
[4]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[5]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[6]: ../SqlBuilder/ParameterValues.md
[7]: Transaction.md
[8]: README.md