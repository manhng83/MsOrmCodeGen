using System;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	/// <summary>
	/// Creates FieldMembers that are compliant for Entity Framework
	/// and Linq To Sql data transfer object code.
	/// </summary>
	public class FieldMember : Member, IFieldMember
	{
		private string name;	

		public FieldMember(CodeTypeEnum codeType) : base(codeType)
		{				
		} 

		/// <summary>
		/// Returns the field name formatted as follows : "_FieldName"
		/// </summary>
		public override string Name
		{
			get
			{
				if (!name.StartsWith("_"))
				{
					name = String.Format("_{0}", Utility.UpperCaseFirstChar(name));
				}
				else
				{
					name = Utility.UpperCaseFirstChar(name);
				}

				return name;
			}
			set
			{
				name = value;
			}
		}
	}
}
