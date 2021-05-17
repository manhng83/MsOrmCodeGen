using System;
using System.Data.Metadata.Edm;

namespace Northwind.Entity
{
	/// <remarks>
	/// This class is intended to support the <see cref="Northwind.Entity.ObjectContext"/>
	/// specifically. If you needed another type of ObjectContext in your project, another
	/// Configuration class should be created.
	/// </remarks>
	public class Configuration
	{
		private static readonly MetadataWorkspace defaultMetadataWorkspace;
	
		static Configuration()
		{
			string defaultObjectContextTypeName = typeof(Northwind.Entity.ObjectContext).AssemblyQualifiedName;		
			defaultMetadataWorkspace = SetMetadataWorkspace(defaultObjectContextTypeName);
		}

		public static string ConnectionStringName
		{
			get { return "Northwind_OrmTest"; }
		}

		public static MetadataWorkspace DefaultMetadataWorkspace
		{
			get { return defaultMetadataWorkspace; }
		}	

		private static MetadataWorkspace SetMetadataWorkspace(string objectContextTypeName)
		{
			Type defaultObjectContextType = Type.GetType(objectContextTypeName);
			return new MetadataWorkspace(new[] { "res://*/" }, new[] { defaultObjectContextType.Assembly });
		}
	}
}