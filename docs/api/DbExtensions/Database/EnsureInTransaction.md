Database.EnsureInTransaction Method
===================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

|                  | Name                                     | Description                                                                                                                 |
| ---------------- | ---------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ![Public method] | **EnsureInTransaction()**                | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |
| ![Public method] | [EnsureInTransaction(IsolationLevel)][2] | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |


Syntax
------

```csharp
public IDbTransaction EnsureInTransaction()
```

#### Return Value
[IDbTransaction][3]  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. If [Current][4] is not null, this method creates a new [TransactionScope][5] and returns an [IDbTransaction][3] object that wraps it, and by calling [Commit()][6] on this object it will then call [Complete()][7] on the [TransactionScope][5]. If [Current][4] is null, this methods begins a new [IDbTransaction][3], or uses an existing transaction created by a previous call to this method, and returns an [IDbTransaction][3] object that wraps it, and by calling [Commit()][6] on this object it will then call [Commit()][6] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created. 

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
[Database Class][8]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: EnsureInTransaction_1.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction
[4]: https://learn.microsoft.com/dotnet/api/system.transactions.transaction.current
[5]: https://learn.microsoft.com/dotnet/api/system.transactions.transactionscope
[6]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction.commit
[7]: https://learn.microsoft.com/dotnet/api/system.transactions.transactionscope.complete
[8]: README.md
[Public method]: ../../icons/pubmethod.svg "Public method"