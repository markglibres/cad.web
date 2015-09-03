using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.IO;

namespace CAD.Web
{
    public static class ModulePathExtensions
    {
        private static string GetAssemblyDirectory(object classObject)
        {
            string codeBase = classObject.GetType().Assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path).ToLower(); ;
        }
        private static string GetModuleDirectory(object classObject)
        {
            string assemblyDir = GetAssemblyDirectory(classObject);
            string[] tokens = assemblyDir.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            var modDirectory = String.Join("\\", tokens, 0, tokens.Count() - 1);
            return modDirectory;
        }
        private static string ToRelativePath(string physicalPath)
        {
            var applicationPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToLower();
            return physicalPath.Replace(applicationPath, "/").Replace("\\", "/");
        }

        public static string AssemblyDirectory(this object executingObject)
        {
            return GetAssemblyDirectory(executingObject);
        }

        public static string AssemblyRelativePath(this object executingObject)
        {
            var physicalPath = GetAssemblyDirectory(executingObject);
            return ToRelativePath(physicalPath);
            
        }

        public static string ModuleDirectory(this object executingObject)
        {
            return GetModuleDirectory(executingObject);
        }

        public static string ModuleRelativePath(this object executingObject)
        {
            var physicalPath = ModuleDirectory(executingObject);
            return ToRelativePath(physicalPath);
        }

        public static string ModuleViewsDirectory(this object executingObject)
        {
            return Path.Combine(ModuleDirectory(executingObject), "views");
            
        }

        public static string ModuleViewsRelativePath(this object executingObject)
        {
            var physicalPath = ModuleViewsDirectory(executingObject);
            return ToRelativePath(physicalPath);
        }
    }
}