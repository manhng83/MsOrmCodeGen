using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Jodo.CodeGenerator.Core;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Entities.Provider;
using Jodo.CodeGenerator.Core.Entities.Provider.Database;
using Jodo.CodeGenerator.Core.Generator;

namespace Jodo.CodeGenerator.SqlMetalEntityProvider
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

		public string Name { get { return "SqlMetal Entity Provider"; } }
	
		public event EventHandler GenerateCodeStart;
		public event EventHandler GenerateCodeEnd;		

		private string SqlMetalExePath
		{
			get
			{
				string path = String.Format(@"{0}\SqlMetal.exe", Utility.StartUpDirectory);
				if (!File.Exists(path))
					throw new ApplicationException(String.Format("SqlMetal.exe was not found at path {0}.", path));
				
				return path;
			}
		}

		[ImportingConstructor]
		public Provider(IConfiguration configuration, IEntityFactory entityFactory)
		{
			this.configuration = configuration;
			this.entityFactory = entityFactory;

			foundEntities = new List<IEntity>();			
		}

		#region IEntityProvider Members

		IList<IEntity> IDatabaseEntityProvider.FindEntities(ConnectionString connectionString, IMemberFactory memberFactory)
		{
			if (String.IsNullOrEmpty(configuration.CodeDestinationFilePath))
				throw new ArgumentNullException("A destination file path for the Linq To Sql's object code file must be set.");

			if (String.IsNullOrEmpty(configuration.CodeMetaDataDestinationFilePath))
				throw new ArgumentNullException("A destination file path for the Linq To Sql's mapping file must be set.");

			this.connectionString = connectionString;
			this.nameSpace = configuration.NameSpace;
			this.memberFactory = memberFactory;

			if (GenerateCodeStart != null) 
				GenerateCodeStart(this, new EventArgs());

			ExecuteSqlMetal(connectionString, configuration);	

			if (GenerateCodeStart != null) 
				GenerateCodeEnd(this, new EventArgs());

			ParseForEntities(Utility.LoadStreamReaderWithTimeout(configuration.CodeDestinationFilePath, configuration.FileOperationTimeout));		
			return foundEntities;
		}

		IEnumerable<IEntity> IEntityProvider.FindEntities(IConfigurationData configurationData, IMemberFactory memberFactory)
		{
			return ((IDatabaseEntityProvider)this).FindEntities((ConnectionString)configurationData, memberFactory);
		}

		#endregion	

		/// <summary>
		/// Will generate object code and xml mapping files. 
		/// </summary>
		public void ExecuteSqlMetal(ConnectionString connectionString, IConfiguration configuration)
		{			
			// delete all files to start
			Utility.EnsureFileDeleted(configuration.CodeDestinationFilePath, configuration.FileOperationTimeout);
			Utility.EnsureFileDeleted(configuration.CodeMetaDataDestinationFilePath, configuration.FileOperationTimeout);

			new SqlMetalManager(SqlMetalExePath, connectionString, configuration).Generate();	
		}

		/// <summary>
		/// read generated code file and parse to find entities
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

					if (line.Contains("public partial class") && !line.Contains("System.Data.Linq.DataContext"))
					{
						entity = entityFactory.Instance();
						foundEntities.Add(entity);

						string[] classElements = line.Split(' ');
						entity.Name = classElements[3].Trim(); // index 3 is class name                       

						properties = new List<IPropertyMember>();
						entity.Properties = properties;
					}

					// looking for the entities private fields only. That is all we need to be able to re-build the class.
					else if (line.Contains("private") && !line.Contains("private void") && !line.Contains("private static"))
					{
						string[] lineElements = line.Split(' ');
						IPropertyMember property = memberFactory.PropertyMemberInstance(configuration.CodeType);
						property.Type = lineElements[1];
						property.Name = lineElements[2].Replace(";", "");

						IFieldMember privateField = memberFactory.FieldMemberInstance(configuration.CodeType);
						privateField.Type = lineElements[1];
						privateField.Name = lineElements[2].Replace(";", "");

						if (privateField.Name.Contains("_@"))
						{
							// this is a special case in which the SqlMetal generator produces code with erros
							// seems to happen when the column name contains only numbers, such as "2002".
							// The SqlMetal generator will add a "@" character to the field name, the code below has solved this issue 
							// in the rare case that I encountered this. This might not work in all cases.
							privateField.Name = privateField.Name.Replace("_@", String.Empty);

							if (property.Name.Contains("@__"))
								property.Name = property.Name.Replace("@_", "_");
						}

						property.BackingStore = privateField;

						properties.Add(property);
					}
				}
			}
		}		
	}
}
