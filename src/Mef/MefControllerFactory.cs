using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CAD.Web
{
    public class MefControllerFactory : IControllerFactory
    {
        private readonly CompositionContainer _container;
        private readonly DefaultControllerFactory _default;

        public MefControllerFactory(CompositionContainer container)
        {
            _default = new DefaultControllerFactory();
            _container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller = null;
            bool noModule = false;

            var controllers = _container.GetExports<IController, IModuleAttribute>();
            
            if (controllers == null) noModule = true;
            else
            {
                controller = controllers.Where(a => a.Metadata.Controller.Equals(controllerName, StringComparison.InvariantCultureIgnoreCase))
                    .Select(e => e.Value)
                    .FirstOrDefault();

                if (controller == null) noModule = true;
            }

            if (noModule)
            {
                try
                {
                    controller = _default.CreateController(requestContext, controllerName);
                    _container.ComposeParts(controller);
                    
                }
                catch(Exception ex)
                {
                    //throw new Exception("Controller " + controllerName + " not found!");
                    throw;
                }
            }
            else
            {
                
            }

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;

            if (disposableController != null)
            {
                disposableController.Dispose();
            }
        }

    }
}
