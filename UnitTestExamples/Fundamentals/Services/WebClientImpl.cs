using Fundamentals.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Services
{
    public class WebClientImpl : IWebClient
    {
        public bool DownloadFile(string url, string path)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, path);
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
