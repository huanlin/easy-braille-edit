﻿using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using BrailleToolkit;
using EasyBrailleEdit.Common;
using Huanlin.Windows.Forms;

namespace EasyBrailleEdit
{
    public partial class DualPrintDialog : Form
    {
        private BrailleDocument m_BrDoc;

        private string m_PaperSourceName;
        private string m_PaperName;
        private Margins m_OddPageMargins;
        private Margins m_EvenPageMargins;
        private string m_TextFontName;
        private double m_TextFontSize;

        private bool m_DontSaveSettings = false;

        private DualPrintDialog()
        {
            InitializeComponent();
        }

        public DualPrintDialog(BrailleDocument brDoc)
            : this()
        {
            m_BrDoc = brDoc;
        }

        public DualPrintDialog(string filename)
            : this()
        {
            m_BrDoc = BrailleDocument.LoadBrailleFile(filename);
        }

        private void LoadSettings()
        {			
            var cfg = AppGlobals.Config.Printing;

            chkPrintPageFoot.Checked = cfg.PrintPageFoot;
            chkChangeStartPageNum.Checked = false;
            txtStartPageNumber.Text = "1";
            cboPrintTextManualDoubleSide.SelectedIndex = 0;
            chkPrintBraille.Checked = cfg.PrintBrailleToBrailler;
            chkPrintBrailleToFile.Checked = cfg.PrintBrailleToFile;
            txtBrailleFileName.TextBox.Text = cfg.PrintBrailleToFileName;
            chkSendPageBreakAtEof.Checked = cfg.PrintBrailleSendPageBreakAtEndOfDoc;
            lblLinesPerPage.Text = AppGlobals.Config.Braille.LinesPerPage.ToString();
            lblCellsPerLine.Text = m_BrDoc.CellsPerLine.ToString();

            m_PaperSourceName = cfg.PrintTextPaperSourceName;
            m_PaperName = cfg.PrintTextPaperName;
            m_TextFontName = cfg.PrintTextFontName;
            m_TextFontSize = cfg.PrintTextFontSize;
            m_OddPageMargins = new Margins(cfg.PrintTextMarginLeft, cfg.PrintTextMarginRight, cfg.PrintTextMarginTop, cfg.PrintTextMarginBottom);
            m_EvenPageMargins = new Margins(cfg.PrintTextMarginLeft2, cfg.PrintTextMarginRight2, cfg.PrintTextMarginTop2, cfg.PrintTextMarginBottom2);

            cboPrinters.Items.Clear();
            cboPrintersForBraille.Items.Clear();
            cboPrintersForBraille.Items.Add(AppGlobals.Config.Printing.BraillePrinterPort);
            foreach (string s in PrinterSettings.InstalledPrinters)
            {
                cboPrinters.Items.Add(s);
                cboPrintersForBraille.Items.Add(s);
            }
            if (!String.IsNullOrEmpty(cfg.DefaultTextPrinter))
            {
                cboPrinters.SelectedIndex = cboPrinters.Items.IndexOf(cfg.DefaultTextPrinter);
            }
            if (!String.IsNullOrWhiteSpace(cfg.BraillePrinterName))
            {
                cboPrintersForBraille.Text = cfg.BraillePrinterName;
            }
        }

        private void SaveSettings()
        {
            var cfgPrint = AppGlobals.Config.Printing;

            cfgPrint.PrintPageFoot = chkPrintPageFoot.Checked;
            cfgPrint.DefaultTextPrinter = cboPrinters.Text;
            cfgPrint.BraillePrinterName = cboPrintersForBraille.Text;
            cfgPrint.PrintBrailleToBrailler = chkPrintBraille.Checked;
            cfgPrint.PrintBrailleToFile = chkPrintBrailleToFile.Checked;
            cfgPrint.PrintBrailleToFileName = txtBrailleFileName.TextBox.Text;
            cfgPrint.PrintTextPaperSourceName = m_PaperSourceName;
            cfgPrint.PrintTextPaperName = m_PaperName;
            cfgPrint.PrintTextMarginLeft = m_OddPageMargins.Left;
            cfgPrint.PrintTextMarginTop = m_OddPageMargins.Top;
            cfgPrint.PrintTextMarginRight = m_OddPageMargins.Right;
            cfgPrint.PrintTextMarginBottom = m_OddPageMargins.Bottom;
            cfgPrint.PrintTextMarginLeft2 = m_EvenPageMargins.Left;
            cfgPrint.PrintTextMarginTop2 = m_EvenPageMargins.Top;
            cfgPrint.PrintTextMarginRight2 = m_EvenPageMargins.Right;
            cfgPrint.PrintTextMarginBottom2 = m_EvenPageMargins.Bottom;
            cfgPrint.PrintTextFontName = m_TextFontName;
            cfgPrint.PrintTextFontSize = m_TextFontSize;

            cfgPrint.PrintBrailleSendPageBreakAtEndOfDoc = chkSendPageBreakAtEof.Checked;
        }

