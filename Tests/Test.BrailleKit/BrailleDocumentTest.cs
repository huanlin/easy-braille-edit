using BrailleToolkit;
using NChinese.Phonetic;
using NUnit.Framework;
using System.Text;

namespace Test.BrailleToolkit
{
    /// <summary>
    ///This is a test class for BrailleToolkit.BrailleDocument and is intended
    ///to contain all BrailleToolkit.BrailleDocument Unit Tests
    ///</summary>
    [TestFixture]
	public class BrailleDocumentTest
	{
        [SetUp]
        public void SetUp()
        {
            Shared.SetupLogger();
        }

        /// <summary>
        ///A test for Load ()
        ///</summary>
        [Test]
		public void Should_LoadFromFileAndConvert_Succeed()
		{
			BrailleProcessor processor = 
                BrailleProcessor.GetInstance(new ZhuyinReverseConverter(null));

            string filename = Shared.TestDataPath + "TestData_Braille.txt";
			BrailleDocument brDoc = new BrailleDocument(filename, processor, 32);

			brDoc.LoadAndConvert();
		}

        [TestCase(
            "小明說：（今天）下雨。",
            "(15 246 4)(134 13456 2)(24 25 3)(25 25)(246)(13 1456 3)(124 2345 3)(135)()(15 23456 5)(1256 4)(36)")]
        public void Should_ConvertString_Succeed(string inputText, string expectedDotNumbers)
        {
            BrailleProcessor processor =
                BrailleProcessor.GetInstance(new ZhuyinReverseConverter(null));

            BrailleDocument brDoc = new BrailleDocument(processor, 32);

            brDoc.Convert(inputText);

            var result = brDoc.Lines[0].ToDotNumberString();
            Assert.AreEqual(result, expectedDotNumbers);            
        }
    }

}
