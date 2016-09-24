namespace Samples.FSharp.Northwind

open System
open System.Collections.ObjectModel
open DbExtensions

[<AllowNullLiteral>]
[<Table(Name = "Categories")>]
type Category() =
   
   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val CategoryID = 0 with get,set

   [<Column>]
   member val CategoryName : string = null with get,set
   
   [<Column>]
   member val Description : string = null with get,set
   
   [<Column>]
   member val Picture : Byte[] = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Suppliers")>]
type Supplier() =
   
   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val SupplierID = 0 with get,set

   [<Column>]
   member val CompanyName : string = null with get,set

   [<Column>]
   member val ContactName : string = null with get,set

   [<Column>]
   member val ContactTitle : string = null with get,set

   [<Column>]
   member val Address : string = null with get,set

   [<Column>]
   member val City : string = null with get,set

   [<Column>]
   member val Region : string = null with get,set

   [<Column>]
   member val PostalCode : string = null with get,set

   [<Column>]
   member val Country : string = null with get,set

   [<Column>]
   member val Phone : string = null with get,set

   [<Column>]
   member val Fax : string = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Products")>]
type Product() =

   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val ProductID = 0 with get,set
   
   [<Column>]
   member val ProductName : string = null with get,set
   
   [<Column>]
   member val SupplierID = new Nullable<int>() with get,set
   
   [<Column>]
   member val CategoryID = new Nullable<int>() with get,set
   
   [<Column>]
   member val QuantityPerUnit : string = null with get,set
   
   [<Column>]
   member val UnitPrice = new Nullable<decimal>() with get,set
   
   [<Column>]
   member val UnitsInStock = new Nullable<Int16>() with get,set
   
   [<Column>]
   member val UnitsOnOrder = new Nullable<Int16>() with get,set
   
   [<Column>]
   member val ReorderLevel = new Nullable<Int16>() with get,set
   
   [<Column>]
   member val Discontinued = false with get,set

   [<Association(ThisKey = "CategoryID")>]
   member val Category : Category = null with get,set

   [<Association(ThisKey = "SupplierID")>]
   member val Supplier : Supplier = null with get,set

   member val ValueInStock = 0m with get,set

[<AllowNullLiteral>]
[<Table(Name = "Employees")>]
type Employee() =
   
   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val EmployeeID = 0 with get,set

   [<Column>]
   member val LastName : string = null with get,set
   
   [<Column>]
   member val FirstName : string = null with get,set
   
   [<Column>]
   member val Title : string = null with get,set
   
   [<Column>]
   member val TitleOfCourtesy : string = null with get,set
   
   [<Column>]
   member val BirthDate = new Nullable<DateTime>() with get,set
   
   [<Column>]
   member val HireDate = new Nullable<DateTime>() with get,set
   
   [<Column>]
   member val Address : string = null with get,set
   
   [<Column>]
   member val City : string = null with get,set
   
   [<Column>]
   member val Region : string = null with get,set
   
   [<Column>]
   member val PostalCode : string = null with get,set
   
   [<Column>]
   member val Country : string = null with get,set
   
   [<Column>]
   member val HomePhone : string = null with get,set
   
   [<Column>]
   member val Extension : string = null with get,set
   
   [<Column>]
   member val Photo : Byte[] = null with get,set
   
   [<Column>]
   member val Notes : string = null with get,set
   
   [<Column>]
   member val ReportsTo = new Nullable<int>() with get,set
   
   [<Column>]
   member val PhotoPath : string = null with get,set

   [<Association(ThisKey = "ReportsTo")>]
   member val ReportsToEmployee : Employee = null with get,set

[<AllowNullLiteral>]
[<Table>]
type Region() =

   [<Column(IsPrimaryKey = true)>]
   member val RegionID = 0 with get,set
   
   [<Column>]
   member val RegionDescription : string = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Territories")>]
type Territory() =

   [<Column(IsPrimaryKey = true)>]
   member val TerritoryID : string = null with get,set

   [<Column>]
   member val TerritoryDescription : string = null with get,set
   
   [<Column>]
   member val RegionID = 0 with get,set

   [<Association(ThisKey = "RegionID")>]
   member val Region : Region = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "EmployeeTerritories")>]
