AutoSync Enumeration
====================
Used to specify for during INSERT and UPDATE operations when a data member should be read back after the operation completes.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public enum AutoSync
```


Members
-------

| Member name  | Value | Description                                       |
| ------------ | ----- | ------------------------------------------------- |
| **Default**  | 0     | Automatically selects the value.                  |
| **Always**   | 1     | Always returns the value.                         |
| **Never**    | 2     | Never returns the value.                          |
| **OnInsert** | 3     | Returns the value only after an INSERT operation. |
| **OnUpdate** | 4     | Returns the value only after an UPDATE operation. |


See Also
--------

#### Reference
[DbExtensions Namespace][1]  

[1]: ../README.md