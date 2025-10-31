// Copyright 2025 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtensions;

#nullable enable

partial class SqlSet {

   private protected virtual IAsyncEnumerable<object>
   AsyncMap(bool singleResult) {

      var query = GetDefiningQuery(clone: false);
      var results = default(IAsyncEnumerable<object>);

      if (this.ResultType is not null) {

         PocoAsyncMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set.");

      } else {

         DynamicAsyncMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set unless you specify a result type.");
      }
   }

   partial void
   PocoAsyncMap(bool singleResult, SqlBuilder query, ref IAsyncEnumerable<object>? results);

   partial void
   DynamicAsyncMap(bool singleResult, SqlBuilder query, ref IAsyncEnumerable<object>? results);

   // ISqlSet Members

   /// <inheritdoc cref="AsEnumerable()"/>

   public IAsyncEnumerable<object>
   AsAsyncEnumerable() =>
      AsAsyncEnumerable(singleResult: false);

   IAsyncEnumerable<object>
   AsAsyncEnumerable(bool singleResult) =>
      AsyncMap(singleResult);

   /// <inheritdoc cref="All(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   AllAsync(string predicate, CancellationToken cancellationToken = default) {

      ArgumentNullException.ThrowIfNull(predicate);

      return !await AnyAsync(String.Concat("NOT (", predicate, ")"), cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="All(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   AllAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      var builder = predicate.Fragment;
      builder.Buffer.Insert(0, "NOT (")
         .Append(')');

      return !await AnyAsync(predicate, cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Any()"/>
   /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>

   public async ValueTask<bool>
   AnyAsync(CancellationToken cancellationToken = default) {

      var (query, mapFn) = AnyImplParams();

      return await _db.AsyncMap(query, mapFn)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Any(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   AnyAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .AnyAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Any(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<bool>
   AnyAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .AnyAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Count()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<int>
   CountAsync(CancellationToken cancellationToken = default) {

      var (query, mapFn) = CountImplParams();

      return await _db.AsyncMap(query, mapFn)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Count(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<int>
   CountAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .CountAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Count(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<int>
   CountAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .CountAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="First()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   FirstAsync(CancellationToken cancellationToken = default) {

      return await Take(1)
         .AsAsyncEnumerable(singleResult: true)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="First(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   FirstAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="First(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   FirstAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="FirstOrDefault()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   FirstOrDefaultAsync(CancellationToken cancellationToken = default) {

      return await Take(1)
         .AsAsyncEnumerable(singleResult: true)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="FirstOrDefault(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   FirstOrDefaultAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="FirstOrDefault(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   FirstOrDefaultAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <summary>
   /// Returns an async enumerator that iterates through the set.
   /// </summary>
   /// <returns>A <see cref="IAsyncEnumerator&lt;Object>"/> for the set.</returns>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public IAsyncEnumerator<object>
   GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
      AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);

   /// <inheritdoc cref="LongCount()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<long>
   LongCountAsync(CancellationToken cancellationToken = default) {

      var (query, mapFn) = LongCountImplParams();

      return await _db.AsyncMap(query, mapFn)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="LongCount(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<long>
   LongCountAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .LongCountAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="LongCount(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<long>
   LongCountAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .LongCountAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Single()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   SingleAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable(singleResult: true)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Single(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   SingleAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="Single(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object>
   SingleAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SingleOrDefault()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   SingleOrDefaultAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable(singleResult: true)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SingleOrDefault(String)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   SingleOrDefaultAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SingleOrDefault(ref OperatorStringHandler)"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object?>
   SingleOrDefaultAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="ToArray()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<object[]>
   ToArrayAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable()
         .ToArrayAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="ToList()"/>
   /// <inheritdoc cref="AnyAsync(CancellationToken)" path="param"/>

   public async ValueTask<List<object>>
   ToListAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable()
         .ToListAsync(cancellationToken)
         .ConfigureAwait(false);
   }
}

partial class SqlSet<TResult> {

   private protected override IAsyncEnumerable<object>
   AsyncMap(bool singleResult) {

      if (_explicitMapper is not null) {

         return _db.AsyncMap(
            GetDefiningQuery(clone: false),
            r => (object)_explicitMapper.Invoke(r)!);
      }

      return base.AsyncMap(singleResult);
   }

   IAsyncEnumerable<TResult>
   AsyncMapTyped(bool singleResult) {

      var query = GetDefiningQuery(clone: false);

      if (_explicitMapper is not null) {
         return _db.AsyncMap(query, _explicitMapper);
      } else {

         var results = default(IAsyncEnumerable<TResult>);

         PocoAsyncMap(singleResult, query, ref results);

         return results
            ?? throw new InvalidOperationException("Cannot enumerate this set.");
      }
   }

   partial void
   PocoAsyncMap(bool singleResult, SqlBuilder query, ref IAsyncEnumerable<TResult>? results);

   // ISqlSet Members

   /// <inheritdoc cref="AsEnumerable()"/>

   public new IAsyncEnumerable<TResult>
   AsAsyncEnumerable() =>
      AsAsyncEnumerable(singleResult: false);

   IAsyncEnumerable<TResult>
   AsAsyncEnumerable(bool singleResult) =>
      AsyncMapTyped(singleResult);

   /// <inheritdoc cref="SqlSet.FirstAsync(CancellationToken)"/>

   public new async ValueTask<TResult>
   FirstAsync(CancellationToken cancellationToken = default) {

      return await Take(1)
         .AsAsyncEnumerable(singleResult: true)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.FirstAsync(String, CancellationToken)"/>

   public new async ValueTask<TResult>
   FirstAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.FirstAsync(OperatorStringHandler, CancellationToken)"/>

   public new async ValueTask<TResult>
   FirstAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .FirstAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.FirstOrDefaultAsync(CancellationToken)"/>

   public new async ValueTask<TResult?>
   FirstOrDefaultAsync(CancellationToken cancellationToken = default) {

      return await Take(1)
         .AsAsyncEnumerable(singleResult: true)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.FirstOrDefaultAsync(String, CancellationToken)"/>

   public new async ValueTask<TResult?>
   FirstOrDefaultAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.FirstOrDefaultAsync(OperatorStringHandler, CancellationToken)"/>

   public new async ValueTask<TResult?>
   FirstOrDefaultAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .FirstOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <summary>
   /// Returns an async enumerator that iterates through the set.
   /// </summary>
   /// <returns>A <see cref="IAsyncEnumerator&lt;TResult>"/> for the set.</returns>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public new IAsyncEnumerator<TResult>
   GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
      AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);

   /// <inheritdoc cref="SqlSet.SingleAsync(CancellationToken)"/>

   public new async ValueTask<TResult>
   SingleAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable(singleResult: true)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.SingleAsync(String, CancellationToken)"/>

   public new async ValueTask<TResult>
   SingleAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.SingleAsync(OperatorStringHandler, CancellationToken)"/>

   public new async ValueTask<TResult>
   SingleAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .SingleAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.SingleOrDefaultAsync(CancellationToken)"/>

   public new async ValueTask<TResult?>
   SingleOrDefaultAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable(singleResult: true)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.SingleOrDefaultAsync(String, CancellationToken)"/>

   public new async ValueTask<TResult?>
   SingleOrDefaultAsync(string predicate, CancellationToken cancellationToken = default) {

      return await Where(predicate)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.SingleOrDefaultAsync(OperatorStringHandler, CancellationToken)"/>

   public new async ValueTask<TResult?>
   SingleOrDefaultAsync(OperatorStringHandler predicate, CancellationToken cancellationToken = default) {

      return await Where(ref predicate)
         .SingleOrDefaultAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="SqlSet.ToArrayAsync(CancellationToken)"/>

   public new async ValueTask<TResult[]>
   ToArrayAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable()
         .ToArrayAsync(cancellationToken)
         .ConfigureAwait(false);
   }

   /// <inheritdoc cref="ToList()"/>
   /// <inheritdoc cref="SqlSet.AnyAsync(CancellationToken)" path="param"/>

   public new async ValueTask<List<TResult>>
   ToListAsync(CancellationToken cancellationToken = default) {

      return await AsAsyncEnumerable()
         .ToListAsync(cancellationToken)
         .ConfigureAwait(false);
   }
}

partial interface ISqlSet<TSqlSet, TSource> {

   ValueTask<bool>
   AllAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<bool>
   AllAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<bool>
   AnyAsync(CancellationToken cancellationToken);

   ValueTask<bool>
   AnyAsync(string predicate, CancellationToken cancellationToken);

   IAsyncEnumerable<TSource>
   AsAsyncEnumerable();

   ValueTask<int>
   CountAsync(CancellationToken cancellationToken);

   ValueTask<int>
   CountAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<int>
   CountAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<TSource>
   FirstAsync(CancellationToken cancellationToken);

   ValueTask<TSource>
   FirstAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<TSource>
   FirstAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<TSource?>
   FirstOrDefaultAsync(CancellationToken cancellationToken);

   ValueTask<TSource?>
   FirstOrDefaultAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<TSource?>
   FirstOrDefaultAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   IAsyncEnumerator<TSource>
   GetAsyncEnumerator(CancellationToken cancellationToken);

   ValueTask<long>
   LongCountAsync(CancellationToken cancellationToken);

   ValueTask<long>
   LongCountAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<long>
   LongCountAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<TSource>
   SingleAsync(CancellationToken cancellationToken);

   ValueTask<TSource>
   SingleAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<TSource>
   SingleAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<TSource?>
   SingleOrDefaultAsync(CancellationToken cancellationToken);

   ValueTask<TSource?>
   SingleOrDefaultAsync(string predicate, CancellationToken cancellationToken);

   ValueTask<TSource?>
   SingleOrDefaultAsync(SqlSet.OperatorStringHandler predicate, CancellationToken cancellationToken);

   ValueTask<TSource[]>
   ToArrayAsync(CancellationToken cancellationToken);

   ValueTask<List<TSource>>
   ToListAsync(CancellationToken cancellationToken);
}
