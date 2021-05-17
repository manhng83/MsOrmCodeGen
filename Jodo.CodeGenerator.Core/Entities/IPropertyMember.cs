
namespace Jodo.CodeGenerator.Core.Entities
{
	public interface IPropertyMember : IMember
	{
		IFieldMember BackingStore { get; set; }
	}
}
