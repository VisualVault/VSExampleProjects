using System;
using System.Windows.Forms;
using VisualVault.Examples.Common;

namespace VisualVault.ExamplesCs.Authentication_Examples
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Authenticate : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Authenticate()
        {
            InitializeComponent();

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;

            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
        }

        private static void AuthenticateUser(string serverUrl, string userID, string password)
        {
            var vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            if (vault != null)
            {
                //make some API calls
                MessageBox.Show("Login Success", "Login Success");
            }else
            {
                MessageBox.Show("Login Failed", "Login Failed");
            }
        }
        
    }
}
