Extensions.AffectOneOrNone Method (DbConnection, String, Object[])
==================================================================
Creates and executes a [DbCommand][1] (using the provided *commandText* as a composite format string, as used on [Format(String, Object[])][2], where the format items are replaced with appropiate parameter names, and the objects in the *parameters* array are added to the command's [Parameters][3] collection) in a new or existing transaction, and validates that the affected records value is less or equal to one before comitting.

**Namespace:** [DbExtensions][4]  
**Assembly:** DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public static int AffectOneOrNone(
	this DbConnection connection,
	string commandText,
	params Object[] parameters
)
```

### Parameters

#### *connection*
Type: [System.Data.Common.DbConnection][5]  
The connection to which the command is executed against.

#### *commandText*
Type: [System.String][6]  
The non-query command to execute.

#### *parameters*
Type: [System.Object][7][]  
The parameters to apply to the command text.

### Return Value
Type: [Int32][8]  
The number of affected records.
### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [DbConnection][5]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][9] or [Extension Methods (C# Programming Guide)][10].

Exceptions
----------

Exception                    | Condition                                           
---------------------------- | --------------------------------------------------- 
[DBConcurrencyException][11] | The number of affected records is greater than one. 


See Also
--------
[Extensions Class][12]  
[DbExtensions Namespace][4]  
[Extensions.AffectOneOrNone(IDbCommand)][13]  

[1]: http://msdn.microsoft.com/en-us/library/852d01k6
[2]: http://msdn.microsoft.com/en-us/library/b1csw23d
[3]: http://msdn.microsoft.com/en-us/library/9czdkzd1
[4]: ../README.md
[5]: http://msdn.microsoft.com/en-us/library/c790zwhc
[6]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[7]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[8]: http://msdn.microsoft.com/en-us/library/td2s409d
[9]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[10]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[11]: http://msdn.microsoft.com/en-us/library/bsdf9tb2
[12]: README.md
[13]: AffectOneOrNone_4.md