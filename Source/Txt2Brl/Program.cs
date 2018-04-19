using System;
using System.Collections.Generic;
using System.IO;
using EasyBrailleEdit.Core;
using Serilog;

namespace Txt2Brl
{
    class Program
	{
		const int DefaultCellsPerLine = 40;

		[STAThread]
		static int Main(string[] args)
		{
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .WriteTo.RollingFile(@"Logs\log-txt2brl-{Date}.txt")
                .CreateLogger();

            Console.WriteLine("Txt2Brl version 2.9 Copyright(c) 2007-2018 Michael Tsai.\n");

			List<string> switches = new List<string>();
			string inFileName = null;
			string outFileName = null;

			if (!ParseArgs(args, out inFileName, out outFileName, switches))
			{
				ShowUsage();
				return -1;
			}

			// Switches
			int cellsPerLine = DefaultCellsPerLine;
			bool verboseMode = false;

			if (!ParseSwitches(switches, ref cellsPerLine, ref verboseMode))
			{
				ShowUsage();
				return -1;
			}

			Console.WriteLine("★注意：執行點字轉換的過程中，請勿關閉此視窗!!!");
			Console.WriteLine(" ");
			Console.WriteLine("轉換工作開始於 " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

			DoConvert(inFileName, outFileName, cellsPerLine, verboseMode);

			Console.Write(System.Environment.NewLine);
			Console.WriteLine("轉換工作結束於 " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

			return 0;
		}

		private static void ShowUsage()
		{
			Console.WriteLine("使用方法: Txt2Brl <輸入檔名> [輸出檔名] [參數]\n");
			Console.WriteLine("參數:\n");
			Console.WriteLine("    -Cn : 每列最大方數。\n");
			Console.WriteLine("    -V  : 冗長資訊模式。\n");
		}

		private static bool ParseArgs(string[] args, 
			out string inFileName, out string outFileName, List<string> switches) 
		{
			inFileName = null;
			outFileName = null;

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i][0] == '-' || args[i][0] == '/')
				{
					switches.Add(args[i].Remove(0, 1));
				}
				else
				{
					if (String.IsNullOrEmpty(inFileName))
					{
						inFileName = args[i];
					}
					else if (String.IsNullOrEmpty(outFileName))
					{
						outFileName = args[i];
					}
				}
			}

			if (String.IsNullOrEmpty(inFileName))
			{
				return false;
			}
			if (String.IsNullOrEmpty(outFileName)) 
			{
				outFileName = Path.ChangeExtension(inFileName, Constant.Files.DefaultBrailleFileExt);
			}

			return true;
		}

		private static bool ParseSwitches(List<string> switches, ref int cellsPerLine, ref bool verboseMode)
		{
			char sw;
			string value;
			int valueInt;
			const int ImpossibleValue = 999999999;

			for (int i = 0; i < switches.Count; i++)
			{
				sw = Char.ToUpper(switches[i][0]);

				value = null;
				valueInt = ImpossibleValue;

				if (switches[i].Length > 1)
				{
					value = switches[i].Remove(0, 1);
					try
					{
						valueInt = Convert.ToInt32(value);
					}
					catch
					{
					}
				}
				switch (sw)
				{
					case 'C':	// cells per line.
						if (valueInt == ImpossibleValue)
						{
							return false;
						}
						cellsPerLine = valueInt;
						break;
					case 'V':	// Verbose mode.
						verboseMode = true;
						break;
					default:
						break;
				}
			}
			return true;
		}

		private static void DoConvert(string inFileName, string outFileName, 
			int cellsPerLine, bool verboseMode)
		{
			BrailleConverter cvt = new BrailleConverter();

			cvt.ConvertFile(inFileName, outFileName, cellsPerLine, verboseMode);
		}
	}
}
