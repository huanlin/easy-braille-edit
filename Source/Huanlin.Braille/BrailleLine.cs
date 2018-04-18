using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Huanlin.Braille
{
    /// <summary>
    /// 用來儲存一列點字。
    /// </summary>
    [Serializable]
    [DataContract]
	public class BrailleLine : ICloneable
	{
		private List<BrailleWord> m_Words;

		public BrailleLine()
		{
			m_Words = new List<BrailleWord>();
		}

		public void Clear()
		{
			m_Words.Clear();
		}

        [DataMember]
		public List<BrailleWord> Words
		{
			get { return m_Words; }
            set { m_Words = value; }
		}

        public int WordCount
        {
            get { return m_Words.Count; }
        }

		public BrailleWord this[int index]
		{
			get
			{
				return m_Words[index];
			}
		}

		/// <summary>
		/// 傳回所有點字的總方數。
		/// </summary>
		public int CellCount
		{
			get
			{
				int cnt = 0;
				foreach (BrailleWord brWord in m_Words)
				{
					cnt += brWord.Cells.Count;
				}
				return cnt;
			}
		}

		/// <summary>
		/// 計算斷行的點字索引位置。
		/// 此處僅根據傳入的最大方數來計算可斷行的點字索引，並未加入其他斷行規則的判斷。
		/// </summary>
		/// <param name="cellsPerLine">一行可允許多少方數。</param>
		/// <returns>可斷行的點字索引。例如，若索引編號第 29 個字（0-based）必須折到下一行，
		/// 傳回值就是 29。若不需要斷行，則傳回整行的字數。</returns>
		public int CalcBreakPoint(int cellsPerLine)
		{
			if (cellsPerLine < 4)
			{
				throw new ArgumentException("cellsPerLine 參數值不可小於 4。");
			}

			int cellCnt = 0;
			int index = 0;
			while (index < m_Words.Count)
			{
				cellCnt += m_Words[index].Cells.Count;
				if (cellCnt > cellsPerLine)
				{
					break;
				}
				index++;
			}
			return index;
		}

		/// <summary>
		/// 從指定的起始位置複製指定個數的點字 (BrailleWord) 到新建立的點字串列。
		/// </summary>
		/// <param name="index">起始位置</param>
		/// <param name="count">要複製幾個點字。</param>
		/// <returns>新的點字串列。</returns>
		public BrailleLine Copy(int index, int count)
		{
			BrailleLine brLine = new BrailleLine();
			BrailleWord newWord = null;
			while (index < m_Words.Count && count > 0)
			{
				//newWord = m_Words[index].Copy();
				newWord = m_Words[index]; 
				brLine.Words.Add(newWord);

				index++;
				count--;

			}
			return brLine;
		}

        public void RemoveAt(int index)
        {
            m_Words.RemoveAt(index);
        }

		public void RemoveRange(int index, int count)
		{
            if ((index + count) > m_Words.Count)    // 防止要取的數量超出邊界。
            {
                count = m_Words.Count - index;
            }
			m_Words.RemoveRange(index, count);
		}

        /// <summary>
        /// 將指定的點字列附加至此點字列。
        /// </summary>
        /// <param name="brLine"></param>
        public void Append(BrailleLine brLine)
        {
            if (brLine == null || brLine.WordCount < 1)
                return;

            m_Words.AddRange(brLine.Words);
        }

        public void Insert(int index, BrailleWord brWord)
        {
            m_Words.Insert(index, brWord);
        }

        /// <summary>
        /// 去掉開頭的空白字元。
        /// </summary>
		public void TrimStart()
		{
			int i = 0;
			while (i < m_Words.Count)
			{
				if (BrailleWord.IsBlank(m_Words[i]) || BrailleWord.IsEmpty(m_Words[i]))
				{
					m_Words.RemoveAt(i);
					continue;
				}
				break;
			}
		}

        /// <summary>
        /// 去掉結尾的空白字元。
        /// </summary>
		public void TrimEnd()
		{
			int i = m_Words.Count - 1;
			while (i >= 0)
			{
				if (BrailleWord.IsBlank(m_Words[i]) || BrailleWord.IsEmpty(m_Words[i]))
				{
					m_Words.RemoveAt(i);
					i--;
					continue;
				}
				break;
			}
		}

		/// <summary>
		/// 把頭尾的空白去掉。
		/// </summary>
		public void Trim()
		{
			TrimStart();
			TrimEnd();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (BrailleWord brWord in m_Words)
			{
				sb.Append(brWord.ToString());
			}
			return sb.ToString();
		}

        /// <summary>
        /// 是否包含標題情境標籤。
        /// </summary>
        /// <returns></returns>
        public bool ContainsTitleTag()
        {
            if (m_Words.Count > 0 && m_Words[0].Text.Equals(ContextTagNames.Title))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除所有情境標籤。
        /// </summary>
        public void RemoveContextTags()
        {
            BrailleWord brWord;

            for (int i = this.WordCount - 1; i >= 0; i--)
            {
                brWord = this.m_Words[i];
                if (brWord.IsContextTag)
                {
                    this.m_Words.RemoveAt(i);
                }
            }
        }

		/// <summary>
		/// 在串列中尋找指定的字串，從串列中的第 startIndex 個字開始找起。
		/// </summary>
		/// <param name="value"></param>
		/// <param name="startIndex"></param>
		/// <param name="comparisonType"></param>
		/// <returns></returns>
		public int IndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			if (startIndex + value.Length > this.WordCount)
			{
				return -1;
			}

			int i;
			StringBuilder sb = new StringBuilder();
			for (i = startIndex; i < this.WordCount; i++)
			{
				sb.Append(m_Words[i].Text);
			}

			int idx = sb.ToString().IndexOf(value, comparisonType);
			if (idx < 0)
			{
				return -1;
			}

			// 有找到，但這是字元索引，還必須修正為點字索引。
			for (i = startIndex; i < this.WordCount; i++)
			{
				idx = idx - m_Words[i].Text.Length + 1;
			}

			return startIndex + idx;
		}

		#region ICloneable Members

		/// <summary>
		/// 深層複製。
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			BrailleLine brLine = new BrailleLine();
			BrailleWord newWord = null;

			foreach (BrailleWord brWord in m_Words)
			{
				newWord = brWord.Copy();
				brLine.Words.Add(newWord);
			}
			return brLine;
		}

		#endregion
	}
}
