DatabaseConfiguration Class
===========================
Holds configuration options that customize the behavior of [Database][1]. This class cannot be instantiated, to get an instance use the [Configuration][2] property.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **DbExtensions.DatabaseConfiguration**  

  **Namespace:**  [DbExtensions][4]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class DatabaseConfiguration
```

The **DatabaseConfiguration** type exposes the following members.


Properties
----------

|                                    | Name                                 | Description                                                                                                                                                                                   |
| ---------------------------------- | ------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property]                 | [CommandTimeout][5]                  | Specifies a timeout to assign to commands. This setting is ignored if less or equal to -1. The default is -1.                                                                                 |
| ![Public property]                 | [DefaultComplexPropertySeparator][6] | The default separator to use when mapping complex properties. The default value is null, which means no separator is used, unless an explicit separator is specified on [Separator][7].       |
| ![Public property]![Static member] | [DefaultConnectionString][8]         | The connection string to use as default.                                                                                                                                                      |
| ![Public property]![Static member] | [DefaultProviderInvariantName][9]    | The provider's invariant name to use as default.                                                                                                                                              |
| ![Public property]                 | [EnableBatchCommands][10]            | true to execute batch commands when possible; otherwise, false. The default is true.                                                                                                          |
| ![Public property]                 | [LastInsertIdCommand][11]            | Gets or sets the SQL command that returns the last identity value generated on the database.                                                                                                  |
| ![Public property]                 | [Log][12]                            | Specifies the destination to write the SQL query or command.                                                                                                                                  |
| ![Public property]                 | [ParameterNameBuilder][13]           | Specifies a function that prepares a parameter name to be used on [ParameterName][14].                                                                                                        |
| ![Public property]                 | [ParameterPlaceholderBuilder][15]    | Specifies a function that builds a parameter placeholder to be used in SQL statements.                                                                                                        |
| ![Public property]                 | [QuotePrefix][16]                    | Gets or sets the beginning character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens. |
| ![Public property]                 | [QuoteSuffix][17]                    | Gets or sets the ending character or characters to use when specifying database objects (for example, tables or columns) whose names contain characters such as spaces or reserved tokens.    |
| ![Public property]                 | [UseCompiledMapping][18]             | true to use the new cached compiled mapping implementation for POCO objects; otherwise, false. The default is false.                                                                          |
| ![Public property]                 | [UseVersionMember][19]               | true to include version column check in SQL statements' predicates; otherwise, false. The default is true.                                                                                    |


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

[1]: ../Database/README.md
[2]: ../Database/Configuration.md
[3]: https://docs.microsoft.com/dotnet/api/system.object
[4]: ../README.md
[5]: CommandTimeout.md
[6]: DefaultComplexPropertySeparator.md
[7]: ../ComplexPropertyAttribute/Separator.md
[8]: DefaultConnectionString.md
[9]: DefaultProviderInvariantName.md
[10]: EnableBatchCommands.md
[11]: LastInsertIdCommand.md
[12]: Log.md
[13]: ParameterNameBuilder.md
[14]: https://docs.microsoft.com/dotnet/api/system.data.idataparameter.parametername#System_Data_IDataParameter_ParameterName
[15]: ParameterPlaceholderBuilder.md
[16]: QuotePrefix.md
[17]: QuoteSuffix.md
[18]: UseCompiledMapping.md
[19]: UseVersionMember.md
[Public property]: ../../icons/pubproperty.svg "Public property"
[Static member]: ../../icons/static.gif "Static member"