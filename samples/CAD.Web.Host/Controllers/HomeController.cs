using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using CAD.Web;

namespace CAD.Web.Host.Controllers
{
    [Export(typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        //[ImportingConstructor]
        //public HomeController(IEnumerable<CAD.Web.IModuleInfo> modules)
        //{
        //   // this._modules = modules;
        //}

        public ActionResult Index()
        {
            //foreach(var module in this._modules)
            //{

            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}