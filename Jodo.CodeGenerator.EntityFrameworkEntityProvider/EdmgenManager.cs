using System;
using System.Diagnostics;
using System.IO;
using Jodo.CodeGenerator.Core.Entities.Provider.Database;
using Jodo.CodeGenerator.Core.Generator;

namespace Jodo.CodeGenerator.EdmgenEntityProvider
{
	internal class EdmgenManager
	{
		private string edmgenExePath;
		private ConnectionString connectionString;
		private IConfiguration configuration;

		public string SsdlDestinationPath { get; private set; }
		public string CsdlDestinationPath { get; private set; }
		public string MslDestinationPath { get; private set; }
		public string ViewsDestinationPath { get; private set; }

		public EdmgenManager(string edmgenExePath, ConnectionString connectionString, IConfiguration configuration)
		{
			if(String.IsNullOrEmpty(edmgenExePath) || !File.Exists(edmgenExePath))
				throw new ApplicationException(String.Format("Edmgen.exe was not found at path {0}.", edmgenExePath));

			this.edmgenExePath = edmgenExePath;
			this.connectionString = connectionString;
			this.configuration = configuration;
		
			SsdlDestinationPath = configuration.CodeMetaDataDestinationDirectory + "\\Ssdl.ssdl";
			CsdlDestinationPath = configuration.CodeMetaDataDestinationDirectory + "\\Csdl.csdl";
			MslDestinationPath = configuration.CodeMetaDataDestinationDirectory + "\\Msl.msl";
			ViewsDestinationPath = configuration.CodeMetaDataDestinationDirectory + "\\Views.cs";
		}
		
		/// <summary>
		/// Generates Entity Framework code and mapping files.
		/// </summary>
		/// <param name="generatorMode"></param>
		public void Generate(GeneratorMode generatorMode)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(edmgenExePath, generatorMode == GeneratorMode.FullGeneration ? BuildCommandArgsForFullgeneration() : BuildCommandArgsForFromSSDLGeneration());
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

				// if there are no erros this string should be present
				if (!message.ToLower().Contains("0 errors"))
					throw new Exception(message);
			}
		}

		private string BuildCommandArgsForFullgeneration()
		{
			string args = String.Format("/mode:fullgeneration /c:\"{0}\" /project:{1} /entitycontainer:{2} /namespace:{3} /language:CSharp /outcsdl:{4} /outmsl:{5} /outssdl:{6} /outviews:{7} /outobjectlayer:{8}",
			   connectionString,
			   "ObjectContext",
			   "ObjectContextEntities",
			   configuration.NameSpace,
				"\"" + CsdlDestinationPath + "\"",
				"\"" + MslDestinationPath + "\"",
				"\"" + SsdlDestinationPath + "\"",
				"\"" + ViewsDestinationPath + "\"",
				"\"" + configuration.CodeDestinationFilePath + "\""
				);

			return args;
		}

		private string BuildCommandArgsForFromSSDLGeneration()
		{
			string args = String.Format("/mode:FromSSDLGeneration /c:\"{0}\" /project:{1} /entitycontainer:{2} /namespace:{3} /language:CSharp /outcsdl:{4} /outmsl:{5} /inssdl:{6} /outviews:{7} /outobjectlayer:{8}",
			   connectionString,
			   "ObjectContext",
			   "ObjectContextEntities",
			   configuration.NameSpace,
				"\"" + CsdlDestinationPath + "\"",
				"\"" + MslDestinationPath + "\"",
				"\"" + SsdlDestinationPath + "\"",
				"\"" + ViewsDestinationPath + "\"",
				"\"" + configuration.CodeDestinationFilePath + "\""
				);

			return args;
		}

		public enum GeneratorMode
		{
			FullGeneration ,
			FromSSDLGeneration
		}
	}
}
