using System.Collections.Generic;

namespace Jodo.CodeGenerator.Core.Entities.Provider
{
	public interface IEntityProvider
	{
		/// <summary>
		/// The name that this <see cref="IEntityProvider"/> should
		/// be referenced with.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Retrieves a list of <see cref="IEntity"/>s, that code will be generated for.
		/// </summary>
		/// <param name="configurationData"></param>
		/// <param name="memberFactory"></param>
		/// <returns></returns>
		IEnumerable<IEntity> FindEntities(IConfigurationData configurationData, IMemberFactory memberFactory);
	}
}
