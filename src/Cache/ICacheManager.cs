using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface ICacheManager
    {
        T GetValue<T>(string key);
        void Add<T>(T cacheItem, string key, string fileDependency);
    }
}
