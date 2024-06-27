using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using VisualVault.Forms.Import.BusinessLogic;
using VisualVault.Forms.Import.Entities;
using VisualVault.Forms.Import.Entities.Profiles;
using VisualVault.Forms.Import.UI;
using VVRestApi.Vault;
using VVRestApi.Vault.Forms;
using VVRestApi.Vault.Library;
using Form = System.Windows.Forms.Form;

namespace VisualVault.Forms.Import
{
    public partial class ImportFormData : Form
    {

        #region Fields

        //private Vault _vault;

        private VaultApi _vault;

        private FormTemplate _selectedFormTemplate;

        //private FormDashboard _selectedFormDashboard;

        private FormImportActionType _actionType;

        private string _csvFilePath;

        private string _exportFilePath;

        private FormImportEngine _importEngine;

        private FormExportEngine _exportEngine;

        private Profiles _profiles;

        private Profile _profile;

        private string _serverCulture;

        private CancellationToken _cancellationToken = new CancellationToken();

        private string _newUserEmailField;

        private string _newUserIdField;

        private string _newUserSiteField;

        private string _newUserAccountFormFilter;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ImportFormData()
        {
            InitializeComponent();

            _actionType = FormImportActionType.GetTemplateList;

            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
            tabPage5.Enabled = false;           

            ShowFirstProfile();

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = string.Format("Version {0}", version);
        }

        #region Event Handlers

        void OnImportProgressChanged(object sender, ProgressChangedArgs args)
        {

            switch (args.ImportStatus)
            {
                case ProgressStatus.Starting:
                    var step = args.TotalItems > 0 ? 100 / args.TotalItems : 0;
                    Invoke((Action)(() => progressBar1.Step = step));
                    break;
                case ProgressStatus.Processing:
                    Invoke((Action)(() => progressBar1.PerformStep()));
                    break;
                case ProgressStatus.Completed:
                    Invoke((Action)(() => progressBar1.Value = 100));
                    Invoke((Action)(() => btnImport.Text = "Start Import"));
                    Invoke((Action)(Application.DoEvents));
                    break;
            }

            Invoke((Action)(() => progressBar1.Text = args.ProgressMessage));

            if (!string.IsNullOrEmpty(args.ErrorMessage))
            {
                Invoke((Action)(() => txtErrors.Text = txtErrors.Text + Environment.NewLine + Environment.NewLine + args.ProgressMessage));
                Invoke((Action)(Application.DoEvents));
            }
        }

        void OnExportProgressChanged(object sender, ProgressChangedArgs args)
        {
            switch (args.ImportStatus)
            {
                case ProgressStatus.Starting:
                    var step = 100 / args.TotalItems;
                    Invoke((Action)(() => progressBar1.Step = step));
                    break;
                case ProgressStatus.Processing:
                    Invoke((Action)(() => progressBar1.PerformStep()));
                    break;
                case ProgressStatus.Completed:
                    Invoke((Action)(() => progressBar1.Value = 100));
                    Application.DoEvents();
                    break;
            }

            Invoke((Action)(() => progressBar1.Text = args.ProgressMessage));

            if (!string.IsNullOrEmpty(args.ErrorMessage))
            {
                Invoke((Action)(() => MessageBox.Show(args.ErrorMessage, "Error", MessageBoxButtons.OK)));
            }
        }

        private void btnCreateUserAccounts_Click(object sender, EventArgs e)
        {
            var createUsersFormTemplate = (FormTemplate)cboCreateUserFormTemplates.SelectedItem;

            _newUserEmailField = (string)cboCreateUserEmailField.SelectedText;
            _newUserIdField = (string)cboCreateUserUserIdField.SelectedText;
            _newUserSiteField = (string)cboCreateUserSiteField.SelectedText;
            _newUserAccountFormFilter = txtCreateUserApiFilter.Text;

            if (createUsersFormTemplate != null)
            {
                _actionType = FormImportActionType.CreateUserAccountsUsingFormRecords;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Please select a form template", "Error", MessageBoxButtons.OK);
            }
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            _actionType = FormImportActionType.Authenticate;
            backgroundWorker1.RunWorkerAsync();
        }

