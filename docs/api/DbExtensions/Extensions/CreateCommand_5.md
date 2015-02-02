Extensions.CreateCommand Method (DbProviderFactory, SqlBuilder)
===============================================================
Creates and returns a [DbCommand][1] object from the specified *sqlBuilder*.

**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static DbCommand CreateCommand(
	this DbProviderFactory providerFactory,
	SqlBuilder sqlBuilder
)
```

#### Parameters

##### *providerFactory*
Type: [System.Data.Common.DbProviderFactory][3]  
The provider factory used to create the command.

##### *sqlBuilder*
Type: [DbExtensions.SqlBuilder][4]  
The [SqlBuilder][4] that provides the command's text and parameters.

#### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][5] property is initialized with the *sqlBuilder*'s string representation, and whose [Parameters][6] property is initialized with the values from the [ParameterValues][7] property of the *sqlBuilder* parameter. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbProviderFactory][3]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][8] or [Extension Methods (C# Programming Guide)][9].

See Also
--------

#### Reference
[Extensions Class][10]  
[DbExtensions Namespace][2]  
[Extensions.CreateCommand(DbProviderFactory, String, Object[])][11]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/c6c4a26c
[4]: ../SqlBuilder/README.md
[5]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[6]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[7]: ../SqlBuilder/ParameterValues.md
[8]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[9]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[10]: README.md
[11]: CreateCommand_7.md