using System.IO;
using Newtonsoft.Json;

namespace Fundamentals.Mocking
{
    public class VideoService
    {

        public IFileReader FileReader { get; set; }
        private IFileReader _reader;
        public string ReadVideoTitle()
        {
            var str = new FileReader().Read("MyVideo.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video==null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }
        
        public VideoService(IFileReader reader)
        {
            _reader = reader ?? new FileReader();
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
    }
}
