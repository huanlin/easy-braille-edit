namespace EasyBrailleEdit
{
    public class AppConst
    {
        public const string ProductID = "EASYBRAILLEEDIT10";
        public const string AppName = "EasyBrailleEdit";
        public const string UpdateWebUri = "UpdateWeb/EBE2/";    // e.g. http://www.huanlin.com/UpdateWeb/EBE2

        public const string DefaultAppUpdateFilesUri =
            "https://raw.githubusercontent.com/huanlin/EasyBrailleEdit/master/UpdateFiles/";

        // 預設一行最大方數
        public const int DefaultCellsPerLine = 40;
        public const int DefaultLinesPerPage = 25;

        public const string DefaultBrailleFileExt = ".brlj";	// 預設的點字檔副檔名 (舊版為 .btx)

        // 暫存檔案
        public const string CvtInputTempFileName = "cvt_in.tmp";			// 輸入的明眼字檔
        public const string CvtInputPhraseListFileName = "cvt_in_phrase.tmp";	// 輸入的詞庫設定檔
        public const string CvtOutputTempFileName = "cvt_out.tmp";			// 輸出的點字檔
        public const string CvtErrorCharFileName = "cvt_errchar.tmp";		// 儲存轉換失敗的字元資訊
        public const string CvtResultFileName = "cvt_result.tmp";	// 儲存成功或失敗的旗號以及錯誤訊息

        public const string FileNameFilter = "雙視檔案 1.x 版 (*.btx)|*.btx|雙視檔案 2.x 版 (*.brlj)|*.brlj";
        public const int FileNameFilterIndex = 2;
        public const string SaveAsFileNameFilter = "雙視檔案 2.x 版 (*.brlj)|*.brlj";
        public const int SaveAsFileNameFilterIndex = 1;
    }
}
