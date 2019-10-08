using Fundamentals.Enums;

namespace Fundamentals.ServiceInterface
{
    public interface IDownloader
    {
        IDownloadService GetDownloadService(DownloadProvider provider);
    }
}
