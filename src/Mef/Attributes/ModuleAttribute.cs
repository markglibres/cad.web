using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CAD.Web
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    [InheritedExport(typeof(IModuleAttribute))]
    public class ModuleAttribute : ExportAttribute, IModuleAttribute
    {
        public ModuleAttribute() : base(typeof(IController)) { }

        public string Name { get; set; }
        public string Controller { get; set; }
        public string Type { get; set; }
        public string JsonProperties { get; set; }

        protected Dictionary<string, string> _properties;

        public string GetProperty(string propertyName)
        {
            if (this._properties == null)
            { 
                this._properties = new Dictionary<string, string>();
                if (!String.IsNullOrEmpty(this.JsonProperties))
                {
                    this._properties = JsonConvert.DeserializeObject<Dictionary<string, string>>(this.JsonProperties);
                }
            }

            if(this._properties.ContainsKey(propertyName))
                return this._properties[propertyName];

            return String.Empty;
        }
        
    }
}
