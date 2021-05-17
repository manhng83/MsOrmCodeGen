using Jodo.CodeGenerator.Core.Entities;

namespace CodeGeneratorFake
{
	public class PropertyMember : IPropertyMember, IFieldMember
	{
		public IFieldMember BackingStore { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}
}
