Database.EnsureInTransaction Method (IsolationLevel)
====================================================
  Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.

  **Namespace:**  [DbExtensions][1]  
  **Assembly:**  DbExtensions (in DbExtensions.dll)

Syntax
------

```csharp
public IDbTransaction EnsureInTransaction(
	IsolationLevel isolationLevel
)
```

#### Parameters

##### *isolationLevel*
Type: [System.Data.IsolationLevel][2]  
 Specifies the isolation level for the transaction. This parameter is ignored when using an existing transaction.

#### Return Value
Type: [IDbTransaction][3]  
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
[2]: http://msdn.microsoft.com/en-us/library/xb2zxexk
[3]: http://msdn.microsoft.com/en-us/library/yas366ac
[4]: http://msdn.microsoft.com/en-us/library/f1a9t75e
[5]: http://msdn.microsoft.com/en-us/library/h5w5se33
[6]: http://msdn.microsoft.com/en-us/library/00w6tek6
[7]: http://msdn.microsoft.com/en-us/library/ms149857
[8]: README.md