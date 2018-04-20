using Config.Net;

namespace EasyBrailleEdit.Common.Config
{
    public interface IPrintingConfig
    {
        [Option(Alias = "Printing.BraillePrinterName", DefaultValue = "")]
        string BraillePrinterName { get; set; }

        [Option(Alias = "Printing.BraillePrinterPort", DefaultValue = "LPT1")]
        string BraillePrinterPort { get; set; }

        [Option(Alias = "Printing.DefaultTextPrinter", DefaultValue = "")]
        string DefaultTextPrinter { get; set; }

        [Option(Alias = "Printing.PrintBrailleSendPageBreakAtEndOfDoc", DefaultValue = false)]
        bool PrintBrailleSendPageBreakAtEndOfDoc { get; set; }

        [Option(Alias = "Printing.PrintBrailleToBrailler", DefaultValue = true)]
        bool PrintBrailleToBrailler { get; set; }

        [Option(Alias = "Printing.PrintBrailleToFile", DefaultValue = false)]
        bool PrintBrailleToFile { get; set; }

        [Option(Alias = "Printing.PrintBrailleToFileName", DefaultValue = "")]
        string PrintBrailleToFileName { get; set; }

        [Option(Alias = "Printing.PrintPageFoot", DefaultValue = true)]
        bool PrintPageFoot { get; set; }

        [Option(Alias = "Printing.PrintTextFontName", DefaultValue = "新細明體")]
        string PrintTextFontName { get; set; }

        [Option(Alias = "Printing.PrintTextFontSize", DefaultValue = Constant.DefaultPrintTextFontSize)]
        double PrintTextFontSize { get; set; }

        [Option(Alias = "Printing.PrintTextLineHeight", DefaultValue = 40.0975)]
        double PrintTextLineHeight { get; set; }

        [Option(Alias = "Printing.PrintTextMarginLeft", DefaultValue = Constant.DefaultPrintTextMarginLeft)]
        int PrintTextMarginLeft { get; set; }

        [Option(Alias = "Printing.PrintTextMarginTop", DefaultValue = Constant.DefaultPrintTextMarginTop)]
        int PrintTextMarginTop { get; set; }

        [Option(Alias = "Printing.PrintTextMarginRight", DefaultValue = Constant.DefaultPrintTextMarginRight)]
        int PrintTextMarginRight { get; set; }

        [Option(Alias = "Printing.PrintTextMarginBottom", DefaultValue = Constant.DefaultPrintTextMarginBottom)]
        int PrintTextMarginBottom { get; set; }

        #region 偶數頁的明眼字列印邊界

        [Option(Alias = "Printing.PrintTextMarginLeft2", DefaultValue = Constant.DefaultPrintTextMarginLeft2)]
        int PrintTextMarginLeft2 { get; set; }

        [Option(Alias = "Printing.PrintTextMarginTop2", DefaultValue = Constant.DefaultPrintTextMarginTop2)]
        int PrintTextMarginTop2 { get; set; }

        [Option(Alias = "Printing.PrintTextMarginRight2", DefaultValue = Constant.DefaultPrintTextMarginRight2)]
        int PrintTextMarginRight2 { get; set; }

        [Option(Alias = "Printing.PrintTextMarginBottom2", DefaultValue = Constant.DefaultPrintTextMarginBottom2)]
        int PrintTextMarginBottom2 { get; set; }

        #endregion

        [Option(Alias = "Printing.PrintTextPaperName", DefaultValue = "")]
        string PrintTextPaperName { get; set; }

        [Option(Alias = "Printing.PrintTextPaperSourceName", DefaultValue = "")]
        string PrintTextPaperSourceName { get; set; }
    }
}
