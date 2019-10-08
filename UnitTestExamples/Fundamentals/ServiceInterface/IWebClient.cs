using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.ServiceInterface
{
    public interface IWebClient
    {
        bool DownloadFile(string url, string path);
    }
}
