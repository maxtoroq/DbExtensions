Database.EnsureInTransaction Method
===================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IDbTransaction EnsureInTransaction()
```

#### Return Value
Type: [IDbTransaction][2]  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing. 

Remarks
-------
 This method returns a virtual transaction that wraps an existing or new transaction. If [Current][3] is not null, this method creates a new [TransactionScope][4] and returns an [IDbTransaction][2] object that wraps it, and by calling [Commit()][5] on this object it will then call [Complete()][6] on the [TransactionScope][4]. If [Current][3] is null, this methods begins a new [IDbTransaction][2], or uses an existing transaction created by a previous call to this method, and returns an [IDbTransaction][2] object that wraps it, and by calling [Commit()][5] on this object it will then call [Commit()][5] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created. 

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
[Database Class][7]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://docs.microsoft.com/dotnet/api/system.data.idbtransaction
[3]: https://docs.microsoft.com/dotnet/api/system.transactions.transaction.current#System_Transactions_Transaction_Current
[4]: https://docs.microsoft.com/dotnet/api/system.transactions.transactionscope
[5]: https://docs.microsoft.com/dotnet/api/system.data.idbtransaction.commit#System_Data_IDbTransaction_Commit
[6]: https://docs.microsoft.com/dotnet/api/system.transactions.transactionscope.complete#System_Transactions_TransactionScope_Complete
[7]: README.md