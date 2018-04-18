using Huanlin.Braille;
using NChinese.Phonetic;
using NUnit.Framework;

namespace Test.Huanlin.Braille
{
    /// <summary>
    ///This is a test class for Huanlin.Braille.BrailleDocument and is intended
    ///to contain all Huanlin.Braille.BrailleDocument Unit Tests
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
		public void LoadTest()
		{
			BrailleProcessor processor = 
                BrailleProcessor.GetInstance(
                    new ZhuyinReverseConverter(
                        new ZhuyinReverseConversionProvider()));

            string filename = Shared.TestDataPath + "TestData_Braille.txt";
			BrailleDocument brDoc = new BrailleDocument(filename, processor, 32);

			brDoc.LoadAndConvert();
		}

	}


}
