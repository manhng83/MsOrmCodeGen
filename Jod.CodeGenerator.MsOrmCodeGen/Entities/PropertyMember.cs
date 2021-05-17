using System;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	/// <summary>
	/// Creates PropertyMembers that are compliant for Entity Framework
	/// and Linq To Sql data transfer object code.
	/// </summary>
	public class PropertyMember : Member, IPropertyMember
    {
		public PropertyMember(CodeTypeEnum codeType) : base(codeType) { }

		public IFieldMember BackingStore { get; set; }

		public override string Name
		{
			get
			{		
				if (base.Name.StartsWith("_"))
					return base.Name.Substring(1);

				return Utility.UpperCaseFirstChar(base.Name);
			}
			set
			{
				base.Name = value;
			}
		}
	}
}
