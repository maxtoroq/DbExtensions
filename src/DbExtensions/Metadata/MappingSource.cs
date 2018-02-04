// Copyright 2016-2018 Max Toro Q.
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

#region Based on code from .NET Framework
#endregion

using System;
using System.Collections.Generic;
using System.Threading;

namespace DbExtensions.Metadata {

   /// <summary>
   /// Represents a source for mapping information.
   /// </summary>

   internal abstract class MappingSource {

      MetaModel primaryModel;
      ReaderWriterLock rwlock;
      Dictionary<Type, MetaModel> secondaryModels;

      /// <summary>
      /// Gets the MetaModel representing a DataContext and all it's 
      /// accessible tables, functions and entities.
      /// </summary>

      public MetaModel GetModel(Type dataContextType) {

         if (dataContextType == null) throw Error.ArgumentNull(nameof(dataContextType));

         MetaModel model = null;

         if (this.primaryModel == null) {
            model = CreateModel(dataContextType);
            Interlocked.CompareExchange<MetaModel>(ref this.primaryModel, model, null);
         }

         // if the primary one matches, use it!

         if (this.primaryModel.ContextType == dataContextType) {
            return this.primaryModel;
         }

         // the rest of this only happens if you are using the mapping source for
         // more than one context type

         // build a map if one is not already defined

         if (this.secondaryModels == null) {
            Interlocked.CompareExchange<Dictionary<Type, MetaModel>>(ref this.secondaryModels, new Dictionary<Type, MetaModel>(), null);
         }

         // if we haven't created a read/writer lock, make one now

         if (this.rwlock == null) {
            Interlocked.CompareExchange<ReaderWriterLock>(ref this.rwlock, new ReaderWriterLock(), null);
         }

         // lock the map and look inside

         MetaModel foundModel;
         this.rwlock.AcquireReaderLock(Timeout.Infinite);

         try {
            if (this.secondaryModels.TryGetValue(dataContextType, out foundModel)) {
               return foundModel;
            }
         } finally {
            this.rwlock.ReleaseReaderLock();
         }

         // if it wasn't found, lock for write and try again

         this.rwlock.AcquireWriterLock(Timeout.Infinite);

         try {

            if (this.secondaryModels.TryGetValue(dataContextType, out foundModel)) {
               return foundModel;
            }

            if (model == null) {
               model = CreateModel(dataContextType);
            }

            this.secondaryModels.Add(dataContextType, model);

         } finally {
            this.rwlock.ReleaseWriterLock();
         }

         return model;
      }

      /// <summary>
      /// Creates a new instance of a MetaModel.  This method is called by GetModel().
      /// Override this method when defining a new type of MappingSource.
      /// </summary>
      /// <param name="dataContextType"></param>
      /// <returns></returns>

      protected abstract MetaModel CreateModel(Type dataContextType);
   }

   /// <summary>
   /// A mapping source that uses attributes on the context to create the mapping model.
   /// </summary>

   internal sealed class AttributeMappingSource : MappingSource {

      public AttributeMappingSource() { }

      protected override MetaModel CreateModel(Type dataContextType) {

         if (dataContextType == null) throw Error.ArgumentNull(nameof(dataContextType));

         return new AttributedMetaModel(this, dataContextType);
      }
   }
}
