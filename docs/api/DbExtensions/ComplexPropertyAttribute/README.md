ComplexPropertyAttribute Class
==============================
Designates a property as a complex property that groups columns of a table that share the same base name.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Attribute][2]  
    **DbExtensions.ComplexPropertyAttribute**  

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class ComplexPropertyAttribute : Attribute
```

The **ComplexPropertyAttribute** type exposes the following members.


Constructors
------------

|                  | Name                          | Description                                                          |
| ---------------- | ----------------------------- | -------------------------------------------------------------------- |
| ![Public method] | [ComplexPropertyAttribute][4] | Initializes a new instance of the **ComplexPropertyAttribute** class |


Properties
----------

|                    | Name           | Description                                                                                                                                                                                                                                                             |
| ------------------ | -------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public property] | [Name][5]      | The base name for the columns on the complex property. The default is the property name.                                                                                                                                                                                |
| ![Public property] | [Separator][6] | The separator to use between the base name and the complex property's columns. The default is null, which means the separator is taken from [DefaultComplexPropertySeparator][7]. To use no separator and override the default configuration, use an empty [String][8]. |


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/e8kc3626
[3]: ../README.md
[4]: _ctor.md
[5]: Name.md
[6]: Separator.md
[7]: ../DatabaseConfiguration/DefaultComplexPropertySeparator.md
[8]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[Public method]: ../../icons/pubmethod.svg "Public method"
[Public property]: ../../icons/pubproperty.svg "Public property"