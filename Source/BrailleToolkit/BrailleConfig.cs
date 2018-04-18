using System.IO;
using System.Reflection;
using Huanlin.Common.Helpers;
using SharpConfig;

namespace BrailleToolkit
{
    /// <summary>
    /// 點字組態。
    /// </summary>
    public class BrailleConfig
    {
        private static bool m_Activated = false;
        private static Configuration m_Config = null;
        private static string m_ConfigFileName = null;

        private const string ConfigFileName = "Braille.ini";
        private const string ConversionSectionName = "Conversion";

        private BrailleConfig()
        {

        }

        static BrailleConfig()
        {
            Assembly asmb = Assembly.GetEntryAssembly();
            if (asmb != null)
            {
                m_ConfigFileName = StrHelper.ExtractFilePath(asmb.Location) + ConfigFileName;
                if (File.Exists(m_ConfigFileName))
                {
                    try
                    {
                        m_Config = Configuration.LoadFromFile(m_ConfigFileName);
                        m_Activated = true;
                    }
                    catch
                    {
                        m_Activated = false;
                    }
                }
            }
        }

        public static void Save()
        {
            if (!m_Activated)
                return;

            m_Config.SaveToFile(m_ConfigFileName);
        }

        public static bool Activated
        {
            get { return m_Activated; }
        }

        #region 組態屬性

		/// <summary>
		/// 當以 # 開頭的編號項目文字折行時，是否要自動內縮一方。
		/// </summary>
		public static bool AutoIndentNumberedLine
        {
			get
            {
                return m_Config[ConversionSectionName]["AutoIndentNumberedLine"].BoolValue;
            }
			set
            {
                m_Config[ConversionSectionName]["AutoIndentNumberedLine"].BoolValue = value;
            }
        }

        #endregion

    }
}
