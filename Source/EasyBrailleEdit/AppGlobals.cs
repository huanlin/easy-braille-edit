using System.IO;
using System.Windows.Forms;

namespace EasyBrailleEdit
{
    internal class AppGlobals
    {
        private AppGlobals()
        {
        }

        public static AppOptions Options = null;

        // Class constructor.
        static AppGlobals()
        {
            AppGlobals.Options = new AppOptions();           
            Options.Load();
        }

        /// <summary>
        /// 計算總頁數
        /// </summary>
        /// <param name="totalLines">總列數。</param>
        /// <param name="linesPerPage">每頁可印幾列。</param>
        /// <param name="printPageFoot">是否印頁尾。</param>
        /// <returns></returns>
        public static int CalcTotalPages(int totalLines, int linesPerPage, bool printPageFoot)
        {
            if (printPageFoot)
            {
                linesPerPage--;
            }

            int totalPages = totalLines / linesPerPage;
            if (totalLines % linesPerPage > 0)
            {
                totalPages++;
            }
            return totalPages;
        }

        /// <summary>
        /// 計算指定的列號位於第幾頁。注意：第一頁是傳回 0。
        /// </summary>
        /// <param name="lineNumer">列號，從 0 開始。</param>
        /// <param name="linesPerPage"></param>
        /// <param name="printPageFoot"></param>
        /// <returns>頁號，0-based。</returns>
        public static int CalcCurrentPage(int lineNumer, int linesPerPage, bool printPageFoot)
        {
            if (printPageFoot)
            {
                linesPerPage--;
            }

            int page = lineNumer / linesPerPage;
            return page;
        }

		public static string GetTempPath()
		{
			string path = Application.StartupPath + @"\Temp\";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}
    }
}
