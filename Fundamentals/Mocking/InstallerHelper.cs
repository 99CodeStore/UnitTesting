using System.Net;

namespace Fundamentals.Mocking
{
    public class InstallerHelper
    {
        private string _setDestinationFile;

        private IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader downloader)
        {
            _fileDownloader = downloader;
        }


        public bool DownloadInstaller(string customerName, string installerName)
        {

            try
            {
                _fileDownloader.DownloadFile(string.Format("http://Example.com/{0}/{1}", customerName, installerName), _setDestinationFile);
                return true;
            }
            catch (WebException)
            {

                return false;
            }
        }
    }
}
