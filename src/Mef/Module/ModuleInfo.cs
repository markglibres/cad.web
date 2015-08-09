using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace CAD.Web
{
    [InheritedExport(typeof(IModuleInfo))]
    public abstract class ModuleInfo : IModuleInfo
    {
        public string Name { get; set; }
        public string DefaultController { get; set; }
        public string DefaultAction { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }

        protected Lazy<Dictionary<string, object>> _properties = new Lazy<Dictionary<string, object>>(() => new Dictionary<string, object>());

        public Dictionary<string, object> Properties 
        { 
            get { return this._properties.Value; }
            set { this._properties = new Lazy<Dictionary<string,object>>(() => value); }
        }

        protected Lazy<IEnumerable<IMenuInfo>> _menu = new Lazy<IEnumerable<IMenuInfo>>(() => new List<IMenuInfo>());
        public IEnumerable<IMenuInfo> Menu 
        {
            get { return this._menu.Value;  }
            set { this._menu = new Lazy<IEnumerable<IMenuInfo>>(() => value);  } 
        }

        public object GetProperty(string propertyName)
        {
            if (this.Properties.ContainsKey(propertyName))
                return this.Properties[propertyName];

            return null;
        }

        public void SetProperty(string propertyName, object propertyValue)
        {
            if (this.Properties.ContainsKey(propertyName))
                this.Properties[propertyName] = propertyValue;
            else
                this.Properties.Add(propertyName, propertyValue);
        }

    }
}
