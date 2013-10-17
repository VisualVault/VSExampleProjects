using System;
using System.Windows.Forms;
using VisualVault.Examples.Common;
using VisualVault.ExamplesCs.TreeView_Examples;

namespace VisualVault.ExamplesCs.Document_CheckIn
{
	///<summary>
	///
	///</summary>
    public partial class DocumentCheckIn : Form, VVRuntime.VisualVault.Common.ChunkingCallback
	{
		private VVRuntime.VisualVault.Library.DocumentLibrary _library;
		private VVRuntime.VisualVault.Vault _vault;
        private VVRuntime.VisualVault.Library.Folders.Folder _selectedFolder;
		private Guid _selectedFolderID;
        private VVRuntime.VisualVault.Library.Documents.Document _selectedDocument;

		///<summary>
		///
		///</summary>
		public DocumentCheckIn()
		{
			InitializeComponent();

			if (treeView1 != null) treeView1.BeforeExpand += TreeView1BeforeExpand;

			if (treeView1 != null) treeView1.BeforeSelect += TreeView1BeforeSelect;

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;
		}

		private void BtnGetFoldersClick(object sender, EventArgs e)
		{
			InitializeTreeview();
		}

		private void AuthenticateUser(string serverUrl, string userID, string password)
		{
            _vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

			if (_vault != null)
			{
				_library = _vault.DefaultStore.Library;

                tabControl1.SelectTab(1);

			}else
			{
			    MessageBox.Show("Login Failed", "Login Failed");
			}
		}

		private void InitializeTreeview()
		{
		    if (_vault != null)
			{
				var folderCollection = _vault.DefaultStore.Library.GetTopLevelFolders();

			    VvTreeNode node;
			    foreach (VVRuntime.VisualVault.Library.Folders.Folder folder in folderCollection)
				{
					node = new VvTreeNode(folder.FolderID, folder.Name);
					node.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
					treeView1.Nodes.Add(node);
				}

				if (treeView1.GetNodeCount(false) > 0)
				{
					node = (VvTreeNode)treeView1.Nodes[0];

					//select the first folder in the tree
					if (node != null)
					{
						treeView1.SelectedNode = node;
						_selectedFolderID = _vault.DefaultStore.Library.GetFolder(node.NodeID).FolderID;
					}
				}
			}
		}

		void TreeView1BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			var node = (VvTreeNode)e.Node;

			if (node != null)
			{
				_selectedFolderID = node.NodeID;

				_selectedFolder = _library.GetFolder(_selectedFolderID);
			}
		}

		void TreeView1BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			VvTreeNode childnode;

			VvTreeNode newnode;

			var node = (VvTreeNode)e.Node;

