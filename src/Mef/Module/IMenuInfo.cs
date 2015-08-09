using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface IMenuInfo
    {
        string ParentPath { get; set; }
        string DisplayText { get; set; }
        string TargetPath { get; set; }
        Dictionary<string,object> Properties { get; set; }

        object GetProperty(string propertyName);
        void SetProperty(string propertyName, object propertyValue);
    }
}
