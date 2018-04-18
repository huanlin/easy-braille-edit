namespace Huanlin.Braille
{
    public interface IBrailleConfiguration
    {
        bool Enabled { get; }

        /// <summary>
        /// 當以 # 開頭的編號項目文字折行時，是否要自動內縮一方。
        /// </summary>
        bool AutoIndentNumberedLine { get; set; }

        void Load();
        void Save();
    }
}
