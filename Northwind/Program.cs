using System;
using System.Linq;
using Northwind.Dto;
using Northwind.Entity;
using Northwind.Linq;

namespace Northwind
{
	class Program
	{
		static void Main(string[] args)
		{
			Program p = new Program();
			p.SelectAllCustomersWithDataContext();
			p.SelectAllCustomersWithObjectContext();

			Console.ReadLine();
		}

		private void SelectAllCustomersWithDataContext()
		{
			// eager load Orders and OrderDetails
			var loadOptions = new System.Data.Linq.DataLoadOptions();	
			loadOptions.LoadWith<Customers>(p => p.Orders);
			loadOptions.LoadWith<Orders>(p => p.Orderdetails);

			DataContext dataContext = new DataContext();
			dataContext.LoadOptions = loadOptions;
			var customers = dataContext.GetTable<Customers>().ToList();
			customers.ForEach(c => Console.WriteLine(c.ContactName));
		}

		private void SelectAllCustomersWithObjectContext()
		{
			ObjectContext objectContext = new ObjectContext();
			// eager load Orders and OrderDetails
			var customers = objectContext.CreateObjectSet<Customers>().Include("Orders").Include("Orders.Orderdetails").ToList();
			customers.ForEach(c => Console.WriteLine(c.ContactName));
		}
	}
}
