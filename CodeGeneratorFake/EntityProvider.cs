using System.Collections.Generic;
using System.ComponentModel.Composition;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Entities.Provider;

namespace CodeGeneratorFake
{
	[Export(typeof(IEntityProvider))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class EntityProvider : IEntityProvider
	{
		public string Name
		{
			get { return "Code Generator Fake"; }
		}

		public IEnumerable<IEntity> FindEntities(IConfigurationData configurationData, IMemberFactory privateFieldFactory)
		{
			PropertyMember firstName = new PropertyMember() { Name = "FirstName", Type = "string" };
			firstName.BackingStore = firstName;

			return new List<IEntity> { new Entity
			{ 
				Name = "Person",
				NameSpace = "fakeProvider",
				Properties = new List<IPropertyMember> { firstName }
			} 
			};
		}
	}	
}
