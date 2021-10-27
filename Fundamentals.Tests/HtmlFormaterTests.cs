using NUnit.Framework;
using Fundamentals;


namespace Fundamentals.Tests
{
    [TestFixture()]
    public class HtmlFormaterTests
    {
        [Test()]
        [TestCase("computer")]
        [TestCase("")]
        [TestCase("Computer")]
        [TestCase("COMPUTER")]
        [TestCase("cOMPUTER")]
        public void FormatAsBold_WhenCalled_ReturnStringEnclosedWithStrongElement(string plainTest)
        {
            var result = new HtmlFormater().FormatAsBold(plainTest);

            Assert.That(result, Does.Contain(plainTest).IgnoreCase);
            Assert.That(result, Does.StartWith("<Strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</Strong>").IgnoreCase);
        }
    }
}