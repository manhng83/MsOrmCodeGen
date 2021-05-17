using System.Collections.Generic;

namespace Jodo.CodeGenerator.Core.Entities.Provider.Database
{
	public interface IDatabaseEntityProvider : IEntityProvider
	{
		IList<IEntity> FindEntities(ConnectionString connectionString, IMemberFactory memberFactory);
	}
}
