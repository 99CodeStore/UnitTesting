using NUnit.Framework;
using Fundamentals;
 

namespace Fundaementals.Tests
{
    [TestFixture()]
    public class ErrorLogerTests
    {
        [Test()]
        public void Log_WhenCall_SetLastErrorPropery()
        {
            var _logger = new ErrorLoger();
            _logger.Log("First error");


        }
    }
}