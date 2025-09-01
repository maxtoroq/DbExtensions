Database.EnsureInTransaction(IsolationLevel) Method
===================================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                    | Description                                                                                                                 |
| ---------------- | --------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | [EnsureInTransaction()][2]              | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |
| ![Public method] | **EnsureInTransaction(IsolationLevel)** | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |


Syntax
------

```csharp
public IDbTransaction EnsureInTransaction(
	IsolationLevel isolationLevel
)
```

#### Parameters

##### *isolationLevel*  [IsolationLevel][3]
Specifies the isolation level for the transaction. This parameter is ignored when using an existing transaction.

#### Return Value
[IDbTransaction][4]  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. If [Current][5] is not null, this method creates a new [TransactionScope][6] and returns an [IDbTransaction][4] object that wraps it, and by calling [Commit()][7] on this object it will then call [Complete()][8] on the [TransactionScope][6]. If [Current][5] is null, this methods begins a new [IDbTransaction][4], or uses an existing transaction created by a previous call to this method, and returns an [IDbTransaction][4] object that wraps it, and by calling [Commit()][7] on this object it will then call [Commit()][7] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created. 

Calls to this method can be nested, like in the following example:

```csharp
void DoSomething() {

   using (var tx = this.db.EnsureInTransaction()) {

      // Execute commands

      DoSomethingElse();

      tx.Commit();
   }
}

void DoSomethingElse() { 

   using (var tx = this.db.EnsureInTransaction()) {

      // Execute commands

      tx.Commit();
   }
}
```


See Also
--------

#### Reference
[Database Class][9]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: EnsureInTransaction.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.isolationlevel
[4]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction
[5]: https://learn.microsoft.com/dotnet/api/system.transactions.transaction.current
[6]: https://learn.microsoft.com/dotnet/api/system.transactions.transactionscope
[7]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction.commit
[8]: https://learn.microsoft.com/dotnet/api/system.transactions.transactionscope.complete
[9]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"