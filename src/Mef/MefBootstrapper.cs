using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Web.Mvc;
using System.Web;
using System.Web.Http.Dispatcher;

namespace CAD.Web
{
    public class MefBootstrapper
    {
        private static CompositionContainer _container;
        private static MefDependencyResolver _resolver;
        
        //public const string ModulesFolder = "Modules";
        public const string ModulesFolder = "App/modules";

        public static List<string> ModuleDirectories
        {
            get
            {
                List<string> _modules = new List<string>();
                string moduleDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MefBootstrapper.ModulesFolder);
                if(Directory.Exists(moduleDirectory))
                {
                    var moduleFolders = Directory.GetDirectories(moduleDirectory);

                    if (moduleFolders != null)
                    {
                        
                        foreach(string moduleFolder in moduleFolders)
                        {
                            _modules.Add(Path.GetFileName(moduleFolder));
                        }
                    }
                        
                }

                return _modules;
            }
        }

        public static CompositionContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static CompositionContainer Initialize()
        {
            if (_container == null)
            {
                
                string binDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
                var binCatalog = new DirectoryCatalog(binDirectory);

                //register bin directory for exports
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(binCatalog);

                var assemblyCatalogue = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
                catalog.Catalogs.Add(assemblyCatalogue);
                

                //add module directories
                var moduleFolders = ModuleDirectories;

                foreach (var moduleFolder in moduleFolders)
                {
                    var pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ModulesFolder, moduleFolder, "bin");
                    
                    if(Directory.Exists(pluginPath))
                    {
                        //var dirCatalog = new DirectoryCatalog(pluginPath);
                        var dirCatalog = new DirectoryCatalog(pluginPath, "*.Module.dll");
                        catalog.Catalogs.Add(dirCatalog);
                    }
                    

                }

                //_container = new CompositionContainer(catalog);
                //_container.ComposeParts();
                _container = new CompositionContainer(catalog);
                _container.ComposeParts();

                _resolver = new MefDependencyResolver(_container);
                
            }
            return _container;
        }
        /// <summary>
        /// Compose for MVC
        /// </summary>
        public static void ComposeMVC()
        {
            MefBootstrapper.Initialize();

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(_container));
            ViewEngines.Engines.Add(new MefViewEngine(MefBootstrapper.ModulesFolder, MefBootstrapper.ModuleDirectories));
            DependencyResolver.SetResolver(_resolver);
            
        }

        /// <summary>
        /// Compose for Web API or MVC with Web API
        /// </summary>
        public static void ComposeWebAPI()
        {
            MefBootstrapper.Initialize();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = _resolver as System.Web.Http.Dependencies.IDependencyResolver;

            //MefAssemblyResolver assemblyResolver = new MefAssemblyResolver(_container);
            //var test = System.Web.Http.GlobalConfiguration.Configuration.Services.GetServices(typeof(IAssembliesResolver));
            //System.Web.Http.GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), assemblyResolver);
        }

        public static T GetInstance<T>(string contractName = null)
        {
            T _instance = default(T);
            
            if (_container != null)
            {
                if(String.IsNullOrEmpty(contractName))
                {
                    
                    try
                    {
                        _instance = _container.GetExportedValue<T>();
                        
                    }
                    catch
                    {
                        
                    }
                }
                else
                {
                    try
                    {
                        _instance = _container.GetExportedValue<T>(contractName);
                        
                    }
                    catch
                    {
                        
                    }
                }
            }
            
            return _instance;
        }

        
    }
}
