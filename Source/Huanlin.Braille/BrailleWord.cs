using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Huanlin.Braille.Data;
using Huanlin.Common.Helpers;
using NChinese.Phonetic;

namespace Huanlin.Braille
{
    public enum BrailleLanguage
    {
        Neutral = 0,
        Chinese,
        English
    };


	/// <summary>
	/// 代表一個中文字，內含注音碼與點字值。
	/// </summary>
    [Serializable]
    [DataContract]
	public class BrailleWord
	{
        private static BrailleWord m_Blank;

		private string m_Text;	// 字元。可能是一個英數字、中文字、全形標點符號、或雙字元標點符號，例如：破折號。
        private BrailleLanguage m_Language;     // 語言國別。用來識別是中文還是英文。
		private BrailleCellList m_CellList;	    // 點字。        
        private List<string> m_PhoneticCodes;   // 所有注音組字字根（以支援破音字）。
        private int m_ActivePhoneticIndex;      // 目前使用的注音組字字根索引。
        private bool m_DontBreakLineHere;       // 設定/判別在斷行時是否能斷在這個字。

        [NonSerialized]
        private string m_PhoneticCode;          // 注音字根（ㄅㄆㄇㄈ）。

        [NonSerialized]
        private bool m_IsPolyphonic;          // 是否為多音字。

        [NonSerialized]
        private bool m_IsContextTag;            // 是否為情境標籤（情境標籤不會包含實際可印的點字）

        [NonSerialized]
        private bool m_NoDigitCell;             // 是否不加數符。

		[NonSerialized]
		private bool m_IsEngPhonetic;			// 是否為英語音標（用來判斷不要加空方）.

		//private bool m_QuotationResolved;	// 是否已經識別出左右引號（英文的單引號和雙引號都是同一個符號，但點字不同）

        static BrailleWord()
        {
            m_Blank = BrailleWord.NewBlank();
        }

        /// <summary>
        /// 建立並傳回情境標籤的 BrailleWord。
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static BrailleWord CreateAsContextTag(string tagName)
        {
            BrailleWord brWord = new BrailleWord();
            brWord.Text = tagName;
            brWord.IsContextTag = true;

            return brWord;
        }

		public BrailleWord()
		{
			m_Text = "";
            m_Language = BrailleLanguage.Neutral;
			m_CellList = new BrailleCellList();

            m_PhoneticCodes = new List<string>();
            m_ActivePhoneticIndex = -1;

            m_DontBreakLineHere = false;

            m_IsContextTag = false;
            m_NoDigitCell = false;
			m_IsEngPhonetic = false;
		}

        public BrailleWord(string aWord, BrailleCellCode brCode)
            : this()
        {
            m_Text = aWord;
            m_CellList.Add(BrailleCell.GetInstance(brCode));
        }

        public BrailleWord(string aWord, string brCode) : this()
        {
            m_Text = aWord;
            AddCell(brCode);
        }

		public BrailleWord(string aWord, byte brCode) : this()
		{
			m_Text = aWord;
			m_CellList.Add(BrailleCell.GetInstance(brCode));
		}

		public BrailleWord(string aWord, string phCode, string brCode) : this(aWord, brCode)
		{
            m_Language = BrailleLanguage.Chinese;
			m_PhoneticCodes.Add(phCode);
            m_ActivePhoneticIndex = 0;
		}

		public override int GetHashCode()
		{
			return m_Text.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
				return true;

			BrailleWord brWord = (BrailleWord)obj;

			if (m_CellList.Count != brWord.Cells.Count)
				return false;
			for (int i = 0; i < m_CellList.Count; i++)
			{				
				if (!m_CellList[i].Equals(brWord.Cells[i]))
					return false;
			}

			// 不比對注音，因為一聲常常和全形空白搞混。
			//if (m_PhoneticCode != brWord.PhoneticCode)
			//    return false;

			// 不比對文字，因為全形空白和半形空白其實應視為相等，比較 cells 就夠了。
			//if (m_Text != brWord.Text)
			//
			//{
			//    return false;
			//}

			return true;
		}

		public override string ToString()
		{
			return m_Text;
		}

		public void Clear()
		{
			m_CellList.Clear();
		}

        [DataMember]
		public string Text
		{
			get { return m_Text; }
			set { m_Text = value; }			
		}

        public int CellCount
        {
            get { return m_CellList.Count; }
        }
        
		public List<BrailleCell> Cells
		{
			get
			{
				return m_CellList.Items;
			}
		}

        [DataMember]
        public BrailleCellList CellList
        {
            get
            {
                return m_CellList;
            }
            set
            {
                m_CellList = value;
            }
        }

