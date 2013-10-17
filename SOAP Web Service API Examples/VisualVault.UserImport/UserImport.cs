using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Security;
using VisualVault.Examples.Common;

namespace VisualVault.UserImport
{
    public partial class UserImport : Form
    {
        private Vault _vault;

        private Site _vVSite;

        ///<summary>
        ///
        ///</summary>
        public UserImport()
        {
            InitializeComponent();
        }

        private void UserImport_Load(object sender, EventArgs e)
        {
            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;
        }

        #region Event Handlers

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files(*.csv)|*.csv|Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void uxAuthCmdLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void cboSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            _vVSite = (Site)cboSites.SelectedItem;
        }

        #endregion

        #region Methods

        private void login()
        {

            uxAuthStatus.ForeColor = Color.LightSteelBlue;
            uxAuthStatus.Text = "Attempting login...";
            Application.DoEvents();

            var myAuth = Authentication.AuthenticateUser(this.txtUserID.Text, txtPassword.Text, txtServerURL.Text);

            if (myAuth.IsAuthenticated)
            {
                uxAuthStatus.ForeColor = Color.Green;
                _vault = myAuth.Vault;
                PopulateSites();
            }
            else
            {
                uxAuthStatus.ForeColor = Color.Red;
                _vault = null;
            }

            uxAuthStatus.Text = myAuth.StatusMessage;
            UpdateAuthenticatedUserInfo(myAuth.Vault); // Populate the login status labels
            
            Application.DoEvents();
        }

        private void UpdateAuthenticatedUserInfo(Vault vault)
        {
            ClearAuthenticatedUserInfo();

            if (vault != null)
            {
                User authUser = vault.CurrentUser.GetCurrentUser();
                if (authUser != null)
                {
                    uxAuthInfoUserId.Text = authUser.UserID;
                    uxAuthInfoAuthType.Text = authUser.Authentication.ToString();
                    uxAuthInfoEmail.Text = authUser.Email;
                    uxAuthInfoNameFirst.Text = authUser.FirstName;
                    uxAuthInfoNameLast.Text = authUser.LastName;
                }
            }
        }

        private void ClearAuthenticatedUserInfo()
        {
            uxAuthInfoUserId.Text = string.Empty;
            uxAuthInfoAuthType.Text = string.Empty;
            uxAuthInfoEmail.Text = string.Empty;
            uxAuthInfoNameFirst.Text = string.Empty;
            uxAuthInfoNameLast.Text = string.Empty;
        }

        private void PopulateSites()
        {
            //get list of sites from VisualVault and populate the sites drop down list
            var sites = _vault.Sites.GetAllSites();

            cboSites.DisplayMember = "Name";
            cboSites.DataSource = sites;
        }

        #endregion

        private void btnImport_Click(object sender, EventArgs e)
        {
            //make sure we are logged in and have a selected CSV file

            if (_vault !=null)
            {
                if (txtFilePath.Text.Length>0)
                {
                    //if no site is selected then select the first item in the list
                    if(_vVSite==null)
                    {
                        _vVSite = (Site)cboSites.SelectedItem;
                    }

                    //import users
                    var userList = ProcessImport.ReadUserCSFile(txtFilePath.Text, _vVSite);

                    //update list box
                    lstUsers.DisplayMember = "UserID";
                    lstUsers.DataSource = userList;
                    lstUsers.MultiColumn = true;
                    
                    Application.DoEvents();
                }else
                {
                    MessageBox.Show("Select a CSV file for import");
                }

            }else
            {
                MessageBox.Show("You are not logged In");
            }
        }
    }
}
