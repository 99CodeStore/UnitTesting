using NUnit.Framework;
using Fundamentals;
using System;

namespace Fundaementals.Tests
{
    [TestFixture()]
    public class ErrorLogerTests
    {
         private ErrorLoger _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLoger();
        }

        [Test()]
        [TestCase("Simple Error Message")]
        public void Log_WhenCall_SetLastErrorPropery(string error)
        {          
            _logger.Log(error);

            Assert.That(_logger.LastError, Is.EqualTo(error));

        }
        [Test()]
        [TestCase("")]
        [TestCase(null)]
        public void Log_WhenErrorNullOrEmpty_SetLastErrorPropery(string error)
        {

            Assert.That(()=> _logger.Log(error),
                    //  Throws.Exception.TypeOf<System.ArgumentNullException>());

                    Throws.Exception.InstanceOf<System.ArgumentNullException>());

        }
        [Test]
        public void Log_ValidError_RaisedErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _logger.ErrorLogged += (sender,arg)=> {
                id = arg;
            };

            _logger.Log("Sample Error");

            Assert.That(id,Is.Not.EqualTo( Guid.Empty));
        }
    }
}