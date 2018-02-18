using System.Data;
using System.IO;
using System.Windows.Forms;

namespace EasyBrailleEdit
{


    /// <summary>
    /// 注意!!!
    /// 每當增加一個欄位，就要修改 Load 方法，增加判斷該欄位是否為 null 的程式碼，
    /// 以免組態檔中沒有該欄位時，導致程式出現錯誤。
    /// 
    /// 如果是使用者不能調整的應用程式進階設定，應放在 App.config 裡面。
    /// </summary>
    partial class AppOptions
    {
        partial class MainDataTable
        {
        }

        private const string SettingsFileName = "Settings.xml";

        // 預設明眼字列印邊界
        public const int DefaultPrintTextMarginLeft = 105;
        public const int DefaultPrintTextMarginTop = 15;
        public const int DefaultPrintTextMarginRight = 150;
        public const int DefaultPrintTextMarginBottom = 100;

        public const double DefaultPrintTextFontSize = 12;      // 預設明眼字字型大小
        public const double DefaultPrintTextLineHeight = 40.0975;  // 明眼字列高（文字高度+列距）
        public const double DefaultPrintTextLineSpace = 20.9;   // 預設明眼字列距

        public int CellsPerLine
        {
            get { return Main[0].CellsPerLine; }
            set { Main[0].CellsPerLine = value; }
        }

        public int LinesPerPage
        {
            get { return Main[0].LinesPerPage; }
            set { Main[0].LinesPerPage = value; }
        }

        public string DefaultTextPrinter
        {
            get { return Main[0].DefaultTextPrinter; }
            set { Main[0].DefaultTextPrinter = value; }
        }

        public bool PrintPageFoot
        {
            get { return Main[0].PrintPageFoot; }
            set { Main[0].PrintPageFoot = value; }
        }

        public bool PrintBrailleToBrailler
        {
            get { return Main[0].PrintBrailleToBrailler; }
            set { Main[0].PrintBrailleToBrailler = value; }
        }

        public bool PrintBrailleToFile
        {
            get { return Main[0].PrintBrailleToFile; }
            set { Main[0].PrintBrailleToFile = value; }
        }

        public string PrintBrailleToFileName
        {
            get { return Main[0].PrintBrailleToFileName; }
            set { Main[0].PrintBrailleToFileName = value; }
        }

        public string BraillePrinterPort
        {
            get { return Main[0].BraillePrinterPort; }
            set { Main[0].BraillePrinterPort = value; }
        }

        public string PrintTextPaperSourceName
        {
            get { return Main[0].PrintTextPaperSourceName; }
            set { Main[0].PrintTextPaperSourceName = value; }
        }

        public string PrintTextPaperName
        {
            get { return Main[0].PrintTextPaperName; }
            set { Main[0].PrintTextPaperName = value; }
        }

        public int PrintTextMarginLeft
        {
            get { return Main[0].PrintTextMarginLeft; }
            set { Main[0].PrintTextMarginLeft = value; }
        }

        public int PrintTextMarginTop
        {
            get { return Main[0].PrintTextMarginTop; }
            set { Main[0].PrintTextMarginTop = value; }
        }

        public int PrintTextMarginRight
        {
            get { return Main[0].PrintTextMarginRight; }
            set { Main[0].PrintTextMarginRight = value; }
        }

        public int PrintTextMarginBottom
        {
            get { return Main[0].PrintTextMarginBottom; }
            set { Main[0].PrintTextMarginBottom = value; }
        }

        public int PrintTextMarginLeft2
        {
            get { return Main[0].PrintTextMarginLeft2; }
            set { Main[0].PrintTextMarginLeft2 = value; }
        }

        public int PrintTextMarginTop2
        {
            get { return Main[0].PrintTextMarginTop2; }
            set { Main[0].PrintTextMarginTop2 = value; }
        }

        public int PrintTextMarginRight2
        {
            get { return Main[0].PrintTextMarginRight2; }
            set { Main[0].PrintTextMarginRight2 = value; }
        }

        public int PrintTextMarginBottom2
        {
            get { return Main[0].PrintTextMarginBottom2; }
            set { Main[0].PrintTextMarginBottom2 = value; }
        }

        public string PrintTextFontName
        {
            get { return Main[0].PrintTextFontName; }
            set { Main[0].PrintTextFontName = value; }
        }

        public double PrintTextFontSize
        {
            get { return Main[0].PrintTextFontSize; }
            set { Main[0].PrintTextFontSize = value; }
        }

        public double PrintTextLineHeight
        {
            get { return Main[0].PrintTextLineHeight; }
        }

        public string BraillePrinterName
        {
            get { return Main[0].BraillePrinterName; }
            set { Main[0].BraillePrinterName = value; }
        }

        public bool UseNewLineForPageBreak
        {
            get { return Main[0].PrintBrailleUseNewLineForPageBreak; }
            set { Main[0].PrintBrailleUseNewLineForPageBreak = value; }
        }

