using NUnit.Framework;
using Fundamentals.Mocking;
using Moq;
using System.Collections.Generic;

namespace Fundaementals.UnitTests.Mocking
{

    [TestFixture()]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();

            _videoService = new VideoService(_fileReader.Object, _repository.Object);

        }
        [Test()]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {

            var result = _videoService.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test()]
        public void ReadVideoTitlePropertyDI_EmptyFile_ReturnError()
        {
            _videoService.FileReader = new FakeFileReader();

            var result = _videoService.ReadVideoTitlePropertyDI();

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

            _fileReader.Setup(fr => fr.Read("videoFile.txt")).Returns("");

            var service = new VideoService(_fileReader.Object);

            var result = service.ReadVideoTitleConstructorInjection();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosListEmpty_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>() { });
            var answer = _videoService.GetUnprocessedVideoAsCsv();
            Assert.That(answer, Is.EqualTo(""), "Some thing went wrong when  All videos are processed");
        }


        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>()
            {

            });
            var answer = _videoService.GetUnprocessedVideoAsCsv();
            Assert.That(answer, Is.EqualTo(""), "Some thing went wrong when  All videos are processed");
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_SomeUnprocessedVideos_ReturnStringOfUnprocessedVideoIds()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(
                new List<Video>()
                {
                    new Video(){Id=2,Title="Video02.mp4",IsProcessed=false},
                    new Video(){Id=3,Title="Video03.mp4",IsProcessed=false}
                });

            var answer = _videoService.GetUnprocessedVideoAsCsv();


            Assert.That(answer, Is.EqualTo("2,3"), "Some thing went wrong when Some are unprocessed videos");

        }
    }
}