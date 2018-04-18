using System;
using System.Collections.Generic;
using System.Text;

namespace BrailleToolkit
{
    /// <summary>
    /// 情境標籤管理員。
    /// </summary>
    public class ContextTagManager
    {
        private List<ContextTag> m_Tags;

        public ContextTagManager()
        {
            m_Tags = new List<ContextTag>();

            foreach (string tagName in ContextTag.AllTagNames) 
            {
                m_Tags.Add(ContextTag.CreateInstance(tagName));
            }
        }

        /// <summary>
        /// 重設所有情境標籤的狀態。
        /// </summary>
        public void Reset()
        {
            foreach (ContextTag tag in m_Tags)
            {
                tag.Reset();
            }
        }

        /// <summary>
        /// 剖析傳入的字串，如果是以情境標籤開頭，就遞增或遞減
        /// 該情境標籤的計數值（根據它是起始還是結束標籤而定）。
        /// </summary>
        /// <param name="s">傳入的字串。</param>
        /// <param name="isBeginTag">傳回的旗號，若為 true，表示找到起始標籤，若為 false，則為結束標籤。</param>
        /// <returns>若有找到情境標籤，則傳回 ContextTag 物件，並設定 isBeginTag 輸出參數。</returns>
        public ContextTag Parse(string s, out bool isBeginTag)
        {
            ContextTag result = null;

            string beginTag;
            string endTag;

            isBeginTag = false;

            foreach (ContextTag tag in m_Tags)
            {
                beginTag = tag.TagName;
                endTag = beginTag.Insert(1, "/");
                if (s.StartsWith(beginTag))
                {
                    // 進入此情境
                    tag.Enter();

                    result = tag;
                    isBeginTag = true;
                    break;
                }
                else if (s.StartsWith(endTag)) // 結束標籤
                {
                    // 離開此情境
                    tag.Leave();

                    result = tag;
                    isBeginTag = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 剖析傳入的字串，如果是以指定的標籤開頭，就遞增或遞減
        /// 該情境標籤的計數值（根據它是起始還是結束標籤而定）。
        /// </summary>
        /// <param name="s">輸入字串。</param>
        /// <param name="tagName">指定的標籤。</param>
        /// <returns></returns>
        public ContextTag Parse(string s, string tagName)
        {
            ContextTag result = null;

            string beginTag;
            string endTag;

            foreach (ContextTag tag in m_Tags)
            {
                if (!tag.TagName.Equals(tagName))
                    continue;

                beginTag = tag.TagName;
                endTag = beginTag.Insert(1, "/");
                if (s.StartsWith(beginTag))
                {
                    // 進入此情境
                    tag.Enter();

                    result = tag;
                    break;
                }
                else if (s.StartsWith(endTag)) // 結束標籤
                {
                    // 離開此情境
                    tag.Leave();

                    result = tag;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 傳回指定的情境標籤目前是否在作用中。
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool IsActive(string tagName)
        {
            foreach (ContextTag tag in m_Tags)
            {
                if (tag.TagName.Equals(tagName))
                {
                    return tag.IsActive;
                }
            }
            return false;
        }

        /// <summary>
        /// 傳回縮排的數量。
        /// </summary>
        public int IndentCount
        {
            get
            {
                foreach (ContextTag tag in m_Tags)
                {
                    if (tag.TagName.Equals(ContextTagNames.Indent))
                    {
                        return tag.Count;
                    }
                }
                throw new Exception("無法取得縮排數量!");
            }
        }
    }
}
