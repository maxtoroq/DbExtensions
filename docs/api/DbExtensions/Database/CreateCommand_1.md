Database.CreateCommand Method (String)
======================================
Creates and returns a [DbCommand][1] object whose [CommandText][2] property is initialized with the *commandText* parameter.

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public DbCommand CreateCommand(
	string commandText
)
```

#### Parameters

##### *commandText*
Type: [System.String][4]  
The command text.

#### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][2] property is initialized with the *commandText* parameter. 

Remarks
-------
[Transaction][5] is associated with all new commands created using this method. 

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][3]  
[Extensions.CreateCommand(DbConnection, String)][7]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: Transaction.md
[6]: README.md
[7]: ../Extensions/CreateCommand_3.md