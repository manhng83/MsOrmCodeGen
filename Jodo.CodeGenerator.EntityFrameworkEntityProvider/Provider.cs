using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Entities.Provider;
using Jodo.CodeGenerator.Core.Entities.Provider.Database;
using Jodo.CodeGenerator.Core.Generator;

namespace Jodo.CodeGenerator.EdmgenEntityProvider
{
	[Export(typeof(IEntityProvider))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class Provider : IDatabaseEntityProvider
	{
		private IConfiguration configuration;
		private List<IEntity> foundEntities;
		private ConnectionString connectionString;
		private string nameSpace;
		private IMemberFactory memberFactory;
		private IEntityFactory entityFactory;

		public string Name { get { return "Edmgen Entity Provider"; } }

		public event EventHandler GenerateCodeStart;
		public event EventHandler GenerateCodeEnd;

		private string EdmgenExePath
		{
			get
			{
				string path = String.Format(@"{0}\Edmgen.exe", Utility.StartUpDirectory);
				if (!File.Exists(path))
					throw new ApplicationException(String.Format("Edmgen.exe was not found at path {0}.", path));
				
				return path;
			}
		}

		[ImportingConstructor]
		public Provider(IConfiguration configuration, IEntityFactory entityFactory)
		{
			if (configuration == null)
				throw new ArgumentNullException("configuration");

			this.configuration = configuration;
			this.entityFactory = entityFactory;

			foundEntities = new List<IEntity>();			
		}

		#region IEntityProvider Members

		IList<IEntity> IDatabaseEntityProvider.FindEntities(ConnectionString connectionString, IMemberFactory memberFactory)
		{
			if (String.IsNullOrEmpty(configuration.CodeDestinationFilePath))
				throw new ArgumentNullException("A destination file path for the Entity Framework's object code file must be set.");

			if (configuration.CodeMetaDataDestinationDirectory == null)
				throw new ArgumentNullException("A destination directory for the Entity Framework's mapping files must be set.");

			this.connectionString = connectionString;
			this.nameSpace = configuration.NameSpace;
			this.memberFactory = memberFactory;

			if (GenerateCodeStart != null) 
				GenerateCodeStart(this, new EventArgs());

			// delete CodeDestinationFilePath to start
			Utility.DeleteFile(configuration.CodeDestinationFilePath);				

			EdmgenManager edmgenManager = new EdmgenManager(EdmgenExePath, connectionString, configuration);

			// Delete existing Ssdl before calling Generate			
			Utility.EnsureFileDeleted(edmgenManager.SsdlDestinationPath, configuration.FileOperationTimeout);			

			edmgenManager.Generate(EdmgenManager.GeneratorMode.FullGeneration);

			DeleteAllFilesExceptSsdl(edmgenManager);

			Utility.EnsureFileIsAvailable(edmgenManager.SsdlDestinationPath, configuration.FileOperationTimeout);
			
			EdmxMappingModifier edmxMappingModifier = new EdmxMappingModifier(edmgenManager, configuration);
			edmxMappingModifier.PascalCaseTypesAndProperies();
		
			if (GenerateCodeStart != null) 
				GenerateCodeEnd(this, new EventArgs());
		
			Utility.EnsureFileIsAvailable(configuration.CodeDestinationFilePath, configuration.FileOperationTimeout);			

			ParseForEntities(Utility.LoadStreamReaderWithTimeout(configuration.CodeDestinationFilePath, configuration.FileOperationTimeout));
			return foundEntities;
		}

		IEnumerable<IEntity> IEntityProvider.FindEntities(IConfigurationData configurationData, IMemberFactory memberFactory)
		{
			return ((IDatabaseEntityProvider)this).FindEntities((ConnectionString)configurationData, memberFactory);
		}

		#endregion

		/// <summary>
		/// Read generated code file and parse to find entities
		/// </summary>
		/// <param name="sr"></param>
		private void ParseForEntities(StreamReader sr)
		{
			using (sr)
			{
				IEntity entity;
				List<IPropertyMember> properties = null;
				string line;

				while (!sr.EndOfStream)
				{
					line = sr.ReadLine().Trim();

					if (line.Contains("public partial class") && line.Contains(" : EntityObject"))
					{
						entity = entityFactory.Instance();
						foundEntities.Add(entity);

						string[] lineElements = line.Split(' ');
						entity.Name = lineElements[3].Trim(); // index 3 is class name                       

						properties = new List<IPropertyMember>();
						entity.Properties = properties;
					}

					// Looking for properties only. 
					// That is all we need to be able to re-build the class.

					// Look for Primitive Properties
					else if (line.Contains("public global::System.") || line.Contains("public Nullable<global::System."))
					{
						properties.Add(BuildPropertyMember(line));
					}

					// Look for Single Navigation Properties
					// This is a tough one to parse out because there is not one
					// single signifier that would allow us to know for sure that the
					// line contains a Single Navigation Property(a complex type).					
					// We must elimate all scenerios we know do not make for a Single Navigation Property.
					else if (
						line.StartsWith("public ")
						&& !line.Contains("ObjectSet<")
						&& !line.Contains("global::System.")
						&& !line.Contains("EntityReference<")
						&& !line.Contains("EntityCollection<")
						&& line.Split(' ').Length == 3)
					{
						properties.Add(BuildPropertyMember(line));
					}

					// Look for Collection Navigation Properties
					else if (line.Contains("public EntityCollection<"))
					{						
						properties.Add(BuildPropertyMember(line));
					}
				}
			}
		}

		private IPropertyMember BuildPropertyMember(string line)
		{			
			string[] lineElements = line.Split(' ');

			IPropertyMember property = memberFactory.PropertyMemberInstance(configuration.CodeType);
			property.Type = lineElements[1];
			property.Name = lineElements[2];

			IFieldMember privateField = memberFactory.FieldMemberInstance(configuration.CodeType);
			privateField.Type = lineElements[1];
			privateField.Name = lineElements[2];
			property.BackingStore = privateField;

			return property;
		}

		/// <summary>
		/// Deletes the msl, csdl, views, and object code files.
		/// </summary>
		/// <param name="edmgenManager"></param>
		private void DeleteAllFilesExceptSsdl(EdmgenManager edmgenManager)
		{
			Utility.DeleteAsyncCreatedFile(configuration.CodeDestinationFilePath, configuration.FileOperationTimeout);
			Utility.DeleteAsyncCreatedFile(edmgenManager.CsdlDestinationPath, configuration.FileOperationTimeout);
			Utility.DeleteAsyncCreatedFile(edmgenManager.MslDestinationPath, configuration.FileOperationTimeout);
			Utility.DeleteAsyncCreatedFile(edmgenManager.ViewsDestinationPath, configuration.FileOperationTimeout);
		}
	}
}
