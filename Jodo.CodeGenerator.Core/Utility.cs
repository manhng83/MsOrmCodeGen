using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Jodo.CodeGenerator.Core
{
	public class Utility
	{
		public static DirectoryInfo StartUpDirectory
		{
			get
			{			
				return new DirectoryInfo(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
			}
		}

		public static string UpperCaseFirstChar(string s)
		{
			return s[0].ToString().ToUpper() + s.Substring(1);
		}

		public static void DeleteFile(string filePath)
		{
			FileInfo file = new FileInfo(filePath);

			FileStream stream = null;
			try
			{
				file.Delete();
			}			
			catch (UnauthorizedAccessException ex)
			{
				throw ex;
			}
			catch (IOException ex)
			{
				throw ex;
			}        
			finally        
			{            
				if (stream != null)                 
					stream.Close();         
			}
		}

		/// <summary>
		/// Attempts to ensure that a file created by a Async process, such as the execution
		/// of a external Process, is deleted. Since the external process will run on a seperate thread
		/// the current thread will not wait for the generated file to be completed and written.
		/// This method will wait for the file to be present before calling delete.	
		/// </summary>
		/// <param name="codeDestinationFilePath"></param>
		public static void DeleteAsyncCreatedFile(string codeDestinationFilePath, int fileOperationTimeout)
		{
			if (Utility.EnsureFileIsAvailable(codeDestinationFilePath, fileOperationTimeout))
				Utility.EnsureFileDeleted(codeDestinationFilePath, fileOperationTimeout);
		}

		public static bool EnsureFileIsAvailable(string filePath, int fileOperationTimeout)
		{			
			int currentTime = 1;

			while (!FileExists(new FileInfo(filePath)))
			{
				if (currentTime >= fileOperationTimeout)
					throw new Exception("EnsureFileIsAvailable timeout.");

				Thread.Sleep(200);
				currentTime++;
			}

			return true;
		}

		public static bool EnsureFileDeleted(string filePath, int fileOperationTimeout)
		{	
			int currentTime = 1;

			while (FileExists(new FileInfo(filePath)))
			{
				if (currentTime >= fileOperationTimeout)
					throw new Exception("EnsureFileDeleted timeout.");

				try
				{
					File.Delete(filePath);
				}
				catch { }
				
				Thread.Sleep(200);
				
				currentTime++;
			}

			return true;
		}

		/// <summary>
		/// Attempts to load a StreamReader for the provided
		/// filePath. If load fails, it will wait 200 milliseconds
		/// and try again. Total number of milliseconds that it will wait for is 40000.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static StreamReader LoadStreamReaderWithTimeout(string filePath, int fileOperationTimeout)
		{			
			int currentTime = 0;
			StreamReader sr = null;

			while (sr == null)
			{
				if (currentTime >= fileOperationTimeout)
					throw new ApplicationException(String.Format("StreamReader could not be loaded for file {0} in the allotted time of {1} milliseconds.", filePath, fileOperationTimeout));

				try
				{
					sr = new StreamReader(filePath);
				}			
				catch
				{
					// Pause to give generated file a chance to show up			
					Thread.Sleep(200);
					currentTime++;
				}
			}

			return sr;
		}

		private static bool FileExists(FileInfo file)
		{         
			FileStream stream = null;
			try
			{
				stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);			
			}
			catch (FileNotFoundException)
			{
				return false;
			}
			catch (DirectoryNotFoundException)
			{
				return false;
			}
			catch (UnauthorizedAccessException)
			{
				return true;
			}
			catch (IOException)
			{
				//the file is unavailable because it is:            
				//still being written to            
				//or being processed by another thread   
				return true;
			}        
			finally        
			{            
				if (stream != null)                 
					stream.Close();         
			}     
			   
			return true;     
		} 
	}
}
