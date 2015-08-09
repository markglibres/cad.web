using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web;

namespace CAD.Web
{
    public class CacheManager : ICacheManager
    {
        private static readonly Lazy<CacheManager> _instance = new Lazy<CacheManager>(() => new CacheManager());

        private CacheManager()
        {

        }

        public static CacheManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public T GetValue<T>(string key)
        {
            var item = HttpContext.Current.Cache[key];

            if (item == null)
                return default(T);

            return (T)item;
            
        }

        public void Add<T>(T cacheItem, string key, string fileDependency)
        {
            T item = this.GetValue<T>(key);

            if(item == null)
            {
                string filePath = HttpContext.Current.Server.MapPath(fileDependency);
                CacheDependency dependency = new CacheDependency(filePath);
                HttpContext.Current.Cache.Insert(key, cacheItem, dependency);
            }
            
        }
    }
}
