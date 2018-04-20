﻿using Config.Net;

namespace EasyBrailleEdit.Common.Config
{
    public interface IBrailleConfig
    {
        [Option(Alias= "Braille.CellsPerLine", DefaultValue = Constant.DefaultCellsPerLine)]
        int CellsPerLine { get; set; }

        [Option(Alias = "Braille.LinesPerPage", DefaultValue = Constant.DefaultLinesPerPage)]
        int LinesPerPage { get; set; }

        /// <summary>
        /// 以 '#' 開頭的編號項目是否要在折行時自動內縮一方。
        /// </summary>
        [Option(Alias = "Braille.AutoIndentNumberedLine", DefaultValue = false)]
        bool AutoIndentNumberedLine { get; set; }

        /// <summary>
        /// 容易判斷錯誤的破音字，這些中文字在雙視編輯視窗中會以紅色顯示，以提醒使用者注意。
        /// </summary>
        [Option(Alias = "Braille.ErrorProneWords", DefaultValue = "為")]
        string ErrorProneWords { get; set; }
    }
}
