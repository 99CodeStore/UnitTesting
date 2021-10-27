using NUnit.Framework;

namespace Fundamentals.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result= FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(12);
            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.That(result, Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_InputIsNoDivisibleBy3And5_ReturnSame()
        {
            var result = FizzBuzz.GetOutput(7);
            Assert.That(result, Is.EqualTo(7.ToString()));
        }
    }
}