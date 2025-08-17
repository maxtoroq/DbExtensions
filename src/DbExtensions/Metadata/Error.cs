// Copyright 2016-2022 Max Toro Q.
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

namespace DbExtensions.Metadata;

static class Error {

   internal static Exception
   ArgumentNull(string paramName) {
      return new ArgumentNullException(paramName);
   }

   internal static Exception
   ArgumentOutOfRange(string paramName) {
      return new ArgumentOutOfRangeException(paramName);
   }

   internal static Exception
   InvalidFieldInfo(object p0, object p1, object p2) {
      return new ArgumentException($"Could not create FieldAccessor&lt;{p0},{p1}&gt; from FieldInfo '{p2}'.");
   }

   internal static Exception
   CouldNotCreateAccessorToProperty(object p0, object p1, object p2) {
      return new ArgumentException($"Could not create PropertyAccessor&lt;{p0},{p1}&gt; to {p2}.");
   }

   internal static Exception
   UnableToAssignValueToReadonlyProperty(object p0) {
      return new InvalidOperationException($"Unable to assign value to read only property '{p0}'.");
   }

   internal static Exception
   NoDiscriminatorFound(object p0) {
      return new InvalidOperationException($"The inheritance type '{p0}' does not declare a discriminator column.");
   }

   internal static Exception
   InheritanceTypeDoesNotDeriveFromRoot(object p0, object p1) {
      return new InvalidOperationException($"Inheritance type '{p0}' does not derive from inheritance root type '{p1}'.");
   }

   internal static Exception
   AbstractClassAssignInheritanceDiscriminator(object p0) {
      return new InvalidOperationException($"Abstract class '{p0}' should not be assigned an inheritance discriminator key.");
   }

   internal static Exception
   CannotGetInheritanceDefaultFromNonInheritanceClass() {
      return new InvalidOperationException("Mapping Problem: Cannot get inheritance default from class not mapped into an inheritance hierarchy.");
   }

   internal static Exception
   InheritanceCodeMayNotBeNull() {
      return new InvalidOperationException("Inheritance code value may not be null.");
   }

   internal static Exception
   InheritanceTypeHasMultipleDiscriminators(object p0) {
      return new InvalidOperationException($"The inherited type '{p0}' cannot have multiple discriminator key values.");
   }

   internal static Exception
   InheritanceCodeUsedForMultipleTypes(object p0) {
      return new InvalidOperationException($"The inheritance code '{p0}' is used for multiple types.");
   }

   internal static Exception
   InheritanceTypeHasMultipleDefaults(object p0) {
      return new InvalidOperationException($"The inheritance type '{p0}' has multiple defaults.");
   }

   internal static Exception
   InheritanceHierarchyDoesNotDefineDefault(object p0) {
      return new InvalidOperationException($"The inheritance hierarchy rooted at '{p0}' does not define a default.");
   }

   internal static Exception
   InheritanceSubTypeIsAlsoRoot(object p0) {
      return new InvalidOperationException($"The inheritance subtype '{p0}' is also declared as a root type.");
   }

   internal static Exception
   NonInheritanceClassHasDiscriminator(object p0) {
      return new InvalidOperationException($"The inheritance type '{p0}' has a discriminator but is not part of a mapped inheritance hierarchy.");
   }

   internal static Exception
   MemberMappedMoreThanOnce(object p0) {
      return new InvalidOperationException($"The member '{p0}' is mapped more than once.");
   }

   internal static Exception
   BadStorageProperty(object p0, object p1, object p2) {
      return new InvalidOperationException($"Bad Storage property: '{p0}' on member '{p1}.{p2}'.");
   }

   internal static Exception
   IncorrectAutoSyncSpecification(object p0) {
      return new InvalidOperationException($"Incorrect AutoSync specification for member '{p0}'.");
   }

   internal static Exception
   BadKeyMember(object p0, object p1, object p2) {
      return new InvalidOperationException($"Could not find key member '{p0}' of key '{p1}' on type '{p2}'. The key may be wrong or the field or property on '{p2}' has changed names.");
   }

   internal static Exception
   UnableToResolveRootForType(object p0) {
      return new InvalidOperationException($"Mapping Problem: Unable to resolve root for type '{p0}'.");
   }

   internal static Exception
   CouldNotFindTypeFromMapping(object p0) {
      return new InvalidOperationException($"Mapping Problem: Cannot find type '{p0}' from mapping.");
   }

   internal static Exception
   TwoMembersMarkedAsPrimaryKeyAndDBGenerated(object p0, object p1) {
      return new InvalidOperationException($"Members '{p0}' and '{p1}' both marked as IsPrimaryKey and IsDbGenerated.");
   }

   internal static Exception
   TwoMembersMarkedAsRowVersion(object p0, object p1) {
      return new InvalidOperationException($"Members '{p0}' and '{p1}' both marked as row version.");
   }

   internal static Exception
   TwoMembersMarkedAsInheritanceDiscriminator(object p0, object p1) {
      return new InvalidOperationException($"Members '{p0}' and '{p1}' both marked as inheritance discriminator.");
   }

   internal static Exception
   CouldNotFindRuntimeTypeForMapping(object p0) {
      return new InvalidOperationException($"Mapping Problem: Cannot find runtime type for type mapping '{p0}'.");
   }

   internal static Exception
   UnexpectedNull(object p0) {
      return new InvalidOperationException($"Unexpected null '{p0}'.");
   }

   internal static Exception
   InvalidDeleteOnNullSpecification(object p0) {
      return new InvalidOperationException($"Invalid DeleteOnNull specification for member '{p0}'. DeleteOnNull can only be true for singleton association members mapped to non-nullable foreign key columns.");
   }

   internal static Exception
   MappedMemberHadNoCorrespondingMemberInType(object p0, object p1) {
      return new NotSupportedException($"The column or association '{p0}' in the mapping had no corresponding member in type '{p1}'. Mapping members from above root type is not supported.");
   }

   internal static Exception
   DiscriminatorClrTypeNotSupported(object p0, object p1, object p2) {
      return new NotSupportedException($"Discriminator '{p0}.{p1}' may not be type '{p2}'.");
   }

   internal static Exception
   IdentityClrTypeNotSupported(object p0, object p1, object p2) {
      return new NotSupportedException($"Invalid type mapping for Identity member '{p0}.{p1}'. Type '{p2}' is not supported for identity members.");
   }

   internal static Exception
   PrimaryKeyInSubTypeNotSupported(object p0, object p1) {
      return new NotSupportedException($"The subtype '{p0}' cannot contain the primary key member '{p1}'.");
   }

   internal static Exception
   MismatchedThisKeyOtherKey(object p0, object p1) {
      return new InvalidOperationException($"The number of ThisKey columns is different from the number of OtherKey columns for the association property '{p0}' in the type '{p1}'.");
   }

   internal static Exception
   MappingOfInterfacesMemberIsNotSupported(object p0, object p1) {
      return new NotSupportedException($"The mapping of interface member {p0}.{p1} is not supported.");
   }

   internal static Exception
   UnmappedClassMember(object p0, object p1) {
      return new InvalidOperationException($"Class member {p0}.{p1} is unmapped.");
   }
}
