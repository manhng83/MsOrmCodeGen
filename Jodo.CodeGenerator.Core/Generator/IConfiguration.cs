using System.IO;

namespace Jodo.CodeGenerator.Core.Generator
{
	public interface IConfiguration
	{
		/// <summary>
		/// The file path to the template to be used.
		/// </summary>
		string TemplateFilePath { get; }

		/// <summary>
		/// Destination for the generated code file.
		/// </summary>
		string CodeDestinationFilePath { get; set; }

		/// <summary>
		/// Defines a location to drop
		/// a file that might be needed to support the generated code,
		/// such as an .xml meta data mapping file.
		/// </summary>
		string CodeMetaDataDestinationFilePath { get; set; }

		/// <summary>
		/// Defines a directory to drop
		/// any files that might be needed to support the generated code,
		/// such as .xml meta data mapping files.
		/// </summary>
		DirectoryInfo CodeMetaDataDestinationDirectory { get; set; }

		/// <summary>
		/// The type of code to be generated.
		/// </summary>
		CodeTypeEnum CodeType { get; }

		/// <summary>
		/// The name of the template.
		/// </summary>
		string TemplateName { get; set; }

		/// <summary>
		/// The directory object that hold the templates.
		/// </summary>
		DirectoryInfo TemplatesDirectory { get; }

		/// <summary>
		/// The namespace to be applied to code and metadata files.
		/// </summary>
		string NameSpace { get; set; }

		/// <summary>
		/// Set the default number of milliseconds
		/// file I/O operation should wait for to complete.
		/// </summary>
		/// <remarks>
		/// Depending on the size of the code files be generatd this 
		/// value might need to be ramped up.  
		/// </remarks>
		int FileOperationTimeout { get; }
	}
}
