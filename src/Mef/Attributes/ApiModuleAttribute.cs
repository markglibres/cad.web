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
    [InheritedExport(typeof(IApiModuleAttribute))]
    public class ApiModuleAttribute : ExportAttribute, IApiModuleAttribute
    {
        public ApiModuleAttribute() : base(typeof(System.Web.Http.Controllers.IHttpController)) { }

        public string Name { get; set; }
        public string Controller { get; set; }
        
    }
}
