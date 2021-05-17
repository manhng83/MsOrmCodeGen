using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Entities.Provider;

namespace Jodo.CodeGenerator.EdmgenEntityProviderCodeGenerator.EdmgenSqlMetalEntityProvider
{
	/// <summary>
	/// <see cref="IEntityProvider"/> that generates Linq To Sql mapping code, 
	/// Entity Framework mapping code, and provides a <see cref="IEntityProvider"/> implementation
	/// that will return a IEnumerable of <see cref="IEntity"/>s that can be used to build 
	/// Entity Framework and Linq To Sql compliant Object code.
	/// This <see cref="IEntityProvider"/> is dependent on the EdmgenEntityProvider.Provider
	/// and SqlMetalEntityProvider.Provider. If these providers are not available this <see cref="IEntityProvider"/> will fail.
	/// </summary>
	[Export(typeof(IEntityProvider))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class Provider : IEntityProvider
	{
		private IEntityProvider edmgenEntityProvider = null;
		private IEntityProvider sqlMetalEntityProvider = null;		

		public string Name { get { return "Edmgen SqlMetal Entity Provider"; } }		

		#region IEntityProvider Members

		public IEnumerable<IEntity> FindEntities(IConfigurationData configurationData, IMemberFactory memberFactory)
		{
			SetEntityProviders(configurationData);

			IEnumerable<IEntity> sqlMetalEntities = sqlMetalEntityProvider.FindEntities(configurationData, memberFactory);
			IEnumerable<IEntity> edmgenEntities = edmgenEntityProvider.FindEntities(configurationData, memberFactory);
		
			foreach (IEntity edmgenEntity in edmgenEntities)
			{
				// sqlMetal and edmgen sometimes name navigation properties differently, so lets add in any names that sqlMetal produced but edmgen does not have
				IEntity sqlMetalEntity = sqlMetalEntities.FirstOrDefault(e => e.Name == edmgenEntity.Name);

				// if the entity is not present we must move on
				if (sqlMetalEntity == null)
					continue;

				foreach (IPropertyMember property in sqlMetalEntity.Properties)
				{
					if (!edmgenEntity.Properties.Any(p => p.Name == property.Name))
						edmgenEntity.Properties.Add(property);
				}
			}

			// merge edmgenEntities and sqlMetalEntities. Edmgen.exe will remove pure relationship Entities, but Linq to Sql will expect these to be there.
			return edmgenEntities.Union(sqlMetalEntities, new EntityComparer());		
		}

		#endregion

		/// <summary>
		/// Searches the IConfigurationData data for a Edmgen Entity Provider
		/// and SqlMetal Entity Provider.
		/// </summary>
		/// <param name="configurationData"></param>
		/// <exception cref="ApplicationException">Thrown if no Edmgen Entity Provider or SqlMetal Entity Provider is found.</exception>
		private void SetEntityProviders(IConfigurationData configurationData)
		{
			foreach (IEntityProvider entityProvider in (IEnumerable<IEntityProvider>)configurationData.ConfigData)
			{
				if (entityProvider.Name == "Edmgen Entity Provider")
					edmgenEntityProvider = entityProvider;

				if (entityProvider.Name == "SqlMetal Entity Provider")
					sqlMetalEntityProvider = entityProvider;
			}

			if (edmgenEntityProvider == null)
				throw new ApplicationException("No IEntityProvider with the name 'Edmgen Entity Provider' has been provided.");

			if (sqlMetalEntityProvider == null)
				throw new ApplicationException("No IEntityProvider with the name 'SqlMetal Entity Provider' has been provided.");
		}

		private class EntityComparer : IEqualityComparer<IEntity>
		{
			public bool Equals(IEntity x, IEntity y)
			{
				return x.Name == y.Name;
			}

			public int GetHashCode(IEntity obj)
			{
				return obj.Name.GetHashCode();
			}
		}
	}
}
