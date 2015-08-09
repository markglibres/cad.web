using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface IApiModuleAttribute
    {
        string Name { get; }
        string Controller { get; }
        
    }
}
