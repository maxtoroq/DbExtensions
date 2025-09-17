Database.EnsureInTransactionAsync(IsolationLevel, CancellationToken) Method
===========================================================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                                            | Description                                                                                                                 |
| --------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| [EnsureInTransactionAsync(CancellationToken)][2]                | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |
| **EnsureInTransactionAsync(IsolationLevel, CancellationToken)** | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |


Syntax
------

```csharp
public ValueTask<DbTransaction> EnsureInTransactionAsync(
	IsolationLevel isolationLevel,
	CancellationToken cancellationToken = default
)
```

#### Parameters

##### *isolationLevel*  [IsolationLevel][3]
Specifies the isolation level for the transaction. This parameter is ignored when using an existing transaction.

##### *cancellationToken*  [CancellationToken][4]  (Optional)
The [CancellationToken][4] to monitor for cancellation requests. The default is [None][5].

#### Return Value
[ValueTask][6]&lt;[DbTransaction][7]>  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. By calling [Commit()][8] on the returned object, this object will then call [Commit()][8] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created.

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
[Database Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: EnsureInTransactionAsync_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.isolationlevel
[4]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken
[5]: https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none
[6]: https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1
[7]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction
[8]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction.commit
[9]: README.md