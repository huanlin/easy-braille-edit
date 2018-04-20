using Config.Net;

namespace EasyBrailleEdit.Common.Config
{
    public interface IBrailleConfig
    {
        [Option(Alias= "Braille.CellsPerLine", DefaultValue = Constant.DefaultCellsPerLine)]
        int CellsPerLine { get; set; }

        [Option(Alias = "Braille.LinesPerPage", DefaultValue = Constant.DefaultLinesPerPage)]
        int LinesPerPage { get; set; }

        /// <summary>
        /// 容易判斷錯誤的破音字，這些中文字在雙視編輯視窗中會以紅色顯示，以提醒使用者注意。
        /// </summary>
        [Option(Alias = "Braille.ErrorProneWords", DefaultValue = "為")]
        string ErrorProneWords { get; set; }
    }
}
