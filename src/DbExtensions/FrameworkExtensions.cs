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
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DbExtensions {

   static class FrameworkExtensions {

      public static string
      ToStringInvariant(this int value) =>
         value.ToString(CultureInfo.InvariantCulture);

      public static string
      ToStringInvariant(this uint value) =>
         value.ToString(CultureInfo.InvariantCulture);

#if NETFRAMEWORK
      public static bool
      TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value) {

         if (!dict.ContainsKey(key)) {
            dict.Add(key, value);
            return true;
         }

         return false;
      }
#endif

#if NET45
      public static TValue
      GetOrAdd<TKey, TValue, TArg>(this ConcurrentDictionary<TKey, TValue> dict, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument) =>
         dict.GetOrAdd(key, k => valueFactory.Invoke(k, factoryArgument));
#endif
   }

#if !NET5_0_OR_GREATER
   sealed class ReferenceEqualityComparer : IEqualityComparer<object>, IEqualityComparer {

      public static readonly ReferenceEqualityComparer
      Instance = new();

      public new bool
      Equals(object x, object y) =>
         Object.ReferenceEquals(x, y);

      public int
      GetHashCode(object obj) =>
         RuntimeHelpers.GetHashCode(obj);
   }
#endif
}