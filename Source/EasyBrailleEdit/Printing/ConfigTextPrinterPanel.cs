using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EasyBrailleEdit.Printing
{
    public partial class ConfigTextPrinterPanel : UserControl
    {
        private string m_PaperSourceName;
        private string m_PaperName;
        private Margins m_OddPageMargins;
        private Margins m_EvenPageMargins;
        private string m_TextFontName;
        private double m_TextFontSize;

        public ConfigTextPrinterPanel()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            AppOptions opt = AppGlobals.Options;

            m_PaperSourceName = opt.PrintTextPaperSourceName;
            m_PaperName = opt.PrintTextPaperName;
            m_TextFontName = opt.PrintTextFontName;
            m_TextFontSize = opt.PrintTextFontSize;
            m_OddPageMargins = new Margins(opt.PrintTextMarginLeft, opt.PrintTextMarginRight, opt.PrintTextMarginTop, opt.PrintTextMarginBottom);
            m_EvenPageMargins = new Margins(opt.PrintTextMarginLeft2, opt.PrintTextMarginRight2, opt.PrintTextMarginTop2, opt.PrintTextMarginBottom2);

            cboPrinters.Items.Clear();
            foreach (string s in PrinterSettings.InstalledPrinters)
            {
                cboPrinters.Items.Add(s);
            }
            if (!String.IsNullOrEmpty(opt.DefaultTextPrinter))
            {
                cboPrinters.SelectedIndex = cboPrinters.Items.IndexOf(opt.DefaultTextPrinter);
            }
        }

        public void SaveSettings()
        {
            AppOptions opt = AppGlobals.Options;

            opt.DefaultTextPrinter = cboPrinters.Text;
            opt.PrintTextPaperSourceName = m_PaperSourceName;
            opt.PrintTextPaperName = m_PaperName;
            opt.PrintTextMarginLeft = m_OddPageMargins.Left;
            opt.PrintTextMarginTop = m_OddPageMargins.Top;
            opt.PrintTextMarginRight = m_OddPageMargins.Right;
            opt.PrintTextMarginBottom = m_OddPageMargins.Bottom;
            opt.PrintTextMarginLeft2 = m_EvenPageMargins.Left;
            opt.PrintTextMarginTop2 = m_EvenPageMargins.Top;
            opt.PrintTextMarginRight2 = m_EvenPageMargins.Right;
            opt.PrintTextMarginBottom2 = m_EvenPageMargins.Bottom;
            opt.PrintTextFontName = m_TextFontName;
            opt.PrintTextFontSize = m_TextFontSize;

            opt.Save();
        }
        

        private void ConfigTextPrinterPanel_Load(object sender, EventArgs e)
        {
            LoadSettings();		// 載入上次的設定。
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cboPrinters.Text))
            {
                MessageBox.Show("請先選擇印表機!");
                return;
            }
            TextPageSetupDialog dlg = new TextPageSetupDialog(cboPrinters.Text);
            dlg.PaperSourceName = m_PaperSourceName;
            dlg.PaperName = m_PaperName;
            dlg.FontName = m_TextFontName;
            dlg.FontSize = m_TextFontSize;
            dlg.OddPageMargins = m_OddPageMargins;
            dlg.EvenPageMargins = m_EvenPageMargins;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_PaperSourceName = dlg.PaperSourceName;
                m_PaperName = dlg.PaperName;
                m_OddPageMargins = dlg.OddPageMargins;
                m_EvenPageMargins = dlg.EvenPageMargins;
                m_TextFontName = dlg.FontName;
                m_TextFontSize = dlg.FontSize;
            }			
        }
    }
}
