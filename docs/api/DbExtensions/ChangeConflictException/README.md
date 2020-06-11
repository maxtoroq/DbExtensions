ChangeConflictException Class
=============================
An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Exception][2]  
    **DbExtensions.ChangeConflictException**  

**Namespace:** [DbExtensions][3]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[SerializableAttribute]
public class ChangeConflictException : Exception
```

The **ChangeConflictException** type exposes the following members.


Constructors
------------

                 | Name                         | Description                                                                                         
---------------- | ---------------------------- | --------------------------------------------------------------------------------------------------- 
![Public method] | [ChangeConflictException][4] | Initializes a new instance of the **ChangeConflictException** class with a specified error message. 


See Also
--------

#### Reference
[DbExtensions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/c18k6c59
[3]: ../README.md
[4]: _ctor.md
[Public method]: ../../icons/pubmethod.gif "Public method"