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

        [Test]
		public void Should_LoadFromFileAndConvert_Succeed()
		{
			BrailleProcessor processor = 
                BrailleProcessor.GetInstance(new ZhuyinReverseConverter(null));

            string filename = Shared.TestDataPath + "TestData_Braille.txt";
			BrailleDocument brDoc = new BrailleDocument(filename, processor, 32);

			brDoc.LoadAndConvert();
		}

        [Test]
        public void Should_ConvertFraction_Succeed()
        {
            BrailleProcessor processor =
                BrailleProcessor.GetInstance(new ZhuyinReverseConverter(null));

            BrailleDocument brDoc = new BrailleDocument(processor, 32);

            brDoc.Convert("<分數>1/2</分數>");
        }

    }

}
