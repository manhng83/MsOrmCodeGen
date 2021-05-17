using System;
using System.ComponentModel.Composition;
using System.IO;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Generator;
using Jodo.CodeGenerator.Core.Templating;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Generator
{
	[Export(typeof(IConfiguration))]
	public class Configuration : IConfiguration
	{		
		private static string templatesDirectory = String.Format(@"{0}\Templates", Utility.StartUpDirectory);
		private CodeTypeEnum? codeType;
		private string templateName;
		private string nameSpace;
		
		public string CodeDestinationFilePath { get; set; }
		public string CodeMetaDataDestinationFilePath { get; set; }
		public DirectoryInfo CodeMetaDataDestinationDirectory { get; set; }

		/// <summary>
		/// Get/Set the namespace for the generated code.
		/// If not namespace is set, "DefaultNamespace" will be returned.
		/// </summary>
		public string NameSpace
		{
			get { return String.IsNullOrEmpty(nameSpace) ? "DefaultNamespace" : nameSpace; }
			set { nameSpace = value; }
		}

		/// <summary>
		/// Set the default number of milliseconds
		/// file I/O operation should wait for to complete.
		/// </summary>
		/// <remarks>
		/// Depending on the size the code files be generatd this 
		/// value might need to be ramped up.  The default value will be 30000.
		/// </remarks>
		public int FileOperationTimeout { get { return 30000; } }

		public DirectoryInfo TemplatesDirectory
		{
			get
			{
				DirectoryInfo di = new DirectoryInfo(templatesDirectory);
				if (!di.Exists)
					di.Create();

				return di;
			}
		}

		public string TemplateName
		{
			get { return templateName; }
			set { templateName = value; }
		}

		public string TemplateFilePath
		{
			get { return String.Format(@"{0}\{1}", TemplatesDirectory.FullName, templateName); }
		}

		public CodeTypeEnum CodeType
		{
			get
			{
				if (String.IsNullOrEmpty(templateName))
					throw new ArgumentNullException("Make sure at leastt one .txt template file has been added to the Templates directory in the applications start-up bin.");
				
				if (codeType == null)
					codeType = GetCodeType();

				return (CodeTypeEnum)codeType;
			}
		}	
		
		private CodeTypeEnum GetCodeType()
		{
			return new TemplateBase(new FileInfo(TemplateFilePath)).CodeType;
		}
	}
}
