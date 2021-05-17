using System.ComponentModel.Composition;
using CodeGenerator.Core.Entities;

namespace CodeGenerator.MicrosoftOrm.Entities
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