        private void DualPrintDialog_Load(object sender, EventArgs e)
        {
            LoadSettings();		// 載入上次的設定。

            txtBrailleFileName.Button.Click += SelectBrailleFileNameButton_Click;
            chkPrintBrailleToFile_CheckedChanged(chkPrintBrailleToFile, EventArgs.Empty);
            chkPrintBraille_CheckedChanged(chkPrintBraille, EventArgs.Empty);
        }

        void SelectBrailleFileNameButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".BRP",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = txtBrailleFileName.TextBox.Text,
                Title = "指定要輸出的檔案名稱",
                Filter = "*.BRP|*BRP"  // Braille for Print.
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBrailleFileName.TextBox.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// 將目前的列印參數蒐集並集中存入 PrintOptions 物件。
        /// </summary>
        /// <returns></returns>
        private PrintOptions GetPrintOptions()
        {
            PrintOptions prnOpt = new PrintOptions
            {
                LinesPerPage = AppGlobals.Config.Braille.LinesPerPage,
                PrintPageFoot = chkPrintPageFoot.Checked,

                // 列印範圍
                AllPages = rdoPrintAll.Checked
            };
            if (!prnOpt.AllPages) 
            {
                string[] pageRange = txtPageRange.Text.Split(new char[] {'-'});
                if (pageRange.Length != 2)
                {
                    MsgBoxHelper.ShowInfo("列印範圍無效: " + txtPageRange.Text);
                    txtPageRange.Focus();
                    return null;
                }

                prnOpt.FromPage = Convert.ToInt32(pageRange[0]);
                prnOpt.ToPage = Convert.ToInt32(pageRange[1]);

                if (prnOpt.FromPage <= 0 || prnOpt.ToPage <= 0 || prnOpt.FromPage > prnOpt.ToPage)
                {
                    MsgBoxHelper.ShowInfo("列印範圍無效: " + txtPageRange.Text);
                    txtPageRange.Focus();
                    return null;
                }
                int totalPages = AppGlobals.CalcTotalPages(m_BrDoc.Lines.Count, prnOpt.LinesPerPage, prnOpt.PrintPageFoot);
                if (prnOpt.FromPage > totalPages || prnOpt.ToPage > totalPages)
                {
                    MsgBoxHelper.ShowInfo("列印範圍無效! 起始頁或終止頁超出總頁數。");
                    txtPageRange.Focus();
                    return null;
                }
            }

            // 起始頁碼
            prnOpt.ReassignStartPageNumber = chkChangeStartPageNum.Checked;
            if (prnOpt.ReassignStartPageNumber)
            {
                try
                {
                    prnOpt.StartPageNumber = Convert.ToInt32(txtStartPageNumber.Text);
                    if (prnOpt.StartPageNumber < 1)
                    {
                        MsgBoxHelper.ShowInfo("無效的起始頁碼: " + txtStartPageNumber.Text);
                        return null;
                    }
                }
                catch
                {
                    MsgBoxHelper.ShowInfo("無效的起始頁碼: " + txtStartPageNumber.Text);
                    return null;
                }
            }

            // 手動雙面列印
            switch (cboPrintTextManualDoubleSide.SelectedIndex)
            {
                case 1: 
                    prnOpt.DoubleSideEffect = DoubleSideEffect.OddPages;
                    break;
                case 2:
                    prnOpt.DoubleSideEffect = DoubleSideEffect.EvenPages;
                    break;
                default:
                    prnOpt.DoubleSideEffect = DoubleSideEffect.None;
                    break;
            }

            prnOpt.PrinterName = cboPrinters.Text;
            prnOpt.PrinterNameForBraille = cboPrintersForBraille.Text;
            prnOpt.PaperSourceName = m_PaperSourceName;
            prnOpt.PaperName = m_PaperName;
            prnOpt.OddPageMargins = m_OddPageMargins;
            prnOpt.EvenPageMargins = m_EvenPageMargins;

            prnOpt.BrSendPageBreakAtEndOfDoc = chkSendPageBreakAtEof.Checked;

            return prnOpt;
        }


