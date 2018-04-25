using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using EasyBrailleEdit.Common;

namespace EasyBrailleEdit
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string filename = Assembly.GetExecutingAssembly().Location;
            string fileVer = " v" + FileVersionInfo.GetVersionInfo(filename).FileVersion;
            lblVesion.Text = "易點雙視 " + fileVer;

            lblLicense.Text = AppGlobals.GetProductLicense();
            picTaipeiForBlind.Visible = AppGlobals.IsLicensedFor_TaipeiForBlind();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try 
            {
                Process.Start(linkLabel1.Text);
            }
            catch 
            {
                Process process = new Process();
                process.StartInfo.FileName = "iexplore.exe";
                process.StartInfo.Arguments = Constant.FacebookGroup;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }
    }
}