        private void BtnImportClick(object sender, EventArgs e)
        {
            if (_selectedFormTemplate != null)
            {
                _csvFilePath = txtFilePath.Text;

                if (File.Exists(_csvFilePath))
                {
                    if (txtDelimeter.Text.Length > 0)
                    {
                        _actionType = FormImportActionType.ImportForms;
                        if (!backgroundWorker1.IsBusy)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Missing Delimeter Character", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a csv file for import", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please select a form template", "Error", MessageBoxButtons.OK);
            }

        }

        private void BtnDeleteAllClick(object sender, EventArgs e)
        {
            var deleteFromTemplate = (FormTemplate)cboDeleteFormTemplates.SelectedItem;

            if (deleteFromTemplate != null)
            {
                _actionType = FormImportActionType.DeleteAll;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Please select a form template", "Error", MessageBoxButtons.OK);
            }

        }

        private void CboFormTemplatesSelectedIndexChanged(object sender, EventArgs e)
        {
            var template = (FormTemplate)cboFormTemplates.SelectedItem;

            //must get the latest released template version
            _selectedFormTemplate = _vault.FormTemplates.GetFormTemplate(template.Id);
        }

        private void BtnSelectFileClick(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files(*.csv)|*.csv|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.ShowDialog();
        }

        private void BtnSelectExportFileClick(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.ShowDialog();
        }

        private void BtnFetchTemplatesClick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _actionType = FormImportActionType.GetTemplateList;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Busy processing another task, please wait...");
            }
        }

