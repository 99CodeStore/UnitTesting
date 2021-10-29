using System.Net;

namespace Fundamentals.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var wc = new WebClient();
            wc.DownloadFile(url, path);
        }
    }
}
