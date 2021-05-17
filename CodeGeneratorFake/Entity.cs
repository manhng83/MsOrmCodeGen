using System.Collections.Generic;
using System.ComponentModel.Composition;
using Jodo.CodeGenerator.Core.Entities;

namespace CodeGeneratorFake
{
	[Export(typeof(IEntity))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class Entity : IEntity
	{
		public string GeneratedCode { get; set; }
		public string Name { get; set; }
		public string NameSpace { get; set; }
		public IList<IPropertyMember> Properties { get; set; }
	}
}