        private void btnFetchDeleteTemplates_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _actionType = FormImportActionType.GetDeletedTemplatesList;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Busy processing another task, please wait...");
            }
        }

        private void btnFetchCreateUserTemplates_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _actionType = FormImportActionType.GetCreateUserTemplateList;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                //MessageBox.Show("Busy processing another task, please wait...");
            }
        }

        private void OpenFileDialog1FileOk(object sender, CancelEventArgs e)
        {
            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void SaveFileDialog1FileOk(object sender, CancelEventArgs e)
        {
            txtExportFilePath.Text = saveFileDialog1.FileName;
        }

        private void BtnFetchDashboardsClick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _actionType = FormImportActionType.GetFormDashboardList;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Busy processing another task, please wait...");
            }
        }

        private void BtnExportClick(object sender, EventArgs e)
        {
            //if (_selectedFormDashboard != null)
            //{
            //    _exportFilePath = txtExportFilePath.Text;

            //    if (Path.HasExtension(_exportFilePath))
            //    {
            //        _actionType = FormImportActionType.ExportFormDashboard;
            //        backgroundWorker1.RunWorkerAsync();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please select a target csv file for the export", "Error", MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a Form Dashboard", "Error", MessageBoxButtons.OK);
            //}
        }

        private void CboFormDashboardsSelectedIndexChanged(object sender, EventArgs e)
        {
            //_selectedFormDashboard = (FormDashboard)cboFormDashboards.SelectedItem;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (ShutDownAndSave())
            {
                Application.Exit();
            }
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            Form frm = new FrmAbout();
            frm.ShowDialog();
        }

        private void CboProfilesSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfileByName(cboProfiles.SelectedItem.ToString());
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveProfileAs();
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (cboProfiles.SelectedItem == null)
            {
                SaveProfileAs();
            }
            else if (string.IsNullOrEmpty(cboProfiles.SelectedItem.ToString()))
            {
                SaveProfileAs();
            }
            else
            {
                SaveProfile(cboProfiles.SelectedItem.ToString(), true);
            }
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveProfileAs();
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            DeleteCurrentProfile();
        }

        private void ImportFormDataFormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.MdiFormClosing:
                case CloseReason.None:
                case CloseReason.FormOwnerClosing:
                case CloseReason.UserClosing:
                    if (ShutDownAndSave())
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void clearErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtErrors.Text = "";
        }

        private void cboCreateUserFormTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                _actionType = FormImportActionType.PopulateCreateUserTemplateFields;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        #endregion

        #region Methods

        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            switch (_actionType)
            {
                case FormImportActionType.Authenticate:
                    AuthenticateWithVault();
                    break;
                case FormImportActionType.GetTemplateList:
                    PopulateFormTemplates();
                    break;
                case FormImportActionType.GetDeletedTemplatesList:
                    PopulateDeletionFormTemplates();
                    break;
                case FormImportActionType.GetCreateUserTemplateList:
                    PopulateCreateUsersFormTemplates();
                    break;
                case FormImportActionType.PopulateCreateUserTemplateFields:
                    PopulateCreateUsersFormTemplateFields();
                    break;
                case FormImportActionType.ImportForms:
                    ImportData();
                    break;
                case FormImportActionType.GetFormDashboardList:
                    PopulateFormDashboards();
                    break;
                case FormImportActionType.ExportFormDashboard:
                    ExportData();
                    break;
                case FormImportActionType.DeleteAll:
                    DeleteAllForms();
                    break;
                case FormImportActionType.CreateUserAccountsUsingFormRecords:
                    CreateUserAccounts();
                    break;
            }
        }

        private void AuthenticateWithVault()
        {
            string resultMessage;

            Invoke((Action)(() => progressBar1.Value = 0));
            Invoke((Action)(() => uxAuthStatus.Text = "Attempting login..."));
            Invoke((Action)(() => progressBar1.Text = "Attempting login..."));

            try
            {

                var authenticationResult = Authentication.AuthenticateUser(uxAuthUserID.Text, uxAuthPassword.Text,
                    uxAuthServerUrl.Text, uxAuthCustomerAlias.Text, uxAuthDbAlias.Text);

                if (authenticationResult.IsAuthenticated)
                {
                    Invoke((Action)(() => uxAuthStatus.ForeColor = Color.Green));

                    _vault = authenticationResult.Vault;

                    //_serverCulture = _vault.Configurations.GetConfigurationSetting("CurrentCulture").Replace("_","-");

                    resultMessage = string.Format("Logged In");

                    Invoke((Action)(() => uxAuthStatus.Text = resultMessage));

                    if (_profile != null)
                    {
                        Invoke((Action)(() => SelectFormTemplate(_profile.ImportFormTemplateName)));

                        Invoke((Action)(() => SelectFormDashboard(_profile.ExportFormDashboardName)));
                    }

                    Invoke((Action)(() => tabControl1.SelectedTab = tabPage2));

                    Invoke((Action)(EnableAllControls));

                    Application.DoEvents();
                }
                else
                {
                    Invoke((Action)(() => uxAuthStatus.ForeColor = Color.Red));
                    _vault = null;
                    resultMessage = "Login Failed";
                }

                Invoke((Action)(() => progressBar1.Text = resultMessage));
                Invoke((Action)(() => uxAuthStatus.Text = resultMessage));

            }
            catch (Exception ex)
            {
                Invoke((Action)(() => progressBar1.Text = string.Format("Authentication error {0}", ex.Message)));
                Invoke((Action)(() => uxAuthStatus.Text = string.Format("Authentication error {0}", ex.Message)));
            }
        }

        private void EnableAllControls()
        {
            tabPage2.Enabled = true;
            tabPage3.Enabled = true;
            tabPage5.Enabled = true;            
        }

        private void SelectFormTemplate(string formTemplateName)
        {
            try
            {
                if (_vault != null)
                {
                    var i = cboFormTemplates.FindStringExact(formTemplateName);

                    if (i < 0)
                    {
                        PopulateFormTemplates();
                        i = cboFormTemplates.FindStringExact(formTemplateName);
                    }

                    if (i >= 0)
                    {
                        cboFormTemplates.SelectedIndex = i;
                    }

                    var template = (FormTemplate)cboFormTemplates.SelectedItem;

                    //must get the latest released template version
                    _selectedFormTemplate = _vault.FormTemplates.GetFormTemplate(template.Id);
                }
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => progressBar1.Text = ex.Message));
            }
        }

        private void SelectFormDashboard(string formDashBoardName)
        {
            //try
            //{
            //    if (_vault != null)
            //    {
            //        var i = cboFormDashboards.FindStringExact(formDashBoardName);

            //        if (i < 0)
            //        {
            //            PopulateFormDashboards();
            //            i = cboFormDashboards.FindStringExact(formDashBoardName);
            //        }

            //        if (i >= 0)
            //        {
            //            cboFormDashboards.SelectedIndex = i;
            //        }

            //        _selectedFormDashboard = (FormDashboard)cboFormDashboards.SelectedItem;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Invoke((Action)(() => progressBar1.Text = ex.Message));
            //}
        }

        private void PopulateFormTemplates()
        {
            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = "Fetching Form Templates..."));

            Application.DoEvents();

            var templates = _vault.FormTemplates.GetFormTemplates().Items;

            string resultMessage;

            if (templates != null)
            {
                resultMessage = string.Format("{0} Form templates found", templates.Count());

                //Invoke((Action)(() => cboFormTemplates.Items.Clear()));

                Invoke((Action)(() => cboFormTemplates.DisplayMember = "Name"));

                Invoke((Action)(() => cboFormTemplates.DataSource = templates));
            }
            else
            {
                resultMessage = "No form templates found";
            }

            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = resultMessage));

            Application.DoEvents();
        }

        private void PopulateDeletionFormTemplates()
        {
            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = "Fetching Form Templates..."));

            Application.DoEvents();

            var templates = _vault.FormTemplates.GetFormTemplates().Items;

            string resultMessage;

            if (templates != null)
            {
                resultMessage = string.Format("{0} Form templates found", templates.Count());

                Invoke((Action)(() => cboDeleteFormTemplates.Items.Clear()));

                Invoke((Action)(() => cboDeleteFormTemplates.DisplayMember = "Name"));

                Invoke((Action)(() => cboDeleteFormTemplates.DataSource = templates));
            }
            else
            {
                resultMessage = "No form templates found";
            }

            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = resultMessage));

            Application.DoEvents();
        }

        private void PopulateCreateUsersFormTemplates()
        {
            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = "Fetching Form Templates..."));

            Application.DoEvents();

            var templates = _vault.FormTemplates.GetFormTemplates().Items;

            string resultMessage;

            if (templates != null)
            {
                resultMessage = string.Format("{0} Form templates found", templates.Count());

                Invoke((Action)(() => cboCreateUserFormTemplates.Items.Clear()));

                Invoke((Action)(() => cboCreateUserFormTemplates.DisplayMember = "Name"));

                Invoke((Action)(() => cboCreateUserFormTemplates.DataSource = templates));

                Invoke((Action)(() => cboCreateUserFormTemplates.Items.Add("Select Form Template")));
            }
            else
            {
                resultMessage = "No form templates found";
            }

            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = resultMessage));

            Application.DoEvents();
        }

        private void PopulateCreateUsersFormTemplateFields()
        {
            try
            {
                FormTemplate createUsersFormTemplate = null;

                Invoke((Action)(() =>
                {
                    btnImport.Text = "Processing...";

                    progressBar1.Value = 0;

                    Application.DoEvents();

                    createUsersFormTemplate = (FormTemplate)cboCreateUserFormTemplates.SelectedItem;

                    if (createUsersFormTemplate != null)
                    {
                        cboCreateUserUserIdField.Items.Clear();
                        cboCreateUserEmailField.Items.Clear();
                        cboCreateUserSiteField.Items.Clear();

                        foreach (KeyValuePair<string, string> formField in createUsersFormTemplate.GetFormFields().Fields)
                        {
                            cboCreateUserUserIdField.Items.Add(formField.Key);
                            cboCreateUserEmailField.Items.Add(formField.Key);
                            cboCreateUserSiteField.Items.Add(formField.Key);
                        }
                    }
                }));

            }
            catch (Exception ex)
            {
                Invoke((Action)(() => MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace))));
                Invoke((Action)(() => btnImport.Text = "Start Delete"));
            }
        }

        private void CreateUserAccounts()
        {
            try
            {
                FormTemplate createUsersFormTemplate = null;

                Invoke((Action)(() =>
                {
                    btnImport.Text = "Processing...";

                    progressBar1.Value = 0;

                    _profile = BuildFormProfile();

                    Application.DoEvents();

                    createUsersFormTemplate = (FormTemplate)cboCreateUserFormTemplates.SelectedItem;

                }));

                if (createUsersFormTemplate != null)
                {
                    _importEngine = new FormImportEngine(_csvFilePath, _vault, _selectedFormTemplate, _profile);

                    _importEngine.OnProgressChanged += OnImportProgressChanged;

                    _importEngine.CreateUserAccountsUsingFormInstances(createUsersFormTemplate, _newUserIdField,
                        _newUserEmailField, _newUserSiteField, _newUserAccountFormFilter, _cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace))));
                Invoke((Action)(() => btnImport.Text = "Start Delete"));
            }
        }

        private void PopulateFormDashboards()
        {
            //Invoke((Action)(() => progressBar1.Value = 0));

            //Invoke((Action)(() => progressBar1.Text = "Fetching Form Dashboards..."));

            //Application.DoEvents();

            //var dashboards = _vault.Forms.GetFormDashboards();

            //string resultMessage;

            //if (dashboards != null)
            //{
            //    resultMessage = string.Format("{0} Form Dashboards found", dashboards.Count);

            //    Invoke((Action)(() => cboFormDashboards.DisplayMember = "FormDashboardName"));

            //    Invoke((Action)(() => cboFormDashboards.DataSource = dashboards));
            //}
            //else
            //{
            //    resultMessage = "No Form Dashboards found";
            //}

            //Invoke((Action)(() => progressBar1.Value = 0));

            //Invoke((Action)(() => progressBar1.Text = resultMessage));

            //Application.DoEvents();
        }

        private void ImportData()
        {
            try
            {
                Invoke((Action)(() => btnImport.Text = "Processing..."));

                Invoke((Action)(() => progressBar1.Value = 0));

                Application.DoEvents();

                _profile = BuildFormProfile();

                _importEngine = new FormImportEngine(_csvFilePath, _vault, _selectedFormTemplate, _profile);

                _importEngine.OnProgressChanged += OnImportProgressChanged;

                _importEngine.ImportFormDataFromCsvFile();
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace))));
                Invoke((Action)(() => btnImport.Text = "Start Import"));
            }
        }

        private void DeleteAllForms()
        {
            try
            {
                FormTemplate deleteFromTemplate = null;

                Invoke((Action)(() =>
                {
                    btnImport.Text = "Processing...";

                    progressBar1.Value = 0;

                    Application.DoEvents();

                    _profile = BuildFormProfile();

                    _importEngine = new FormImportEngine(_csvFilePath, _vault, _selectedFormTemplate, _profile);

                    _importEngine.OnProgressChanged += OnImportProgressChanged;

                    deleteFromTemplate = (FormTemplate)cboDeleteFormTemplates.SelectedItem;
                }));

                if (deleteFromTemplate != null)
                {
                    _importEngine.DeleteFormInstances(deleteFromTemplate, _cancellationToken);
                }

            }
            catch (Exception ex)
            {
                Invoke((Action)(() => MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace))));
                Invoke((Action)(() => btnImport.Text = "Start Delete"));
            }
        }

        private void ExportData()
        {
            Invoke((Action)(() => progressBar1.Value = 0));

            Invoke((Action)(() => progressBar1.Text = "Starting form data export..."));

            Application.DoEvents();

            //_exportEngine = new FormExportEngine(_exportFilePath, _selectedFormDashboard);

            //_exportEngine.OnProgressChanged += OnExportProgressChanged;

            //_exportEngine.ExportFormData();
        }

        private static bool ShutDownAndSave()
        {
            return true;

            //var closeApplication = true;

            //var diagResult = MessageBox.Show("Save Profile configuration?", "Save Profile",
            //                                 MessageBoxButtons.YesNoCancel);
            //switch (diagResult)
            //{
            //    case DialogResult.Yes:
            //        SaveProfile(_profile.Name, true);
            //        closeApplication = true;
            //        break;
            //    case DialogResult.No:
            //        closeApplication = true;
            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //}

            //return closeApplication;
        }

        #endregion

        #region Profiles

        private void SaveProfile(string profileName, bool overwrite)
        {
            try
            {
                var myProfile = BuildFormProfile(profileName);

                myProfile.Name = profileName;

                var saveStatus = ProfileHandler.SaveProfile(_profiles, myProfile, overwrite);

                if (saveStatus.Successful)
                {
                    _profiles = saveStatus.Profiles;
                    _profile = _profiles.GetByName(profileName);
                    BindProfiles(profileName);
                }


                if (saveStatus.Successful)
                {
                    MessageBox.Show(saveStatus.Message, "Saved Profile", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(saveStatus.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private void SaveProfileAs()
        {
            var newProfileName = Interaction.InputBox("Enter a profile name", "Save As", string.Empty).Trim();

            if (newProfileName != string.Empty)
            {
                if (Regex.IsMatch(newProfileName, @"[\(|\)|\\|/|:|*|?|""|<|>|\|]"))
                // checks for invalid characters: ( ) \ / : * ? " < > |
                {
                    MessageBox.Show(@"A profile name cannot contain: ( ) \ / : * ? "" < > |.",
                                    "Invalid Characters", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool cancelSave = false;

                    // prompt for profile overwrite if name conflict
                    if (_profiles.Exists(newProfileName))
                    {
                        cancelSave = true;

                        var diag =
                            MessageBox.Show("A profile with the provided name already exists. Overwrite?", "Overwrite?",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2);
                        if (diag == DialogResult.Yes)
                        {
                            cancelSave = false;
                        }
                    }

                    if (!cancelSave)
                    {
                        SaveProfile(newProfileName, true);
                    }
                }
            }
        }

        private Profile BuildFormProfile(string newProfileName = "")
        {
            var profile = new Profile
            {
                Username = uxAuthUserID.Text,
                Password = uxAuthPassword.Text,
                ServerUrl = uxAuthServerUrl.Text,
                ImportCsvSourcePath = txtFilePath.Text,
                ExportCsvTargetPath = txtExportFilePath.Text,
                CsvHeadersQuoted = chkCsvHeadersQuoted.Checked,
                CsvLineItemsQuoted = chkCsvLinesQuoted.Checked,
                CsvDelimeterCharacter = txtDelimeter.Text,
                AllowUpdate = chkAllowUpdate.Checked,
                DateTimeFormat = txtDateTimeFormat.Text,
                CustomerAlias = uxAuthCustomerAlias.Text,
                DatabaseAlias = uxAuthDbAlias.Text

            };

            if (_selectedFormTemplate != null)
            {
                profile.ImportFormTemplateName = _selectedFormTemplate.Name;
            }

            //if (_selectedFormDashboard != null)
            //{
            //    profile.ExportFormDashboardName = _selectedFormDashboard.FormDashboardName;
            //}

            if (!string.IsNullOrEmpty(newProfileName))
            {
                profile.Name = newProfileName;
            }
            else
            {
                Invoke((Action)(() => profile.Name = cboProfiles.SelectedItem.ToString()));
            }

            return profile;
        }

        private void ShowFirstProfile()
        {
            ShowFirstProfile(string.Empty);
        }

        private void ShowFirstProfile(string name)
        {
            // Init the profiles and bind them
            _profiles = ProfileHandler.LoadProfiles();

            if (_profiles.Items.Count == 0)
            {
                _profiles.Add(ProfileHandler.CreateNew());
            }

            BindProfiles("");

            Application.DoEvents();

            LoadProfileByName(name);

        }

        private void LoadProfileByName(string name)
        {
            try
            {
                if (_profiles != null)
                {
                    // load the appropiate profile
                    _profile = name == String.Empty
                                   ? _profiles.Items[0]
                                   : ProfileHandler.GetProfileByName(_profiles, name);

                    if (_profile != null)
                    {
                        //select the profile in the drop down list
                        cboProfiles.SelectedValue = _profile.Name;

                        uxAuthServerUrl.Text = _profile.ServerUrl;
                        uxAuthUserID.Text = _profile.Username;
                        uxAuthPassword.Text = _profile.Password;
                        txtFilePath.Text = _profile.ImportCsvSourcePath;
                        txtExportFilePath.Text = _profile.ExportCsvTargetPath;
                        SelectFormTemplate(_profile.ImportFormTemplateName);
                        SelectFormDashboard(_profile.ExportFormDashboardName);
                        chkCsvHeadersQuoted.Checked = _profile.CsvHeadersQuoted;
                        chkCsvLinesQuoted.Checked = _profile.CsvLineItemsQuoted;
                        chkAllowUpdate.Checked = _profile.AllowUpdate;
                        uxAuthCustomerAlias.Text = _profile.CustomerAlias;
                        uxAuthDbAlias.Text = _profile.DatabaseAlias;

                        if (!string.IsNullOrEmpty(_profile.CsvDelimeterCharacter))
                        {
                            txtDelimeter.Text = _profile.CsvDelimeterCharacter;
                        }

                        if (!string.IsNullOrEmpty(_profile.DateTimeFormat))
                        {
                            txtDateTimeFormat.Text = _profile.DateTimeFormat;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private void LoadSelectedProfile()
        {
            try
            {
                if (_profile != null)
                {
                    uxAuthServerUrl.Text = _profile.ServerUrl;
                    uxAuthUserID.Text = _profile.Username;
                    uxAuthPassword.Text = _profile.Password;
                    txtFilePath.Text = _profile.ImportCsvSourcePath;
                    txtExportFilePath.Text = _profile.ExportCsvTargetPath;
                    SelectFormTemplate(_profile.ImportFormTemplateName);
                    SelectFormDashboard(_profile.ExportFormDashboardName);
                    chkCsvHeadersQuoted.Checked = _profile.CsvHeadersQuoted;
                    chkCsvLinesQuoted.Checked = _profile.CsvLineItemsQuoted;
                    chkAllowUpdate.Checked = _profile.AllowUpdate;

                    if (!string.IsNullOrEmpty(_profile.CsvDelimeterCharacter))
                    {
                        txtDelimeter.Text = _profile.CsvDelimeterCharacter;
                    }

                    if (!string.IsNullOrEmpty(_profile.DateTimeFormat))
                    {
                        txtDateTimeFormat.Text = _profile.DateTimeFormat;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private void BindProfiles(string selectedProfileName)
        {
            //clear the controls
            cboProfiles.Items.Clear();

            _profiles.Items.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));

            foreach (var profile in _profiles.Items)
            {
                cboProfiles.Items.Add(profile.Name);
            }

            if (!string.IsNullOrEmpty(selectedProfileName))
            {
                var i = cboProfiles.FindStringExact(selectedProfileName);

                if (i >= 0)
                {
                    cboProfiles.SelectedIndex = i;
                }
            }
            else
            {
                cboProfiles.SelectedIndex = 0;
            }
        }

        private void DeleteCurrentProfile()
        {
            var dialogResult = MessageBox.Show("Delete the current Profile?", "Delete Profile", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                ProfileHandler.DeleteProfile(_profiles, _profile, true);

                ShowFirstProfile();
            }
        }



        #endregion

        #region Treeview

        private Guid _selectedFolderId;
        private Folder _selectedFolder;

        private void InitializeTreeview()
        {
            if (_vault != null)
            {
                TreeView1.Nodes.Clear();

                var topLevelFolders = _vault.Folders.GetTopLevelFolders();

                VvTreeNode node;
                foreach (var folder in topLevelFolders)
                {
                    node = new VvTreeNode(folder.Id, folder.Name);
                    node.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                    TreeView1.Nodes.Add(node);
                }

                if (TreeView1.GetNodeCount(false) > 0)
                {
                    if (_selectedFolderId.Equals(Guid.Empty))
                    {
                        node = (VvTreeNode) TreeView1.Nodes[0];
                        if (node != null)
                        {
                            TreeView1.SelectedNode = node;
                            LoadChildTreeNodes(node);
                            _selectedFolder = _vault.Folders.GetFolderByFolderId(node.NodeId);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not logged in to the Target VisualVault Server", "Error", MessageBoxButtons.OK);
            }
        }

        private void LoadChildTreeNodes(VvTreeNode node)
        {
            VvTreeNode childnode;
            if (node.GetNodeCount(true) == 1)
            {
                childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeId))
                {
                    node.Nodes.Remove(childnode);
                }
            }

            var childFolders = _vault.Folders.GetChildFolders(node.NodeId);

            foreach (var folder in childFolders)
            {
                childnode = new VvTreeNode(folder.Id, folder.Name);
                childnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                node.Nodes.Add(childnode);
            }
            
            node.Expand();
        }

        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = (VvTreeNode)e.Node;
            if (node.GetNodeCount(true) == 1)
            {
                var childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeId))
                {
                    node.Nodes.Remove(childnode);
                    LoadChildTreeNodes(node);
                }
            }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                var node = (VvTreeNode)e.Node;
                if (node != null && _vault != null)
                {
                    _selectedFolderId = node.NodeId;
                    _selectedFolder = _vault.Folders.GetFolderByFolderId(node.NodeId);

                    lblFolderPath.Text = _selectedFolder.FolderPath;

                    var securityMembers = _vault.Folders.GetFolderSecurityMembers(_selectedFolderId);
                    BindSecurityMembersListView(securityMembers);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void BindSecurityMembersListView(List<SecurityMember> securityMembers)
        {
            listViewSecurityMembers.Items.Clear();
            foreach (SecurityMember securityMember in securityMembers)
            {
                var lvi = new MyListViewItem(securityMember.Id, securityMember.MemberName) { Checked = false };
                lvi.SubItems.Add(securityMember.MemberRoleValue);
                lvi.SubItems.Add(securityMember.MemberType.ToString());
                
                listViewSecurityMembers.Items.Add(lvi);
                //if (_selectedDocument != null)
                //{
                //    if (doc.DocID.ToLower() == _selectedDocument.DocID.ToLower())
                //    {
                //        lvi.Selected = true;
                //        lvi.BackColor = SystemColors.Highlight;
                //        lvi.ForeColor = SystemColors.HighlightText;
                //    }
                //}
            }

            Application.DoEvents();
        }

        private void InitializSecurityMembersListView()
        {
            listViewSecurityMembers.Columns.Clear();
            listViewSecurityMembers.View = View.Details;
            listViewSecurityMembers.LabelEdit = false;
            listViewSecurityMembers.AllowColumnReorder = true;
            listViewSecurityMembers.CheckBoxes = false;
            listViewSecurityMembers.FullRowSelect = true;
            listViewSecurityMembers.GridLines = false;
            listViewSecurityMembers.Sorting = SortOrder.Ascending;
            listViewSecurityMembers.Columns.Add("DocID", 122, HorizontalAlignment.Right);
            listViewSecurityMembers.Columns.Add("Description", 150, HorizontalAlignment.Left);
            listViewSecurityMembers.Columns.Add("Rev", 40, HorizontalAlignment.Left);
        }


        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

     
        private void lblFolderPath_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadFolders_Click(object sender, EventArgs e)
        {
            InitializeTreeview();
        }

        #endregion
    }
}
