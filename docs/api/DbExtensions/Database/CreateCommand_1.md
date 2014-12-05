Database.CreateCommand Method (String)
======================================
Creates and returns a [DbCommand][1] object using the specified *commandText*.

**Namespace:** [DbExtensions][2]  
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
Type: [System.String][3]  
The SQL command.

#### Return Value
Type: [DbCommand][1]  
 A new [DbCommand][1] object whose [CommandText][4] property is initialized with the *commandText* parameter. 

Remarks
-------
[Transaction][5] is associated with all new commands created using this method. 

See Also
--------

#### Reference
[Database Class][6]  
[DbExtensions Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/9d2hk99t
[5]: Transaction.md
[6]: README.md