ChangeConflictException Class
=============================
An exception that is thrown when a concurrency violation is encountered while saving to the database. A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because the data in the database has been modified since it was loaded into memory.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Exception][2]  
    [System.SystemException][3]  
      **DbExtensions.ChangeConflictException**  

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
[SerializableAttribute]
public class ChangeConflictException : SystemException
```

The **ChangeConflictException** type exposes the following members.


Constructors
------------

                 | Name                         | Description                                                                                         
---------------- | ---------------------------- | --------------------------------------------------------------------------------------------------- 
![Public method] | [ChangeConflictException][5] | Initializes a new instance of the **ChangeConflictException** class with a specified error message. 


See Also
--------

#### Reference
[DbExtensions Namespace][4]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/c18k6c59
[3]: http://msdn.microsoft.com/en-us/library/z3h75xk6
[4]: ../README.md
[5]: _ctor.md
[Public method]: ../../_icons/pubmethod.gif "Public method"