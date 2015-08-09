using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD.Core;

namespace CAD.Web
{
    public class Tenant : ITenant
    {
        public string Name { get; set;   }
        private Lazy<List<TenantPlugin>> _plugins = new Lazy<List<TenantPlugin>>(() => new List<TenantPlugin>());

        public List<TenantPlugin> Plugins 
        {
            get
            {
                return this._plugins.Value;
            }

        }

        public TenantPlugin GetPlugin(string name)
        {
            return this.Plugins.Where(p => p.Name == name).FirstOrDefault();
        }


        public void AddPlugin(TenantPlugin tenant)
        {
            var plugin = this.GetPlugin(tenant.Name);

            if(plugin != null)
            {
                this._plugins.Value.Remove(plugin);
                
            }

            this._plugins.Value.Add(tenant);
            
        }

        public void SortPriority()
        {
            this._plugins.Value.Sort((p1,p2) => p1.Priority.CompareTo(p2.Priority));
        }
    }
}
