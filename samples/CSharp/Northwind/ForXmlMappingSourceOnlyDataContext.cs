using System;

namespace Samples.CSharp.Northwind {

   /// <summary>
   /// Unlike AttributeMappingSource, XmlMappingSource crashes when you call GetModel and
   /// pass a Type that doesn't inherit from DataContext. The workaround is to define a DataContext
   /// type in the same namespace as your entities.
   /// </summary>

   public sealed class ForXmlMappingSourceOnlyDataContext : System.Data.Linq.DataContext {
      private ForXmlMappingSourceOnlyDataContext()
         : base((string)null, null) {
         throw new System.InvalidOperationException();
      }
   }
}
