using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Generator;
using Jodo.CodeGenerator.Core.Templating;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Generator
{
	/// <summary>
	/// Generates object code that can be used with
	/// Entity Framework or Linq To Sql Orm technologies.
	/// </summary>
	[Export(typeof(ICodeGenerator))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class PocoCodeGenerator : ICodeGenerator
    {
		private IList<IEntity> generatedEntities;
		private IEnumerable<IEntity> selectedEntities;
		private IConfiguration configuration;

		#region Events

		public event EventHandler<CodeGenerationCompletedArgs> CodeGenerationCompleted;

		#endregion

		#region Constructors

		[ImportingConstructor]
		public PocoCodeGenerator(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		#endregion

		#region ICodeGenerator Members

		public void GenerateCodeFor(IEnumerable<IEntity> entities)
        {
			this.selectedEntities = entities;		
			GenerateCodeForInternal(selectedEntities);            
            WriteFiles();

			if(CodeGenerationCompleted != null)
				CodeGenerationCompleted(this, new CodeGenerationCompletedArgs(this));
        }

		public string GetCodeOutput()
		{
			StringBuilder output = new StringBuilder();
			output.Append(WriteUsings());
			output.Append(WriteNamespaceStart());

			foreach (IEntity entity in generatedEntities)
				output.Append(entity.GeneratedCode);

			output.Append(WriteNamespaceEnd());
			return output.ToString();			
		}

		#endregion

		private void GenerateCodeForInternal(IEnumerable<IEntity> selectedEntities)
        {
			if (String.IsNullOrEmpty(configuration.TemplateFilePath))
				throw new ArgumentNullException("A valid path to a template file must be provided.");
		
			// Store local copy of propertySection section so that this code only runs once.
			// The method to get the propertySection is very slow and we can use the same section for 
			// all entities, so we will grab it here and save it.		
			string propertySection = GetPropertiesSection();

			foreach (IEntity entity in selectedEntities)
            {
				StringBuilder privateFieldsStringBuilder = new StringBuilder();
				StringBuilder propertyStringBuilder = new StringBuilder();

				entity.NameSpace = configuration.NameSpace;

				ClassTemplate template = new ClassTemplate(new FileInfo(configuration.TemplateFilePath));
				template.ReplaceToken(ClassTemplate.Token.ClassName.ToString(), entity.Name);

				foreach (IPropertyMember propertyMember in entity.Properties)
					privateFieldsStringBuilder.AppendLine(String.Format("private {0} {1};", propertyMember.BackingStore.Type, propertyMember.BackingStore.Name));

				template.ReplaceToken(ClassTemplate.Token.PrivateFields.ToString(), privateFieldsStringBuilder.ToString());
								
				foreach (IPropertyMember propertyMember in entity.Properties)
                {
                    string property = propertySection;
					property = template.ReplaceToken(property, ClassTemplate.Token.PropertType.ToString(), propertyMember.Type);
					property = template.ReplaceToken(property, ClassTemplate.Token.PropertyName.ToString(), propertyMember.Name);
					property = template.ReplaceToken(property, ClassTemplate.Token.PropertyReturnField.ToString(), propertyMember.BackingStore.Name);
					property = template.ReplaceToken(property, ClassTemplate.Token.PropertySetField.ToString(), propertyMember.BackingStore.Name);

					propertyStringBuilder.Append(property);
                }

				template.ReplaceSection(propertySection, propertyStringBuilder.ToString(), ClassTemplate.Token.PropertiesStart.ToString(), ClassTemplate.Token.PropertiesEnd.ToString());
				entity.GeneratedCode = template.GetOutput();
				entity.GeneratedCode = entity.GeneratedCode + Environment.NewLine + Environment.NewLine;				
            }		
			
            generatedEntities = selectedEntities.ToList();
        }		

		private string GetPropertiesSection()
		{
			return new ClassTemplate(new FileInfo(configuration.TemplateFilePath)).PropertiesSection;
		}

		private string WriteNamespaceStart()
		{
			return "namespace " + configuration.NameSpace + Environment.NewLine + "{" + Environment.NewLine;		
		}

		private string WriteNamespaceEnd()
		{
			return Environment.NewLine + "}";		
		}

		private string WriteUsings()
		{
			return String.Format("using System;{0}using System.Collections.Generic;{1}using System.Runtime.Serialization;{2}{3}", 
				 Environment.NewLine,				
				 Environment.NewLine,
				 Environment.NewLine, 
				 Environment.NewLine);					
		}

        private void WriteFiles()
        {
			if (String.IsNullOrEmpty(configuration.CodeDestinationFilePath))
				return;

			using (FileStream filestream = new FileStream(configuration.CodeDestinationFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
				using (StreamWriter sw = new StreamWriter(filestream))
					sw.Write(GetCodeOutput());         
            }
        }	
	}
}
