using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CAD.Web
{
    public interface IModuleControllerFactory
    {
        IEnumerable<IController> GetModulesByType(string moduleType);
        IEnumerable<IController> GetModulesByProperty(string propertyName);
    }
}
