using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CAD.Web
{
    public class MefViewEngine : RazorViewEngine
    {
        private readonly List<string> _moduleFolders;
        private readonly string _moduleFolder;

        public MefViewEngine(string moduleFolder, List<string> moduleDirectories)
        {
            this._moduleFolders = moduleDirectories; 
            this._moduleFolder = moduleFolder;

            this.ViewLocationFormats = GetViewLocations();
            this.MasterLocationFormats = GetMasterLocations();
            this.PartialViewLocationFormats = GetViewLocations();
        }

        public string[] GetViewLocations()
        {
            var views = new List<string>();
            views.Add("~/Views/{1}/{0}.cshtml");

            _moduleFolders.ForEach(module =>
                views.Add("~/" + this._moduleFolder + "/" + module + "/Views/{1}/{0}.cshtml")
            );
            return views.ToArray();
        }

        public string[] GetMasterLocations()
        {
            var masterPages = new List<string>();

            masterPages.Add("~/Views/Shared/{0}.cshtml");

            _moduleFolders.ForEach(module =>
                masterPages.Add("~/" + this._moduleFolder + "/" + module + "/Views/Shared/{0}.cshtml")
            );

            return masterPages.ToArray();
        }


    }
}
