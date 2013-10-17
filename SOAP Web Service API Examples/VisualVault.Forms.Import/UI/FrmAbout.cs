using System;
using System.Reflection;
using System.Windows.Forms;

namespace VisualVault.Forms.Import.UI
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAboutLoad(object sender, EventArgs e)
        {
            lblBuild.Text = Application.ProductVersion;

            var objCopyright = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));

            label2.Text = objCopyright.Copyright;
        }   
    }
   
}
