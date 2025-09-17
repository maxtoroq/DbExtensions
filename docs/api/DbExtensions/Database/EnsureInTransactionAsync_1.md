Database.EnsureInTransactionAsync(CancellationToken) Method
===========================================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                             | Description                                                                                                                 |
| ---------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| **EnsureInTransactionAsync(CancellationToken)**                  | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |
| [EnsureInTransactionAsync(IsolationLevel, CancellationToken)][2] | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |


Syntax
------

```csharp
public ValueTask<DbTransaction> EnsureInTransactionAsync(
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *cancellationToken*  [CancellationToken][3]  (Optional)
The [CancellationToken][3] to monitor for cancellation requests. The default is [None][4].

#### Return Value
[ValueTask][5]&lt;[DbTransaction][6]>  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. By calling [Commit()][7] on the returned object, this object will then call [Commit()][7] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created.

Example
-------

Calls to this method can be nested, like in the following example:

```csharp
async Task DoSomething() {

   await using (var tx = await this.db.EnsureInTransactionAsync()) {

      // Execute commands

      await DoSomethingElse();

      await tx.CommitAsync();
   }
}

async Task DoSomethingElse() {

   await using (var tx = await this.db.EnsureInTransactionAsync()) {

      // Execute commands

      await tx.CommitAsync();
   }
}
```


See Also
--------

#### Reference
[Database Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: EnsureInTransactionAsync.md
[3]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[5]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[6]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction
[7]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction.commit
[8]: README.md