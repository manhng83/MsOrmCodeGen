
namespace Jodo.CodeGenerator.Core.Entities
{
	public interface IMemberFactory
	{
		IPropertyMember PropertyMemberInstance(CodeTypeEnum codeType);
		IFieldMember FieldMemberInstance(CodeTypeEnum codeType);
	}
}