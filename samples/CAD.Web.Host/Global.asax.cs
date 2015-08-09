using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CAD.Web;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http;


namespace CAD.Web.Host
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //START: Mef boostrap

            //for MVC app
           MefBootstrapper.ComposeMVC();

            //for Web API or MVC app with Web API
            MefBootstrapper.ComposeWebAPI();

            //CompositionContainer container = MefBootstrapper.Initialize();
            //ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));
            //ViewEngines.Engines.Add(new MefViewEngine(MefBootstrapper.ModulesFolder, MefBootstrapper.ModuleDirectories));
            
            //END: Mef boostrap
        }
    }
}
