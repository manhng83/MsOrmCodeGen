using System.Data.Entity;
using System.Data.Entity.Database;

namespace MsOrmCodeGen.Client.Data
{
	public class ObjectContext : DbContext
	{
		public DbSet<ConfigurationStore> ConfigurationStore { get; set; }

		public ObjectContext()
		{
			DbDatabase.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
			DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<ObjectContext>());
		}
	}
}
