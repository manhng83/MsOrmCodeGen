using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Entities.Provider;
using Jodo.CodeGenerator.Core.Entities.Provider.Database;
using Jodo.CodeGenerator.Core.Generator;
using MsOrmCodeGen.Client.Data;

namespace MsOrmCodeGen.Client
{
	[Export]
    public partial class Manager : Form
    {
		bool canExit;	      
		private IConfiguration configuration;		
		private IMemberFactory memberFactory;
		private string selectedEntityProvider;
		private UserProvidedData userProvidedData;

		/// <remarks>
		/// ConfigData will be set with all discovered IEntityProviders. 
		/// They will be used by an EdmgenSqlMetalEntityProvider.Provider if present.
		/// </remarks>
		private ConnectionString ConnectionString
		{			
			get { return new ConnectionString() { DatabaseName = tbDatabase.Text, ServerName = tbServer.Text, Username = tbUsername.Text, Password = tbPassword.Text, ConfigData = Program.Container.GetExportedValues<IEntityProvider>() }; }
		}

		public Manager()
        {
			Program.ErrorAction = () => SetUIIdleState();

			// If a IConfiguration is provided, it will be used to capture data from the UI
			// IConfiguration object should be a singleton and will be mutated and reused as needed			
			this.configuration = Program.Container.GetExportedValueOrDefault<IConfiguration>();

			// We can only use one IMemberFactory
			IEnumerable<IMemberFactory> memberFactories = Program.Container.GetExportedValues<IMemberFactory>();
			memberFactory = memberFactories.Any() ? memberFactories.ToList()[0] : null;

            InitializeComponent();
            InitializeUI();           	
        }	

		#region Events

		private void cbEntityProviders_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedEntityProvider = (string)cbEntityProviders.SelectedValue;
		}		

