Database.EnsureInTransaction(IsolationLevel) Method
===================================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Overloads
---------

| Name                                    | Description                                                                                                                 |
| --------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| [EnsureInTransaction()][2]              | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |
| **EnsureInTransaction(IsolationLevel)** | Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing. |


Syntax
------

```csharp
public DbTransaction EnsureInTransaction(
	IsolationLevel isolationLevel
)
```

#### Parameters

##### *isolationLevel*  [IsolationLevel][3]
Specifies the isolation level for the transaction. This parameter is ignored when using an existing transaction.

#### Return Value
[DbTransaction][4]  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. By calling [Commit()][5] on the returned object, this object will then call [Commit()][5] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created.

Example
-------

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
[Database Class][6]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: EnsureInTransaction.md
[3]: https://learn.microsoft.com/dotnet/api/system.data.isolationlevel
[4]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction
[5]: https://learn.microsoft.com/dotnet/api/system.data.common.dbtransaction.commit
[6]: README.md