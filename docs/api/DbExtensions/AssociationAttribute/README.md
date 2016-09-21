AssociationAttribute Class
==========================
Designates a property to represent a database association, such as a foreign key relationship.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Attribute][2]  
    **DbExtensions.AssociationAttribute**  

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public sealed class AssociationAttribute : Attribute, 
	IDataAttribute
```

The **AssociationAttribute** type exposes the following members.


Constructors
------------

                 | Name                      | Description                                                      
---------------- | ------------------------- | ---------------------------------------------------------------- 
![Public method] | [AssociationAttribute][4] | Initializes a new instance of the **AssociationAttribute** class 


Properties
----------

                   | Name              | Description                                                                                                     
------------------ | ----------------- | --------------------------------------------------------------------------------------------------------------- 
![Public property] | [IsForeignKey][5] | Gets or sets the member as the foreign key in an association representing a database relationship.              
![Public property] | [IsUnique][6]     | Gets or sets the indication of a uniqueness constraint on the foreign key.                                      
![Public property] | [Name][7]         | Gets or sets the name of a constraint.                                                                          
![Public property] | [OtherKey][8]     | Gets or sets one or more members of the target entity class as key values on the other side of the association. 
![Public property] | [Storage][9]      | Gets or sets a private storage field to hold the value for the association property.                            
![Public property] | [ThisKey][10]     | Gets or sets members of this entity class to represent the key values on this side of the association.          


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/e8kc3626
[3]: ../README.md
[4]: _ctor.md
[5]: IsForeignKey.md
[6]: IsUnique.md
[7]: Name.md
[8]: OtherKey.md
[9]: Storage.md
[10]: ThisKey.md
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"