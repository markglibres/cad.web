using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition.Hosting;


namespace CAD.Web
{
    public class MefDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver,  IDependencyResolver
    {
        private readonly CompositionContainer _container;

        public MefDependencyResolver(CompositionContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            string name = AttributedModelServices.GetContractName(serviceType);
            try
            {
                var service = this._container.GetExportedValueOrDefault<object>(name);
                return service;
            }
            catch
            {
                return null;
            }

            

           
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            string name = AttributedModelServices.GetContractName(serviceType);


            try
            {
                var service = this._container.GetExportedValues<object>(name);

                return service;
            }
            catch
            {
                return new object[] { };
            }

           
            
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;

            
        }

        public void Dispose()
        {
            
        }

    }
}
