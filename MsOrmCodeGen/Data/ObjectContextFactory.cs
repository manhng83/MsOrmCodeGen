
namespace MsOrmCodeGen.Client.Data
{
	public class ObjectContextFactory
	{
		public ObjectContext Instance()
		{
			return new ThreadLifetimeManager<ObjectContext>().GetValue();
		}
	}
}
