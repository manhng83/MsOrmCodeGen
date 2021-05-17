using System.Collections.Generic;

namespace Jodo.CodeGenerator.Core.Entities
{
	public interface IEntity
	{
		string GeneratedCode { get; set; }
		string Name { get; set; }
		string NameSpace { get; set; }
		IList<IPropertyMember> Properties { get; set; }
	}
}