			if (node.GetNodeCount(true) == 1)
			{
				childnode = (VvTreeNode)node.Nodes[0];

				//if node has an empty ID it has not been initialized
				if (Guid.Empty.Equals(childnode.NodeID))
				{
					node.Nodes.Remove(childnode);

					var folderID = node.NodeID;

					var folderCollection = _vault.DefaultStore.Library.GetChildFolders(folderID);

                    foreach (VVRuntime.VisualVault.Library.Folders.Folder folder in folderCollection)
					{
						newnode = new VvTreeNode(folder.FolderID, folder.Name);

						newnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));

						node.Nodes.Add(newnode);
					}
				}
			}
		}

		private void BtnLoginClick(object sender, EventArgs e)
		{
			AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
		}

		private void BtnSelectFileClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}

		private void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			txtNewDocumentFilePath.Text = openFileDialog1.FileName;
		}

		private void BtnSelectFile2Click(object sender, EventArgs e)
		{
			openFileDialog2.ShowDialog();
		}

		private void OpenFileDialog2FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			txtNewRevisionFilePath.Text = openFileDialog2.FileName;
		}

		private void BtnCheckInNewClick(object sender, EventArgs e)
		{
			// This example checks in a new document using a file stream.
			// A progress bar is incremented using the chunking interface.
			// All files are transferred in chunks for efficiently sending large files. 
			// The chunking interface is optional and only used to provide status.  
			// A byte array could also be used.  
		  
			if (_selectedFolder != null)
			{
				if (txtNewDocumentFilePath.Text.Length > 0)
				{
					//get the file name from the selected file path
					var fileName = txtNewDocumentFilePath.Text.Replace("\\", "/");
					var sFileName = fileName.Split('/');
					fileName = sFileName[sFileName.Length - 1];

					//In this example we use the file name for the file name, document ID, and description values.
					//You can specify a document ID.  However, if the target VisualVault folder has a naming convention configured
					//then the naming convention rules will determine what value is assigned to the Document ID

                    _selectedDocument = CreateDocumentInFolder(txtNewDocumentFilePath.Text, fileName, "1", VVRuntime.VisualVault.Library.Documents.DocumentState.Released, fileName, fileName);
				
                    if(_selectedDocument!=null)
                    {
                        MessageBox.Show(string.Format("Document {0} created", _selectedDocument.DocID), "Document Created");
                    }
                }
				else
				{
					MessageBox.Show("Please select a file to check-in");
				}

			}
			else
			{
				MessageBox.Show("Please select a target VisualVault folder");
			}
		}

        private VVRuntime.VisualVault.Library.Documents.Document CreateDocumentInFolder(string fileNameAndPath, string fileName, string revision, VVRuntime.VisualVault.Library.Documents.DocumentState documentState, string docID, string description)
		{
            VVRuntime.VisualVault.Library.Documents.Document document = null;

			if (_selectedFolder != null)
			{
				System.IO.FileStream fs = System.IO.File.Open(fileNameAndPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				
				//document is created by calling the NewDocument method on the target VisualVault folder
				document = _selectedFolder.NewDocument(this,docID, description, revision, fs, fileName, documentState);
				
				fs.Close();
			}

			return document;
		}

		private void BtnCheckInRevisionClick(object sender, EventArgs e)
		{
			if (_selectedFolder != null)
			{
				if (_selectedDocument != null)
				{
					//attempt to check-out the document
                    if (_selectedDocument.DocumentStatus == VVRuntime.VisualVault.Library.Documents.DocumentStatus.CheckedIn)
					{
						_selectedDocument.CheckOut();

						//check-in a new revision
						if (txtNewRevisionFilePath.Text.Length > 0)
						{
							//get the file name from the selected file path
							var fileName = txtNewRevisionFilePath.Text.Replace("\\", "/");
							var sFileName = fileName.Split('/');
							fileName = sFileName[sFileName.Length - 1];

							createNewDocumentRevision(txtNewRevisionFilePath.Text, fileName, txtNewRevision.Text, "",
                                                      VVRuntime.VisualVault.Library.Documents.DocumentCheckInState.Released);
						}
						else
						{
							MessageBox.Show("Select a file to check-in as the new revision");
						}
					}
					else
					{
						MessageBox.Show("Document is already checked out.  Use Document.CurrentLibraryStatus.LastCheckedOutInfo to see which user has the document checked out");
					}
				}
				else
				{
					MessageBox.Show("Please check-In a new document first then use this action to create a new revision");
				}
			}
			else
			{
				MessageBox.Show("Please select a target VisualVault folder");
			}

		}

        private void createNewDocumentRevision(string fileNameAndPath, string fileName, string revision, string changeReason, VVRuntime.VisualVault.Library.Documents.DocumentCheckInState checkinState)
		{
		 
			System.IO.FileStream fs = null;
		   
			if (_selectedDocument != null)
			{
				try
				{
					fs = System.IO.File.Open(fileNameAndPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
					_selectedDocument.CheckIn(fs, checkinState, fileName, revision, changeReason);

                    if (_selectedDocument != null)
                    {
                        MessageBox.Show(string.Format("Document Revision {0} created", _selectedDocument.Revision), "Document Revision Created");
                    }
				}
                catch (VVRuntime.VisualVault.Library.Documents.RevisionNotUniqueException ex)
				{
					MessageBox.Show(ex.Message + "\n Document Revision is not unique, select another revision and try again");
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred, \n" + ex.Message + "\n Please try again");
				}
				finally
				{
					if (fs != null) fs.Close();
				}
			}
		}

	   
		#region Implementation of ChunkingCallback

		///<summary>
		///
		///</summary>
		public void RespondToChunk()
		{
            progressBar1.PerformStep();

            this.Invoke(new Action(() => progressBar1.PerformStep()));

			Application.DoEvents(); 
		}

		///<summary>
		///
		///</summary>
		///<param name="chunkCount"></param>
		public void BeginChunk(int chunkCount)
		{

            this.Invoke(new Action(() =>
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = chunkCount;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                }));

			Application.DoEvents();
		}

		///<summary>
		///
		///</summary>
		public void ChunkingComplete()
		{
            this.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
                progressBar1.Visible = false;

            }));

			Application.DoEvents();
		}

		#endregion

		
	}
}
