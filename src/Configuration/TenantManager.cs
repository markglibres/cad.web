using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD.Core;
using System.Web;

namespace CAD.Web
{
    public class TenantManager : ITenantManager
    {
        private static readonly Lazy<TenantManager> _instance = new Lazy<TenantManager>(() => new TenantManager());
        private string _cacheKey = "_cadCurrentTenant";
        private string _defaultTenant = "~/Configs/default.config";

        private string DefaultTenantPath
        {
            get
            {
                string filePath = HttpContext.Current.Server.MapPath(this._defaultTenant);
                return filePath;
            }
        }

        private TenantManager()
        {

        }

        public static TenantManager Instance 
        { 
            get
            {
                return _instance.Value;
            }
        }

        public Tenant Current
        {
           get
            {
                //check if on cache
               Tenant currentTenant = CacheManager.Instance.GetValue<Tenant>(this._cacheKey);
               
               if(currentTenant == null)
               {
                   currentTenant = FileConfigManager.Instance.Deserialize<Tenant>(this.DefaultTenantPath);
                   currentTenant.SortPriority();
                   //read from file
               }

               return currentTenant;
            }
        }

        public void Save(Tenant tenant)
        {
            if(tenant != null)
            {
                FileConfigManager.Instance.Serialize<Tenant>(this.DefaultTenantPath, tenant);
            }
        }
    }
}
