using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EasyBrailleEdit;
using BrailleToolkit;
using NChinese;
using NChinese.Imm;
using NChinese.Phonetic;
using Serilog;

namespace Txt2Brl
{
    public class BrailleConverter 
	{
		BrailleDocument _doc;
		BrailleProcessor _processor;
        ZhuyinReverseConverter _zhuyinConverter;

		string m_OutFileName;
		string m_CvtResultFileName;
		string m_CvtErrorCharFileName;

		bool _verboseMode;

        private ZhuyinReverseConverter CreateZhuyinConverter(bool preferIFELanguage)
        {
            IReverseConversionProvider provider = null;
            if (preferIFELanguage)
            {
                provider = new ImmZhuyinConversionProvider();
                Log.Debug("注音字根提供者使用 IFELanguage 版本的 ImmZhuyinConversionProvider。");
            }

            if (provider == null || provider.IsAvailable == false)
            {
                provider = new ZhuyinReverseConversionProvider();
                Log.Debug("注音字根提供者使用內建的 ZhuyinReverseConversionProvider。");
            }
            return new ZhuyinReverseConverter(provider);
        }

        public BrailleConverter()
		{
            _zhuyinConverter = CreateZhuyinConverter(AppConfig.Instance.PreferIFELanguage);
            _processor = BrailleProcessor.GetInstance(_zhuyinConverter);
			_doc = new BrailleDocument(_processor);

			_processor.ConvertionFailed += new ConvertionFailedEventHandler(BrailleProcessor_ConvertionFailed);
			_processor.TextConverted += new TextConvertedEventHandler(BrailleProcessor_TextConverted);

			//m_Processor.ChineseConverter = null;	// 保護

			m_CvtResultFileName = GetTempPath() + AppConst.CvtResultFileName;
			m_CvtErrorCharFileName = GetTempPath() + AppConst.CvtErrorCharFileName;

			_verboseMode = false;

			LoadPhraseFiles();

            // TODO: 還需要這個嗎？
            ZhuyinQueryHelper.Initialize(); // 初始化注音字根查詢器（載入注音字根表）。
		}

		/// <summary>
		/// 載入使用者自訂詞庫。
		/// </summary>
		private void LoadPhraseFiles()
		{
			string phraseListFileName = GetTempPath() + AppConst.CvtInputPhraseListFileName;
			if (!File.Exists(phraseListFileName))
			{
				return;
			}

			string[] phraseFiles = File.ReadAllLines(phraseListFileName, Encoding.UTF8);

			string fname;
            ZhuyinPhraseTable phtbl = ZhuyinPhraseTable.GetInstance();

			foreach (string s in phraseFiles)
			{
				fname = s.Trim().ToLower();
				if (String.IsNullOrEmpty(fname))
					continue;
				if (!File.Exists(fname))    // 檔案如果不存在，就不處理
					continue;
				phtbl.Load(fname);
			}
		}

		/// <summary>
		/// 執行點字轉檔。
		/// </summary>
		/// <param name="inFileName">輸入的明眼字檔名。</param>
		/// <param name="outFileName">輸出的點字檔名。</param>
		/// <param name="cellsPerLine">每列最大方數。</param>
		/// <param name="verboseMode">冗長資訊模式。</param>
		public void ConvertFile(string inFileName, string outFileName, 
			int cellsPerLine, bool verboseMode) 
		{
			m_OutFileName = outFileName;

			PrepareConvertion();

			try
			{
				_doc.CellsPerLine = cellsPerLine;

				_doc.LoadAndConvert(inFileName);

				if (!_processor.HasError)	// 轉換過程都沒錯誤才輸出點字檔
				{
					_doc.SaveBrailleFile(outFileName);
				}

				_doc.Clear();
				_doc = null;

				WriteInvalidCharsToFile();

				WriteResultToFile();

			}
			finally
			{
				FinalizeConversion();
			}
		}

		/// <summary>
		/// 儲存轉換失敗的字元。
		/// </summary>
		private void WriteInvalidCharsToFile()
		{	
			using (StreamWriter sw = new StreamWriter(m_CvtErrorCharFileName, false, Encoding.Default))
			{
				foreach (CharPosition ch in _processor.InvalidChars)
				{
					sw.Write(ch.LineNumber.ToString());	// 列號
					sw.Write(' ');
					sw.Write(ch.CharIndex.ToString());	// 字元索引
					sw.Write(' ');
					sw.WriteLine(ch.CharValue);			// 字元值
				}
				sw.Flush();
				sw.Close();
			}
		}

		/// <summary>
		/// 將轉換結果寫入檔案。
		/// 檔案的第 1 列若為 "0" 表示完全沒錯誤，若為 "1" 表示有錯誤（exception 或有無法轉換的字元）。
		/// 檔案的第 2 列以後為錯誤訊息。
		/// </summary>
		private void WriteResultToFile()
		{
			using (StreamWriter sw = new StreamWriter(m_CvtResultFileName, false, Encoding.Default))
			{
				if (_processor.HasError)
				{
					sw.WriteLine("1");
					sw.WriteLine(_processor.ErrorMessage);
				}
				else
				{
					sw.WriteLine("0");
				}
				sw.Flush();
				sw.Close();
			}
		}

		private void PrepareConvertion()
		{
			if (File.Exists(m_OutFileName)) 
			{
				File.Delete(m_OutFileName);
			}

			if (File.Exists(m_CvtResultFileName))
			{
				File.Delete(m_CvtResultFileName);
			}

			if (File.Exists(m_CvtErrorCharFileName))
			{
				File.Delete(m_CvtErrorCharFileName);
			}
		}

		private void FinalizeConversion()
		{
		}

		public BrailleProcessor Processor
		{
			get { return _processor; }
		}

		/// <summary>
		/// 碰到無法轉換的字元時觸發此事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void BrailleProcessor_ConvertionFailed(object sender, ConvertionFailedEventArgs args)
		{
			Console.Write(System.Environment.NewLine);
			Console.WriteLine("無法轉換: " + args.InvalidChar.CharValue);
/*
			if (m_FailedCharFile != null)
			{
				m_FailedCharFile.Write(args.InvalidChar.LineNumber.ToString());
				m_FailedCharFile.Write(' ');
				m_FailedCharFile.Write(args.InvalidChar.CharIndex.ToString());
				m_FailedCharFile.Write(' ');
				m_FailedCharFile.WriteLine(args.InvalidChar.CharValue);
				m_FailedCharFile.Flush();
			}
*/ 
		}

		private void BrailleProcessor_TextConverted(object sender, TextConvertedEventArgs e)
		{
			if (_verboseMode)
			{
				// 輸出每次轉好的文字
				Console.WriteLine(e.LineNumber.ToString() + ": " + e.Text);
			}
			else
			{
				Console.Write(".");
			}
		}

		/// <summary>
		/// NOTE: 此函式的邏輯必須跟 EasyBrailleEdit\AppGlobals 的一樣！
		/// </summary>
		/// <returns></returns>
		public string GetTempPath()
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
