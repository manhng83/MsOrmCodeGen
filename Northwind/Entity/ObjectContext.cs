using System.Configuration;
using System.Data.Common;
using System.Data.EntityClient;

namespace Northwind.Entity
{
	public class ObjectContext : System.Data.Objects.ObjectContext
	{
		public ObjectContext() :
			base(new EntityConnection(Configuration.DefaultMetadataWorkspace, (DbConnection)DbConnection(Configuration.ConnectionStringName)))
		{
			
		}

		private static DbConnection DbConnection(string connectionStringName)
		{
			ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
			DbConnection connection = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName).CreateConnection();
			connection.ConnectionString = connectionStringSettings.ConnectionString;
			return connection;
		}
	}
}