        [DataMember]
		public string PhoneticCode
		{
			get
			{
                if (String.IsNullOrEmpty(m_PhoneticCode))   // 這是為了向下相容，舊版沒有 PhoneticCode 屬性。
                {
                    // 若沒有注音字根，則傳回空字串。
                    if (m_PhoneticCodes == null || m_PhoneticCodes.Count < 1 || m_ActivePhoneticIndex < 0)
                    {
                        return "";
                    }
                    return m_PhoneticCodes[m_ActivePhoneticIndex];
                }
                return m_PhoneticCode;
			}
            set
            {
                if (m_PhoneticCode == value)
                    return;
                m_PhoneticCode = value;
/*
                // 若沒有注音字根，則增加一個。
                if (m_PhoneticCodes.Count < 1)
                {
                    m_PhoneticCodes.Add(value);
                    m_ActivePhoneticIndex = 0;
                }
                else
                {   // 否則設定作用中的注音字根索引
                    int i = m_PhoneticCodes.IndexOf(value);
                    if (i < 0)
                    {
                        m_PhoneticCodes.Add(value);
                        i = m_PhoneticCodes.Count - 1;
                        System.Diagnostics.Trace.WriteLine("指定給 BrailleWord.PhoneticCode 的注音字根不存在! 已自動加入。");
                    }
                    m_ActivePhoneticIndex = i;
                }
*/
            }
		}

        [DataMember]
        public bool IsPolyphonic
        {
            get 
            {
                if (m_PhoneticCodes != null && m_PhoneticCodes.Count > 1)   // for 向下相容.
                {
                    return true;
                }
                return m_IsPolyphonic; 
            }
            set { m_IsPolyphonic = value; }
        }

        [DataMember]
        public bool DontBreakLineHere
        {
            get { return m_DontBreakLineHere; }
            set { m_DontBreakLineHere = value; }
        }

        public List<string> PhoneticCodes
        {
            get
            {
                if (m_PhoneticCodes == null)
                {
                    m_PhoneticCodes = new List<string>();
                }
                return m_PhoneticCodes;
            }
        }

        public int ActivePhoneticIndex
        {
            get
            {
                return m_ActivePhoneticIndex;
            }
            set
            {
                if (value >= m_PhoneticCodes.Count)
                    throw new ArgumentOutOfRangeException();
                m_ActivePhoneticIndex = value;
            }
        }

        public BrailleLanguage Language
        {
            get
            {
                return m_Language;
            }
            set
            {
                m_Language = value;
            }
        }

        public void SetPhoneticCodes(string[] phCodes)
        {
            m_PhoneticCodes.Clear();
            m_PhoneticCodes.AddRange(phCodes);
        }

        /// <summary>
        /// 建立一個新的 BrailleWord 物件，並將自己的內容完整複製到新的物件。
        /// </summary>
        /// <returns></returns>
		public BrailleWord Copy()
		{
			BrailleWord newBrWord = new BrailleWord();
			newBrWord.Text = m_Text;
            newBrWord.Language = m_Language;
			newBrWord.DontBreakLineHere = m_DontBreakLineHere;
			newBrWord.NoDigitCell = m_NoDigitCell;

            foreach (BrailleCell brCell in m_CellList.Items)
            {
                newBrWord.Cells.Add(brCell);
            }

            newBrWord.PhoneticCode = this.PhoneticCode;
            newBrWord.IsPolyphonic = this.IsPolyphonic;

/* PhoneticCodes 已經要淘汰
            newBrWord.PhoneticCodes.Clear();
            newBrWord.PhoneticCodes.AddRange(m_PhoneticCodes);
            newBrWord.ActivePhoneticIndex = m_ActivePhoneticIndex;
*/
			return newBrWord;
		}

        /// <summary>
        /// 將指定的 BrailleWord 內容完整複製給自己。
        /// </summary>
        /// <param name="brWord"></param>
        public void Copy(BrailleWord brWord)
        {
            System.Diagnostics.Debug.Assert(brWord != null, "參數 brWord 不可為 NULL!");

            m_Text = brWord.Text;
            m_Language = brWord.Language;

            m_CellList.Clear();
            foreach (BrailleCell brCell in brWord.CellList.Items)
            {
                m_CellList.Add(brCell);
            }

            m_PhoneticCode = brWord.PhoneticCode;
            m_IsPolyphonic = brWord.m_IsPolyphonic;
/*
            // 複製所有注音字根與點字串列, for 向下相容.
            if (brWord.PhoneticCodes != null)
            {
                m_PhoneticCodes.Clear();
                m_PhoneticCodes.AddRange(brWord.PhoneticCodes);
                m_ActivePhoneticIndex = brWord.ActivePhoneticIndex;
            }
 */
        }

        /// <summary>
        /// 把指定的點字字串（16進位）轉成 BrailleCell 物件，並加入點字串列中。
        /// </summary>
        /// <param name="brCode">欲加入串列的點字碼 16 進位字串。</param>
        public void AddCell(string brCode)
        {
            if (String.IsNullOrEmpty(brCode))
            {
                return;
            }

            for (int i = 0; i < brCode.Length; i += 2)
            {
                string s = brCode.Substring(i, 2);
                byte aByte = StrHelper.HexStrToByte(s);
                BrailleCell cell = BrailleCell.GetInstance(aByte);
                m_CellList.Add(cell);
            }
        }

