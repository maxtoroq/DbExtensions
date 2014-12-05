Extensions.Find Method (SqlSet, Object)
=======================================
Gets the entity whose primary key matches the *id* parameter.

**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static Object Find(
	this SqlSet source,
	Object id
)
```

#### Parameters

##### *source*
Type: [DbExtensions.SqlSet][2]  
The source set.

##### *id*
Type: [System.Object][3]  
The primary key value.

#### Return Value
Type: [Object][3]  
 The entity whose primary key matches the *id* parameter, or null if the *id* does not exist. 
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [SqlSet][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][4] or [Extension Methods (C# Programming Guide)][5].

Remarks
-------
 This method can only be used on mapped sets created by [Database][6]. 

See Also
--------

#### Reference
[Extensions Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ../SqlSet/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[5]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[6]: ../Database/README.md
[7]: README.md