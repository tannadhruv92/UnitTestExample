using Fundamentals.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Services
{
    public class DirectApiDownloadService : IDownloadService
    {
        private readonly IWebClient _webClient;
        private readonly IDBRepository _dBRepository;

        public DirectApiDownloadService(IWebClient webClient, IDBRepository dBRepository)
        {
            _webClient = webClient;
            _dBRepository = dBRepository;
        }

        public void DownloadPages(string path, string url)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path))
                throw new ArgumentNullException();

            var fileDownloaded = _webClient.DownloadFile(path, url);

            if (fileDownloaded)
                _dBRepository.SaveDetailsToDB(url, path);
        }

    }
}
