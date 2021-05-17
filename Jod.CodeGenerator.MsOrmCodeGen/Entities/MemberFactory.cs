using System.ComponentModel.Composition;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	[Export(typeof(IMemberFactory))]
	public class MemberFactory : IMemberFactory
	{
		public IPropertyMember PropertyMemberInstance(CodeTypeEnum codeType)
		{
			return new PropertyMember(codeType);
		}

		public IFieldMember FieldMemberInstance(CodeTypeEnum codeType)
		{
			return new FieldMember(codeType);
		}
	}
}
