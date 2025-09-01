Database.Map(Type, SqlBuilder) Method
=====================================
Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                                            | Description                                                                                                                 |
| ---------------- | --------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [Map(SqlBuilder)][2]                                            | Maps the results of the *query* to dynamic objects. The query is deferred-executed.                                         |
| ![Public method] | **Map(Type, SqlBuilder)**                                       | Maps the results of the *query* to objects of type specified by the *resultType* parameter. The query is deferred-executed. |
| ![Public method] | [Map&lt;TResult>(SqlBuilder)][3]                                | Maps the results of the *query* to TResult objects. The query is deferred-executed.                                         |
| ![Public method] | [Map&lt;TResult>(SqlBuilder, Func&lt;IDataRecord, TResult>)][4] | Maps the results of the *query* to TResult objects, using the provided *mapper* delegate.                                   |


Syntax
------

```csharp
public IEnumerable<Object> Map(
	Type resultType,
	SqlBuilder query
)
```

#### Parameters

##### *resultType*  [Type][5]
The type of objects to map the results to.

##### *query*  [SqlBuilder][6]
The query.

#### Return Value
[IEnumerable][7]&lt;[Object][8]>  
The results of the query as objects of type specified by the *resultType* parameter.

See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Map.md
[3]: Map__1.md
[4]: Map__1_1.md
[5]: https://learn.microsoft.com/dotnet/api/system.type
[6]: ../SqlBuilder/README.md
[7]: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
[8]: https://learn.microsoft.com/dotnet/api/system.object
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"