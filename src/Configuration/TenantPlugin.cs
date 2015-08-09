using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public class TenantPlugin : ITenantPlugin
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        private Lazy<Dictionary<string, object>> _properties = new Lazy<Dictionary<string, object>>(() => new Dictionary<string,object>());
        public Dictionary<string, object> Properties 
        { 
            get
            {
                return this._properties.Value;
            }
        }

        public T GetProperty<T>(string propertyName)
        {
            if(this.Properties != null && this.Properties.ContainsKey(propertyName) && this.Properties[propertyName] != null)
            {
                return (T)this.Properties[propertyName];
            }
            
            return default(T);
        }


        public void AddProperty<T>(string propertyName, T item)
        {
            if (this.Properties.ContainsKey(propertyName))
                this.Properties[propertyName] = item;
            else
                this.Properties.Add(propertyName, item);
        }
    }
}
