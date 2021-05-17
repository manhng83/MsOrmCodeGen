using System;
using System.Diagnostics;
using Jodo.CodeGenerator.Core.Entities.Provider.Database;
using Jodo.CodeGenerator.Core.Generator;

namespace Jodo.CodeGenerator.SqlMetalEntityProvider
{
    internal class SqlMetalManager
    {
        private string sqlMetalExePath;
		private ConnectionString connectionString;
		private IConfiguration configuration;
		
		public SqlMetalManager(string sqlMetalExePath, ConnectionString connectionString, IConfiguration configuration)
        {
            this.sqlMetalExePath = sqlMetalExePath;
			this.connectionString = connectionString;
			this.configuration = configuration;
        }      

        public void Generate()
        {
            Process();
        }

        private void Process()
        {			
			ProcessStartInfo processStartInfo = new ProcessStartInfo(sqlMetalExePath, BuildCommandArgs());
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.RedirectStandardOutput = true;		

			using (Process process = new Process())
			{				
				process.StartInfo = processStartInfo;
				process.Start();				

				string message = String.Empty;
				while (!process.HasExited)
					message += process.StandardOutput.ReadToEnd(); 

				process.WaitForExit();

				if (message.ToLower().Contains("error"))
					throw new Exception(message);
			}					
        }

        private string BuildCommandArgs()
        {
            string args = String.Format("/server:{0} /database:{1} /code:{2} /map:{3} /views /namespace:{4}",
               connectionString.ServerName,
               connectionString.DatabaseName,
			   "\"" + configuration.CodeDestinationFilePath + "\"",
			   "\"" + configuration.CodeMetaDataDestinationFilePath + "\"",
			   configuration.NameSpace);

            if (!String.IsNullOrEmpty(connectionString.Username))
                args += String.Format(" /user:{0}", connectionString.Username);

            if (!String.IsNullOrEmpty(connectionString.Password))
                args += String.Format(" /password:{0}", connectionString.Password);

            return args;
        }		
    }
}
