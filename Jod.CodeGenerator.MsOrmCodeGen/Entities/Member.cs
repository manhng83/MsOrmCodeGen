using System;
using System.Text.RegularExpressions;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	/// <summary>
	/// Provides a base <see cref="IMember"/> implementation 
	/// to supports generating <see cref="Entity"/>s that are formed
	/// to support Entity Framework and Linq to Sql 
	/// data technologies.
	/// </summary>
	public abstract class Member : IMember
	{
		private CodeTypeEnum codeType;
		private string type;
		private string typeExtracted;

		public CodeTypeEnum CodeTypeEnum { get; private set; }
		public virtual string Name { get; set; }

		public string Type
		{
			get
			{
				if (String.IsNullOrEmpty(typeExtracted))
				{
					string typeLocal = String.Empty;

					if (type != null)
					{
						// clean up type from Edmgen.exe generated code
						typeLocal = CleanUpEdmgenGeneratedTypeName(type);

						// Sqlmetal.exe code generator scenerios

						if (typeLocal.Contains("EntityRef<"))
						{
							typeLocal = new Regex(@"(?<=\bEntityRef<).*(?=>)").Match(typeLocal).Value;
							typeLocal = CodeTypeEnum == CodeTypeEnum.Interface ? "I" + typeLocal : typeLocal;
						}

						else if (typeLocal.Contains("EntitySet<"))
						{
							typeLocal = new Regex(@"(?<=\bEntitySet<).*(?=>)").Match(typeLocal).Value;
							typeLocal = CodeTypeEnum == CodeTypeEnum.Interface ? String.Format("ICollection<I{0}>", typeLocal) : String.Format("ICollection<{0}>", typeLocal);
						}
						else if (typeLocal.Contains("System.Data.Linq.Binary"))
						{
							typeLocal = "byte[]";
						}

						// Edmgen.exe code generator scenerios

						else if (typeLocal.Contains("EntityCollection<"))
						{
							typeLocal = new Regex(@"(?<=\bEntityCollection<).*(?=>)").Match(typeLocal).Value;
							typeLocal = CodeTypeEnum == CodeTypeEnum.Interface ? String.Format("ICollection<I{0}>", typeLocal) : String.Format("ICollection<{0}>", typeLocal);
						}
					}

					typeExtracted = typeLocal;
				}

				return typeExtracted;
			}

			set { type = value; }
		}	

		public Member(CodeTypeEnum codeType)
		{
			this.codeType = codeType;			
		}

		protected MemberType GetMemberType()
		{
			string typeLowered = Type.ToLower();

			if (typeLowered.Contains("string") ||
				typeLowered.Contains("int") ||
				typeLowered.Contains("short") ||
				typeLowered.Contains("long") ||
				typeLowered.Contains("decimal") ||
				typeLowered.Contains("bool") ||
				typeLowered.Contains("double") ||
				typeLowered.Contains("byte") ||
				typeLowered.Contains("datetime") ||
				typeLowered.Contains("guid"))
			{
				return MemberType.Simple;
			}
			else if (typeLowered.Contains("icollection"))
			{
				return MemberType.ComplexCollection;
			}
			else
			{
				return MemberType.ComplexSingle;
			}
		}

		/// <summary>
		/// Extracts the type from a ICollection string declaration.
		/// </summary>
		/// <returns></returns>
		protected string ExtractTypeFromGenericCollection()
		{
			return Type.Substring(12).Replace(">", "");
		}

		/// <summary>
		/// Edmgen.exe specific generated code parsing method.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		protected string CleanUpEdmgenGeneratedTypeName(string type)
		{
			if (type.Contains("Nullable<global::System."))
			{
				type = type.Replace("Nullable<global::System.", String.Empty);
				return type.Replace(">", "?");
			}				

			return type.Replace("global::System.", String.Empty);
		}		
	}
}
