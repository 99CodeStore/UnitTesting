using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.Linq;
using System.Linq;

namespace Fundamentals.Mocking
{
    public class VideoService
    {

        public IFileReader FileReader { get; set; }
        private IFileReader _reader;
        private IVideoRepository _videoRepository;
        public string ReadVideoTitle()
        {
            var str = new FileReader().Read("MyVideo.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }

        public VideoService(IFileReader reader = null, IVideoRepository repository = null)
        {
            _reader = reader ?? new FileReader();
            _videoRepository = repository ?? new VideoRepository();

        }

        public VideoService()
        {
            _reader = new FileReader();
        }

        public string ReadVideoTitleConstructorInjection()
        {
            var str = _reader.Read("MyVideo.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }

        public string ReadVideoTitlePropertyDI()
        {
            var str = FileReader.Read("MyVideo.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }

        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("MyVideo.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }

        public string GetUnprocessedVideoAsCsv()
        {
            var videosIds = new List<int>();
            var videos = _videoRepository.GetUnprocessedVideos();
            foreach (var v in videos)
            {
                videosIds.Add(v.Id);
            }
            return string.Join(",", videosIds);
        }

        public string GetUnprocessedVideoAsCsv_Faulty()
        {
            var videosIds = new List<int>();

            using (var context = new VideoDataContext())
            {
                var videos = (from video in context.Videos
                              where !video.IsProcessed
                              select video).ToList();

                foreach (var v in videos)
                {
                    videosIds.Add(v.Id);
                }
                return string.Join(",", videosIds);
            }
        }
    }
}