        public bool PrintBrailleSendPageBreakAtEndOfDoc
        {
            get { return Main[0].PrintBrailleSendPageBreakAtEndOfDoc; }
            set { Main[0].PrintBrailleSendPageBreakAtEndOfDoc = value; }
        }

        /// <summary>
        /// 容易判斷錯誤的破音字，這些中文字在雙視編輯視窗中會以紅色顯示，以提醒使用者注意。
        /// </summary>
        public string ErrorProneWords
        {
            get { return Main[0].ErrorProneWords; }
            set { Main[0].ErrorProneWords = value; }
        }

        private static string GetOptionsFileName()
        {
            return Application.StartupPath + "\\" + SettingsFileName;
        }

        public void Load()
        {
            AppOptions options = AppGlobals.Options;

            string filename = GetOptionsFileName();
            if (File.Exists(filename))
            {
                // 必須使用 InferSchema，若用 IgnoreSchema，會因為日後新增欄位而無法從既有的檔案載入資料。
                options.ReadXml(filename, XmlReadMode.InferSchema);

                MainRow row = options.Main[0];

                if (row.IsLinesPerPageNull())
                {
                    row.LinesPerPage = AppConst.DefaultLinesPerPage;
                }

                if (row.IsCellsPerLineNull())
                {
                    row.CellsPerLine = AppConst.DefaultCellsPerLine;
                }

                if (row.IsPrintPageFootNull())
                {
                    row.PrintPageFoot = true;
                }

                if (row.IsErrorProneWordsNull())
                {
                    row.ErrorProneWords = "為和";
                }

                if (row.IsDefaultTextPrinterNull())
                {
                    row.DefaultTextPrinter = "";
                }

                if (row.IsPrintBrailleToBraillerNull())
                {
                    row.PrintBrailleToBrailler = true;
                }

                if (row.IsPrintBrailleToFileNull())
                {
                    row.PrintBrailleToFile = false;
                }

                if (row.IsPrintBrailleToFileNameNull())
                {
                    row.PrintBrailleToFileName = "";
                }

                if (row.IsBraillePrinterPortNull())
                {
                    row.BraillePrinterPort = "LPT1";
                }

                if (row.IsPrintTextPaperSourceNameNull())
                {
                    row.PrintTextPaperSourceName = "";
                }

                if (row.IsPrintTextPaperNameNull())
                {
                    row.PrintTextPaperName = "";
                }

                if (row.IsPrintTextMarginLeftNull())
                {
                    row.PrintTextMarginLeft = DefaultPrintTextMarginLeft;
                }

                if (row.IsPrintTextMarginTopNull())
                {
                    row.PrintTextMarginTop = DefaultPrintTextMarginTop;
                }

                if (row.IsPrintTextMarginRightNull())
                {
                    row.PrintTextMarginRight = DefaultPrintTextMarginRight;
                }

                if (row.IsPrintTextMarginBottomNull())
                {
                    row.PrintTextMarginBottom = DefaultPrintTextMarginBottom;
                }

                if (row.IsPrintTextMarginLeft2Null())
                {
                    row.PrintTextMarginLeft2 = DefaultPrintTextMarginLeft;
                }

                if (row.IsPrintTextMarginTop2Null())
                {
                    row.PrintTextMarginTop2 = DefaultPrintTextMarginTop;
                }

                if (row.IsPrintTextMarginRight2Null())
                {
                    row.PrintTextMarginRight2 = DefaultPrintTextMarginRight;
                }

                if (row.IsPrintTextMarginBottom2Null())
                {
                    row.PrintTextMarginBottom2 = DefaultPrintTextMarginBottom;
                }

                if (row.IsPrintTextFontSizeNull())
                {
                    row.PrintTextFontSize = DefaultPrintTextFontSize;
                }

                if (row.IsPrintTextLineHeightNull())
                {
                    row.PrintTextLineHeight = DefaultPrintTextLineHeight;
                }

                if (row.IsPrintTextFontNameNull())
                {
                    row.PrintTextFontName = "新細明體";
                }

                if (row.IsBraillePrinterNameNull())
                {
                    row.BraillePrinterName = "";
                }

                if (row.IsPrintBrailleUseNewLineForPageBreakNull())
                {
                    row.PrintBrailleUseNewLineForPageBreak = false;
                }

                if (row.IsPrintBrailleSendPageBreakAtEndOfDocNull())
                {
                    row.PrintBrailleSendPageBreakAtEndOfDoc = false;
                }
            }
            if (options.Main.Rows.Count < 1)
            {
                AppOptions.MainRow row = options.Main.NewMainRow();
                row.CellsPerLine = AppConst.DefaultCellsPerLine;
                row.LinesPerPage = AppConst.DefaultLinesPerPage;
                row.DefaultTextPrinter = "";
                row.BraillePrinterPort = "LPT1";
                row.BraillePrinterName = "";
                row.PrintBrailleToFileName = "";
                options.Main.AddMainRow(row);

                Save();
            }
        }

        public void Save()
        {
            string filename = GetOptionsFileName();
            AppGlobals.Options.WriteXml(filename, System.Data.XmlWriteMode.IgnoreSchema);
        }
    }
}

