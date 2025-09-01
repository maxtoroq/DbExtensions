SqlBuilder.Append(String, Object[]) Method
==========================================
Appends *format* to this instance.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                         | Description                        |
| ---------------- | ---------------------------- | ---------------------------------- |
| ![Public method] | [Append(SqlBuilder)][2]      | Appends *sql* to this instance.    |
| ![Public method] | **Append(String, Object[])** | Appends *format* to this instance. |


Syntax
------

```csharp
public SqlBuilder Append(
	string format,
	params Object[] args
)
```

#### Parameters

##### *format*  [String][3]
A SQL format string.

##### *args*  [Object][4][]
The array of parameters.

#### Return Value
[SqlBuilder][5]  
A reference to this instance after the append operation has completed.

See Also
--------

#### Reference
[SqlBuilder Class][5]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: Append.md
[3]: https://learn.microsoft.com/dotnet/api/system.string
[4]: https://learn.microsoft.com/dotnet/api/system.object
[5]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"