Imports System
Imports System.Data.Linq.Mapping

Namespace Northwind

   ''' <summary>
   ''' Unlike AttributeMappingSource, XmlMappingSource crashes when you call GetModel and
   ''' pass a Type that doesn't inherit from DataContext. The workaround is to define a DataContext
   ''' type in the same namespace as your entities.
   ''' </summary>
   Public NotInheritable Class ForXmlMappingSourceOnlyDataContext
      Inherits System.Data.Linq.DataContext

      Public Sub New()
         MyBase.New(CStr(Nothing), Nothing)
         Throw New InvalidOperationException
      End Sub
   End Class

End Namespace
