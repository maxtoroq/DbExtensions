SqlSet.SingleOrDefaultAsync(CancellationToken) Method
=====================================================
Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                                | Description                                                                                                                                                                                              |
| ------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **SingleOrDefaultAsync(CancellationToken)**                         | Returns the only element of the set, or a default value if the set is empty; this method throws an exception if there is more than one element in the set.                                               |
| [SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)][2] | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |
| [SingleOrDefaultAsync(String, CancellationToken)][3]                | Returns the only element of the set that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition. |


Syntax
------

```csharp
public ValueTask<Object> SingleOrDefaultAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[Object][7]>  
The single element of the set, or a default value if the set contains no elements.

Exceptions
----------

| Exception                      | Condition                               |
| ------------------------------ | --------------------------------------- |
| [InvalidOperationException][8] | The set contains more than one element. |


See Also
--------

#### Reference
[SqlSet Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: SingleOrDefaultAsync.md
[3]: SingleOrDefaultAsync_1.md
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.object
[8]: https://learn.microsoft.com/dotnet/api/system.invalidoperationexception
[9]: README.md