DatabaseConfiguration Class
===========================
  Holds configuration options that customize the behavior of [Database][1]. This class cannot be instantiated, to get an instance use the [Configuration][2] property.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **DbExtensions.DatabaseConfiguration**  

  **Namespace:**  [DbExtensions][4]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

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
![Public property]                 | [CommandTimeout][5]               | Specifies a timeout to assign to commands. This setting is ignored if less or equal to -1. The default is -1.                                                                                 
![Public property]![Static member] | [DefaultConnectionString][6]      | The connection string to use as default.                                                                                                                                                      
![Public property]![Static member] | [DefaultProviderInvariantName][7] | The provider's invariant name to use as default.                                                                                                                                              
![Public property]                 | [EnableBatchCommands][8]          | true to execute batch commands when possible; otherwise, false. The default is true.                                                                                                          
![Public property]                 | [LastInsertIdCommand][9]          | Gets or sets the SQL command that returns the last identity value generated on the database.                                                                                                  
![Public property]                 | [Log][10]                         | Specifies the destination to write the SQL query or command.                                                                                                                                  
![Public property]                 | [ParameterNameBuilder][11]        | Specifies a function that prepares a parameter name to be used on [ParameterName][12].                                                                                                        
![Public property]                 | [ParameterPlaceholderBuilder][13] | Specifies a function that builds a parameter placeholder to be used in SQL statements.                                                                                                        
![Public property]                 | [QuotePrefix][14]                 | Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens. 
![Public property]                 | [QuoteSuffix][15]                 | Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens.    
![Public property]                 | [UseVersionMember][16]            | true to include version column check in SQL statements' predicates; otherwise, false. The default is true.                                                                                    


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

[1]: ../Database/README.md
[2]: ../Database/Configuration.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: CommandTimeout.md
[6]: DefaultConnectionString.md
[7]: DefaultProviderInvariantName.md
[8]: EnableBatchCommands.md
[9]: LastInsertIdCommand.md
[10]: Log.md
[11]: ParameterNameBuilder.md
[12]: http://msdn.microsoft.com/en-us/library/109h62zs
[13]: ParameterPlaceholderBuilder.md
[14]: QuotePrefix.md
[15]: QuoteSuffix.md
[16]: UseVersionMember.md
[Public property]: ../../icons/pubproperty.gif "Public property"
[Static member]: ../../icons/static.gif "Static member"