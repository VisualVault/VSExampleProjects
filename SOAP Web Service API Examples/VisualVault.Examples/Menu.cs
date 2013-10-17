using System;
using System.Windows.Forms;
using VisualVault.ExamplesCs.Document_CheckIn;
using VisualVault.ExamplesCs.Document_MetaData;
using VisualVault.ExamplesCs.Authentication_Examples;
using VisualVault.ExamplesCs.Document_Search;

namespace VisualVault.ExamplesCs
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnCheckInClick(object sender, EventArgs e)
        {
            Form documentCheckIn = new DocumentCheckIn();
            documentCheckIn.ShowDialog();
        }

        private void BtnAuthenticateClick(object sender, EventArgs e)
        {
            Form documentCheckIn = new Authenticate();
            documentCheckIn.ShowDialog();
        }

        private void BtnDocumentSearchClick(object sender, EventArgs e)
        {
            Form documentCheckIn = new Search();
            documentCheckIn.ShowDialog();
        }

        private void BtnTreeViewClick(object sender, EventArgs e)
        {
            Form documentCheckIn = new TreeView();
            documentCheckIn.ShowDialog();
        }

        private void BtnFindFolderClick(object sender, EventArgs e)
        {
            Form documentCheckIn = new FindFolder();
            documentCheckIn.ShowDialog();
        }

        private void Button1Click1(object sender, EventArgs e)
        {
            Form metaDataExamples = new DocumentMetaData();
            metaDataExamples.ShowDialog();
        }
    }
}
