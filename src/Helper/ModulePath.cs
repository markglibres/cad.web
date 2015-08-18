using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.IO;

namespace CAD.Web
{
    public class ModulePath
    {
        //http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in/283917#283917
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string AssemblyRelativePath
        {
            get
            {
                var physicalPath = AssemblyDirectory.ToLower();
                var applicationPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToLower();
                return physicalPath.Replace(applicationPath, "~/").Replace("\\", "/");
            }
        }

        public static string ModuleDirectory
        {
            get
            {
                string assemblyDir = AssemblyDirectory;
                string[] tokens = assemblyDir.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                var modDirectory = String.Join("\\", tokens, 0, tokens.Count() - 1);
                return modDirectory;
            }
        }

        public static string ModuleRelativePath
        {
            get
            {
                var physicalPath = ModuleDirectory.ToLower();
                var applicationPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToLower();

                return physicalPath.Replace(applicationPath, "~/").Replace("\\", "/");
            }
        }

        public static string ModuleViewsDirectory
        {
            get
            {
                return Path.Combine(ModuleDirectory, "Views");
            }
        }

        public static string ModuleViewsRelativePath
        {
            get
            {
                var physicalPath = ModuleViewsDirectory.ToLower();
                var applicationPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToLower();
                return physicalPath.Replace(applicationPath, "~/").Replace("\\", "/");
            }
        }
    }
}