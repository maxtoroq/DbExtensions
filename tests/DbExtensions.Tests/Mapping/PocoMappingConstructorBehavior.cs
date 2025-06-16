using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DbExtensions.Tests.Mapping {

   using static TestUtil;

   [TestFixture]
   public class PocoMappingConstructorBehavior {

      [Test]
      public void Map_Constructor_Named_Arguments() {

         var data = new Dictionary<string, object> {
            { "name", "John" },
            { "id", 5 }
         };

         var db = MockQuery(data);

         var value = db.Map<Poco.Constructor.NamedArguments._Basic>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("John", value.nameArg);
         Assert.AreEqual(5, value.idArg);
      }

      [Test]
      public void Map_Constructor_Named_Arguments_Matching_Properties() {

         var data = new Dictionary<string, object> {
            { "name", "John" },
            { "id", 5 }
         };

         var db = MockQuery(data);

         var value = db.Map<Poco.Constructor.NamedArguments._ParamsMatchProperties>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("John", value.nameArg);
         Assert.AreEqual(5, value.idArg);
         Assert.IsNull(value.name);
         Assert.AreEqual(0, value.id);
      }

      [Test]
      public void Map_Constructor_Named_Arguments_Missing_Arg() {

         var data = new Dictionary<string, object> {
            { "name", "John" },
            { "id", 5 }
         };

         var db = MockQuery(data);

         var results = db.Map<Poco.Constructor.NamedArguments._MissingArg>(SQL
            .SELECT("NULL"));

         Assert.Throws<InvalidOperationException>(() => results.Single());
      }

      [Test]
      public void Map_Constructor_Named_Arguments_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "prop$name", "John" },
            { "prop$id", 5 }
         };

         var db = MockQuery(data);

         var value = db.Map<Poco.Constructor.NamedArguments._ComplexProperty>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("John", value.prop.nameArg);
         Assert.AreEqual(5, value.prop.idArg);
      }

      [Test]
      public void Map_Constructor_Named_Arguments_Complex_Argument() {

         var data = new Dictionary<string, object> {
            { "0$name", "John" },
            { "0$id", 5 }
         };

         var db = MockQuery(data);

         var value = db.Map<Poco.Constructor.NamedArguments._ComplexArgument>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("John", value.valueArg.nameArg);
         Assert.AreEqual(5, value.valueArg.idArg);
      }

      [Test]
      public void Map_Constructor_Named_Arguments_Nested() {

         var data = new Dictionary<string, object> {
            { "value$name", "John" },
            { "value$id", 5 }
         };

         var db = MockQuery(data);

         var value = db.Map<Poco.Constructor.NamedArguments._Nested>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("John", value.valueArg.nameArg);
         Assert.AreEqual(5, value.valueArg.idArg);
      }
   }

   namespace Poco.Constructor.NamedArguments {

      class _Basic {

         public readonly int idArg;
         public readonly string nameArg;

         public _Basic(int id, string name) {
            this.idArg = id;
            this.nameArg = name;
         }
      }

      class _ParamsMatchProperties {

         public readonly int idArg;
         public readonly string nameArg;

         public int id { get; set; }
         public string name { get; set; }

         public _ParamsMatchProperties(int id, string name) {
            this.idArg = id;
            this.nameArg = name;
         }
      }

      class _MissingArg {

         public _MissingArg(int id, string name, DateTime dob) { }
      }

      class _ComplexProperty {

         public _ComplexPropertyType prop { get; set; }

         public class _ComplexPropertyType {

            public readonly int idArg;
            public readonly string nameArg;

            public _ComplexPropertyType(int id, string name) {
               this.idArg = id;
               this.nameArg = name;
            }
         }
      }

      class _ComplexArgument {

         public readonly _ComplexArgumentType valueArg;

         public _ComplexArgument(_ComplexArgumentType value) {
            this.valueArg = value;
         }

         public class _ComplexArgumentType {

            public readonly int idArg;
            public readonly string nameArg;

            public _ComplexArgumentType(int id, string name) {
               this.idArg = id;
               this.nameArg = name;
            }
         }
      }

      class _Nested {

         public readonly _NestedType valueArg;

         public _Nested(_NestedType value) {
            this.valueArg = value;
         }

         public class _NestedType {

            public readonly int idArg;
            public readonly string nameArg;

            public _NestedType(int id, string name) {
               this.idArg = id;
               this.nameArg = name;
            }
         }
      }
   }
}
