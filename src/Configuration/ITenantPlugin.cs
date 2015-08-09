using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Web
{
    public interface ITenantPlugin
    {
        T GetProperty<T>(string propertyName);
        void AddProperty<T>(string propertyName, T item);
    }
}
