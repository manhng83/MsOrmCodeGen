using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Northwind.Dto
{
 public class Alphabeticallistofproducts 
    {
	#region

        private Int32? _CategoryID;
private String _CategoryName;
private Boolean _Discontinued;
private Int32 _ProductID;
private String _ProductName;
private String _QuantityPerUnit;
private Int16? _ReorderLevel;
private Int32? _SupplierID;
private Decimal? _UnitPrice;
private Int16? _UnitsInStock;
private Int16? _UnitsOnOrder;

       
	#endregion

	#region

	
        public Int32? CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public Boolean Discontinued
        {
            get { return _Discontinued; }
            set { _Discontinued = value; }
        }
	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public String QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set { _QuantityPerUnit = value; }
        }
	
        public Int16? ReorderLevel
        {
            get { return _ReorderLevel; }
            set { _ReorderLevel = value; }
        }
	
        public Int32? SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
	
        public Decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	
        public Int16? UnitsInStock
        {
            get { return _UnitsInStock; }
            set { _UnitsInStock = value; }
        }
	
        public Int16? UnitsOnOrder
        {
            get { return _UnitsOnOrder; }
            set { _UnitsOnOrder = value; }
        }
	

	#endregion
    }

 public class Categories 
    {
	#region

        private Int32 _CategoryID;
private String _CategoryName;
private String _Description;
private Byte[] _Picture;
private ICollection<Products> _Products;

       
	#endregion

	#region

	
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
	
        public Byte[] Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }
	
        public ICollection<Products> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
	

	#endregion
    }

 public class CategorySalesfor1997 
    {
	#region

        private String _CategoryName;
private Decimal? _CategorySales;

       
	#endregion

	#region

	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public Decimal? CategorySales
        {
            get { return _CategorySales; }
            set { _CategorySales = value; }
        }
	

	#endregion
    }

 public class CurrentProductList 
    {
	#region

        private Int32 _ProductID;
private String _ProductName;

       
	#endregion

	#region

	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	

	#endregion
    }

 public class CustomerandSuppliersbyCity 
    {
	#region

        private String _City;
private String _CompanyName;
private String _ContactName;
private String _Relationship;

       
	#endregion

	#region

	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public String ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
	
        public String Relationship
        {
            get { return _Relationship; }
            set { _Relationship = value; }
        }
	

	#endregion
    }

 public class CustomerDemographics 
    {
	#region

        private String _CustomerDesc;
private ICollection<Customers> _Customers;
private String _CustomerTypeID;

       
	#endregion

	#region

	
        public String CustomerDesc
        {
            get { return _CustomerDesc; }
            set { _CustomerDesc = value; }
        }
	
        public ICollection<Customers> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }
	
        public String CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }
	

	#endregion
    }

 public class Customers 
    {
	#region

        private String _Address;
private String _City;
private String _CompanyName;
private String _ContactName;
private String _ContactTitle;
private String _Country;
private ICollection<CustomerDemographics> _CustomerDemographics;
private String _CustomerID;
private String _Fax;
private ICollection<Orders> _Orders;
private String _Phone;
private String _PostalCode;
private String _Region;

       
	#endregion

	#region

	
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public String ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
	
        public String ContactTitle
        {
            get { return _ContactTitle; }
            set { _ContactTitle = value; }
        }
	
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public ICollection<CustomerDemographics> CustomerDemographics
        {
            get { return _CustomerDemographics; }
            set { _CustomerDemographics = value; }
        }
	
        public String CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
	
        public ICollection<Orders> Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
	
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
	
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
	
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	

	#endregion
    }

 public class Employees 
    {
	#region

        private String _Address;
private DateTime? _BirthDate;
private String _City;
private String _Country;
private Int32 _EmployeeID;
private ICollection<Employees> _Employees1;
private Employees _Employees2;
private String _Extension;
private String _FirstName;
private DateTime? _HireDate;
private String _HomePhone;
private String _LastName;
private String _Notes;
private ICollection<Orders> _Orders;
private Byte[] _Photo;
private String _PhotoPath;
private String _PostalCode;
private String _Region;
private Int32? _ReportsTo;
private ICollection<Territories> _Territories;
private String _Title;
private String _TitleOfCourtesy;

       
	#endregion

	#region

	
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
	
        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
	
        public ICollection<Employees> Employees1
        {
            get { return _Employees1; }
            set { _Employees1 = value; }
        }
	
        public Employees Employees2
        {
            get { return _Employees2; }
            set { _Employees2 = value; }
        }
	
        public String Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
	
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
	
        public DateTime? HireDate
        {
            get { return _HireDate; }
            set { _HireDate = value; }
        }
	
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
	
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
	
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
	
        public ICollection<Orders> Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
	
        public Byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
	
        public String PhotoPath
        {
            get { return _PhotoPath; }
            set { _PhotoPath = value; }
        }
	
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
	
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	
        public Int32? ReportsTo
        {
            get { return _ReportsTo; }
            set { _ReportsTo = value; }
        }
	
        public ICollection<Territories> Territories
        {
            get { return _Territories; }
            set { _Territories = value; }
        }
	
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
	
        public String TitleOfCourtesy
        {
            get { return _TitleOfCourtesy; }
            set { _TitleOfCourtesy = value; }
        }
	

	#endregion
    }

 public class Invoices 
    {
	#region

        private String _Address;
private String _City;
private String _Country;
private String _CustomerID;
private String _CustomerName;
private Single _Discount;
private Decimal? _ExtendedPrice;
private Decimal? _Freight;
private DateTime? _OrderDate;
private Int32 _OrderID;
private String _PostalCode;
private Int32 _ProductID;
private String _ProductName;
private Int16 _Quantity;
private String _Region;
private DateTime? _RequiredDate;
private String _Salesperson;
private String _ShipAddress;
private String _ShipCity;
private String _ShipCountry;
private String _ShipName;
private DateTime? _ShippedDate;
private String _ShipperName;
private String _ShipPostalCode;
private String _ShipRegion;
private Decimal _UnitPrice;

       
	#endregion

	#region

	
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public String CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	
        public String CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
	
        public Single Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
	
        public Decimal? ExtendedPrice
        {
            get { return _ExtendedPrice; }
            set { _ExtendedPrice = value; }
        }
	
        public Decimal? Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
	
        public DateTime? OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public Int16 Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
	
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	
        public DateTime? RequiredDate
        {
            get { return _RequiredDate; }
            set { _RequiredDate = value; }
        }
	
        public String Salesperson
        {
            get { return _Salesperson; }
            set { _Salesperson = value; }
        }
	
        public String ShipAddress
        {
            get { return _ShipAddress; }
            set { _ShipAddress = value; }
        }
	
        public String ShipCity
        {
            get { return _ShipCity; }
            set { _ShipCity = value; }
        }
	
        public String ShipCountry
        {
            get { return _ShipCountry; }
            set { _ShipCountry = value; }
        }
	
        public String ShipName
        {
            get { return _ShipName; }
            set { _ShipName = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	
        public String ShipperName
        {
            get { return _ShipperName; }
            set { _ShipperName = value; }
        }
	
        public String ShipPostalCode
        {
            get { return _ShipPostalCode; }
            set { _ShipPostalCode = value; }
        }
	
        public String ShipRegion
        {
            get { return _ShipRegion; }
            set { _ShipRegion = value; }
        }
	
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	

	#endregion
    }

 public class Orderdetails 
    {
	#region

        private Single _Discount;
private Int32 _OrderID;
private Orders _Orders;
private Int32 _ProductID;
private Products _Products;
private Int16 _Quantity;
private Decimal _UnitPrice;

       
	#endregion

	#region

	
        public Single Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public Orders Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public Products Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
	
        public Int16 Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
	
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	

	#endregion
    }

 public class OrderdetailsExtended 
    {
	#region

        private Single _Discount;
private Decimal? _ExtendedPrice;
private Int32 _OrderID;
private Int32 _ProductID;
private String _ProductName;
private Int16 _Quantity;
private Decimal _UnitPrice;

       
	#endregion

	#region

	
        public Single Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
	
        public Decimal? ExtendedPrice
        {
            get { return _ExtendedPrice; }
            set { _ExtendedPrice = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public Int16 Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
	
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	

	#endregion
    }

 public class Orders 
    {
	#region

        private String _CustomerID;
private Customers _Customers;
private Int32? _EmployeeID;
private Employees _Employees;
private Decimal? _Freight;
private DateTime? _OrderDate;
private ICollection<Orderdetails> _Orderdetails;
private Int32 _OrderID;
private DateTime? _RequiredDate;
private String _ShipAddress;
private String _ShipCity;
private String _ShipCountry;
private String _ShipName;
private DateTime? _ShippedDate;
private Shippers _Shippers;
private String _ShipPostalCode;
private String _ShipRegion;
private Int32? _ShipVia;

       
	#endregion

	#region

	
        public String CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	
        public Customers Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }
	
        public Int32? EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
	
        public Employees Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }
	
        public Decimal? Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
	
        public DateTime? OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
	
        public ICollection<Orderdetails> Orderdetails
        {
            get { return _Orderdetails; }
            set { _Orderdetails = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public DateTime? RequiredDate
        {
            get { return _RequiredDate; }
            set { _RequiredDate = value; }
        }
	
        public String ShipAddress
        {
            get { return _ShipAddress; }
            set { _ShipAddress = value; }
        }
	
        public String ShipCity
        {
            get { return _ShipCity; }
            set { _ShipCity = value; }
        }
	
        public String ShipCountry
        {
            get { return _ShipCountry; }
            set { _ShipCountry = value; }
        }
	
        public String ShipName
        {
            get { return _ShipName; }
            set { _ShipName = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	
        public Shippers Shippers
        {
            get { return _Shippers; }
            set { _Shippers = value; }
        }
	
        public String ShipPostalCode
        {
            get { return _ShipPostalCode; }
            set { _ShipPostalCode = value; }
        }
	
        public String ShipRegion
        {
            get { return _ShipRegion; }
            set { _ShipRegion = value; }
        }
	
        public Int32? ShipVia
        {
            get { return _ShipVia; }
            set { _ShipVia = value; }
        }
	

	#endregion
    }

 public class OrdersQry 
    {
	#region

        private String _Address;
private String _City;
private String _CompanyName;
private String _Country;
private String _CustomerID;
private Int32? _EmployeeID;
private Decimal? _Freight;
private DateTime? _OrderDate;
private Int32 _OrderID;
private String _PostalCode;
private String _Region;
private DateTime? _RequiredDate;
private String _ShipAddress;
private String _ShipCity;
private String _ShipCountry;
private String _ShipName;
private DateTime? _ShippedDate;
private String _ShipPostalCode;
private String _ShipRegion;
private Int32? _ShipVia;

       
	#endregion

	#region

	
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public String CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	
        public Int32? EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
	
        public Decimal? Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
	
        public DateTime? OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
	
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	
        public DateTime? RequiredDate
        {
            get { return _RequiredDate; }
            set { _RequiredDate = value; }
        }
	
        public String ShipAddress
        {
            get { return _ShipAddress; }
            set { _ShipAddress = value; }
        }
	
        public String ShipCity
        {
            get { return _ShipCity; }
            set { _ShipCity = value; }
        }
	
        public String ShipCountry
        {
            get { return _ShipCountry; }
            set { _ShipCountry = value; }
        }
	
        public String ShipName
        {
            get { return _ShipName; }
            set { _ShipName = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	
        public String ShipPostalCode
        {
            get { return _ShipPostalCode; }
            set { _ShipPostalCode = value; }
        }
	
        public String ShipRegion
        {
            get { return _ShipRegion; }
            set { _ShipRegion = value; }
        }
	
        public Int32? ShipVia
        {
            get { return _ShipVia; }
            set { _ShipVia = value; }
        }
	

	#endregion
    }

 public class OrderSubtotals 
    {
	#region

        private Int32 _OrderID;
private Decimal? _Subtotal;

       
	#endregion

	#region

	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public Decimal? Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }
	

	#endregion
    }

 public class Products 
    {
	#region

        private Categories _Categories;
private Int32? _CategoryID;
private Boolean _Discontinued;
private ICollection<Orderdetails> _Orderdetails;
private Int32 _ProductID;
private String _ProductName;
private String _QuantityPerUnit;
private Int16? _ReorderLevel;
private Int32? _SupplierID;
private Suppliers _Suppliers;
private Decimal? _UnitPrice;
private Int16? _UnitsInStock;
private Int16? _UnitsOnOrder;

       
	#endregion

	#region

	
        public Categories Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }
	
        public Int32? CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
	
        public Boolean Discontinued
        {
            get { return _Discontinued; }
            set { _Discontinued = value; }
        }
	
        public ICollection<Orderdetails> Orderdetails
        {
            get { return _Orderdetails; }
            set { _Orderdetails = value; }
        }
	
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public String QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set { _QuantityPerUnit = value; }
        }
	
        public Int16? ReorderLevel
        {
            get { return _ReorderLevel; }
            set { _ReorderLevel = value; }
        }
	
        public Int32? SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
	
        public Suppliers Suppliers
        {
            get { return _Suppliers; }
            set { _Suppliers = value; }
        }
	
        public Decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	
        public Int16? UnitsInStock
        {
            get { return _UnitsInStock; }
            set { _UnitsInStock = value; }
        }
	
        public Int16? UnitsOnOrder
        {
            get { return _UnitsOnOrder; }
            set { _UnitsOnOrder = value; }
        }
	

	#endregion
    }

 public class ProductsAboveAveragePrice 
    {
	#region

        private String _ProductName;
private Decimal? _UnitPrice;

       
	#endregion

	#region

	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public Decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
	

	#endregion
    }

 public class ProductSalesfor1997 
    {
	#region

        private String _CategoryName;
private String _ProductName;
private Decimal? _ProductSales;

       
	#endregion

	#region

	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public Decimal? ProductSales
        {
            get { return _ProductSales; }
            set { _ProductSales = value; }
        }
	

	#endregion
    }

 public class ProductsbyCategory 
    {
	#region

        private String _CategoryName;
private Boolean _Discontinued;
private String _ProductName;
private String _QuantityPerUnit;
private Int16? _UnitsInStock;

       
	#endregion

	#region

	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public Boolean Discontinued
        {
            get { return _Discontinued; }
            set { _Discontinued = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public String QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set { _QuantityPerUnit = value; }
        }
	
        public Int16? UnitsInStock
        {
            get { return _UnitsInStock; }
            set { _UnitsInStock = value; }
        }
	

	#endregion
    }

 public class Region 
    {
	#region

        private String _RegionDescription;
private Int32 _RegionID;
private ICollection<Territories> _Territories;

       
	#endregion

	#region

	
        public String RegionDescription
        {
            get { return _RegionDescription; }
            set { _RegionDescription = value; }
        }
	
        public Int32 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }
	
        public ICollection<Territories> Territories
        {
            get { return _Territories; }
            set { _Territories = value; }
        }
	

	#endregion
    }

 public class SalesbyCategory 
    {
	#region

        private Int32 _CategoryID;
private String _CategoryName;
private String _ProductName;
private Decimal? _ProductSales;

       
	#endregion

	#region

	
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
	
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
	
        public String ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
	
        public Decimal? ProductSales
        {
            get { return _ProductSales; }
            set { _ProductSales = value; }
        }
	

	#endregion
    }

 public class SalesTotalsbyAmount 
    {
	#region

        private String _CompanyName;
private Int32 _OrderID;
private Decimal? _SaleAmount;
private DateTime? _ShippedDate;

       
	#endregion

	#region

	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public Decimal? SaleAmount
        {
            get { return _SaleAmount; }
            set { _SaleAmount = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	

	#endregion
    }

 public class Shippers 
    {
	#region

        private String _CompanyName;
private ICollection<Orders> _Orders;
private String _Phone;
private Int32 _ShipperID;

       
	#endregion

	#region

	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public ICollection<Orders> Orders
        {
            get { return _Orders; }
            set { _Orders = value; }
        }
	
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
	
        public Int32 ShipperID
        {
            get { return _ShipperID; }
            set { _ShipperID = value; }
        }
	

	#endregion
    }

 public class SummaryofSalesbyQuarter 
    {
	#region

        private Int32 _OrderID;
private DateTime? _ShippedDate;
private Decimal? _Subtotal;

       
	#endregion

	#region

	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	
        public Decimal? Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }
	

	#endregion
    }

 public class SummaryofSalesbyYear 
    {
	#region

        private Int32 _OrderID;
private DateTime? _ShippedDate;
private Decimal? _Subtotal;

       
	#endregion

	#region

	
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
	
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set { _ShippedDate = value; }
        }
	
        public Decimal? Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }
	

	#endregion
    }

 public class Suppliers 
    {
	#region

        private String _Address;
private String _City;
private String _CompanyName;
private String _ContactName;
private String _ContactTitle;
private String _Country;
private String _Fax;
private String _HomePage;
private String _Phone;
private String _PostalCode;
private ICollection<Products> _Products;
private String _Region;
private Int32 _SupplierID;

       
	#endregion

	#region

	
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
	
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public String ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
	
        public String ContactTitle
        {
            get { return _ContactTitle; }
            set { _ContactTitle = value; }
        }
	
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
	
        public String HomePage
        {
            get { return _HomePage; }
            set { _HomePage = value; }
        }
	
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
	
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
	
        public ICollection<Products> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
	
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	
        public Int32 SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
	

	#endregion
    }

 public class Territories 
    {
	#region

        private ICollection<Employees> _Employees;
private Region _Region;
private Int32 _RegionID;
private String _TerritoryDescription;
private String _TerritoryID;

       
	#endregion

	#region

	
        public ICollection<Employees> Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }
	
        public Region Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
	
        public Int32 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }
	
        public String TerritoryDescription
        {
            get { return _TerritoryDescription; }
            set { _TerritoryDescription = value; }
        }
	
        public String TerritoryID
        {
            get { return _TerritoryID; }
            set { _TerritoryID = value; }
        }
	

	#endregion
    }

 public class CustomerCustomerDemo 
    {
	#region

        private CustomerDemographics _CustomerDemographics;
private string _CustomerID;
private Customers _Customers;
private string _CustomerTypeID;

       
	#endregion

	#region

	
        public CustomerDemographics CustomerDemographics
        {
            get { return _CustomerDemographics; }
            set { _CustomerDemographics = value; }
        }
	
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	
        public Customers Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }
	
        public string CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }
	

	#endregion
    }

 public class EmployeeTerritories 
    {
	#region

        private int _EmployeeID;
private Employees _Employees;
private Territories _Territories;
private string _TerritoryID;

       
	#endregion

	#region

	
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
	
        public Employees Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }
	
        public Territories Territories
        {
            get { return _Territories; }
            set { _Territories = value; }
        }
	
        public string TerritoryID
        {
            get { return _TerritoryID; }
            set { _TerritoryID = value; }
        }
	

	#endregion
    }

 public class QuarterlyOrders 
    {
	#region

        private string _City;
private string _CompanyName;
private string _Country;
private string _CustomerID;

       
	#endregion

	#region

	
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
	
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
	
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
	
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
	

	#endregion
    }


}