		private void btnFileBrowseCode_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialogDestination.ShowDialog() == DialogResult.OK)
				tbObjectCodeFilePath.Text = folderBrowserDialogDestination.FileName;

			userProvidedData.ObjectCodeFilePath = tbObjectCodeFilePath.Text;
			SetProcessButtonsState();
		}

		private void btnFileBrowseXml_Click(object sender, EventArgs e)
		{
			if (fileBrowserDialogXmlDestination.ShowDialog() == DialogResult.OK)
				tbLinqXmlMappingFilePath.Text = fileBrowserDialogXmlDestination.FileName;

			userProvidedData.LinqXmlMappingFilePath = tbLinqXmlMappingFilePath.Text;
			SetProcessButtonsState();
		}

		private void btnEFFilesDestination_Click(object sender, EventArgs e)
		{
			if (efFilesDestinationDialog.ShowDialog() == DialogResult.OK)
				tbEntityMappingDestination.Text = efFilesDestinationDialog.SelectedPath;

			userProvidedData.EntityMappingDestination = tbEntityMappingDestination.Text;
			SetProcessButtonsState();
		}		

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			canExit = true;
			Application.Exit();         
        }

		private void cbConfigurationStores_SelectedIndexChanged(object sender, EventArgs e)
		{
			PopulateUI((ConfigurationStore)cbConfigurationStores.SelectedItem);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Sure you want to delete this configuration?", String.Empty, MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				ConfigurationStore.Delete((ConfigurationStore)cbConfigurationStores.SelectedItem);
				LoadConfigurationStores();
			}
		}

		private void Manager_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == WindowState)
				Hide();
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void Manager_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (canExit)
				return;

			Hide();
			e.Cancel = true;
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			SaveConfiguration();
			SetUIUploadState();			
			tbOutput.Visible = true;
			pcProgressIndicator.Visible = true;

			backgroundWorker.RunWorkerAsync(userProvidedData);
		}

		#endregion

		#region Background Worker

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
			if (configuration != null)
			{
				configuration.TemplateName = (string)this.Invoke(new Func<string>(() => (string)cbTemplates.SelectedValue));
				configuration.NameSpace = (string)this.Invoke(new Func<string>(() => tbNameSpace.Text.Trim()));

				UserProvidedData userProvidedData = (UserProvidedData)e.Argument;
				configuration.CodeDestinationFilePath = userProvidedData.ObjectCodeFilePath;
				configuration.CodeMetaDataDestinationFilePath = userProvidedData.LinqXmlMappingFilePath;

				if (!String.IsNullOrEmpty(userProvidedData.EntityMappingDestination))
					configuration.CodeMetaDataDestinationDirectory = new DirectoryInfo(userProvidedData.EntityMappingDestination);	
			}
				
			IEntityProvider entityProvider = Program.Container.GetExportedValues<IEntityProvider>().FirstOrDefault(c => c.Name == selectedEntityProvider);
			IEnumerable<IEntity> entities = entityProvider.FindEntities(ConnectionString, memberFactory);

			// there could be more then one ICodeGenerator depending on what is in the bin at runtime. We can only utilize one.
			ICodeGenerator codeGenerator = Program.Container.GetExportedValues<ICodeGenerator>().First();
			codeGenerator.GenerateCodeFor(entities);
			e.Result = new BackgroundWorkerResult() { Output = codeGenerator.GetCodeOutput(), Entities = entities };
        }		

		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			BackgroundWorkerResult backgroundWorkerResult = (BackgroundWorkerResult)e.Result;
			
			lbEntities.DisplayMember = "Name";
			lbEntities.DataSource = backgroundWorkerResult.Entities.ToList();

			tbOutput.Text = backgroundWorkerResult.Output;
			SetUIIdleState();		
        }

		#endregion

		#region Configurations

		private void LoadConfigurationStores()
		{
			Func<ICollection<ConfigurationStore>> selectAllOperation = () =>
			{
				try { return ConfigurationStore.SelectAll(); }
				catch
				{					
					MessageBox.Show("Please consider installing Microsoft SQL Server Compact 4.0 so your configurations can be saved.");
					return new List<ConfigurationStore>();					
				}
			};

			cbConfigurationStores.DisplayMember = "Database";
			cbConfigurationStores.DataSource = selectAllOperation();

			PopulateUI((ConfigurationStore)cbConfigurationStores.SelectedItem);
		}  

		private void SaveConfiguration()
		{
			ConfigurationStore configurationStore;

			if (cbSaveAsNew.Checked)
				configurationStore = new ConfigurationStore() { ID = Guid.NewGuid() };
			else
				configurationStore = (ConfigurationStore)cbConfigurationStores.SelectedItem;

			if (configurationStore == null)
				return;

			configurationStore.CodeFilePath = tbObjectCodeFilePath.Text;
			configurationStore.NameSpace = tbNameSpace.Text;
			configurationStore.Database = tbDatabase.Text;
			configurationStore.Password = tbPassword.Text;
			configurationStore.Server = tbServer.Text;
			configurationStore.Username = tbUsername.Text;
			configurationStore.LinqXmlMappingFilePath = tbLinqXmlMappingFilePath.Text;
			configurationStore.EntityFilesPath = tbEntityMappingDestination.Text;
			configurationStore.Template = (string)cbTemplates.SelectedValue;
			configurationStore.DateLastUsed = DateTime.Now;
			configurationStore.EntityProviderName = (string)cbEntityProviders.SelectedValue;

			try
			{
				// SqlCompact is not installed this will fail
				ConfigurationStore.Save(configurationStore);
			}
			catch { MessageBox.Show("Please consider installing Microsoft SQL Server Compact 4.0 so your configurations can be saved."); }			

			if (cbSaveAsNew.Checked)
				LoadConfigurationStores();
		}

		#endregion

		#region UI Configuration

		private void InitializeUI()
		{		
			btnGenerate.Enabled = false;
			tcMain.TabPages[0].Text = "Output";
			tcMain.TabPages[1].Text = "Entities";
			LoadTemplates();
			LoadEntityProviders();
			LoadConfigurationStores();

			// set intial state of UserProvidedData
			userProvidedData = new UserProvidedData();	
			userProvidedData.EntityMappingDestination = tbEntityMappingDestination.Text;
			userProvidedData.LinqXmlMappingFilePath = tbLinqXmlMappingFilePath.Text;
			userProvidedData.ObjectCodeFilePath = tbObjectCodeFilePath.Text;

			SetProcessButtonsState();
		}

		private void LoadEntityProviders()
		{			
			cbEntityProviders.DataSource = Program.Container.GetExportedValues<IEntityProvider>().Select(e => e.Name).Distinct().ToList();
		}

		private void LoadTemplates()
		{
			if (configuration != null)
				cbTemplates.DataSource = configuration.TemplatesDirectory.GetFiles().Select(f => f.Name).ToList();
		}

		private void PopulateUI(ConfigurationStore configurationStore)
		{
			if (configurationStore == null)
				return;

			tbObjectCodeFilePath.Text = configurationStore.CodeFilePath;
			tbNameSpace.Text = configurationStore.NameSpace;
			tbDatabase.Text = configurationStore.Database;
			tbServer.Text = configurationStore.Server;
			tbLinqXmlMappingFilePath.Text = configurationStore.LinqXmlMappingFilePath;
			tbEntityMappingDestination.Text = configurationStore.EntityFilesPath;
			tbUsername.Text = configurationStore.Username;
			tbPassword.Text = configurationStore.Password;
			cbTemplates.SelectedItem = configurationStore.Template;
			
			try { cbTemplates.SelectedItem = configurationStore.Template; }
			catch { }

			// try and set EntityProvider if available
			try { cbEntityProviders.SelectedItem = configurationStore.EntityProviderName; }
			catch { }

			// try and set Template if available
			try { cbTemplates.SelectedItem = configurationStore.Template; }
			catch { }
		}

		private void SetUIUploadState()
        {
			lbEntities.DataSource = null;
			tbOutput.Text = String.Empty;		
            btnFileBrowseCode.Enabled = false;
			btnGenerate.Enabled = false;
        }

		private void SetUIIdleState()
        {    
            btnFileBrowseCode.Enabled = true;           
			cbSaveAsNew.Checked = false;
			pcProgressIndicator.Visible = false;

			SetProcessButtonsState();
        }   

		#endregion		

		#region Classes

		private class UserProvidedData 
		{
			public string ObjectCodeFilePath { get; set; }
			public string LinqXmlMappingFilePath { get; set; }
			public string EntityMappingDestination { get; set; }	
		}

		private class BackgroundWorkerResult
		{
			public string Output { get; set; }
			public IEnumerable<IEntity> Entities { get; set; }
		}

		#endregion

		#region Validation Events

		private void tbObjectCodeFilePath_KeyUp(object sender, KeyEventArgs e)
		{
			userProvidedData.ObjectCodeFilePath = tbObjectCodeFilePath.Text;
			SetProcessButtonsState();
		}

		private void tbLinqXmlMappingFilePath_KeyUp(object sender, KeyEventArgs e)
		{
			userProvidedData.LinqXmlMappingFilePath = tbLinqXmlMappingFilePath.Text;
			SetProcessButtonsState();
		}

		private void tbEntityMappingDestination_KeyUp(object sender, KeyEventArgs e)
		{
			userProvidedData.EntityMappingDestination = tbEntityMappingDestination.Text;
			SetProcessButtonsState();
		}

		private void tbServer_KeyUp(object sender, KeyEventArgs e)
		{
			SetProcessButtonsState();
		}

		private void tbDatabase_KeyUp(object sender, KeyEventArgs e)
		{
			SetProcessButtonsState();
		}	

		private void SetProcessButtonsState()
		{			
			btnGenerate.Enabled = UIIsInValidStateToRunProcess();
		}

		private bool UIIsInValidStateToRunProcess()
		{
			Func<bool> serverCredentialsPresent = () =>
			{
				if (!String.IsNullOrEmpty(tbServer.Text) && !String.IsNullOrEmpty(tbDatabase.Text))
					return true;
				return false;
			};

			if (!String.IsNullOrEmpty(userProvidedData.ObjectCodeFilePath)
				&& (!String.IsNullOrEmpty(userProvidedData.LinqXmlMappingFilePath) || !String.IsNullOrEmpty(userProvidedData.EntityMappingDestination))
				&& serverCredentialsPresent())
				return true;
			else
				return false;
		}		

		#endregion			
	}
}
