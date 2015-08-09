using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface IModuleAttribute
    {
        string Name { get; }
        string Controller { get; }
        string Type { get; }
        string JsonProperties { get; }
    }
}
