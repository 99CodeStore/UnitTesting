using System.Collections.Generic;

namespace Fundamentals.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}