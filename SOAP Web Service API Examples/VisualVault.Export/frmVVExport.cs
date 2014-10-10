using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using VVRuntime.Instances;
using VVRuntime.Instances.Customers;
using VVRuntime.Instances.Users;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Common;
using VVRuntime.VisualVault.Library;
using VVRuntime.VisualVault.Library.Documents;
using VVRuntime.VisualVault.Library.Folders;
using VVRuntime.VisualVault.Security;
using VisualVault.Examples.Common;

namespace VisualVault.Examples.Export
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class FrmVvExport : Form, ChunkingCallback
    {
        public static DocumentLibrary SourceLibrary;
        public static DocumentLibrary TargetLibrary;

        public Vault SourceVault;
        public Vault TargetVault;

        public InstanceApi SourceInstance;
        public InstanceApi TargetInstance;

        private DocumentCollection _docColl;

        private DataSet _dsErrorLog;
        private DataView _dvErrorLog;

        private int _exportedDocumentCount;
        private int _exportedFolderCount;
        private string _fsFolderPath = "";
        private Document _selectedDocument;
        private Folder _selectedFolder;
        private Guid _sourceSelectedFolderId;
        private Folder _targetVisualVaultFolder;

        private List<Group> _sourceVaultGroupList;

        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellationToken;

        public FrmVvExport()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        #region ChunkingCallback Members

        /// <summary>
        /// Progress bar initialize
        /// </summary>
        /// <param name="chunkCount"></param>
        void ChunkingCallback.BeginChunk(int chunkCount)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => lblProgress.Visible = true));
            }

            int stepSize = PROGRESSBARMAX;
            if (chunkCount > 0)
            {
                stepSize = (int)(PROGRESSBARMAX / chunkCount);
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => pbProgress.Visible = true));
                Invoke(new MethodInvoker(() => pbProgress.Minimum = 0));
                Invoke(new MethodInvoker(() => pbProgress.Maximum = PROGRESSBARMAX));
                Invoke(new MethodInvoker(() => pbProgress.Value = stepSize));
                Invoke(new MethodInvoker(() => pbProgress.Step = stepSize));
            }

            Application.DoEvents();
        }


        /// <summary>
        /// Progress bar respond to file transfer chunk event
        /// </summary>
        void ChunkingCallback.RespondToChunk()
        {
            this.Invoke(new Action(() =>
                 {
                     pbProgress.Visible = true;
                     pbProgress.PerformStep();

                 }));

            Application.DoEvents();
        }

        private const int PROGRESSBARMAX = 1000;
        /// <summary>
        /// Progress bar file transfer complete
        /// </summary>
        void ChunkingCallback.ChunkingComplete()
        {

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => pbProgress.Value = PROGRESSBARMAX));
                Invoke(new MethodInvoker(() => lblProgress.Text = string.Empty));
            }

            Application.DoEvents();
        }

        #endregion

        #region Event Handlers

        private void LvDocumentsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDocuments.SelectedItems.Count > 0)
            {
                MyListViewItem lvi = (MyListViewItem)lvDocuments.SelectedItems[0];
                Guid dhId = lvi.ListViewItemID;
                _selectedDocument = SourceVault.DefaultStore.Library.GetDocument(dhId);
            }
        }


        private void btnGetFolders_Click(object sender, EventArgs e)
        {
            if (SourceLibrary != null)
            {
                InitializeTreeview();
            }
            else
            {
                MessageBox.Show("You are not logged in");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateSourceUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);

            if (SourceLibrary != null)
            {
                InitializeTreeview();
            }
            else
            {
                MessageBox.Show("You are not logged in");
            }
        }


        private void btnExportAll_Click(object sender, EventArgs e)
        {

            _exportedDocumentCount = 0;
            _exportedFolderCount = 0;

            if (SourceLibrary != null)
            {
                if (_fsFolderPath.Length > 0)
                {
                    //export all documents found in folder
                    bool bRecursive = chkFsRecursive.Checked;

                    Thread t = new Thread(delegate()
                                                                                {

                                                                                    ExportFilesToFileSystem(_selectedFolder, _fsFolderPath, bRecursive);


                                                                                    MessageBox.Show("Processed " + _exportedFolderCount + " folders and " + _exportedDocumentCount + " documents");

                                                                                    if (InvokeRequired)
                                                                                    {
                                                                                        Invoke(new MethodInvoker(() => pbProgress.Value = 0));
                                                                                        Invoke(new MethodInvoker(() => pbProgress.Visible = false));
                                                                                        Invoke(new MethodInvoker(() => lblProgress.Text = ""));
                                                                                    }

                                                                                });
                    t.Start();



                }
                else
                {
                    MessageBox.Show("Please select a target folder path.");
                }
            }
            else
            {
                MessageBox.Show("You are not logged in");
            }


        }


        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            _exportedDocumentCount = 0;
            _exportedFolderCount = 0;

            List<Guid> dhIds = (from MyListViewItem lvi in lvDocuments.Items where lvi.Selected select lvi.ListViewItemID).ToList();

            Thread t = new Thread(delegate()
            {
                if (SourceLibrary != null)
                {
                    string fileSystemFolderPath = _fsFolderPath;

                    if (fileSystemFolderPath.Length > 0)
                    {
                        //export all documents found in folder

                        foreach (Guid dhId in dhIds)
                        {
                            try
                            {
                                Document document = SourceVault.DefaultStore.Library.GetDocument(dhId);
                                SaveDocumentFile(document, fileSystemFolderPath);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogEntry("Exception in SaveDocumentFile: " + ex.Message, "Source Document: Unknown");
                            }
                        }

                        MessageBox.Show("Processed " + _exportedDocumentCount + " documents");
                    }
                    else
                    {
                        MessageBox.Show("Please select a target folder path.");
                    }
                }
                else
                {
                    MessageBox.Show("You are not logged in");
                }

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => pbProgress.Value = 0));
                    Invoke(new MethodInvoker(() => pbProgress.Visible = false));
                    Invoke(new MethodInvoker(() => lblProgress.Text = ""));
                }

            });

            t.Start();
        }


        private void btnTargetLogin_Click(object sender, EventArgs e)
        {
            AuthenticateTargetUser(txtTargetServerURL.Text, txtTargetUserID.Text, txtTargetPassword.Text);
        }


        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            SelectTargetVisualVaultFolder();
        }


        private void BtnExportAllToUrlClick(object sender, EventArgs e)
        {
            _exportedDocumentCount = 0;
            _exportedFolderCount = 0;

            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;

            if (SourceLibrary != null)
            {
                if (TargetVault != null)
                {
                    //get list of the source folders to copy
                    List<Folder> sourceFolderList = new List<Folder>();

                    if (!chkCopyFromDocumentLibraryRoot.Checked)
                    {
                        if (_selectedFolder != null)
                        {
                            sourceFolderList.Add(_selectedFolder);
                        }
                    }
                    else
                    {
                        var topLevelFolders = SourceVault.DefaultStore.Library.GetTopLevelFolders();

                        sourceFolderList.AddRange(topLevelFolders.Cast<Folder>());
                    }

                    bool copyToDocumentLibraryRoot = chkCopyToDocumentLibraryRoot.Checked;

                    if (sourceFolderList.Count > 0)
                    {
                        if (_targetVisualVaultFolder != null || copyToDocumentLibraryRoot)
                        {
                            bool bRecursive = chkFolderRecursive.Checked;

                            TaskFactory taskFactory = new TaskFactory(_cancellationToken);

                            taskFactory.StartNew(
                                delegate
                                {
                                    Invoke(new MethodInvoker(() => btnCancel.Enabled = true));

                                    Invoke(new MethodInvoker(() => pbProgress.Value = 0));
                                    Invoke(new MethodInvoker(() => pbProgress.Visible = false));
                                    Invoke(new MethodInvoker(() => lblProgress.Text = ""));

                                    Folder targetFolder = _targetVisualVaultFolder;

                                    //problem with the instance API running in SSL mode (wcf binding),skipping this for now
                                    //SynchronizeTargetVaultUsers();

                                    foreach (Folder sourceFolder in sourceFolderList)
                                    {
                                        if (!_cancellationToken.IsCancellationRequested)
                                        {
                                            if (copyToDocumentLibraryRoot)
                                            {
                                                targetFolder =
                                                    TargetLibrary.FindFolderByPath(sourceFolder.FolderPath) ??
                                                    TargetLibrary.NewFolder(sourceFolder.Name, sourceFolder.Description);
                                            }

                                            ExportFolderToTargetUrl(sourceFolder, targetFolder, bRecursive);
                                        }
                                        else
                                        {
                                            string updateText = "Copying cancelled at path " + sourceFolder.FolderPath;

                                            var updateText1 = updateText;
                                            Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                                            Invoke(new MethodInvoker(() => btnCancel.Enabled = false));
                                        }
                                    }

                                }, _cancellationToken);
                        }
                        else
                        {
                            MessageBox.Show("No target folder is selected");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No source folder is selected");
                    }
                }
                else
                {
                    MessageBox.Show("You are not logged in to the target URL");
                }
            }
            else
            {
                MessageBox.Show("You are not logged in to the source URL");
            }
        }


        private void BtnExportSelectedToUrlClick(object sender, EventArgs e)
        {
            _exportedDocumentCount = 0;
            _exportedFolderCount = 0;

            if (SourceLibrary != null)
            {
                if (TargetVault != null)
                {
                    if (_selectedFolder != null)
                    {
                        if (_targetVisualVaultFolder != null)
                        {
                            //export selected documents found in the source folder

                            System.Threading.Thread t = new System.Threading.Thread(delegate()
                                                                                        {
                                                                                            Invoke(new MethodInvoker(delegate
                                                                                            {

                                                                                                foreach (MyListViewItem lvi in lvDocuments.Items)
                                                                                                {
                                                                                                    if (lvi.Selected)
                                                                                                    {
                                                                                                        Guid dhId = lvi.ListViewItemID;

                                                                                                        Document sourceDocument = SourceVault.DefaultStore.Library.GetDocument(dhId);

                                                                                                        ExportDocumentToTargetUrl(_selectedFolder, sourceDocument, _targetVisualVaultFolder);

                                                                                                        MessageBox.Show("Processed " + _exportedDocumentCount + " documents");

                                                                                                        lblProgress.Text = "";
                                                                                                    }
                                                                                                }
                                                                                            }));

                                                                                        });
                            t.Start();
                        }
                        else
                        {
                            MessageBox.Show("No target folder is selected");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No source folder is selected");
                    }
                }
                else
                {
                    MessageBox.Show("You are not logged in to the target URL");
                }
            }
            else
            {
                MessageBox.Show("You are not logged in to the source URL");
            }


            this.Invoke(new Action(() =>
            {
                pbProgress.Value = 0;
                pbProgress.Visible = false;

            }));
        }


        private void btnSelectFsTargetFolder_Click(object sender, EventArgs e)
        {
            _fsFolderPath = GetFolder();
            lblFsTargetFolderPath.Text = _fsFolderPath;
        }

        #endregion

        #region Logging

        private void ErrorLogEntry(string errorMessage, string sourceDocument)
        {
            //log entry is made when there is an error during processing
            //save errors to the error log

            try
            {
                //log to error log xml file
                if (_dsErrorLog != null)
                {
                    DataTable dt = null;

                    if (_dsErrorLog.Tables.Count > 0)
                    {
                        dt = _dsErrorLog.Tables[0];
                    }

                    //append a new row to the data table
                    if (dt != null)
                    {
                        DataRow dr = dt.NewRow();

                        dr["logTime"] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        dr["errorMessage"] = errorMessage;
                        dr["sourceFile"] = sourceDocument;

                        dt.Rows.Add(dr);
                    }

                    if (dt != null) dt.AcceptChanges();

                    SaveErrorLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ClearErrorLog()
        {
            DataTable dt;

            if (_dsErrorLog != null)
            {
                if (_dsErrorLog.Tables.Count > 0)
                {
                    dt = _dsErrorLog.Tables[0];

                    dt.Clear();
                    dt.AcceptChanges();
                    SaveErrorLog();
                }
            }
        }


        private void InitErrorLogDataGrid()
        {
            try
            {
                dgErrors.DataBindings.Clear();
                dgErrors.TableStyles.Clear();
                dgErrors.DataSource = _dvErrorLog;
                dgErrors.RowHeadersVisible = true;
                dgErrors.RowHeaderWidth = 20;
                dgErrors.ReadOnly = false;

                var gs = new DataGridTableStyle
                             {
                                 MappingName = "DtErrorLog",
                                 ColumnHeadersVisible = true,
                                 RowHeadersVisible = true,
                                 RowHeaderWidth = 20,
                                 ReadOnly = false
                             };

                var textCol = new DataGridTextBoxColumn
                                  {
                                      MappingName = "errorDate",
                                      HeaderText = "Time",
                                      Width = 100,
                                      ReadOnly = false,
                                      NullText = ""
                                  };
                gs.GridColumnStyles.Add(textCol);

                textCol = new DataGridTextBoxColumn
                              {
                                  MappingName = "errorMessage",
                                  HeaderText = "Error Message",
                                  Width = 500,
                                  ReadOnly = false,
                                  NullText = ""
                              };
                gs.GridColumnStyles.Add(textCol);

                textCol = new DataGridTextBoxColumn
                              {
                                  MappingName = "sourceFile",
                                  HeaderText = "Source",
                                  Width = 100,
                                  ReadOnly = false,
                                  NullText = ""
                              };
                gs.GridColumnStyles.Add(textCol);

                dgErrors.TableStyles.Add(gs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadErrorLogData()
        {
            try
            {
                _dsErrorLog = new DataSet();

                if (File.Exists(GetDataSetFileLocation("errorlog.xml")))
                {
                    _dsErrorLog.ReadXml(GetDataSetFileLocation("errorlog.xml"));
                }
                else
                {
                    //create new (empty) dataset
                    var dt = new DataTable();

                    var dc = new DataColumn("logTime", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("errorMessage", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("sourceFile", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    _dsErrorLog.Tables.Add(dt);
                }

                if (_dsErrorLog.Tables.Count > 0)
                {
                    _dsErrorLog.Tables[0].TableName = "DtErrorLog";

                    //make sure new columns exist

                    DataColumn dc = _dsErrorLog.Tables[0].Columns["logTime"];
                    if (dc == null)
                    {
                        dc = new DataColumn("logTime", Type.GetType("System.String"));
                        _dsErrorLog.Tables[0].Columns.Add(dc);
                    }

                    dc = _dsErrorLog.Tables[0].Columns["errorMessage"];
                    if (dc == null)
                    {
                        dc = new DataColumn("errorMessage", Type.GetType("System.String"));
                        _dsErrorLog.Tables[0].Columns.Add(dc);
                    }

                    dc = _dsErrorLog.Tables[0].Columns["sourceFile"];
                    if (dc == null)
                    {
                        dc = new DataColumn("sourceFile", Type.GetType("System.String"));
                        _dsErrorLog.Tables[0].Columns.Add(dc);
                    }

                    _dvErrorLog = new DataView(_dsErrorLog.Tables[0]);
                }
                else
                {
                    //create new (empty) dataset
                    var dt = new DataTable();

                    var dc = new DataColumn("logTime", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("errorMessage", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("sourceFile", Type.GetType("System.String"));
                    dt.Columns.Add(dc);

                    _dsErrorLog.Tables.Add(dt);

                    _dsErrorLog.Tables[0].TableName = "DtErrorLog";
                    _dvErrorLog = new DataView(_dsErrorLog.Tables[0]);
                }

                //create a sortable date column using the date stored in the logTime column
                if (!_dsErrorLog.Tables[0].Columns.Contains("errorDate"))
                {
                    _dsErrorLog.Tables[0].Columns.Add(new DataColumn("errorDate", Type.GetType("System.DateTime"), "logTime"));
                }


                //initialize the data grid
                InitErrorLogDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveErrorLog()
        {
            try
            {
                string datasetName = GetDataSetFileLocation("errorLog.xml");

                //make sure the xml file is not in use then serialize
                //the in-memory dataset to the xml file

                if (File.Exists(datasetName))
                {
                    while (true)
                    {
                        if (!SupportCode.IsFileInUse(datasetName))
                        {
                            //serialize the dataset to an xml file
                            if (_dsErrorLog != null && _dsErrorLog.Tables.Count > 0)
                            {
                                _dsErrorLog.WriteXml(datasetName);
                                break;
                            }
                        }

                        Thread.Sleep(2 * 1000); //2 second delay
                    }
                }
                else
                {
                    _dsErrorLog.WriteXml(datasetName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        internal static string GetDataSetFileLocation(string xmlFileName)
        {
            string configPath = typeof(FrmVvExport).Assembly.Location;
            const string delimStr = @"\";
            char[] delimiter = delimStr.ToCharArray();
            {
                string[] params1 = configPath.Split(delimiter);
                int paramCount = params1.Length;
                string fileName = params1[paramCount - 1];

                configPath = configPath.Replace(fileName, "");
            }

            return configPath + xmlFileName;
        }


        private void buttonClearErrorLog_Click(object sender, EventArgs e)
        {
            ClearErrorLog();
        }


        private void btnRefreshErrorLog_Click(object sender, EventArgs e)
        {
            LoadErrorLogData();
            InitErrorLogDataGrid();
        }

        #endregion

        /// <summary>
        /// Form load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVvExportLoad(object sender, EventArgs e)
        {
            InitializeDocumentsListView();

            LoadErrorLogData();
            InitErrorLogDataGrid();

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtTargetServerURL.Text = Constants.SoapApiTargetServerUrl;

            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;

            txtTargetUserID.Text = Constants.UserId;
            txtTargetPassword.Text = Constants.Password;

            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
        }


        /// <summary>
        /// Authenticates with the source VisualVault server
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        public void AuthenticateSourceUser(string serverUrl, string userId, string password)
        {

            this.Invoke(new Action(() =>
            {
                lblAuthStatus.Text = "Login In Progress";
                lblAuthStatus.ForeColor = Color.OrangeRed;

            }));

            SourceVault = VVRuntime.VisualVaultLogin.Login(serverUrl, userId, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            Version sourceVaultVersion = SourceVault.Configurations.GetVisualVaultVersion();

            if (sourceVaultVersion.Major >= 4)
            {
                //instance API only available in VV 4.0+
                SourceInstance = VVRuntime.InstanceLogin.Login(serverUrl, userId, password, Constants.DeveloperKey,
                    Constants.DeveloperSecret, Constants.ProductId);
            }

            if (SourceVault != null)
            {
                var user = SourceVault.Sites.GetUser(userId);

                if (user != null)
                {
                    var token = user.GetLoginToken();
                }

                SourceLibrary = SourceVault.DefaultStore.Library;


                this.Invoke(new Action(() =>
                {
                    lblAuthStatus.Text = "Logged in";
                    lblAuthStatus.ForeColor = Color.Green;
                    groupBoxSourceVault.Text = string.Format("Copy from {0}", txtServerURL.Text);

                }));

            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    lblAuthStatus.Text = "Login Failed.  Check UserID \\ Password";
                    lblAuthStatus.ForeColor = Color.Red;
                    groupBoxSourceVault.Text = "Copy from";

                }));
            }
        }


        /// <summary>
        /// Authenticates with the target VisualVault server
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        public void AuthenticateTargetUser(string serverUrl, string userId, string password)
        {
            TargetVault = VVRuntime.VisualVaultLogin.Login(serverUrl, userId, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            Version targetVaultVersion = TargetVault.Configurations.GetVisualVaultVersion();

            if (targetVaultVersion.Major >= 4)
            {
                //instance API only available in VV 4.0+
                TargetInstance = VVRuntime.InstanceLogin.Login(serverUrl, userId, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);
            }

            if (TargetVault != null)
            {
                MethodInvoker method = delegate
                                           {
                                               TargetLibrary = TargetVault.DefaultStore.Library;
                                               lblTargetAuthStatus.Text = "Logged in";
                                               lblTargetAuthStatus.ForeColor = Color.Green;
                                           };

                if (InvokeRequired)
                {
                    BeginInvoke(method);
                }
                else
                {
                    method.Invoke();
                }
            }
            else
            {
                MethodInvoker method = delegate
                                           {
                                               lblTargetAuthStatus.Text = "Login Failed.  Check UserID \\ Password";
                                               lblTargetAuthStatus.ForeColor = Color.Red;
                                           };

                if (InvokeRequired)
                {
                    BeginInvoke(method);
                }
                else
                {
                    method.Invoke();
                }
            }
        }


        /// <summary>
        /// Populates a tree view control by reading the folder heirarchy from the source VisualVault server
        /// </summary>
        private void InitializeTreeview()
        {
            VvTreeNode node;

            MethodInvoker method = delegate
                                       {
                                           TreeView1.Nodes.Clear();
                                       };

            if (InvokeRequired)
            {
                BeginInvoke(method);
            }
            else
            {
                method.Invoke();
            }


            if (SourceVault != null)
            {
                FolderCollection folderCollection = SourceVault.DefaultStore.Library.GetTopLevelFolders();
                foreach (Folder folder in folderCollection)
                {
                    node = new VvTreeNode(folder.FolderID, folder.Name);
                    node.Nodes.Add(new VvTreeNode(Guid.Empty, ""));

                    VvTreeNode node1 = node;
                    method = delegate
                                               {
                                                   TreeView1.Nodes.Add(node1);
                                               };

                    if (InvokeRequired)
                    {
                        BeginInvoke(method);
                    }
                    else
                    {
                        method.Invoke();
                    }


                }

                method = delegate
                                          {
                                              if (TreeView1.GetNodeCount(false) > 0)
                                              {
                                                  node = (VvTreeNode)TreeView1.Nodes[0];
                                                  if (node != null)
                                                  {
                                                      //TreeView1.SelectedNode = node;
                                                      //LoadChildTreeNodes(node);
                                                      //_selectedFolder = SourceVault.DefaultStore.Library.GetFolder(node.NodeID);

                                                      //node.Collapse();
                                                  }
                                              }
                                          };

                if (InvokeRequired)
                {
                    BeginInvoke(method);
                }
                else
                {
                    method.Invoke();
                }
            }
            else
            {
                MessageBox.Show("You are not logged in", "Error", MessageBoxButtons.OK);
            }
        }


        /// <summary>
        /// Treeview node expand event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView1BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            VvTreeNode childnode;
            VvTreeNode newnode;
            var node = (VvTreeNode)e.Node;
            if (node.GetNodeCount(true) == 1)
            {
                childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeID))
                {
                    node.Nodes.Remove(childnode);
                    Guid folderId = node.NodeID;
                    FolderCollection folderCollection = SourceVault.DefaultStore.Library.GetChildFolders(folderId);
                    foreach (Folder folder in folderCollection)
                    {
                        newnode = new VvTreeNode(folder.FolderID, folder.Name);
                        newnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                        node.Nodes.Add(newnode);
                    }
                }
            }
        }


        /// <summary>
        /// Treeview node select event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView1BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                VvTreeNode node = (VvTreeNode)e.Node;
                if (node != null)
                {
                    _sourceSelectedFolderId = node.NodeID;
                    _selectedFolder = SourceLibrary.GetFolder(_sourceSelectedFolderId);
                    lvDocuments.Items.Clear();
                    Application.DoEvents();
                    if (_selectedFolder != null)
                    {
                        UpdateSelectedFolderInfo();

                        _docColl = _selectedFolder.GetDocuments(txtDocumentFilter.Text);

                        BindDocumentsListView(false);
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        /// <summary>
        /// Populates a tree node with its children by getting the collection of folder objects from 
        /// the source VisualVault server
        /// </summary>
        /// <param name="node"></param>
        private void LoadChildTreeNodes(VvTreeNode node)
        {
            VvTreeNode childnode;
            if (node.GetNodeCount(true) == 1)
            {
                childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeID))
                {
                    node.Nodes.Remove(childnode);
                }
            }
            FolderCollection fldrColl = SourceVault.DefaultStore.Library.GetChildFolders(node.NodeID);
            foreach (Folder folder in fldrColl)
            {
                childnode = new VvTreeNode(folder.FolderID, folder.Name);
                childnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                node.Nodes.Add(childnode);
            }
            node.Expand();
        }


        /// <summary>
        /// Updates the selected folder label text
        /// </summary>
        private void UpdateSelectedFolderInfo()
        {
            bool isNamingConventionEnabled = false;
            if (_selectedFolder == null)
            {
                txtSourceFolderPath.Text = "Select folder using tree view above";
            }
            else
            {
                txtSourceFolderPath.Text = _selectedFolder.FolderPath;

                if (_selectedFolder.HasNamingConventions)
                {
                    if (_selectedFolder.DCNamingConvention.Enabled)
                    {
                        isNamingConventionEnabled = true;
                    }
                }
            }
            if (isNamingConventionEnabled)
            {
                //txtNewDocID.Text = "Auto Assigned";
                //txtNewDocID.Enabled = false;
                //chkUseFileNameForDocID.Enabled = false;
                //chkUseFileNameForDocID.Checked = false;
            }
        }


        /// <summary>
        /// Configures the document list view columns
        /// </summary>
        private void InitializeDocumentsListView()
        {
            lvDocuments.Columns.Clear();
            lvDocuments.View = View.Details;
            lvDocuments.LabelEdit = false;
            lvDocuments.AllowColumnReorder = true;
            lvDocuments.CheckBoxes = false;
            lvDocuments.FullRowSelect = true;
            lvDocuments.GridLines = false;
            lvDocuments.Sorting = SortOrder.Ascending;
            lvDocuments.Columns.Add("DocID", 122, HorizontalAlignment.Left);
            lvDocuments.Columns.Add("Description", 150, HorizontalAlignment.Left);
            lvDocuments.Columns.Add("Rev", 40, HorizontalAlignment.Left);
            lvDocuments.Columns.Add("Filename", 150, HorizontalAlignment.Left);
            lvDocuments.Columns.Add("Doc State", 80, HorizontalAlignment.Left);
        }


        /// <summary>
        /// Populates the document list view using the selected folder's collection of document objects
        /// </summary>
        /// <param name="withFolderPath"></param>
        private void BindDocumentsListView(bool withFolderPath)
        {
            lvDocuments.Items.Clear();
            foreach (Document doc in _docColl)
            {
                MyListViewItem lvi = new MyListViewItem(doc.DhID, doc.DocID) { Checked = false };
                lvi.SubItems.Add(doc.Description);
                lvi.SubItems.Add(doc.Revision);
                lvi.SubItems.Add(doc.Filename);
                lvi.SubItems.Add(doc.DocumentState.ToString());
                if (withFolderPath)
                {
                    lvi.SubItems.Add(doc.FolderPath);
                }
                lvDocuments.Items.Add(lvi);
                if (_selectedDocument != null)
                {
                    if (doc.DocID.ToLower() == _selectedDocument.DocID.ToLower())
                    {
                        lvi.Selected = true;
                        lvi.BackColor = SystemColors.Highlight;
                        lvi.ForeColor = SystemColors.HighlightText;
                    }
                }
            }
        }


        /// <summary>
        /// Launches the windows folder selection dialog box
        /// </summary>
        /// <returns></returns>
        public string GetFolder()
        {
            folderBrowserDialog1.ShowDialog();
            return folderBrowserDialog1.SelectedPath;
        }


        /// <summary>
        /// Exports all documents found in the source folder to the file system.  If recursive then this method calls itself
        /// until all subfolders have been processed.
        /// </summary>
        /// <param name="folder">Source VisualVault Folder</param>
        /// <param name="targetFolderPath">Files system target folder path where the exported files will be saved</param>
        /// <param name="recursive">If true then all subfolders will be processed</param>
        private void ExportFilesToFileSystem(Folder folder, string targetFolderPath, bool recursive)
        {
            //iterate through all the files in the selected VisualVault folder
            //and write them to the target file system folder			
            DocumentCollection documents = null;
            if (!String.IsNullOrEmpty(txtDocumentFilter.Text.Trim()))
            {
                documents = folder.GetDocuments(txtDocumentFilter.Text);
            }
            else
            {
                documents = folder.GetDocuments(txtDocumentFilter.Text);
            }

            foreach (Document doc in documents)
            {
                SaveDocumentFile(doc, targetFolderPath);
            }

            _exportedFolderCount += 1;

            MethodInvoker method = delegate
                                       {
                                           lblRunningTotals.Text = "Processed " + _exportedFolderCount + " folders and " + _exportedDocumentCount + " documents";
                                       };

            if (InvokeRequired)
            {
                BeginInvoke(method);
            }
            else
            {
                method.Invoke();
            }
            Application.DoEvents();

            if (recursive)
            {
                //iterate through all child folders
                foreach (Folder childFolder in folder.GetChildFolders())
                {
                    ExportFilesToFileSystem(childFolder, targetFolderPath, true);
                }
            }
        }


        /// <summary>
        /// For each document in the source folder, create a new document in the target folder with the same meta-data and file.
        /// </summary>
        /// <param name="sourceFolder">Source VisualVault folder</param>
        /// <param name="targetFolder">Target VisualVault folder</param>
        /// <param name="recursive">Include all subfolders</param>
        private void ExportFolderToTargetUrl(Folder sourceFolder, Folder targetFolder, bool recursive)
        {
            try
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    string updateText1 = "Copying cancelled at path " + sourceFolder.FolderPath;

                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                    Invoke(new MethodInvoker(() => btnCancel.Enabled = false));

                    return;
                }

                string updateText = "Copying folder from " + sourceFolder.FolderPath + @" to " + targetFolder.FolderPath;

                if (InvokeRequired)
                {
                    var updateText1 = updateText;
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                }

                //make sure target folder has all index fields defined in the source folder
                bool createFolderIndexFields = false;
                Invoke(new MethodInvoker(() => createFolderIndexFields = chkIncludeIndexFields.Checked));

                if (createFolderIndexFields)
                {
                    CreateFolderIndexFields(sourceFolder, targetFolder);
                }

                //copy source folder naming conventions
                bool copyNamingConventions = false;
                Invoke(new MethodInvoker(() => copyNamingConventions = chkCopyNamingConventions.Checked));

                if (copyNamingConventions)
                {
                    NamingConventions targetNamingConventions = sourceFolder.DCNamingConvention;
                    targetFolder.UpdateNamingRules(targetNamingConventions);
                }

                //copy source folder record retention rules
                bool copyRecordRetention = false;
                Invoke(new MethodInvoker(() => copyRecordRetention = chkCopyRecordRetention.Checked));

                if (copyRecordRetention)
                {
                    RecordRetention targetRecordRetentionRules = sourceFolder.DCRecordRention;
                    targetFolder.UpdateRetentionPlan(targetRecordRetentionRules);
                }

                //remove system generated index fields from the target folder
                RemoveFolderDefaultIndexFields(targetFolder);

                //copy folder security
                bool copyFolderSecurity = false;
                Invoke(new MethodInvoker(() => copyFolderSecurity = chkCopyGroups.Checked));

                if (copyFolderSecurity)
                {
                    updateText = "Copying folder security from " + sourceFolder.FolderPath + @" to " + targetFolder.FolderPath;

                    var updateText1 = updateText;
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));

                    _sourceVaultGroupList = new List<Group>();

                    CopyFolderSecurity(sourceFolder, targetFolder);

                    if (chkAddGroupMembers.Checked)
                    {
                        SynchronizeTargetVaultGroupMembers();
                    }
                }

                //iterate through all the documents in the source server's selected VisualVault folder
                //and check them into the target VisualVault server's target folder.

                updateText = "Copying folder documents " + sourceFolder.FolderPath + @" to " + targetFolder.FolderPath;

                if (InvokeRequired)
                {
                    var updateText1 = updateText;
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                }

                if (_cancellationToken.IsCancellationRequested)
                {
                    updateText = "Copying cancelled at path " + sourceFolder.FolderPath;

                    var updateText1 = updateText;
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                    Invoke(new MethodInvoker(() => btnCancel.Enabled = false));

                    return;
                }

                foreach (Document sourceDoc in sourceFolder.GetDocuments())
                {
                    if (!_cancellationToken.IsCancellationRequested)
                    {
                        //try up to five times to export a document if there was a failure
                        bool exportSuccessfull = false;
                        var i = 0;

                        while (!exportSuccessfull && i <= 5)
                        {
                            exportSuccessfull = ExportDocumentToTargetUrl(sourceFolder, sourceDoc, targetFolder);
                            if (!exportSuccessfull)
                            {
                                SourceVault.ReValidateLogin();
                                TargetVault.ReValidateLogin();
                            }

                            i++;
                        }
                    }
                    else
                    {
                        updateText = "Copying cancelled at path " + sourceFolder.FolderPath;

                        var updateText1 = updateText;
                        Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                        Invoke(new MethodInvoker(() => btnCancel.Enabled = false));

                        break;
                    }
                }

                _exportedFolderCount += 1;

                Invoke(new MethodInvoker(() => lblRunningTotals.Text = "Processed " + _exportedFolderCount + " folders and " + _exportedDocumentCount + " documents"));

                Application.DoEvents();

                if (recursive)
                {
                    //iterate through all child folders
                    foreach (Folder sourceChildFolder in sourceFolder.GetChildFolders())
                    {
                        //Make sure the child folder name exists as a subfolder of the target folder
                        //if not then create the new child folder and pass it in as the target folder

                        FolderCollection targetChildFolders = targetFolder.GetChildFolders();

                        Folder targetChildFolder;

                        if (targetFolder.IsFolderNameUniqueInCurrentFolder(sourceChildFolder.Name))
                        {
                            //child folder does not exist in target parent folder so create it
                            targetChildFolder = targetFolder.NewChildFolder(sourceChildFolder.Name,
                                                                            sourceChildFolder.Description, false, false);

                            //temporary workaround to populate the new folder's path
                            targetChildFolder = TargetVault.DefaultStore.Library.GetFolder(targetChildFolder.FolderID);
                        }
                        else
                        {
                            //if the folder name we want to use is the same as a folder is in the recyle bin
                            //we need to use a different name.  In the future, the API will be fixed to return all 
                            //child folders regardless of their state (active or deleted).  Currently we only get
                            //back active folders.
                            try
                            {
                                targetChildFolder = targetChildFolders[sourceChildFolder.Name];
                            }
                            catch (Exception ex)
                            {
                                //create new child folder by appending a new guid value to the end of the source folder's name
                                string exMessage = ex.Message;
                                targetChildFolder = targetFolder.NewChildFolder(sourceChildFolder.Name + "-" + Guid.NewGuid(),
                                                                sourceChildFolder.Description, false, false);

                                //temporary workaround to populate the new folder's path
                                targetChildFolder = TargetVault.DefaultStore.Library.GetFolder(targetChildFolder.FolderID);
                            }
                        }

                        if (_cancellationToken.IsCancellationRequested)
                        {
                            updateText = "Copying cancelled at path " + sourceFolder.FolderPath;

                            var updateText1 = updateText;
                            Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                            Invoke(new MethodInvoker(() => btnCancel.Enabled = false));

                            break;
                        }

                        ExportFolderToTargetUrl(sourceChildFolder, targetChildFolder, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry(ex.Message, "");
            }
        }


        /// <summary>
        /// Creates a new document in the target folder with the same file and meta-data as the source document
        /// </summary>
        /// <param name="sourceFolder">VisualVault folder the source document belongs to</param>
        /// <param name="sourceDoc">VisualVault document object to export to the target folder</param>
        /// <param name="targetFolder">Target VisualVault folder</param>
        private bool ExportDocumentToTargetUrl(Folder sourceFolder, Document sourceDoc, Folder targetFolder)
        {

            var documentExported = false;

            try
            {
                Document existingDoc = null;

                var checkForExistingDocuments = false;

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => checkForExistingDocuments = chkLookForExistingDocs.Checked));
                }

                if (checkForExistingDocuments)
                {
                    existingDoc = targetFolder.GetDocument(sourceDoc.DocID, DocumentLatestState.Latest);
                }
                if (existingDoc == null)
                {
                    var docState = DocumentState.Released;

                    if (chkUnReleased.Checked)
                        docState = DocumentState.Unreleased;

                    //get the source document
                    var tempFileName = Path.Combine(Path.GetTempPath(), sourceDoc.DhID + "." + sourceDoc.Extension);

                    string updateText = "Getting source file from document: " + sourceFolder.FolderPath + @"/" + sourceDoc.DocID;

                    if (InvokeRequired)
                    {
                        var updateText1 = updateText;
                        Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                    }

                    Application.DoEvents();

                    using (var sourceStream = sourceDoc.GetStream())
                    {
                        CreateFileFromStream(sourceStream, 1, tempFileName);
                    }

                    updateText = "Checking new document into target location: " + targetFolder.FolderPath + @"/" + sourceDoc.DocID;

                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(() => lblProgress.Text = updateText));
                    }

                    using (FileStream fs = new FileStream(tempFileName, FileMode.Open, FileAccess.Read))
                    {
                        Document targetDocument = targetFolder.NewDocumentUsingStream(sourceDoc.DocID, sourceDoc.Description, sourceDoc.DhRev.ToString(CultureInfo.InvariantCulture), fs, fs.Length, sourceDoc.Filename, docState);

                        if (targetDocument != null)
                        {
                            documentExported = true;

                            targetDocument.UpdateAbstract(sourceDoc.Abstract, true);
                            targetDocument.UpdateExpireDate(sourceDoc.ExpirationDate);
                            targetDocument.UpdateKeywords(sourceDoc.Keywords, true);
                            targetDocument.UpdateReviewDate(sourceDoc.ReviewDate);

                            //update the target document's index field values
                            if (chkIncludeIndexFields.Checked)
                                CopyDocumentIndexFieldValues(sourceDoc, targetDocument);

                        }
                    }

                    File.Delete(tempFileName);
                }
                else
                {
                    documentExported = true;

                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(() => lblProgress.Text = "Skipped existing document " + existingDoc.FolderPath + "\\" + existingDoc.DocID));
                    }
                }

                _exportedDocumentCount += 1;

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => lblRunningTotals.Text = "Processed " + _exportedFolderCount + " folders and " + _exportedDocumentCount + " documents"));
                }


                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ErrorLogEntry(ex.Message, sourceDoc.FolderPath + @"\" + sourceDoc.DocID);
            }

            return documentExported;
        }


        /// <summary>
        /// Saves a VisualVault Document's file to a file system path
        /// </summary>
        /// <param name="document"> </param>
        /// <param name="saveToPath"></param>
        private void SaveDocumentFile(Document document, string saveToPath)
        {
            try
            {
                if (chkExportAllRevisions.Checked)
                {
                    try
                    {
                        DocumentRevisionCollection documentRevisions = document.GetRevisions();
                        foreach (var documentRevision in documentRevisions.OfType<Document>())
                        {
                            if (documentRevision != null)
                            {
                                SaveSingleDocumentFile(documentRevision, saveToPath);
                            }
                        }
                    }
                    catch (InsufficientSecurityRoleException)
                    {
                        ErrorLogEntry("Exception in SaveDocumentFile- unable to get revisions due to invalid security clearance, getting only the latest rev.", "Source Document: " + document.FolderPath + @"\" + document.DocID);
                        SaveSingleDocumentFile(document, saveToPath);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogEntry("Exception in SaveDocumentFile: " + ex.Message, "Source Document: " + document.FolderPath + @"\" + document.DocID);
                    }

                }
                else
                {
                    SaveSingleDocumentFile(document, saveToPath);
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in SaveDocumentFile: " + ex.Message, "Source Document: " + document.FolderPath + @"\" + document.DocID);
            }

        }


        private void SaveSingleDocumentFile(Document documentRevision, string saveToPath)
        {
            try
            {
                _selectedDocument = documentRevision;

                string filePath = saveToPath;

                if (chkPreservePath.Checked)
                {
                    filePath = filePath + (@"\" + documentRevision.FolderPath + @"\").Replace(@"/", @"\").Replace(@"\\", @"\");
                }

                //if folderpath does not exist then create it
                CreateFolderPath(filePath);

                string dottedExtension;
                if (documentRevision.Extension.StartsWith("."))
                {
                    dottedExtension = documentRevision.Extension;
                }
                else
                {
                    dottedExtension = "." + documentRevision.Extension;
                }
                if (chkExportAllRevisions.Checked)
                {
                    filePath += String.Format("{0}__{1}__{2}{3}", CleanupForFileName(documentRevision.DocID), CleanupForFileName(documentRevision.Revision), CleanupForFileName(documentRevision.Filename.TrimEnd(dottedExtension.ToCharArray())), CleanupForFileName(dottedExtension));
                }
                else
                {
                    if (chkUseDocID.Checked)
                    {
                        filePath = Path.Combine(filePath, CleanupForFileName(documentRevision.DocID) + "." + CleanupForFileName(documentRevision.Extension));
                    }
                    else
                    {
                        filePath = Path.Combine(filePath, CleanupForFileName(documentRevision.Filename));
                    }

                }

                string updateText = "Exporting: " + filePath;
                if (InvokeRequired)
                {
                    string updateText1 = updateText;
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                }

                Application.DoEvents();

                string originalFilePath = filePath;
                int i = 0;
                while (File.Exists(filePath))
                {
                    i++;
                    filePath = String.Format("{0} ({1}){2}", originalFilePath.TrimEnd(dottedExtension.ToArray()), i, dottedExtension);
                }

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => pbProgress.Visible = true));
                    Invoke(new MethodInvoker(() => pbProgress.Value = 0));
                }

                using (var sourceStream = documentRevision.GetStream())
                {
                    CreateFileFromStream(sourceStream, 1, filePath);
                }

                _exportedDocumentCount += 1;

                updateText = "Processed " + _exportedFolderCount + " folders and " + _exportedDocumentCount + " documents";

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText));
                }

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in SaveDocumentFile: " + ex.Message, "Source Document: " + documentRevision.FolderPath + @"\" + documentRevision.DocID);
            }
        }


        private static string CleanupForFileName(string input)
        {
            return input.Replace(@"/", "-").Replace(@"\", "-").Replace("..", ".");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        private static void CreateFolderPath(string folderPath)
        {
            //if path does not exist then create it

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }


        /// <summary>
        /// Creates an instance of frmFolderSelect to select the target VisualVault folder
        /// </summary>	
        private void SelectTargetVisualVaultFolder()
        {
            var frmFolderSelect = new FrmVvFolderSelect();

            if (TargetVault != null)
            {
                frmFolderSelect.Vault = TargetVault;

                if (frmFolderSelect.ShowDialog() == DialogResult.OK)
                {
                    //get the target folder
                    _targetVisualVaultFolder = TargetVault.DefaultStore.Library.GetFolder(frmFolderSelect.FolderID);

                    if (_targetVisualVaultFolder != null)
                    {
                        txtTargetFolderPath.Text = _targetVisualVaultFolder.FolderPath;

                        chkCopyToDocumentLibraryRoot.Checked = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "You must be logged into the target VisualVault server before you can select the target folder location");
            }
        }


        /// <summary>
        /// Makes sure the target VisualVault folder's index field collection contains all index fields found
        /// in the source VisualVault folder's index field collection
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="targetFolder"></param>
        private void CreateFolderIndexFields(Folder sourceFolder, Folder targetFolder)
        {
            try
            {
                FolderIndexFieldCollection sourceFolderIndexFields = sourceFolder.GetFolderIndexFields();

                FolderIndexFieldCollection targetFolderIndexFields = targetFolder.GetFolderIndexFields();

                if (sourceFolderIndexFields != null)
                {
                    foreach (FolderIndexField sourceIndexField in sourceFolderIndexFields)
                    {
                        //ignore system generated index fields userfield1 and userfield2
                        if (sourceIndexField.Name.ToLower().IndexOf("user field", System.StringComparison.Ordinal) == -1)
                        {
                            if (targetFolderIndexFields != null)
                            {
                                FolderIndexField tempIndexField;

                                //look for matching index field in the target folder's collection
                                try
                                {
                                    tempIndexField = targetFolderIndexFields[sourceIndexField.Name];
                                    //will throw exception if index field does not exist
                                }
                                catch (Exception)
                                {
                                    //if no index field found create one
                                    tempIndexField = targetFolderIndexFields.NewFolderIndexField(sourceIndexField.FolderIndexFieldType);
                                    tempIndexField.Name = sourceIndexField.Name;
                                    tempIndexField.Description = sourceIndexField.Description;
                                    targetFolderIndexFields.AddFolderIndexField(tempIndexField);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in CreateFolderIndexFields: " + ex.Message,
                              "Source Folder: " + sourceFolder.FolderPath);
            }
        }


        private void CopyFolderSecurity(Folder sourceFolder, Folder targetFolder)
        {
            try
            {

                bool createUsersGroups = false;
                Invoke(new MethodInvoker(() => createUsersGroups = chkCreateGroups.Checked));

                SecurityMemberCollection sourceFolderSecurityMembers = sourceFolder.GetSecurityMembers();

                SecurityMemberCollection targetFolderMemberCollection = targetFolder.GetSecurityMembers();

                foreach (SecurityMember securityMember in sourceFolderSecurityMembers)
                {
                    //if (securityMember.MemberName == "Configuration Administrator")
                    //{
                    //    continue;
                    //}

                    switch (securityMember.MemberType)
                    {
                        case MemberType.User:

                            //User targetVaultuser = null;

                            //try
                            //{
                            //    targetVaultuser = TargetVault.Sites.GetUser(securityMember.MemberName);
                            //}
                            //catch (Exception ex)
                            //{
                            //    //expected
                            //    if (createUsersGroups)
                            //    {
                            //        string updateText = string.Format("User {0} not found in target vault",
                            //            securityMember.MemberName);

                            //        var updateText1 = updateText;
                            //        Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                            //    }
                            //}

                            //var sourceVaultUser = SourceVault.Sites.GetUser(securityMember.MemberID);

                            //if (targetVaultuser == null && createUsersGroups && sourceVaultUser != null)
                            //{
                            //    Site targetVaultHomeSite = TargetVault.Sites.GetAllSites()["Home"];
                            //    if (targetVaultHomeSite != null)
                            //    {
                            //        targetVaultuser = targetVaultHomeSite.NewUser(sourceVaultUser.UserID, sourceVaultUser.FirstName, sourceVaultUser.MiddleInitial,
                            //            sourceVaultUser.LastName, sourceVaultUser.Email, "password123");

                            //        string updateText = string.Format("User {0} created in target vault", targetVaultuser.UserID);

                            //        var updateText1 = updateText;
                            //        Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                            //    }
                            //}

                            //if (targetVaultuser != null)
                            //{
                            //    SecurityMember sourceFolderSecurityMember = securityMember;
                            //    if (targetFolderMemberCollection.Cast<SecurityMember>().All(targetFolderSecurityMember => targetFolderSecurityMember.MemberName != sourceFolderSecurityMember.MemberName && targetFolderSecurityMember.MemberType == MemberType.User))
                            //    {
                            //        //add source folder user to target folder
                            //        targetFolderMemberCollection.AddMember(targetVaultuser, sourceFolderSecurityMember.Role);
                            //    }
                            //}

                            break;
                        case MemberType.Group:

                            Group targetVaultGroup = null;

                            try
                            {
                                //targetVaultGroup = TargetVault.Sites.GetGroup(securityMember.MemberName);
                                Site homeSite = TargetVault.Sites.GetAllSites()["Home"];
                                targetVaultGroup = homeSite.GetGroup(securityMember.MemberName);
                            }
                            catch (Exception ex)
                            {
                                //expected
                                if (createUsersGroups)
                                {
                                    string updateText = string.Format("Group {0} not found in target vault", securityMember.MemberName);

                                    var updateText1 = updateText;
                                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                                }
                            }

                            var sourceVaultGroup = SourceVault.Sites.GetGroup(securityMember.MemberID);

                            if (targetVaultGroup == null && createUsersGroups && sourceVaultGroup != null)
                            {
                                Site targetVaultHomeSite = TargetVault.Sites.GetSite("Home");
                                if (targetVaultHomeSite != null)
                                {
                                    targetVaultGroup = targetVaultHomeSite.NewGroup(sourceVaultGroup.Name,
                                        sourceVaultGroup.Description);

                                    string updateText = string.Format("Group {0} created in target vault", targetVaultGroup.Name);

                                    var updateText1 = updateText;
                                    Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));
                                }
                            }

                            if (targetVaultGroup != null)
                            {
                                SecurityMember sourceFolderSecurityMember = securityMember;
                                if (!targetFolderMemberCollection.Cast<SecurityMember>().Any(targetFolderSecurityMember => targetFolderSecurityMember.MemberName == sourceFolderSecurityMember.MemberName && targetFolderSecurityMember.MemberType == MemberType.Group))
                                {
                                    //add source folder group to target folder
                                    targetFolderMemberCollection.AddMember(targetVaultGroup.GroupID, MemberType.Group, sourceFolderSecurityMember.Role);
                                }
                            }

                            if (sourceVaultGroup != null)
                            {
                                if (!_sourceVaultGroupList.Contains(sourceVaultGroup))
                                {
                                    _sourceVaultGroupList.Add(sourceVaultGroup);
                                }
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in CopyFolderSecurity: " + ex.Message,
                              "Source Folder: " + sourceFolder.FolderPath);
            }
        }


        private void SynchronizeTargetVaultGroupMembers()
        {
            bool addGroupMembers = false;
            Invoke(new MethodInvoker(() => addGroupMembers = chkAddGroupMembers.Checked));

            Site targetVaultHomeSite = TargetVault.Sites.GetAllSites()["Home"];

            if (_sourceVaultGroupList != null && _sourceVaultGroupList.Count > 0 && targetVaultHomeSite != null)
            {
                if (addGroupMembers)
                {
                    foreach (Group sourceVaultGroup in _sourceVaultGroupList)
                    {
                        var targetVaultGroup = targetVaultHomeSite.GetGroup(sourceVaultGroup.Name);

                        if (targetVaultGroup != null)
                        {
                            foreach (GroupMember sourceVaultGroupMember in sourceVaultGroup.GroupMembers)
                            {
                                //if target vault group does not contain source vault group member then add
                                if (targetVaultGroup.GroupMembers.Cast<GroupMember>().All(gm => gm.UserID != sourceVaultGroupMember.UserID))
                                {
                                    User targetVaultuser = null;

                                    try
                                    {
                                        targetVaultuser = TargetVault.Sites.GetUser(sourceVaultGroupMember.UserID);
                                    }
                                    catch (Exception ex)
                                    {
                                        //expected if user does not exist
                                        string updateText = string.Format("Creating user {0} not found in target vault", sourceVaultGroupMember.UserID);

                                        var updateText1 = updateText;
                                        Invoke(new MethodInvoker(() => lblProgress.Text = updateText1));

                                        var sourceVaultUser = SourceVault.Sites.GetUser(sourceVaultGroupMember.UsID);

                                        targetVaultuser = targetVaultHomeSite.NewUser(sourceVaultUser.UserID, sourceVaultUser.FirstName, sourceVaultUser.MiddleInitial,
                                        sourceVaultUser.LastName, sourceVaultUser.Email, "password123");
                                    }

                                    if (targetVaultuser != null)
                                    {
                                        targetVaultGroup.AddUser(targetVaultuser);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        
        private void SynchronizeTargetVaultUsers()
        {
            if (SourceInstance != null && TargetInstance != null && SourceVault != null && TargetVault != null)
            {
                List<InstanceUser> sourceVaultCustomerUsers = new List<InstanceUser>();

                List<Customer> sourceVaultCustomers = SourceInstance.Customers.GetAllCustomers();

                List<InstanceUser> targetVaultCustomerUsers = new List<InstanceUser>();

                Customer targetInstanceCustomer = null;
                
                foreach (Customer customer in sourceVaultCustomers.Where(instanceCustomer => instanceCustomer.CustomerId.Equals(SourceVault.CustomerId)))
                {
                    sourceVaultCustomerUsers = customer.Users.GetAllUsers();
                    break;
                }
                
                foreach (Customer customer in sourceVaultCustomers.Where(instanceCustomer => instanceCustomer.CustomerId.Equals(TargetVault.CustomerId)))
                {
                    targetInstanceCustomer = customer;
                    targetVaultCustomerUsers = customer.Users.GetAllUsers();
                    break;
                }

                foreach (InstanceUser sourceVaultInstanceUser in sourceVaultCustomerUsers)
                {
                    if (!targetVaultCustomerUsers.Contains(sourceVaultInstanceUser))
                    {
                        if (targetInstanceCustomer != null)
                        {
                            var databases = targetInstanceCustomer.Databases.GetAllDatabases();

                            foreach (var database in databases.Where(database => database.Alias == SourceVault.CustomerDatabaseAlias))
                            {
                                foreach (InstanceUser sourceVaultCustomerUser in sourceVaultCustomerUsers)
                                {
                                    try
                                    {
                                        User user = TargetVault.Sites.GetUser(sourceVaultCustomerUser.Username);
                                    }
                                    catch (InvalidUserIDException ex)
                                    {
                                        database.AddUser(sourceVaultCustomerUser.Username, false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        
        /// <summary>
        /// Deletes the system generated index fields (User Field 1, User Field 2) from a VisualVault folder
        /// </summary>
        /// <param name="folder"></param>
        private void RemoveFolderDefaultIndexFields(Folder folder)
        {
            try
            {
                FolderIndexFieldCollection folderIndexFields = folder.GetFolderIndexFields();

                FolderIndexField tempIndexField;

                try
                {
                    tempIndexField = folderIndexFields["User Field 1"];

                    if (tempIndexField != null) folderIndexFields.DeleteFolderIndexField(tempIndexField);
                }
                catch (Exception ex)
                {
                    string exMessage = ex.Message;
                }

                try
                {
                    tempIndexField = folderIndexFields["User Field 2"];

                    if (tempIndexField != null) folderIndexFields.DeleteFolderIndexField(tempIndexField);
                }
                catch (Exception ex)
                {
                    string exMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in RemoveFolderDefaultIndexFields: " + ex.Message,
                              "Folder: " + folder.FolderPath);
            }
        }
        
        /// <summary>
        /// Copies the values from source document index fields to matching target document index fields
        /// </summary>
        /// <param name="sourceDocument"></param>
        /// <param name="targetDocument"></param>
        private void CopyDocumentIndexFieldValues(Document sourceDocument, Document targetDocument)
        {
            try
            {
                DocumentIndexFieldCollection sourceIndexFields = sourceDocument.GetIndexFieldCollection();

                DocumentIndexFieldCollection targetIndexFields = targetDocument.GetIndexFieldCollection();

                if (sourceIndexFields.Count > 0 && targetIndexFields.Count > 0)
                {
                    //copy index field values from source to target
                    foreach (DocumentIndexField sourceIndexField in sourceIndexFields)
                    {
                        try
                        {
                            //ignore system generated index fields userfield1 and userfield2

                            if (sourceIndexField.Name.ToLower().IndexOf("user field") == -1)
                            {
                                //If the target index field item is not found the VisualVault API throws an exception						
                                DocumentIndexField targetIndexField = targetIndexFields[sourceIndexField.Name];

                                targetIndexField.Value = sourceIndexField.Value;
                                targetIndexField.Update();
                            }
                        }
                        catch (Exception ex)
                        {
                            string exMessage = ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogEntry("Exception in CopyDocumentIndexFieldValues: " + ex.Message,
                              "Target Document: " + targetDocument.FolderPath + @"\" + targetDocument.DocID);
            }
        }

        private FileInfo CreateFileFromStream(Stream sourceFileStream, int maxRetryCount, string targetFileFullPath)
        {
            int retryCount = 0;
            while (retryCount <= maxRetryCount)
            {
                retryCount++;
                bool isError = true;

                try
                {
                    for (int i = 1; i <= maxRetryCount; i++)
                    {
                        try
                        {
                            if (File.Exists(targetFileFullPath))
                            {
                                File.Delete(targetFileFullPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLogEntry(ex.Message, targetFileFullPath);
                        }

                        if (!File.Exists(targetFileFullPath))
                        {
                            break;
                        }
                        else
                        {
                            const int sleepTime = 2;
                            Thread.Sleep(sleepTime * 1000);
                        }
                    }

                    if (!File.Exists(targetFileFullPath))
                    {
                        if (sourceFileStream != null)
                        {
                            using (var targetFileStream = new FileStream(targetFileFullPath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                using (BinaryWriter targetWriter = new BinaryWriter(targetFileStream))
                                {
                                    byte[] buffer = new byte[4096];
                                    int bytesRead;
                                    while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        //System.Diagnostics.Debug.WriteLine("bytes read = " + bytesRead);
                                        targetWriter.Write(buffer, 0, bytesRead);
                                    }

                                    isError = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    isError = true;
                    ErrorLogEntry(ex.Message, targetFileFullPath);

                }

                if (isError == false)
                {
                    break;
                }
                else
                {
                    const int sleepTime = 2;
                    Thread.Sleep(sleepTime * 1000);
                }
            }

            return new FileInfo(targetFileFullPath);
        }

        #region Event Handlers

        private void ChkExportAllRevisionsCheckedChanged(object sender, EventArgs e)
        {
            chkUseDocID.Enabled = !chkExportAllRevisions.Checked;
        }

        private void chkLookForExistingDocs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDocumentLibraryRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopyToDocumentLibraryRoot.Checked)
            {
                txtTargetFolderPath.Text = "/";
                _targetVisualVaultFolder = null;
            }
        }

        private void chkCopyFromDocumentLibraryRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopyFromDocumentLibraryRoot.Checked)
            {
                txtSourceFolderPath.Text = "/";
                _selectedFolder = null;
            }
        }

        private void txtSourceFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }

        #endregion

    }
}