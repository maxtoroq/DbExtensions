Database.EnsureInTransaction Method
===================================
Returns a virtual transaction that you can use to ensure a code block is always executed in a transaction, new or existing.
  
**Namespace:** [DbExtensions][1]  
**Assembly:** DbExtensions.dll

Syntax
------

```csharp
public IDbTransaction EnsureInTransaction()
```

#### Return Value
[IDbTransaction][2]  
 A virtual transaction you can use to ensure a code block is always executed in a transaction, new or existing.

Remarks
-------
This method returns a virtual transaction that wraps an existing or new transaction. By calling [Commit()][3] on the returned object, this object will then call [Commit()][3] on the wrapped transaction if the transaction was just created, or do nothing if it was previously created. 

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
[Database Class][4]  
[DbExtensions Namespace][1]  

[1]: ../README.md
[2]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction
[3]: https://learn.microsoft.com/dotnet/api/system.data.idbtransaction.commit
[4]: README.md