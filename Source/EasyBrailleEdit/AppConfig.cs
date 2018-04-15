using System.IO;
using System.Reflection;
using System.Text;
using Huanlin.Helpers;
using SharpConfig;

namespace EasyBrailleEdit
{
    /// <summary>
    /// 此類別是用來封裝應用程式組態檔。
    /// </summary>
    public class AppConfig
    {
        private const string IniFileName = "AppConfig.ini";
        private const string IniFileNameDefault = "AppConfig.Default.ini";
        class SectionNames
        {
            public const  string General = "General";
            public const string Internet = "Internet";
            public const string UI = "UI";
            public const string Print = "Print";
        }

        private static AppConfig m_Self = null;
        private string m_FileName;

        private Configuration m_Config = null;

        private AppConfig()
        {
            Assembly asmb = Assembly.GetEntryAssembly();
            if (asmb != null)
            {
                string path = StrHelper.ExtractFilePath(asmb.Location);
                m_FileName = path + IniFileName;

                if (!File.Exists(m_FileName))
                {
                    string defaultIni = path + IniFileNameDefault;
                    if (File.Exists(defaultIni))
                    {
                        File.Copy(defaultIni, m_FileName);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(";應用程式組態檔");
                        sb.AppendLine($"[{SectionNames.Internet}]");
                        sb.AppendLine($"AppUpdateFilesUri={AppConst.DefaultAppUpdateFilesUri}");
                        File.WriteAllText(m_FileName, sb.ToString(), Encoding.UTF8);
                    }
                }
                m_Config = Configuration.LoadFromFile(m_FileName);
            }
        }

        public static AppConfig Instance
        {
            get
            {
                if (m_Self == null)
                {
                    m_Self = new AppConfig();
                }
                return m_Self;
            }
        }

        public void Save()
        {
            m_Config.SaveToFile(m_FileName);
        }

        #region General section 的相關屬性

        public bool AutoUpdate
        {
            get
            {
                var setting = m_Config[SectionNames.General][nameof(AutoUpdate)]; 
                return setting.IsEmpty ? true : setting.BoolValue;
            }
            set
            {
                m_Config[SectionNames.General][nameof(AutoUpdate)].BoolValue = value;
            }
        }

        /// <summary>
        /// 是否優先使用 IFELanguage API 來反查注音字根。預設為 False。
        /// </summary>
        public bool PreferIFELanguage
        {
            get
            {
                var setting = m_Config[SectionNames.General][nameof(PreferIFELanguage)];
                return setting.IsEmpty ? false : setting.BoolValue;
            }
            set
            {
                m_Config[SectionNames.General][nameof(PreferIFELanguage)].BoolValue = value;
            }
        }

        /// <summary>
        /// 詞庫檔。
        /// </summary>
        public string PhraseFiles
        {
            get
            {
                return m_Config[SectionNames.General][nameof(PhraseFiles)].StringValue;
            }
            set
            {
                m_Config[SectionNames.General][nameof(PhraseFiles)].StringValue = value;
            }
        }

        #endregion

        public string AppUpdateFilesUri
        {
            get
            {
                var s = m_Config[SectionNames.Internet][nameof(AppUpdateFilesUri)].StringValue;
                if (string.IsNullOrWhiteSpace(s))
                    s = AppConst.DefaultAppUpdateFilesUri;
                return s;
            }
            set
            {
                m_Config[SectionNames.Internet][nameof(AppUpdateFilesUri)].StringValue = value;
            }
        }
    }
}
