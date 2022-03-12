ColumnAttribute Class
=====================
Associates a property with a column in a database table.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Attribute][2]  
    **DbExtensions.ColumnAttribute**  

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class ColumnAttribute : Attribute
```

The **ColumnAttribute** type exposes the following members.


Constructors
------------

                 | Name                 | Description                                                 
---------------- | -------------------- | ----------------------------------------------------------- 
![Public method] | [ColumnAttribute][4] | Initializes a new instance of the **ColumnAttribute** class 


Properties
----------

                   | Name               | Description                                                                                                     
------------------ | ------------------ | --------------------------------------------------------------------------------------------------------------- 
![Public property] | [AutoSync][5]      | Gets or sets the [AutoSync][5] enumeration.                                                                     
![Public property] | [ConvertTo][6]     | Gets or sets the type to convert this member to before sending to the database.                                 
![Public property] | [IsDbGenerated][7] | Gets or sets whether a column contains values that the database auto-generates.                                 
![Public property] | [IsPrimaryKey][8]  | Gets or sets whether this class member represents a column that is part or all of the primary key of the table. 
![Public property] | [IsVersion][9]     | Gets or sets whether the column type of the member is a database timestamp or version number.                   
![Public property] | [Name][10]         | Gets or sets the name of a column.                                                                              


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/e8kc3626
[3]: ../README.md
[4]: _ctor.md
[5]: AutoSync.md
[6]: ConvertTo.md
[7]: IsDbGenerated.md
[8]: IsPrimaryKey.md
[9]: IsVersion.md
[10]: Name.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"