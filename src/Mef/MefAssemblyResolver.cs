using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;


namespace CAD.Web
{
    public class MefAssemblyResolver : IAssembliesResolver 
    {
        private CompositionContainer _container;

        public MefAssemblyResolver(CompositionContainer container)
        {
            this._container = container;
        }
        public  ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> baseAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //var controllersAssembly = Assembly.LoadFrom(@"C:\libs\controllers\ControllersLibrary.dll");
            //baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;
        }
    }
}
