using System;
using System.Collections.Generic;
using System.Text;

namespace BrailleToolkit
{
    // 列舉常數 for 情境標籤的生命週期（何時要移除該情境標籤）
    public enum ContextLifetime
    {
        BeforeConvertion,   // 只存在於點字轉換動作之前。
        BeforeFormatDoc,    // 在點字轉換過程中，直到整份文件進行斷行之前。
        EndOfFormatDoc      // 在整份文件斷行完畢之後即消失。
    }

    public class ContextTagNames
    {
        public const string Title = "<標題>";
        public const string Indent = "<縮排>";
        public const string Math = "<數學>";
        public const string Coordinate = "<座標>";
		public const string Fraction = "<分數>";
		public const string Table = "<表格>";
		public const string Time = "<時間>";
		public const string Delete = "<刪>";
		public const string Phonetic = "<音標>";

		// NOTE: 每當有變動時，必須同步修改 AllTagNames 的內容。
    }

    /// <summary>
    /// 情境標籤。用途主要是供 ContextTagManager 記錄某情境標籤在特定時間點的出現次數。
    /// 注意：此標籤物件皆為起始標籤。
    /// </summary>
    public abstract class ContextTag
    {
        public static List<string> AllTagNames;

        protected string m_TagName;
        protected ContextLifetime m_Lifetime;
        protected bool m_SingleLine;      // 是否為單列標籤（整列只能有此標籤，不能包含其他標籤）
        protected int m_Count;            // 出現的次數

        static ContextTag()
        {
            AllTagNames = new List<string>();
            AllTagNames.Add(ContextTagNames.Title);
            AllTagNames.Add(ContextTagNames.Indent);
            AllTagNames.Add(ContextTagNames.Math);
            AllTagNames.Add(ContextTagNames.Coordinate);
			AllTagNames.Add(ContextTagNames.Fraction);
			AllTagNames.Add(ContextTagNames.Table);
			AllTagNames.Add(ContextTagNames.Time);
			AllTagNames.Add(ContextTagNames.Delete);
			AllTagNames.Add(ContextTagNames.Phonetic);
        }

        /// <summary>
        /// 根據標籤名稱建立對應的 ContextTag 物件。
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static ContextTag CreateInstance(string tagName)
        {
            switch (tagName)
            {
                case ContextTagNames.Math:
                    return new MathContextTag();
                case ContextTagNames.Indent:
                    return new IndentContextTag();
                case ContextTagNames.Title:
                    return new TitleContextTag();
                default:
                    return new GenericContextTag(tagName, ContextLifetime.BeforeFormatDoc, false);
            }
            //throw new ArgumentException("呼叫 ContextTag.CreateInstance() 時傳入的參數 tagName 無效: " + tagName);
        }

        /// <summary>
        /// 比對傳入的字串是否為特定的標籤。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static bool IsTag(string value, string tagName)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(tagName))
                return false;
            if (value.Equals(tagName))
                return true;
            tagName = tagName.Insert(1, "/");   // 結束標籤
            if (value.Equals(tagName))
                return true;
            return false;
        }

        public static bool IsTitleTag(string s)
        {
            return IsTag(s, ContextTagNames.Title);
        }

        /// <summary>
        /// 檢查傳入的字串是否是以情境標籤（含起始及結束標籤）開頭。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool StartsWithContextTag(string s)
        {
            string beginTag;
            string endTag;
            bool found = false;

            foreach (string tagName in AllTagNames)
            {
                beginTag = tagName;
                endTag = beginTag.Insert(1, "/");
                if (s.StartsWith(beginTag) || s.StartsWith(endTag))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

		/// <summary>
		/// 傳回結束標籤字串。
		/// </summary>
		/// <param name="tagName"></param>
		/// <returns></returns>
		public static string GetEndTagName(string tagName)
		{
			if (tagName[1] == '/')
			{
				return tagName;
			}
			return tagName.Insert(1, "/");
		}

        public ContextTag() 
        {
            m_Lifetime = ContextLifetime.BeforeFormatDoc;
            m_SingleLine = false;
            m_Count = 0;
        }

        public virtual void Enter()
        {
            m_Count++;
        }

        public virtual void Leave()
        {
            if (m_Count > 0)
            {
                m_Count--;
            }
        }

        public virtual void Reset()
        {
            m_Count = 0;
        }

        #region 屬性

        public string TagName 
        {
            get { return m_TagName; }
            set { m_TagName = value; }
        }

        /// <summary>
        /// 傳回結束標籤名稱。
        /// </summary>
        public string EndTagName
        {
            get { return m_TagName.Insert(1, "/"); }
        }

        public ContextLifetime Lifetime
        {
            get { return m_Lifetime; }
            set { m_Lifetime = value; }
        }

        public bool SingleLine
        {
            get { return m_SingleLine; }
            set { m_SingleLine = value; }
        }

        public int Count
        {
            get { return m_Count; }
        }

        /// <summary>
        /// 傳回此情境標籤目前是否在作用中。
        /// </summary>
        public bool IsActive
        {
            get
            {
                if (m_Count > 0)
                    return true;
                return false;
            }
        }

        #endregion
    }

    internal class GenericContextTag : ContextTag
    {
        public GenericContextTag(string tagName, ContextLifetime lifeTime, bool singleLine)
        {
            m_TagName = tagName;
            m_Lifetime = lifeTime;
            m_SingleLine = singleLine;
        }
    }

    /// <summary>
    /// 縮排情境標籤。
    /// </summary>
    internal class IndentContextTag : ContextTag
    {
        public IndentContextTag() : base()
        {
            m_TagName = ContextTagNames.Indent;
            m_Lifetime = ContextLifetime.BeforeFormatDoc;
            m_SingleLine = false;
        }
    }

    /// <summary>
    /// 數學情境標籤。
    /// </summary>
    internal class MathContextTag : ContextTag
    {
        public MathContextTag() : base()
        {
            m_TagName = ContextTagNames.Math;
            m_Lifetime = ContextLifetime.BeforeFormatDoc;
            m_SingleLine = false;
        }
    }

    /// <summary>
    /// 標題情境標籤。用於指定頁標題。
    /// </summary>
    internal class TitleContextTag : ContextTag
    {
        public TitleContextTag() : base()
        {
            m_TagName = ContextTagNames.Title;
            m_Lifetime = ContextLifetime.EndOfFormatDoc;
            m_SingleLine = true;
        }
    }

	/// <summary>
	/// 分數情境標籤。
	/// </summary>
	internal class FractionContextTag : ContextTag
	{
		public FractionContextTag()
			: base()
		{
			m_TagName = ContextTagNames.Title;
			m_Lifetime = ContextLifetime.EndOfFormatDoc;
			m_SingleLine = true;
		}
	}
}
