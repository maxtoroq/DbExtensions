DatabaseConfiguration Class
===========================
Holds configuration options that customize the behavior of [Database][1]. This class cannot be instantiated, to get an instance use the [Configuration][2] property.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **DbExtensions.DatabaseConfiguration**  
  
**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class DatabaseConfiguration
```

The **DatabaseConfiguration** type exposes the following members.


Properties
----------

| Name                                 | Description                                                                                                                                                                                   |
| ------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [CommandTimeout][5]                  | Specifies a timeout to assign to commands. This setting is ignored if less or equal to -1. The default is -1.                                                                                 |
| [DefaultComplexPropertySeparator][6] | The default separator to use when mapping complex properties. The default value is null, which means no separator is used, unless an explicit separator is specified on [Separator][7].       |
| [EnableBatchCommands][8]             | `true` to execute batch commands when possible; otherwise, `false`. The default is `true`.                                                                                                    |
| [LastInsertIdCommand][9]             | Gets or sets the SQL command that returns the last identity value generated on the database.                                                                                                  |
| [Log][10]                            | Specifies the destination to write the SQL query or command.                                                                                                                                  |
| [ParameterNameBuilder][11]           | Specifies a function that prepares a parameter name to be used on [ParameterName][12].                                                                                                        |
| [ParameterPlaceholderBuilder][13]    | Specifies a function that builds a parameter placeholder to be used in SQL statements.                                                                                                        |
| [QuotePrefix][14]                    | Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens. |
| [QuoteSuffix][15]                    | Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens.    |
| [UseVersionMember][16]               | `true` to include version column check in SQL statements' predicates; otherwise, `false`. The default is `true`.                                                                              |


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

[1]: ../Database/README.md
[2]: ../Database/Configuration.md
[3]: https://learn.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: CommandTimeout.md
[6]: DefaultComplexPropertySeparator.md
[7]: ../ComplexPropertyAttribute/Separator.md
[8]: EnableBatchCommands.md
[9]: LastInsertIdCommand.md
[10]: Log.md
[11]: ParameterNameBuilder.md
[12]: https://learn.microsoft.com/dotnet/api/system.data.common.dbparameter.parametername
[13]: ParameterPlaceholderBuilder.md
[14]: QuotePrefix.md
[15]: QuoteSuffix.md
[16]: UseVersionMember.md