using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface ITenantManager
    {
        Tenant Current { get; }
        void Save(Tenant tenant);
    }
}