type EmployeeTerritory() =

   [<Column(IsPrimaryKey = true)>]
   member val EmployeeID = 0 with get,set
   
   [<Column(IsPrimaryKey = true)>]
   member val TerritoryID : string = null with get,set

   [<Association(ThisKey = "EmployeeID")>]
   member val Employee : Employee = null with get,set

   [<Association(ThisKey = "TerritoryID")>]
   member val Territory : Territory = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Customers")>]
type Customer() =

   [<Column(IsPrimaryKey = true)>]
   member val CustomerID = 0 with get,set

   [<Column>]
   member val CompanyName : string = null with get,set

   [<Column>]
   member val ContactName : string = null with get,set

   [<Column>]
   member val ContactTitle : string = null with get,set

   [<Column>]
   member val Address : string = null with get,set

   [<Column>]
   member val City : string = null with get,set

   [<Column>]
   member val Region : string = null with get,set

   [<Column>]
   member val PostalCode : string = null with get,set

   [<Column>]
   member val Country : string = null with get,set

   [<Column>]
   member val Phone : string = null with get,set

   [<Column>]
   member val Fax : string = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "CustomerDemographics")>]
type CustomerDemographic() =

   [<Column(IsPrimaryKey = true)>]
   member val CustomerTypeID : string = null with get,set

   [<Column>]
   member val CustomerDesc : string = null with get,set

[<AllowNullLiteral>]
[<Table>]
type CustomerCustomerDemo() =

   [<Column(IsPrimaryKey = true)>]
   member val CustomerID : string = null with get,set

   [<Column(IsPrimaryKey = true)>]
   member val CustomerTypeID : string = null with get,set

   [<Association(ThisKey = "CustomerTypeID")>]
   member val CustomerDemographic : CustomerDemographic = null with get,set

   [<Association(ThisKey = "CustomerID")>]
   member val Customer : Customer = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Shippers")>]
type Shipper() =

   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val ShipperID = 0 with get,set

   [<Column>]
   member val CompanyName : string = null with get,set

   [<Column>]
   member val Phone : string = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Order Details")>]
type OrderDetail() =

   [<Column(IsPrimaryKey = true)>]
   member val OrderID = 0 with get,set

   [<Column(IsPrimaryKey = true)>]
   member val ProductID = 0 with get,set

   [<Column>]
   member val UnitPrice = 0M with get,set

   [<Column>]
   member val Quantity = 0s with get,set

   [<Column>]
   member val Discount = 0.0 with get,set

   [<Association(ThisKey = "ProductID")>]
   member val Product : Product = null with get,set

[<AllowNullLiteral>]
[<Table(Name = "Orders")>]
type Order() =

   [<Column(IsPrimaryKey = true, IsDbGenerated = true)>]
   member val OrderID = 0 with get,set

   [<Column>]
   member val CustomerID : string = null with get,set

   [<Column>]
   member val EmployeeID = new Nullable<int>() with get,set

   [<Column>]
   member val OrderDate = new Nullable<DateTime>() with get,set

   [<Column>]
   member val RequiredDate = new Nullable<DateTime>() with get,set

   [<Column>]
   member val ShippedDate = new Nullable<DateTime>() with get,set

   [<Column>]
   member val ShipVia = new Nullable<int>() with get,set

   [<Column>]
   member val Freight =  new Nullable<decimal>() with get,set

   [<Column>]
   member val ShipName : string = null with get,set

   [<Column>]
   member val ShipAddress : string = null with get,set

   [<Column>]
   member val ShipCity : string = null with get,set

   [<Column>]
   member val ShipRegion : string = null with get,set

   [<Column>]
   member val ShipPostalCode : string = null with get,set

   [<Column>]
   member val ShipCountry : string = null with get,set

   [<Association(OtherKey = "OrderID")>]
   member val OrderDetails = new Collection<OrderDetail>() with get,set

   [<Association(ThisKey = "CustomerID")>]
   member val Customer : Customer = null with get,set

   [<Association(ThisKey = "EmployeeID")>]
   member val Employee : Employee = null with get,set

   [<Association(ThisKey = "ShipVia")>]
   member val Shipper : Shipper = null with get,set

type NorthwindDatabase =
   inherit Database

   member this.Products = this.Table<Product>()
   member this.Orders = this.Table<Order>()
   member this.OrderDetails = this.Table<OrderDetail>()
   member this.Employees = this.Table<Employee>()
   member this.EmployeeTerritories = this.Table<EmployeeTerritory>()
   member this.Regions = this.Table<Region>()

   new(connectionString : string, providerInvariantName : string) = {
      inherit Database(connectionString, providerInvariantName)
   }