        public bool IsWhiteSpace
        {
            get
            {
                if (m_Text.Length == 1)
                {
                    if (Char.IsWhiteSpace(m_Text[0]))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

		public bool IsLetter
		{
            get
            {
                if (m_Text.Length == 1)
                {
                    if (CharHelper.IsAsciiLetter(m_Text[0]))
                    {
                        return true;
                    }
                }
                return false;
            }
		}

		public bool IsDigit
		{
            get
            {
                if (m_Text.Length == 1)
                {
                    if (CharHelper.IsAsciiDigit(m_Text[0]))
                    {
                        return true;
                    }
                }
                return false;
            }
		}

		public bool IsLetterOrDigit
		{
            get
            {
                if (m_Text.Length == 1)
                {
                    if (CharHelper.IsAsciiLetterOrDigit(m_Text[0]))
                    {
                        return true;
                    }
                }
                return false;
            }
		}


        /// <summary>
        /// 傳回此點字是否為中文字（以是否有注音字根為判斷依據）。
        /// 注意：跟 Language 屬性無關，Language 屬性包含中文標點符號
        /// </summary>
        /// <returns></returns>
        public bool IsChinese
        {
            get
            {
                if (!String.IsNullOrEmpty(m_PhoneticCode))
                    return true;
                if (!String.IsNullOrEmpty(m_Text) && Zhuyin.IsTone(m_Text[0]))
                    return true;
                if (m_PhoneticCodes != null)
                {
                    return (m_PhoneticCodes.Count > 0);
                }
                return false;
            }
        }

        /// <summary>
        /// 建立一個新的空方點字物件。
        /// </summary>
        /// <returns></returns>
        public static BrailleWord NewBlank()
        {
            return new BrailleWord(" ", BrailleCellCode.Blank);
        }

        /// <summary>
        /// 檢查指定的 BrailleWord 是否為空方。
        /// </summary>
        /// <param name="brWord"></param>
        /// <returns></returns>
        public static bool IsBlank(BrailleWord brWord)
        {
            if (brWord.Equals(BrailleWord.m_Blank))
                return true;
            return false;
        }

		/// <summary>
		/// 檢查指定的 BrailleWord 物件是否沒有包含任何有意義的資料（空方算有意義的資料）。
		/// </summary>
		/// <param name="brWord"></param>
		/// <returns></returns>
		public static bool IsEmpty(BrailleWord brWord)
		{
			if (StrHelper.IsEmpty(brWord.Text) && brWord.CellCount < 1) 
			{
				// 文字為空字串，且沒有任何點字物件，即視為空的 BrailleWord 物件.
				return true;
			}
			return false;
		}

        /// <summary>
        /// 是否為情境標籤。
        /// </summary>
        public bool IsContextTag
        {
            get { return m_IsContextTag; }
            set
            {
                m_IsContextTag = value;
                if (m_IsContextTag)    // 如果是控制字，就要清除點字串列
                {
                    m_CellList.Clear();
                }
            }
        }

        public bool NoDigitCell
        {
            get { return m_NoDigitCell; }
            set { m_NoDigitCell = value; }
        }

		public bool IsEngPhonetic
		{
			get { return m_IsEngPhonetic; }
			set { m_IsEngPhonetic = value; }
		}

        /// <summary>
        /// 檢查指定的 BrailleWord 是否為數字編號的起始點字。亦即以 # 開頭的數字。
        /// </summary>
        /// <param name="brWord"></param>
        /// <returns></returns>
        public static bool IsOrderedListItem(BrailleWord brWord)
        {
            if (brWord.Cells.Count < 2)
                return false;
            if (brWord.Cells[0].Value == (byte)BrailleCellCode.Digit) // 以數字點開頭？
            {
                // 接著比較第二方是否為上位點，注意這裡的上位點數值並未使用查表，
                // 而是寫死在程式裡。參考: BraillTableEng.xml。
                // TODO: 改成查表。
                byte value = brWord.Cells[1].Value;
                switch (value) 
                {
                    case 0x01:  case 0x03:
                    case 0x09:  case 0x19:
                    case 0x11:  case 0x0B:
                    case 0x1B:  case 0x13:
                    case 0x4A:  case 0x1A:
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }

        /// <summary>
        /// 檢查指定的 BrailleWord 是否為國語標點符號。
        /// </summary>
        /// <param name="brWord"></param>
        /// <returns></returns>
        public static bool IsChinesePunctuation(BrailleWord brWord)
        {
            ChineseBrailleTable chtBrlTbl = ChineseBrailleTable.GetInstance();
            string brCode = chtBrlTbl.FindPunctuation(brWord.Text);
            if (String.IsNullOrEmpty(brCode))
                return false;
            return true;
        }
	}
}
