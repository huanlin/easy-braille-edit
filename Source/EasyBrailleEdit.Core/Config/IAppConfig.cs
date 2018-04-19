﻿using Config.Net;

namespace EasyBrailleEdit.Core.Config
{

    public interface IAppConfig
    {
        // General section

        [Option(Alias = "General.AutoUpdate", DefaultValue = true)]
        bool AutoUpdate { get; set; }

        [Option(Alias = "General.AutoUpdateFilesUrl", DefaultValue = Constant.DefaultAutoUpdateFilesUrl)]
        string AutoUpdateFilesUrl { get; set; }


        /// <summary>
        /// 是否優先使用 IFELanguage API 來反查注音字根。預設為 False。
        /// </summary>
        [Option(Alias = "General.PreferIFELanguage", DefaultValue = false)]
        bool PreferIFELanguage { get; set; }

        /// 詞庫檔。
        /// </summary>
        [Option(Alias = "General.PhraseFiles", DefaultValue = "")]
        string PhraseFiles { get; set; }

        IBrailleConfig Braille { get; set; }

        IPrintingConfig Printing { get; set; }
    }
}
