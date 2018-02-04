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

namespace DbExtensions.Metadata {

   using static String;

   static class Error {

      internal static Exception ArgumentNull(string paramName) {
         return new ArgumentNullException(paramName);
      }

      internal static Exception ArgumentOutOfRange(string paramName) {
         return new ArgumentOutOfRangeException(paramName);
      }

      internal static Exception InvalidFieldInfo(object p0, object p1, object p2) {
         return new ArgumentException(Format("Could not create FieldAccessor&lt;{0},{1}&gt; from FieldInfo '{2}'.", p0, p1, p2));
      }

      internal static Exception CouldNotCreateAccessorToProperty(object p0, object p1, object p2) {
         return new ArgumentException(Format("Could not create PropertyAccessor&lt;{0},{1}&gt; to {2}.", p0, p1, p2));
      }

      internal static Exception UnableToAssignValueToReadonlyProperty(object p0) {
         return new InvalidOperationException(Format("Unable to assign value to read only property '{0}'.", p0));
      }

      internal static Exception NoDiscriminatorFound(object p0) {
         return new InvalidOperationException(Format("The inheritance type '{0}' does not declare a discriminator column.", p0));
      }

      internal static Exception InheritanceTypeDoesNotDeriveFromRoot(object p0, object p1) {
         return new InvalidOperationException(Format("Inheritance type '{0}' does not derive from inheritance root type '{1}'.", p0, p1));
      }

      internal static Exception AbstractClassAssignInheritanceDiscriminator(object p0) {
         return new InvalidOperationException(Format("Abstract class '{0}' should not be assigned an inheritance discriminator key.", p0));
      }

      internal static Exception CannotGetInheritanceDefaultFromNonInheritanceClass() {
         return new InvalidOperationException("Mapping Problem: Cannot get inheritance default from class not mapped into an inheritance hierarchy.");
      }

      internal static Exception InheritanceCodeMayNotBeNull() {
         return new InvalidOperationException("Inheritance code value may not be null.");
      }

      internal static Exception InheritanceTypeHasMultipleDiscriminators(object p0) {
         return new InvalidOperationException(Format("The inherited type '{0}' cannot have multiple discriminator key values.", p0));
      }

      internal static Exception InheritanceCodeUsedForMultipleTypes(object p0) {
         return new InvalidOperationException(Format("The inheritance code '{0}' is used for multiple types.", p0));
      }

      internal static Exception InheritanceTypeHasMultipleDefaults(object p0) {
         return new InvalidOperationException(Format("The inheritance type '{0}' has multiple defaults.", p0));
      }

      internal static Exception InheritanceHierarchyDoesNotDefineDefault(object p0) {
         return new InvalidOperationException(Format("The inheritance hierarchy rooted at '{0}' does not define a default.", p0));
      }

      internal static Exception InheritanceSubTypeIsAlsoRoot(object p0) {
         return new InvalidOperationException(Format("The inheritance subtype '{0}' is also declared as a root type.", p0));
      }

      internal static Exception NonInheritanceClassHasDiscriminator(object p0) {
         return new InvalidOperationException(Format("The inheritance type '{0}' has a discriminator but is not part of a mapped inheritance hierarchy.", p0));
      }

      internal static Exception MemberMappedMoreThanOnce(object p0) {
         return new InvalidOperationException(Format("The member '{0}' is mapped more than once.", p0));
      }

      internal static Exception BadStorageProperty(object p0, object p1, object p2) {
         return new InvalidOperationException(Format("Bad Storage property: '{0}' on member '{1}.{2}'.", p0, p1, p2));
      }

      internal static Exception IncorrectAutoSyncSpecification(object p0) {
         return new InvalidOperationException(Format("Incorrect AutoSync specification for member '{0}'.", p0));
      }

      internal static Exception BadKeyMember(object p0, object p1, object p2) {
         return new InvalidOperationException(Format("Could not find key member '{0}' of key '{1}' on type '{2}'. The key may be wrong or the field or property on '{2}' has changed names.", p0, p1, p2));
      }

      internal static Exception UnableToResolveRootForType(object p0) {
         return new InvalidOperationException(Format("Mapping Problem: Unable to resolve root for type '{0}'.", p0));
      }

      internal static Exception CouldNotFindTypeFromMapping(object p0) {
         return new InvalidOperationException(Format("Mapping Problem: Cannot find type '{0}' from mapping.", p0));
      }

      internal static Exception TwoMembersMarkedAsPrimaryKeyAndDBGenerated(object p0, object p1) {
         return new InvalidOperationException(Format("Members '{0}' and '{1}' both marked as IsPrimaryKey and IsDbGenerated.", p0, p1));
      }

      internal static Exception TwoMembersMarkedAsRowVersion(object p0, object p1) {
         return new InvalidOperationException(Format("Members '{0}' and '{1}' both marked as row version.", p0, p1));
      }

      internal static Exception TwoMembersMarkedAsInheritanceDiscriminator(object p0, object p1) {
         return new InvalidOperationException(Format("Members '{0}' and '{1}' both marked as inheritance discriminator.", p0, p1));
      }

      internal static Exception CouldNotFindRuntimeTypeForMapping(object p0) {
         return new InvalidOperationException(Format("Mapping Problem: Cannot find runtime type for type mapping '{0}'.", p0));
      }

      internal static Exception UnexpectedNull(object p0) {
         return new InvalidOperationException(Format("Unexpected null '{0}'.", p0));
      }

      internal static Exception InvalidDeleteOnNullSpecification(object p0) {
         return new InvalidOperationException(Format("Invalid DeleteOnNull specification for member '{0}'. DeleteOnNull can only be true for singleton association members mapped to non-nullable foreign key columns.", p0));
      }

      internal static Exception MappedMemberHadNoCorrespondingMemberInType(object p0, object p1) {
         return new NotSupportedException(Format("The column or association '{0}' in the mapping had no corresponding member in type '{1}'. Mapping members from above root type is not supported.", p0, p1));
      }

      internal static Exception DiscriminatorClrTypeNotSupported(object p0, object p1, object p2) {
         return new NotSupportedException(Format("Discriminator '{0}.{1}' may not be type '{2}'.", p0, p1, p2));
      }

      internal static Exception IdentityClrTypeNotSupported(object p0, object p1, object p2) {
         return new NotSupportedException(Format("Invalid type mapping for Identity member '{0}.{1}'.  Type '{2}' is not supported for identity members.", p0, p1, p2));
      }

      internal static Exception PrimaryKeyInSubTypeNotSupported(object p0, object p1) {
         return new NotSupportedException(Format("The subtype '{0}' cannot contain the primary key member '{1}'.", p0, p1));
      }

      internal static Exception MismatchedThisKeyOtherKey(object p0, object p1) {
         return new InvalidOperationException(Format("The number of ThisKey columns is different from the number of OtherKey columns for the association property '{0}' in the type '{1}'.", p0, p1));
      }

      internal static Exception MappingOfInterfacesMemberIsNotSupported(object p0, object p1) {
         return new NotSupportedException(Format("The mapping of interface member {0}.{1} is not supported.", p0, p1));
      }

      internal static Exception UnmappedClassMember(object p0, object p1) {
         return new InvalidOperationException(Format("Class member {0}.{1} is unmapped.", p0, p1));
      }
   }
}
