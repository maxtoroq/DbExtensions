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
public sealed class DatabaseConfiguration
```

The **DatabaseConfiguration** type exposes the following members.


Properties
----------

                                   | Name                              | Description                                                                                                                                                                                   
---------------------------------- | --------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property]![Static member] | [DefaultConnectionString][4]      | The connection string to use as default.                                                                                                                                                      
![Public property]![Static member] | [DefaultProviderInvariantName][5] | The provider's invariant name to use as default.                                                                                                                                              
![Public property]                 | [EnableBatchCommands][6]          | true to execute batch commands when possible; otherwise, false. The default is true.                                                                                                          
![Public property]                 | [IgnoreDeleteConflicts][7]        | true to ignore when a concurrency conflict occurs when executing a DELETE command; otherwise, false. The default is true.                                                                     
![Public property]                 | [LastInsertIdCommand][8]          | Gets or sets the SQL command that returns the last identity value generated on the database.                                                                                                  
![Public property]                 | [Log][9]                          | Specifies the destination to write the SQL query or command.                                                                                                                                  
![Public property]                 | [ParameterNameBuilder][10]        | Specifies a function that prepares a parameter name to be used on [ParameterName][11].                                                                                                        
![Public property]                 | [ParameterPlaceholderBuilder][12] | Specifies a function that builds a parameter placeholder to be used in SQL statements.                                                                                                        
![Public property]                 | [QuotePrefix][13]                 | Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens. 
![Public property]                 | [QuoteSuffix][14]                 | Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens.    
![Public property]                 | [UseVersionMember][15]            | true to include version column check in SQL statements' predicates; otherwise, false. The default is true.                                                                                    


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: ../Database/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: DefaultConnectionString.md
[5]: DefaultProviderInvariantName.md
[6]: EnableBatchCommands.md
[7]: IgnoreDeleteConflicts.md
[8]: LastInsertIdCommand.md
[9]: Log.md
[10]: ParameterNameBuilder.md
[11]: http://msdn.microsoft.com/en-us/library/109h62zs
[12]: ParameterPlaceholderBuilder.md
[13]: QuotePrefix.md
[14]: QuoteSuffix.md
[15]: UseVersionMember.md
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Static member]: ../../_icons/static.gif "Static member"