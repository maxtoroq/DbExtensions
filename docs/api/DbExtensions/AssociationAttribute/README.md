AssociationAttribute Class
==========================
Designates a property to represent a database association, such as a foreign key relationship.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Attribute][2]  
    **DbExtensions.AssociationAttribute**  
  
**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class AssociationAttribute : Attribute
```

The **AssociationAttribute** type exposes the following members.


Constructors
------------

| Name                      | Description                                                      |
| ------------------------- | ---------------------------------------------------------------- |
| [AssociationAttribute][4] | Initializes a new instance of the **AssociationAttribute** class |


Properties
----------

| Name          | Description                                                                                                     |
| ------------- | --------------------------------------------------------------------------------------------------------------- |
| [Name][5]     | Gets or sets the name of a constraint.                                                                          |
| [OtherKey][6] | Gets or sets one or more members of the target entity class as key values on the other side of the association. |
| [ThisKey][7]  | Gets or sets members of this entity class to represent the key values on this side of the association.          |


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: https://learn.microsoft.com/dotnet/api/system.object
[2]: https://learn.microsoft.com/dotnet/api/system.attribute
[3]: ../README.md
[4]: _ctor.md
[5]: Name.md
[6]: OtherKey.md
[7]: ThisKey.md