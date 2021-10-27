using NUnit.Framework;
using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Fundaementals.UnitTests.Mocking
{
    [TestFixture()]
    public class VideoServiceTests
    {
        [Test()]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            var result= service.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }


        [Test()]
        public void ReadVideoTitlePropertyDI_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            service.FileReader = new FakeFileReader();

            var result = service.ReadVideoTitlePropertyDI();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }


        [Test()]
        public void ReadVideoTitleConstructorInjection_EmptyFile_ReturnError()
        {
            var service = new VideoService(new FakeFileReader());

            var result = service.ReadVideoTitleConstructorInjection();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test()]
        public void ReadVideoTitleMOQ_EmptyFile_ReturnError()
        {

            var filereader = new Mock<IFileReader>();

            filereader.Setup(fr=>fr.Read("videoFile.txt")).Returns("");

            var service = new VideoService(filereader.Object);

            var result = service.ReadVideoTitleConstructorInjection();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }
    }
}