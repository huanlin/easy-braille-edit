using System.IO;
using System.Reflection;
using System.Text;
using Huanlin.Helpers;
using Nini.Config;

namespace EasyBrailleEdit
{
    /// <summary>
    /// 此類別是用來封裝應用程式組態檔。
    /// </summary>
    public class AppConfig
    {
        private const string IniFileName = "AppConfig.ini";
        private const string IniFileNameDefault = "AppConfig.Default.ini";

        private static AppConfig m_Self = null;
        private string m_FileName;

        private IniConfigSource m_CfgSrc = null;
        private IConfig m_AppLooksCfg = null;		// App 外觀設定
        private IConfig m_AppBehaviorCfg = null;	// App 行為設定
        private IConfig m_PrintCfg = null;			// 列印相關設定
        private IConfig m_InternetCfg = null;		// 網際網路設定

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
                        sb.AppendLine("[Internet]");
                        sb.AppendLine($"AppUpdateFilesUri={AppConst.DefaultAppUpdateFilesUri}");
                        File.WriteAllText(m_FileName, sb.ToString(), Encoding.Default);
                    }
                }
                using (StreamReader sr = new StreamReader(m_FileName, Encoding.Default))
                {
                    m_CfgSrc = new IniConfigSource(sr);
                    CreateSections();
                }
            }
        }

        private void CreateSections()
        {
            m_AppLooksCfg = m_CfgSrc.Configs["App.Looks"];
            if (m_AppLooksCfg == null)
            {
                m_AppLooksCfg = m_CfgSrc.AddConfig("App.Looks");
            }

            m_AppBehaviorCfg = m_CfgSrc.Configs["App.Behavior"];
            if (m_AppBehaviorCfg == null)
            {
                m_AppBehaviorCfg = m_CfgSrc.AddConfig("App.Behavior");
            }

            m_PrintCfg = m_CfgSrc.Configs["Print"];
            if (m_PrintCfg == null)
            {
                m_PrintCfg = m_CfgSrc.AddConfig("Print");
            }

            m_InternetCfg = m_CfgSrc.Configs["Internet"];
            if (m_InternetCfg == null)
            {
                m_InternetCfg = m_CfgSrc.AddConfig("Internet");
            }
        }

        public static AppConfig Self
        {
            get
            {
                if (AppConfig.m_Self == null)
                {
                    m_Self = new AppConfig();
                }
                return m_Self;
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(m_FileName, false, Encoding.Default))
            {
                m_CfgSrc.Save(sw);
            }
        }

        #region App.Behavior 組態的相關屬性

        public bool AutoUpdate
        {
            get
            {
                return m_AppBehaviorCfg.GetBoolean("AutoUpdate", true);
            }
            set
            {
                m_AppBehaviorCfg.Set("AutoUpdate", value);
            }
        }

        /// <summary>
        /// 詞庫檔。
        /// </summary>
        public string PhraseFiles
        {
            get
            {
                return m_AppBehaviorCfg.GetString("PhraseFiles", "Phrase.phf=1");
            }
            set
            {
                m_AppBehaviorCfg.Set("PhraseFiles", value);
            }
        }

        #endregion

        public string AppUpdateFilesUri
        {
            get
            {
                return m_InternetCfg.GetString("AppUpdateFilesUri", AppConst.DefaultAppUpdateFilesUri);
            }
            set
            {
                m_InternetCfg.Set("AppUpdateFilesUri", value);
            }
        }
    }
}
