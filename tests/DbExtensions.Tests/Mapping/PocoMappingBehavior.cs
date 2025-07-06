using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DbExtensions.Tests.Mapping.Poco {

   using static TestUtil;

   [TestFixture(false)]
   [TestFixture(true)]
   public class PocoMappingBehavior(bool useCompiledMapping) {

      [Test]
      public void Map_Property() {

         var data = new Dictionary<string, object> {
            { "Foo", "a" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("a", value.Foo);
      }

      [Test]
      public void Map_Null_Property() {

         var data = new Dictionary<string, object> {
            { "Foo", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Null_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Foo);
      }

      [Test]
      public void Map_Object() {

         var data = new Dictionary<string, object> {
            { "Foo", "a" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Object>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("a", value.Foo);
      }

      [Test]
      public void Map_Property_Private_Setter() {

         var data = new Dictionary<string, object> {
            { "Foo", "a" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Property_Private_Setter>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual("a", value.Foo);
      }

      [Test]
      public void Ignore_Unmapped_Property() {

         var data = new Dictionary<string, object> {
            { "Foo", "a" },
            { "Bar", "b" }
         };

         var db = MockQuery(useCompiledMapping, data);

         _ = db.Map<PocoMapping.Ignore_Unmapped_Property>(SQL
            .SELECT("NULL"))
            .Single();
      }

      [Test]
      public void Map_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "Bar$Foo", "b" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNotNull(value.Bar);
         Assert.AreEqual("b", value.Bar.Foo);
      }

      [Test]
      public void Map_Null_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "Bar", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Null_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Bar);
      }

      [Test]
      public void Map_Complex_Property_To_Null_When_All_Subproperties_Are_Null() {

         var data = new Dictionary<string, object> {
            { "Nested$Foo", null },
            { "Nested$Bar", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Complex_Property_To_Null_When_All_Subproperties_Are_Null>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Nested);
      }

      [Test]
      public void Load_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "Foo$B", 2 }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Load_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual(1, value.Foo.A);
      }

      [Test]
      public void Map_Constructor() {

         var data = new Dictionary<string, object> {
            { "1", 5 },
            { "2", "b" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual(5, value.Foo);
         Assert.AreEqual("b", value.Bar);
      }

      [Test]
      public void Fail_When_Duplicate_Arguments() {

         var data = new KeyValuePair<string, object>[] {
            new("1", "http://example.com"),
            new("1", "http://example.com"),
         };

         var db = MockQuery(useCompiledMapping, data);

         var results = db.Map<Uri>(SQL
            .SELECT("NULL"));

         Assert.Throws<InvalidOperationException>(() => results.Single());
      }

      [Test]
      public void Fail_When_Multiple_Constructors_With_Same_Number_Of_Parameters() {

         var data = new Dictionary<string, object> {
            { "1", "http://example.com" },
            { "2", 1 }
         };

         var db = MockQuery(useCompiledMapping, data);

         var results = db.Map<Uri>(SQL
            .SELECT("NULL"));

         Assert.Throws<InvalidOperationException>(() => results.Single());
      }

      [Test]
      public void Map_Constructor_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "Url$1", "http://example.com" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNotNull(value.Url);
         Assert.AreEqual("http://example.com", value.Url.OriginalString);
      }

      [Test]
      public void Map_Constructor_Nullable_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "Foo1$1", 1 },
            { "Foo2", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor_Nullable_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual(1, value.Foo1.Value.A);
         Assert.IsNull(value.Foo2);
      }

      [Test]
      public void Map_Constructor_Complex_Property_To_Null_When_All_Arguments_And_Subproperties_Are_Null() {

         var data = new Dictionary<string, object> {
            { "Foo$1", null },
            { "Foo$Foo", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor_Complex_Property_To_Null_When_All_Arguments_And_Subproperties_Are_Null>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Foo);
      }

      [Test]
      public void Map_Constructor_Complex_Argument_To_Null_When_All_Arguments_And_Subproperties_Are_Null() {

         var data = new Dictionary<string, object> {
            { "1$1", null },
            { "1$Foo", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor_Complex_Argument_To_Null_When_All_Arguments_And_Subproperties_Are_Null>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Foo);
      }

      [Test]
      public void Load_Constructor_Complex_Property() {

         var data = new Dictionary<string, object> {
            { "1", 1 },
            { "Foo$A", 2 },
            { "Foo$Bar$B", 2 }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Load_Constructor_Complex_Property>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual(1, value.Foo.Bar.A);
      }

      [Test]
      public void Load_Constructor_Complex_Argument() {

         var data = new Dictionary<string, object> {
            { "1$A", 2 },
            { "1$Bar$B", 2 }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Load_Constructor_Complex_Argument>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.AreEqual(1, value.Foo.Bar.A);
      }

      [Test]
      public void Map_Null_Constructor_Argument() {

         var data = new Dictionary<string, object> {
            { "1", 1 },
            { "2", null }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Null_Constructor_Argument>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNull(value.Url);
      }

      [Test]
      public void Map_Constructor_Nested() {

         var data = new Dictionary<string, object> {
            { "1$1", 5 },
            { "1$2", "b" }
         };

         var db = MockQuery(useCompiledMapping, data);

         var value = db.Map<PocoMapping.Map_Constructor_Nested>(SQL
            .SELECT("NULL"))
            .Single();

         Assert.IsNotNull(value.Nested);
         Assert.AreEqual(5, value.Nested.Foo);
         Assert.AreEqual("b", value.Nested.Bar);
      }
   }

   namespace PocoMapping {

      class Map_Property {
         public string Foo { get; set; }
      }

      class Map_Null_Property {
         public string Foo { get; set; }
      }

      class Map_Object {
         public string Foo { get; set; }
      }

      class Map_Property_Private_Setter {
         public string Foo { get; private set; }
      }

      class Ignore_Unmapped_Property {
         public string Foo { get; set; }
      }

      class Map_Complex_Property {

         public string Foo { get; set; }
         public Map_Complex_Property Bar { get; set; }
      }

      class Map_Null_Complex_Property {

         public string Foo { get; set; }
         public Map_Null_Complex_Property Bar { get; set; }
      }

      class Map_Complex_Property_To_Null_When_All_Subproperties_Are_Null {

         public string Foo { get; set; }
         public string Bar { get; set; }
         public Map_Complex_Property_To_Null_When_All_Subproperties_Are_Null Nested { get; set; }
      }

      class Load_Complex_Property {

         public FooClass Foo { get; set; }

         public Load_Complex_Property() {
            this.Foo = new FooClass {
               A = 1
            };
         }

         public class FooClass {
            public int A { get; set; }
            public int B { get; set; }
         }
      }

      class Map_Constructor {

         public int Foo { get; }

         public string Bar { get; }

         public Map_Constructor(int foo, string bar) {
            this.Foo = foo;
            this.Bar = bar;
         }
      }

      class Map_Constructor_Complex_Property {
         public Uri Url { get; set; }
      }

      class Map_Constructor_Nullable_Complex_Property {

         public Foo? Foo1 { get; set; }
         public Foo? Foo2 { get; set; }

         public struct Foo {

            public readonly int A;

            public Foo(int a) {
               this.A = a;
            }
         }
      }

      class Map_Constructor_Complex_Property_To_Null_When_All_Arguments_And_Subproperties_Are_Null {

         public FooClass Foo { get; set; }

         public class FooClass {

            public string Foo { get; set; }

            public FooClass(int? id) { }
         }
      }

      class Map_Constructor_Complex_Argument_To_Null_When_All_Arguments_And_Subproperties_Are_Null {

         public readonly FooClass Foo;

         public Map_Constructor_Complex_Argument_To_Null_When_All_Arguments_And_Subproperties_Are_Null(FooClass foo) {
            this.Foo = foo;
         }

         public class FooClass {

            public string Foo { get; set; }

            public FooClass(int? id) { }
         }
      }

      class Load_Constructor_Complex_Property {

         public readonly int A;
         public FooClass Foo { get; set; }

         public Load_Constructor_Complex_Property(int a) {
            this.A = a;
         }

         public class FooClass {

            public int A { get; set; }
            public BarClass Bar { get; set; }

            public FooClass() {
               this.Bar = new BarClass {
                  A = 1
               };
            }

            public class BarClass {
               public int A { get; set; }
               public int B { get; set; }
            }
         }
      }

      class Load_Constructor_Complex_Argument {

         public readonly FooClass Foo;
         public int A { get; set; }

         public Load_Constructor_Complex_Argument(FooClass foo) {
            this.Foo = foo;
         }

         public class FooClass {

            public int A { get; set; }
            public BarClass Bar { get; set; }

            public FooClass() {
               this.Bar = new BarClass {
                  A = 1
               };
            }

            public class BarClass {
               public int A { get; set; }
               public int B { get; set; }
            }
         }
      }

      class Map_Null_Constructor_Argument {

         public readonly int Id;
         public readonly Uri Url;

         public Map_Null_Constructor_Argument(int id) {
            this.Id = id;
         }

         public Map_Null_Constructor_Argument(int id, Uri url)
            : this(id) {

            this.Url = url;
         }
      }

      class Map_Constructor_Nested {

         public NestedClass Nested { get; }

         public Map_Constructor_Nested(NestedClass nested) {
            this.Nested = nested;
         }

         public class NestedClass {

            public int Foo { get; }

            public string Bar { get; }

            public NestedClass(int foo, string bar) {
               this.Foo = foo;
               this.Bar = bar;
            }
         }
      }
   }
}
