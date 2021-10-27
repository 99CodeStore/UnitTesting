using NUnit.Framework;

namespace Fundamentals.Tests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();           

            Assert.That(()=> calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<System.ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(45, 0)]
        [TestCase(65, 0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(71, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_SpeedBelowOrEqualSpeedLimit_ZeroDemeitPoints(int speed,int expectedResult)
        {
            var calculator = new DemeritPointsCalculator();
            var answer = calculator.CalculateDemeritPoints(speed);
            Assert.That(answer, Is.EqualTo(expectedResult), "No Demerits Points");
        }
    }
}
