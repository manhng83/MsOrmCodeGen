using System;
using System.Configuration;
using System.Globalization;

namespace Jodo.CodeGenerator.Core.Entities.Provider.Database
{
	public struct ConnectionString : IConfigurationData
    {
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
			bool integratedSecurity = true;
			if (!String.IsNullOrEmpty(Username))
				integratedSecurity = false;

			string s = string.Format("Server={0};Database={1};Integrated Security={2};", ServerName, DatabaseName, integratedSecurity);

			if (!integratedSecurity)
				s += string.Format(" User ID={0};Password={1}", Username, Password);
			return s;
        }

        public static ConnectionString InstanceFromConnectionName(string connectionStringName)
        {
            if (String.IsNullOrEmpty(connectionStringName))
                throw new ArgumentNullException("connectionStringName");

            string connString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            if (String.IsNullOrEmpty(connString))
                throw new ApplicationException("The connectionStringName did not resolve to a connection string defined in the app.config.");

            return InstanceFromConnectionString(connString);
        }

        public static ConnectionString InstanceFromConnectionString(string connString)
        {
            ConnectionString connectionString = new ConnectionString();

            string[] connectionElements = connString.Split(';');

            foreach (string s in connectionElements)
            {
                string arg = s.Trim().ToLower(CultureInfo.InvariantCulture); ;

                if (arg.StartsWith("data source", StringComparison.Ordinal) || arg.StartsWith("Server", StringComparison.Ordinal))
                {
                    connectionString.ServerName = GetElementsValue(s);
                }
                else if (arg.StartsWith("initial catalog", StringComparison.Ordinal) || arg.StartsWith("Database", StringComparison.Ordinal))
                {
                    connectionString.DatabaseName = GetElementsValue(s);
                }
                else if (arg.StartsWith("user", StringComparison.Ordinal) || arg.StartsWith("uid", StringComparison.Ordinal))
                {
                    connectionString.Username = GetElementsValue(s);
                }
                else if (arg.StartsWith("pwd", StringComparison.Ordinal))
                {
                    connectionString.Password = GetElementsValue(s);
                }
            }

            return connectionString;
        }

        private static string GetElementsValue(string element)
        {
            string[] keyValuePair = element.Trim().Split('=');
            return keyValuePair[1];
        }

		public object ConfigData { get; set; }
	}
}
