using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace CAD.Web
{
    [InheritedExport(typeof(IModuleInfo))]
    public interface IModuleInfo
    {
        string Name { get; set; }
        string DefaultController { get; set; }
        string DefaultAction { get; set; }
        string Type { get; set; }
        string Category { get; set; }
        
        Dictionary<string, object> Properties { get; set; }
        IEnumerable<IMenuInfo> Menu { get; set; }

        object GetProperty(string propertyName);
        void SetProperty(string propertyName, object propertyValue);

    }
}
