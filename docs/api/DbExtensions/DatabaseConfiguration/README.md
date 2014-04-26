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
[DeleteConflictPolicy][4]  | Gets or sets the default policy to use when calling [Remove(TEntity)][5]. The default value is [IgnoreVersionAndLowerAffectedRecords][6].                                                                                                                                                                                                                                                                                              
[EnableBatchCommands][7]   | true to execute batch commands when possible; otherwise, false. The default is true. You can override the default value using a "DbExtensions:{providerInvariantName}:EnableBatchCommands" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:EnableBatchCommands).                                                   
[EnableInsertRecursion][8] | true to recursively execute INSERT commands for the entity's one-to-one and one-to-many associations; otherwise, false. The default is true.                                                                                                                                                                                                                                                                                           
[LastInsertIdCommand][9]   | Gets or sets the SQL command that returns the last identity value generated on the database. The default value is "SELECT @@identity". You can override the default value using a "DbExtensions:{providerInvariantName}:LastInsertIdCommand" entry in the appSettings configuration section, where {providerInvariantName} is replaced with the provider invariant name (e.g. DbExtensions:System.Data.SqlClient:LastInsertIdCommand). 
[Log][10]                  | Specifies the destination to write the SQL query or command.                                                                                                                                                                                                                                                                                                                                                                           
[Mapping][11]              | Gets the [MetaModel][12] on which the mapping is based.                                                                                                                                                                                                                                                                                                                                                                                
[UpdateConflictPolicy][13] | Gets or sets the default policy to use when calling [Update(TEntity)][14]. The default value is [UseVersion][6].                                                                                                                                                                                                                                                                                                                       


See Also
--------
[DbExtensions Namespace][3]  

[1]: ../Database/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: DeleteConflictPolicy.md
[5]: ../SqlTable_1/Remove.md
[6]: ../ConcurrencyConflictPolicy/README.md
[7]: EnableBatchCommands.md
[8]: EnableInsertRecursion.md
[9]: LastInsertIdCommand.md
[10]: Log.md
[11]: Mapping.md
[12]: http://msdn.microsoft.com/en-us/library/bb534568
[13]: UpdateConflictPolicy.md
[14]: ../SqlTable_1/Update.md