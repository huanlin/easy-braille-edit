using System.IO;
using System.Reflection;
using Huanlin.Helpers;
using SharpConfig;

namespace Huanlin.Braille
{
    public class BrailleConfiguration : IBrailleConfiguration
    {
        private Configuration m_Config = null;
        private string m_ConfigFileName = null;

        private const string ConfigFileName = "Braille.ini";
        private const string ConversionSectionName = "Conversion";

        public BrailleConfiguration()
        {
            Load();
        }

        public void Load()
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
                        Enabled = true;
                    }
                    catch
                    {
                        Enabled = false;
                    }
                }
            }
        }

        public void Save()
        {
            if (!Enabled)
                return;
            m_Config.SaveToFile(m_ConfigFileName);
        }

        public bool Enabled { get; private set; }

        public bool AutoIndentNumberedLine
        {
            get => m_Config [ConversionSectionName]["AutoIndentNumberedLine"].BoolValue;
            set => m_Config[ConversionSectionName]["AutoIndentNumberedLine"].BoolValue = value;
        }
    }
}
