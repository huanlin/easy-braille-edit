using System.Collections.Generic;
using Huanlin.Braille;
using Huanlin.Braille.Converters;
using NUnit.Framework;

namespace Test.Huanlin.Braille
{
    /// <summary>
    ///This is a test class for Huanlin.Braille.EnglishWordConverter and is intended
    ///to contain all Huanlin.Braille.EnglishWordConverter Unit Tests
    ///</summary>
    [TestFixture]
    public class EnglishWordConverterTest
    {
        [SetUp]
        public void SetUp()
        {
            Shared.SetupLogger();
        }

        /// <summary>
        ///A test for Convert (Stack&lt;char&gt;)
        ///</summary>
        [Test]
        public void ConvertTest()
        {
            string msg = "EnglishWordConverter.Convert 測試失敗: ";

            EnglishWordConverter target = new EnglishWordConverter();

			ContextTagManager context = new ContextTagManager();

            // 測試刪節號。
            string text = "...";
            Stack<char> charStack = new Stack<char>(text);
            List<BrailleWord> expected = new List<BrailleWord>();
            BrailleWord brWord = new BrailleWord(text, "040404");
            expected.Add(brWord);
            List<BrailleWord> actual = target.Convert(charStack, context);
            CollectionAssert.AreEqual(expected, actual, msg + text);
            charStack.Clear();

            // 測試左單引號。
            text = "‘";
            charStack = new Stack<char>(text);
            brWord = new BrailleWord(text, "2026");
            expected.Clear();
            expected.Add(brWord);
            actual = target.Convert(charStack, context);
            CollectionAssert.AreEqual(expected, actual, msg + text);
            charStack.Clear();

            // 測試左雙引號。
            text = "“";
            charStack = new Stack<char>(text);
            brWord = new BrailleWord(text, "26");
            expected.Clear();
            expected.Add(brWord);
            actual = target.Convert(charStack, context);
            CollectionAssert.AreEqual(expected, actual, msg + text);
            charStack.Clear();

            // 測試大寫字母（不用加大寫記號，因為延後到整行調整時才處理）。
            text = "A";
            charStack = new Stack<char>(text);
            brWord = new BrailleWord(text, "01");
            expected.Clear();
            expected.Add(brWord);
            actual = target.Convert(charStack, context);
            CollectionAssert.AreEqual(expected, actual, msg + text);
            charStack.Clear();  
          
            // 測試數字
            text = "6";
            charStack = new Stack<char>(text);
            brWord = new BrailleWord(text, "16");	// 下位點。
            expected.Clear();
            expected.Add(brWord);
            actual = target.Convert(charStack, context);
            CollectionAssert.AreEqual(expected, actual, msg + text);
            charStack.Clear();            
        }
    }
}
