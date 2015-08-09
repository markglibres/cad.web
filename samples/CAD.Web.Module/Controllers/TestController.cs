using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using CAD.Web;

namespace CAD.Web.Module.Controllers
{
    [Module(Name = "Test", Controller = "Test", Type = "TestForm")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestController : Controller
    {
        [ImportMany(typeof(IModuleInfo))]
        public IEnumerable<IModuleInfo> _modules;

        [HttpGet]
        
        public ActionResult List()
        {
            List<MenuItem> menus = new List<MenuItem>();

            menus.Add(new MenuItem()
            {
                Text = "Test",
                Action = "Test",
                Baseurl = "Index"
            });

            return Json(menus, JsonRequestBehavior.AllowGet);
        }
        // GET: RequestInvite
        public ActionResult Index()
        {
            return View();
        }

        // GET: RequestInvite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestInvite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestInvite/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestInvite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestInvite/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestInvite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestInvite/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
