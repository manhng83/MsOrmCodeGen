using System.Configuration;
using System.Data.SqlClient;

namespace Northwind.Linq
{	
	public class DataContext : System.Data.Linq.DataContext
	{
		public DataContext() :
			base(new SqlConnection(ConfigurationManager.ConnectionStrings[Configuration.ConnectionStringName].ConnectionString), 
			Configuration.DefaultDataContextMappingFile)
		{
		}		
	}
}