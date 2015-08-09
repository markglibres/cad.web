Server pages: an MVC Controller with views. 

references: 

System.Web.Optimization
RequireJS
AngularJS

1. Create your MVC Controller. For instance: FormsController
2. Update App_Start/BundleConfig.cs:
	
	string angularjsCDN = "https://ajax.googleapis.com/ajax/libs/angularjs/1.4.3/angular.min.js";
	string requireJSCDN = "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.1.20/require.min.js";            

	bundles.Add(new ScriptBundle("~/bundles/angular", angularjsCDN)
        .Include("~/Scripts/angular.min.js")
        .Include("~/Scripts/angular-route.min.js")
    );

    bundles.Add(new ScriptBundle("~/bundles/requirejs", requireJSCDN)
        .Include("~/Scripts/require.js")
    );

3. under "App_Code/ModuleScripts.cshtml", paste this code:

	@helper Render(string name)
	{
		// your helper can contain code and/or markup, e.g.
		// var msg = "Hello " + name;
		// <p>@msg</p>
		// For more information, visit http://go.microsoft.com/fwlink/?LinkID=204658

		if (HttpContext.Current.Request != null)
		{
			//module based loading of angular js
			var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
			var controllerName = routeValues["controller"];

			var moduleMainJs = string.Format("/app/serverpages/{0}/{1}.js", controllerName, name);
			var moduleMainJsFullPath = HttpContext.Current.Server.MapPath(moduleMainJs);

			if (System.IO.File.Exists(moduleMainJsFullPath))
			{
				@System.Web.Optimization.Scripts.Render("~/bundles/requirejs")
				@System.Web.Optimization.Scripts.Render("~/bundles/angular")
				<script src="@moduleMainJs"></script>
			}
		}
	}

4. Layout should have this script reference:

	@ModuleScripts.Render("main");

	and specify the angular directive "ng-view":

	<div ng-view>
        @RenderBody()
    </div>

5. Define your js dependencies on /app/serverpages/{controller name}/main.js
6. Set your angularjs app name directive on /app/serverpages/{controller name}/main.js
7. Define your angularjs routes on /app/serverpages/{controller name}/app.js
8. Define your angularjs app on /app/serverpages/{controller name}/app.js
9. To create your controllers, see /app/components/README.txt


	