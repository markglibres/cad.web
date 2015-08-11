How to (HOST Application):

1. Add assembly: System.ComponentModel.Composition
2. Add reference for CAD.Web
3. Modify Global.asax
----------------------------------
using CAD.Web;

protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    BundleConfig.RegisterBundles(BundleTable.Bundles);

	//for MVC app only
	//==================
    MefBootstrapper.ComposeMVC();
	//==================

	//for Web API only
	//==================
    MefBootstrapper.ComposeWebAPI();
	//==================

	//for MVC app with Web API
	//==================
	MefBootstrapper.ComposeMVC();
    MefBootstrapper.ComposeWebAPI();
	//==================

	//or for the long way
	====================
	var container = MefBootstrapper.Initialize();
	var resolver = MefDependencyResolver(container);
	

	/* MVC */
	var controllerFactory = new MefControllerFactory(container);
	var viewEngine = new MefViewEngine(MefBootstrapper.ModulesFolder, MefBootstrapper.ModuleDirectories);

	ControllerBuilder.Current.SetControllerFactory(controllerFactory);
    ViewEngines.Engines.Add(viewEngine);
	DependencyResolver.SetResolver(resolver);

	/* Web API */
	System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;
	
	//====================

  
}
----------------------------------

4. Create "Modules" folder on root

============================================================================

How to (Module Application):

1. Create separate web application. Assembly name should end with *.Module.dll
2. Add assembly: System.ComponentModel.Composition
3. Add reference for CAD.Web
4. Create new controller
5. Add "Module" attribute on the controller class: For example:

[Module(Name = "MyModule", Controller = "Module")]
public class ModuleController : Controller
{

}

NOTE: you can create your own class attribute by inheriting "ModuleAttribute". See item#9

6. Set controller creation policy to Non-Shared: For example:

[Module(Name = "MyModule", Controller = "Module")]
[PartCreationPolicy(CreationPolicy.NonShared)]
public class ModuleController : Controller
{

}

7. Create views.
8. Compile module project
9. To create custom class attribute, inherit from "ModuleAttribute": For example:

[MetadataAttribute]
[AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
public class FormModuleAttribute : ModuleAttribute
{
    public FormModuleAttribute() : base() { }

}

============================================================================

How to (Module into HOST Application):

1. Copy folder "bin" and "Views" from your module application
2. Browse to your HOST application -> Modules folder. Create new folder under "/Modules" and name it with your module name.
3. Paste the "bin" and "Views" folders on the newly created directory.
4. Open "views" folder and edit web.config.
5. Remove the entry for <add namespace="{Your Module Namespace}" />
6. Run your host application
7. Navigate to "/{Your Module Name}"



=== for razor views in plugins ==
https://github.com/RazorGenerator/RazorGenerator