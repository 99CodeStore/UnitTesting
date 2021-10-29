using Fundamentals.Mocking;
using Moq;
using NUnit.Framework;
using System.Net;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {


            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);



        }


        [Test]
        public void DownloadInstaller_DonwLoadFail_RetrunFalse()
        {
            // Arrange
            _fileDownloader.Setup(f => f.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();
            // Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            // Assert
            Assert.That(result, Is.False);
        }


        [Test]
        public void DownloadInstaller_DonwLoadCompleted_RetrunTrue()
        {
  
            // Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            // Assert
            Assert.That(result, Is.True);
        }


    }
}