using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.ServiceInterface
{
    public interface IDBRepository
    {
        void SaveDetailsToDB(string url, string path);
    }
}