        /// <summary>
        /// 直接預覽明眼字，而不顯示列印對話窗。
        /// </summary>
        public void PreviewText()
        {
            LoadSettings();	// 載入先前儲存的設定。

            if (m_BrDoc.Lines.Count < 1)
            {
                MsgBoxHelper.ShowInfo("沒有資料可供列印!");
                return;
            }

            if (cboPrinters.SelectedIndex < 0)
            {
                MsgBoxHelper.ShowInfo("尚未選擇印表機!");
                return;
            }

            m_DontSaveSettings = true;				// 視窗關閉時不要儲存設定
            cboPrintTextManualDoubleSide.SelectedIndex = 0;

            PrintOptions prnOpt = GetPrintOptions();
            if (prnOpt == null)
                return;

            DualPrintHelper prn = new DualPrintHelper(m_BrDoc, prnOpt);

            prn.PrintText(true);
        }

        private void btnPrintBraille_Click(object sender, EventArgs e)
        {
            if (m_BrDoc.Lines.Count < 1)
            {
                MsgBoxHelper.ShowInfo("沒有資料可供列印!");
                return;
            }

            bool isToFile = chkPrintBrailleToFile.Checked;
            string fileName = txtBrailleFileName.TextBox.Text.Trim();

            if (isToFile && String.IsNullOrEmpty(fileName)) 
            {
                MsgBoxHelper.ShowInfo("請指定欲輸出的檔案名稱。");
                txtBrailleFileName.Focus();
                return;
            }

            if (chkPrintBraille.Checked)
            {
                if (String.IsNullOrWhiteSpace(cboPrintersForBraille.Text))
                {
                    MessageBox.Show("請指定欲輸出點字的印表機!");
                    cboPrintersForBraille.Focus();
                    return;
                }
            }

            PrintOptions prnOpt = GetPrintOptions();
            if (prnOpt == null)
                return;
            DualPrintHelper prn = new DualPrintHelper(m_BrDoc, prnOpt);
            prn.PrintBraille(chkPrintBraille.Checked, chkPrintBrailleToFile.Checked, fileName);
        }

        private void btnPrintText_Click(object sender, EventArgs e)
        {
            if (m_BrDoc.Lines.Count < 1)
            {
                MsgBoxHelper.ShowInfo("沒有資料可供列印!");
                return;
            }

            if (cboPrinters.SelectedIndex < 0)
            {
                MsgBoxHelper.ShowInfo("尚未選擇印表機!");
                return;
            }

            PrintOptions prnOpt = GetPrintOptions();
            if (prnOpt == null)
                return;

            DualPrintHelper prn = new DualPrintHelper(m_BrDoc, prnOpt);

            prn.PrintText(false);
        }

        private void chkPrintPageNumber_CheckStateChanged(object sender, EventArgs e)
        {
            chkChangeStartPageNum.Enabled = chkPrintPageFoot.Checked;
            txtStartPageNumber.Enabled = chkPrintPageFoot.Checked;
        }

        private void rdoPrintRange_CheckedChanged(object sender, EventArgs e)
        {
            txtPageRange.Enabled = rdoPrintRange.Checked;
        }

        private void chkPrintBrailleToFile_CheckedChanged(object sender, EventArgs e)
        {
            txtBrailleFileName.Enabled = chkPrintBrailleToFile.Checked;
            btnPrintBraille.Enabled = chkPrintBrailleToFile.Checked || chkPrintBraille.Checked;
        }

        private void chkPrintBraille_CheckedChanged(object sender, EventArgs e)
        {
            btnPrintBraille.Enabled = chkPrintBrailleToFile.Checked || chkPrintBraille.Checked;
        }

        private void DualPrintDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 記住這次的設定。
            if (chkRememberOptions.Checked && m_DontSaveSettings == false)
            {
                SaveSettings();
            }
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

        private void chkChangeStartPageNum_CheckStateChanged(object sender, EventArgs e)
        {
            txtStartPageNumber.Enabled = chkChangeStartPageNum.Enabled && chkChangeStartPageNum.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

}