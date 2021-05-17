using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Forms;

namespace MsOrmCodeGen.Client
{
    static class Program
    {
		private static CompositionContainer container;

		public static CompositionContainer Container
		{
			get
			{
				return container ??
				(
					container = container = new CompositionContainer
					(
						new AggregateCatalog
						(
							new AssemblyCatalog(Assembly.GetExecutingAssembly()),
							new DirectoryCatalog(@".\CodeGenerator")	,						
							new DirectoryCatalog(@".\EntityProvider")
						)
					)
				);
			}
		}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			UnhandledExceptionEvents();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Manager());			
        }

		/// <summary>
		/// Delegate that can be executed on an error.
		/// </summary>
		internal static Action ErrorAction;

		private static void UnhandledExceptionEvents()
        {
			// Set the unhandled exception mode to force all Windows Forms errors to go through our handler:
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			// Add the event handler for handling non-UI thread exceptions:
			AppDomain.CurrentDomain.UnhandledException += (s, e) => MessageBox.Show("An error has occured.");

            // Add the event handler for handling UI thread exceptions to the event:
			Application.ThreadException += (s, e) =>
			{
				if (ErrorAction != null)
					ErrorAction();
				MessageBox.Show(String.Format("An error has occured. \n \n {0}", e.Exception.Message));
			};
        }	
    }
}
