using System.ComponentModel.Composition;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	[Export(typeof(IEntityFactory))]
	public class EntityFactory : IEntityFactory
	{
		public IEntity Instance()
		{
			return new Entity();
		}
	}
}
