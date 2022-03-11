AssociationAttribute Class
==========================
Designates a property to represent a database association, such as a foreign key relationship.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Attribute][2]  
    **DbExtensions.AssociationAttribute**  

  **Namespace:**  [DbExtensions][3]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public sealed class AssociationAttribute : Attribute
```

The **AssociationAttribute** type exposes the following members.


Constructors
------------

                 | Name                      | Description                                                      
---------------- | ------------------------- | ---------------------------------------------------------------- 
![Public method] | [AssociationAttribute][4] | Initializes a new instance of the **AssociationAttribute** class 


Properties
----------

                   | Name          | Description                                                                                                     
------------------ | ------------- | --------------------------------------------------------------------------------------------------------------- 
![Public property] | [Name][5]     | Gets or sets the name of a constraint.                                                                          
![Public property] | [OtherKey][6] | Gets or sets one or more members of the target entity class as key values on the other side of the association. 
![Public property] | [ThisKey][7]  | Gets or sets members of this entity class to represent the key values on this side of the association.          


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/e8kc3626
[3]: ../README.md
[4]: _ctor.md
[5]: Name.md
[6]: OtherKey.md
[7]: ThisKey.md
[Public method]: ../../icons/pubmethod.gif "Public method"
[Public property]: ../../icons/pubproperty.gif "Public property"