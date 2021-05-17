using System;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Northwind.Linq
{
	/// <remarks>
	/// This class is intended to support the <see cref="Northwind.Linq.DataContext"/>
	/// specifically. If you needed another type of DataContext in your project, another
	/// Configuration class should be created.
	/// </remarks>
	public class Configuration
	{
		private static readonly XmlMappingSource defaultDataContextMappingFile;
		
		static Configuration()
		{
			Type dataContextType = typeof(DataContext);
			defaultDataContextMappingFile = XmlMappingSource.FromXml(GetLinqMappingSourceXml(dataContextType).ToString());			
		}

		public static XmlMappingSource DefaultDataContextMappingFile
		{
			get { return defaultDataContextMappingFile; }
		}
	
		public static string ConnectionStringName
		{
			get { return "Northwind_OrmTest"; }
		}

		private static XElement GetLinqMappingSourceXml(Type t)
		{
			XElement xelement;
			string resourceName = GetMappingSourceFileRelativePath(t);

			using (Stream stream = t.Assembly.GetManifestResourceStream(resourceName))
			{
				if (stream == null)
					throw new ArgumentNullException(String.Format("The DataContext type \"{0}\" does not contain an embedded Linq MappingSource file in its associated assembly.", t));

				using (TextReader sr = new StreamReader(stream))
				{
					xelement = XElement.Load(sr);
				}
			}

			return xelement;
		}

		private static string GetMappingSourceFileRelativePath(Type t)
		{
			string dataContextMap = t.Assembly.GetManifestResourceNames().FirstOrDefault(f => f.Contains(String.Format("{0}.xml", t.Name)));

			if (String.IsNullOrEmpty(dataContextMap))
				throw new ApplicationException(String.Format("MappingSource was not found for type {0}", t.FullName));

			return dataContextMap;
		}
	}
}