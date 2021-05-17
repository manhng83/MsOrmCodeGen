using System;
using System.Linq;
using System.Collections.Generic;

namespace MsOrmCodeGen.Client.Data
{
	public class ConfigurationStore
	{
		public Guid ID { get; set; }
		public string NameSpace { get; set; }
		public string Server { get; set; }
		public string Database { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string CodeFilePath { get; set; }
		public string LinqXmlMappingFilePath { get; set; }
		public string EntityFilesPath { get; set; }
		public string Template { get; set; }
		public DateTime DateLastUsed { get; set; }
		public string EntityProviderName { get; set; }

		private static ObjectContext CurrentObjectContext
		{
			get { return new ObjectContextFactory().Instance(); }
		}

		public static ICollection<ConfigurationStore> SelectAll()
		{
			return CurrentObjectContext.ConfigurationStore.OrderByDescending(t => t.DateLastUsed).ToList();
		}

		public static void Save(ConfigurationStore configurationStore)
		{
			ObjectContext objectContext = CurrentObjectContext;

			if (objectContext.ConfigurationStore.Find(configurationStore.ID) == null)
				objectContext.ConfigurationStore.Add(configurationStore);	

			objectContext.SaveChanges();
		}

		public static void Delete(ConfigurationStore configurationStore)
		{
			if (configurationStore == null)
				return;

			ObjectContext objectContext = CurrentObjectContext;
			objectContext.ConfigurationStore.Remove(configurationStore);
			objectContext.SaveChanges();
		}
	}
}
