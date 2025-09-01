SqlBuilder.ORDER_BY(String, Object[]) Method
============================================
Appends the ORDER BY clause using the provided *format* string and parameters.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                           | Description                                                                                                                                                                |
| ---------------- | ------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [ORDER_BY()][2]                | Sets ORDER BY as the next clause, to be used by subsequent calls to clause continuation methods, such as [_(String, Object[])][3] and [_If(Boolean, String, Object[])][4]. |
| ![Public method] | **ORDER_BY(String, Object[])** | Appends the ORDER BY clause using the provided *format* string and parameters.                                                                                             |


Syntax
------

```csharp
public SqlBuilder ORDER_BY(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][5]
The format string that represents the body of the ORDER BY clause.

##### *args*  [Object][6][]
The parameters of the clause body.

#### Return Value
[SqlBuilder][7]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: ORDER_BY.md
[3]: _.md
[4]: _If.md
[5]: https://learn.microsoft.com/dotnet/api/system.string
[6]: https://learn.microsoft.com/dotnet/api/system.object
[7]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"