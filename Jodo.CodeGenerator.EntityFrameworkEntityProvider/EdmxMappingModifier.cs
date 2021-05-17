using System.Linq;
using System.Xml.Linq;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Generator;

namespace Jodo.CodeGenerator.EdmgenEntityProvider
{	
	/// <summary>
	/// Provides methods for altering the entity framework 
	/// mapping files produced by the Edmgen.exe code generator.
	/// This class does not support 'function' or 'stored procedure' 
	/// mappings.
	/// </summary>
	internal class EdmxMappingModifier
	{
		private EdmgenManager edmgenManager;
		private IConfiguration configuration;

		public EdmxMappingModifier(EdmgenManager edmgenManager, IConfiguration configuration)
		{
			this.edmgenManager = edmgenManager;
			this.configuration = configuration;
		}

		/// <summary>
		/// Modifies the Edmgen.exe generated code to 
		/// PascalCase Types and Properties
		/// </summary>
		public void PascalCaseTypesAndProperies()
		{
			// parse ssdl
			PascalCaseTypesAndProperiesForDefinitionLanguageFiles(edmgenManager.SsdlDestinationPath);

			// re-generate csdl. msl and views from ssdl
			edmgenManager.Generate(EdmgenManager.GeneratorMode.FromSSDLGeneration);
		}

		/// <summary>
		/// Can be used on csdl and ssdl schemas.
		/// </summary>
		/// <param name="mappingFilePath"></param>
		private void PascalCaseTypesAndProperiesForDefinitionLanguageFiles(string mappingFilePath)
		{
			XDocument mappingsDoc = XDocument.Load(mappingFilePath);
		
			foreach (XElement entitySetElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "EntitySet"))
			{
				entitySetElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(entitySetElement.Attribute("Name").Value));
				entitySetElement.SetAttributeValue("EntityType", PascalCaseTypeName(entitySetElement.Attribute("EntityType").Value));
			}

			foreach (XElement associationSetElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "AssociationSet"))
			{
				string nameValue = associationSetElement.Attribute("Name").Value;
			
				// get End children nodes
				foreach (XElement endNodes in associationSetElement.Descendants().Where(el => el.Name.LocalName == "End"))
				{
					endNodes.SetAttributeValue("Role", Utility.UpperCaseFirstChar(endNodes.Attribute("Role").Value));
					endNodes.SetAttributeValue("EntitySet", Utility.UpperCaseFirstChar(endNodes.Attribute("EntitySet").Value));
				}
			}

			foreach (XElement entityTypeElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "EntityType"))
			{
				string nameValue = entityTypeElement.Attribute("Name").Value;
				entityTypeElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(nameValue));

				foreach (XElement keyElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "Key"))
				{
					foreach (XElement propertyRefElement in keyElement.Descendants().Where(el => el.Name.LocalName == "PropertyRef"))
					{
						propertyRefElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(propertyRefElement.Attribute("Name").Value));
					}
				}

				foreach (XElement propertyElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "Property"))
				{
					propertyElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(propertyElement.Attribute("Name").Value));
				}
			}

			foreach (XElement associationSetElement in mappingsDoc.Descendants().Where(el => el.Name.LocalName == "Association"))
			{				
				foreach (XElement endElement in associationSetElement.Descendants().Where(el => el.Name.LocalName == "End"))
				{
					endElement.SetAttributeValue("Role", Utility.UpperCaseFirstChar(endElement.Attribute("Role").Value));
					endElement.SetAttributeValue("Type", PascalCaseTypeName(endElement.Attribute("Type").Value));								
				}
								
				foreach (XElement referentialConstraintElement in associationSetElement.Descendants().Where(el => el.Name.LocalName == "ReferentialConstraint"))
				{
					foreach (XElement principalElement in referentialConstraintElement.Descendants().Where(el => el.Name.LocalName == "Principal"))
					{
						principalElement.SetAttributeValue("Role", Utility.UpperCaseFirstChar(principalElement.Attribute("Role").Value));

						foreach (XElement propertyRefElement in principalElement.Descendants().Where(el => el.Name.LocalName == "PropertyRef"))
						{
							propertyRefElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(propertyRefElement.Attribute("Name").Value));
						}
					}

					foreach (XElement dependentElement in referentialConstraintElement.Descendants().Where(el => el.Name.LocalName == "Dependent"))
					{
						dependentElement.SetAttributeValue("Role", Utility.UpperCaseFirstChar(dependentElement.Attribute("Role").Value));

						foreach (XElement propertyRefElement in dependentElement.Descendants().Where(el => el.Name.LocalName == "PropertyRef"))
						{
							propertyRefElement.SetAttributeValue("Name", Utility.UpperCaseFirstChar(propertyRefElement.Attribute("Name").Value));
						}
					}
				}
			}

			Utility.EnsureFileDeleted(mappingFilePath, configuration.FileOperationTimeout);
			mappingsDoc.Save(mappingFilePath);			
		}

		private string PascalCaseTypeName(string typeName)
		{
			string className = typeName.Split('.').Last();
			return typeName.Substring(0, typeName.LastIndexOf('.')) + "." + Utility.UpperCaseFirstChar(className);			
		}			
	}
}








	