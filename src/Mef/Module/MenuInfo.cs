using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public class MenuInfo : IMenuInfo
    {
        public string ParentPath { get; set; }
        public string DisplayText { get; set; }
        public string TargetPath { get; set; }
        protected Lazy<Dictionary<string, object>> _properties = new Lazy<Dictionary<string, object>>(() => new Dictionary<string, object>());

        public Dictionary<string, object> Properties
        {
            get { return this._properties.Value; }
            set { this._properties = new Lazy<Dictionary<string, object>>(() => value); }
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
