using Fundamentals.Enums;
using Fundamentals.ServiceInterface;

namespace Fundamentals.Services
{
    public class Downloader : IDownloader
    {
        public IDownloadService GetDownloadService(DownloadProvider provider)
        {
            IDownloadService downloadService = null;
            switch (provider)
            {
                case DownloadProvider.DirectApi:
                    downloadService = new DirectApiDownloadService(new WebClientImpl(), new DBRepository());
                    break;
                case DownloadProvider.LambdaFunction:
                    downloadService = new LambdaFunctionDownloadService();
                    break;
            }

            return downloadService;
        }
    }
}
