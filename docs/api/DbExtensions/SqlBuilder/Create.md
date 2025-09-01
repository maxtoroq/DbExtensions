SqlBuilder.Create(SqlBuilder.AppendInterpolatedStringHandler) Method
====================================================================
Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string.
  
**Namespace:** [DbExtensions][2]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                                  | Name                                    | Description                                                                                     |
| -------------------------------- | --------------------------------------- | ----------------------------------------------------------------------------------------------- |
| ![Public method]![Static member] | Create(AppendInterpolatedStringHandler) | Initializes a new instance of the [SqlBuilder][1] class using the provided interpolated string. |
| ![Public method]![Static member] | [Create(String)][3]                     | Initializes a new instance of the [SqlBuilder][1] class using the provided text.                |


Syntax
------

```csharp
public static SqlBuilder Create(
	ref AppendInterpolatedStringHandler handler
)
```

#### Parameters

##### *handler*  AppendInterpolatedStringHandler
The interpolated string.

#### Return Value
[SqlBuilder][1]

See Also
--------

#### Reference
[SqlBuilder Class][1]  
[DbExtensions Namespace][2]  

[1]: README.md
[2]: ../README.md
[3]: Create_1.md
[Public method]: ../../icons/pubmethod.svg "Public method"
[Static member]: ../../icons/Static.gif "Static member"