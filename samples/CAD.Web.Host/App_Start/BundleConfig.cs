using System.Web;
using System.Web.Optimization;

namespace CAD.Web.Host
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            string angularjsCDN = "https://ajax.googleapis.com/ajax/libs/angularjs/1.4.3/angular.min.js";
            string jqueryCDN = "https://code.jquery.com/jquery-2.1.4.min.js";
            string bootstrapCDN = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js";
            string bootstrapcssCDN = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css";
            string jqueryvalCDN = "https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.14.0/jquery.validate.min.js";
            string modernizrCDN = "https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js";
            string requireJSCDN = "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.1.20/require.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCDN)
                .Include("~/Scripts/jquery-{version}.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval", jqueryvalCDN)
                .Include("~/Scripts/jquery.validate*")
            );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr", modernizrCDN)
                .Include("~/Scripts/modernizr-*")
            );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", bootstrapCDN)
                .Include("~/Scripts/bootstrap.js","~/Scripts/respond.js")
            );

            bundles.Add(new StyleBundle("~/Content/css", bootstrapcssCDN)
                .Include("~/Content/bootstrap.css","~/Content/site.css")
            );

            
            bundles.Add(new ScriptBundle("~/bundles/angular", angularjsCDN)
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-route.min.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/requirejs", requireJSCDN)
               .Include("~/Scripts/require.js")
            );

        }
    }
}
