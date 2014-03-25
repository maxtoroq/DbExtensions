DatabaseConfiguration.LastInsertIdCommand Property
==================================================
Gets or sets the SQL command that returns the last identity value generated on the database. The default value is "SELECT @@identity". You can override the default value using a "DbExtensions:{providerInvariantName}:LastInsertIdCommand" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:LastInsertIdCommand).

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public string LastInsertIdCommand { get; set; }
```

### Property Value
Type: [String][2]

Remarks
-------
 SQL Server users should consider using "SELECT SCOPE_IDENTITY()" instead. The command for SQLite is "SELECT LAST_INSERT_ROWID()". 

See Also
--------
[DatabaseConfiguration Class][3]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md