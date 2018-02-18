using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

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
			string fileVer = " v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVesion.Text = "易點雙視 " + fileVer;
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
				process.StartInfo.Arguments = linkLabel1.Text;
				process.StartInfo.UseShellExecute = true;
				process.Start();
			}
		}
    }
}