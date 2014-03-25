DatabaseConfiguration Class
===========================
Holds configuration options that customize the behavior of [Database][1].


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **DbExtensions.DatabaseConfiguration**  

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class DatabaseConfiguration
```

The **DatabaseConfiguration** type exposes the following members.


Properties
----------

Name                       | Description                                                                                                                                                                                                                                                                                                                                                                                                                            
-------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
[DeleteConflictPolicy][4]  | Gets or sets the default policy to use when calling [Delete(TEntity)][5]. The default value is [IgnoreVersionAndLowerAffectedRecords][6].                                                                                                                                                                                                                                                                                              
[EnableBatchCommands][7]   | true to execute batch commands when possible; otherwise, false. The default is true. You can override the default value using a "DbExtensions:{providerInvariantName}:EnableBatchCommands" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:EnableBatchCommands).                                                   
[LastInsertIdCommand][8]   | Gets or sets the SQL command that returns the last identity value generated on the database. The default value is "SELECT @@identity". You can override the default value using a "DbExtensions:{providerInvariantName}:LastInsertIdCommand" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:LastInsertIdCommand). 
[Log][9]                   | Specifies the destination to write the SQL query or command.                                                                                                                                                                                                                                                                                                                                                                           
[Mapping][10]              | Gets the [MetaModel][11] on which the mapping is based.                                                                                                                                                                                                                                                                                                                                                                                
[UpdateConflictPolicy][12] | Gets or sets the default policy to use when calling [Update(TEntity)][13]. The default value is [UseVersion][6].                                                                                                                                                                                                                                                                                                                       


See Also
--------
[DbExtensions Namespace][3]  

[1]: ../Database/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: DeleteConflictPolicy.md
[5]: ../SqlTable_1/Delete.md
[6]: ../ConcurrencyConflictPolicy/README.md
[7]: EnableBatchCommands.md
[8]: LastInsertIdCommand.md
[9]: Log.md
[10]: Mapping.md
[11]: http://msdn.microsoft.com/en-us/library/bb534568
[12]: UpdateConflictPolicy.md
[13]: ../SqlTable_1/Update.md