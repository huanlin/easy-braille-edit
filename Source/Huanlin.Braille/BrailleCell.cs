using System;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;
using Huanlin.Common.Helpers;

namespace Huanlin.Braille
{
    /// <summary>
    /// 點字碼列舉常數。
    /// </summary>
    public enum BrailleCellCode
    {
        Blank       = 0x00,	// 空方的點字碼的十六進位字串。
        Capital     = 0x20,	// 大寫
        Digit       = 0x3C,	// 數字
        Italic      = 0x28,	// 斜體
        Hyphen      = 0x24	// 連字號 '-'        
    }

    /// <summary>
    /// 代表點字的一方 (Braille Cell Dimension)。
    /// NOTE: 每一個 BrailleCell 物件是預先建立且共用的，因此 
    ///       BrailleCell 的 Value 屬性絕對不可讓外界修改!!
    /// </summary>
    [Serializable]
    [DataContract]
    public sealed class BrailleCell
    {
        private static BrailleCell[] m_AllCells;

        // 點字值。六點是以從上到下，由左至右的順序分別對應到 byte 的
        // 高位元至低位元。最低兩個位元沒有用到，固定為 0。
        private byte m_Value;

        static BrailleCell()
        {
            // 建立好 256 個 BraillCell 物件。
            // NOTE: 其實只用到前面 64 個，因為只有六點，用到的位元為 0..5，範圍是
            //       00..3F。考慮到未來支援八點的點字，故使用 256。

            m_AllCells = new BrailleCell[256];
            for (int i = 0; i < m_AllCells.Length; i++)
            {
                m_AllCells[i] = new BrailleCell((byte) i);
            }
        }

        public static BrailleCell GetInstance(BrailleCellCode code)
        {
            return m_AllCells[(int)code];
        }

        public static BrailleCell GetInstance(int index)
        {
            if (index < 0 || index >= m_AllCells.Length)
                throw new IndexOutOfRangeException("傳入 BrailleCell.GetInstance() 的索引超出範圍!");
            return m_AllCells[index];
        }

        public static BrailleCell GetInstance(string hexStr)
        {
            if (String.IsNullOrEmpty(hexStr) || hexStr.Length > 2)
                throw new ArgumentException("參數錯誤: 不是有效的十六進位字串值!");
            return GetInstance(StrHelper.HexStrToByte(hexStr));
        }

        /// <summary>
        /// 以指定點位的方式傳回 BrailleCell 物件。
        /// </summary>
        /// <param name="dots">點位陣列，例如：3、6 點則為 new int[] {3, 6}。</param>
        /// <returns></returns>
        public static BrailleCell GetInstance(int[] dots)
        {
            return GetInstance(DotsToByte(dots));
        }

        /// <summary>
        /// 將點位轉換成 byte 值。
        /// </summary>
        /// <param name="dots">點位</param>
        /// <returns></returns>
        public static byte DotsToByte(params int[] dots)
        {
            BitArray bits = new BitArray(8, false);

            foreach (int dotNum in dots)
            {
                if (dotNum < 1 || dotNum > 6)
                    throw new ArgumentException("參數錯誤：點位必須為 1～6 點!");
                bits[dotNum - 1] = true;
            }

            return ConvertHelper.BitsToByte(bits);
        }

        private BrailleCell(byte value)
        {
            m_Value = value;
        }

        /// <summary>
        /// 建構函式。
        /// </summary>
        /// <param name="hexStr">十六進位的字串，不可加 '0x' 或 'H'。</param>
        private BrailleCell(string hexStr)
        {
            if (String.IsNullOrEmpty(hexStr) || hexStr.Length > 2)
                throw new ArgumentException("參數錯誤: 不是有效的十六進位字串值!");
            m_Value = StrHelper.HexStrToByte(hexStr);
        }

        public override int GetHashCode()
        {
            return m_Value;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            BrailleCell brCell = (BrailleCell)obj;
            if (m_Value != brCell.Value)
                return false;
            return true;
        }

        [DataMember]
        public byte Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        public static BrailleCell Blank
        {
            get 
            {
                return GetInstance(BrailleCellCode.Blank);
            }			
        }

        public static BrailleCell Capital
        {
            get
            {
                return GetInstance(BrailleCellCode.Capital);
            }
        }


        public override string ToString()
        {
            return m_Value.ToString("X2", CultureInfo.CurrentUICulture);
        }
    }
}
