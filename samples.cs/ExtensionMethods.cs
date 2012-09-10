using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using DbExtensions;
using Samples.CSharp.Northwind;

namespace Samples.CSharp {

   public class ExtensionMethodsSamples {

      readonly DbConnection connection;
      readonly TextWriter log;

      public ExtensionMethodsSamples(string connectionString, TextWriter log) {
         this.connection = DbFactory.CreateConnection(connectionString);
         this.log = log;
      }

      public IEnumerable<Product> StaticQuery() { 
      
         return connection
            .CreateCommand("SELECT * FROM Products WHERE ProductID = {0}", 1)
            .Map<Product>(log);
      }

      public IEnumerable<Product> SelectWithManyToOne() {

         var query = SQL
            .SELECT("p.ProductID, p.ProductName, p.CategoryID, s.SupplierID, '' AS MissingProperty")
            ._("c.CategoryID AS Category$CategoryID, c.CategoryName AS Category$CategoryName")
            ._("s.SupplierID AS Supplier$SupplierID, s.CompanyName AS Supplier$CompanyName")
            .FROM("Products p")
            .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID")
            .LEFT_JOIN("Suppliers s ON p.SupplierID = s.SupplierID")
            .WHERE("p.ProductID < {0}", 3);

         return connection.Map<Product>(query, log);
      }

      public IEnumerable<EmployeeTerritory> SelectWithManyToOneNested() {

         var query = SQL
            .SELECT("et.EmployeeID, et.TerritoryID")
            ._("t.TerritoryID AS Territory$TerritoryID, t.TerritoryDescription AS Territory$TerritoryDescription, t.RegionID AS Territory$RegionID")
            ._("r.RegionID AS Territory$Region$RegionID, r.RegionDescription AS Territory$Region$RegionDescription")
            .FROM("EmployeeTerritories et")
            .LEFT_JOIN("Territories t ON et.TerritoryID = t.TerritoryID")
            .LEFT_JOIN("Region r ON t.RegionID = r.RegionID")
            .WHERE("et.EmployeeID < {0}", 3);

         return connection.Map<EmployeeTerritory>(query, log);
      }

      public IEnumerable AnnonymousType() {

         var query = SQL
            .SELECT("p.ProductID, p.ProductName")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3);

         return connection.Map(query, r => new {
            ProductID = r.GetInt32(0),
            ProductName = r.GetStringOrNull(1)
         }, log);
      }

      public IEnumerable<Product> MappingCalculatedColumn() {

         var query = SQL
            .SELECT("p.ProductID, (p.UnitPrice * p.UnitsInStock) AS ValueInStock")
            .FROM("Products p")
            .WHERE("p.ProductID < {0}", 3)
            .ORDER_BY("ValueInStock");

         return connection.Map<Product>(query, log);
      }

      public object Exists() {

         bool result = connection.Exists(SQL
            .SELECT("ProductID")
            .FROM("Products")
            .WHERE("ProductID = 1"));

         return result;
      }

      public void Xml() {

         var query = SQL
            .SELECT("p.ProductID, p.ProductName")
            ._("c.CategoryID AS Category$CategoryID")
            ._("c.CategoryName AS Category$CategoryName")
            ._("p.UnitPrice")
            .FROM("Products p")
            .LEFT_JOIN("Categories c ON p.CategoryID = c.CategoryID")
            .WHERE("ProductID < {0}", 3);

         using (var reader = connection.Set(query, log).AsXml(
            collectionName: new XmlQualifiedName("Products", "http://example.com/ns/Store"),
            itemName: "Product",
            nullHandling: XmlNullHandling.IncludeNilAttribute,
            typeAnnotation: XmlTypeAnnotation.XmlSchema)) {
            
            using (var writer = XmlWriter.Create(log, new XmlWriterSettings { Indent = true })) {
               while (!reader.EOF)
                  writer.WriteNode(reader, defattr: true);
            }
         }
      }
   }
}
