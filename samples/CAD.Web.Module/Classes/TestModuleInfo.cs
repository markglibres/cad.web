using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAD.Web;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CAD.Web.Module
{
    [InheritedExport(typeof(IModuleInfo))]
    public class TestModuleInfo : ModuleInfo
    {
        public TestModuleInfo()
        {
            //load from config file

            this.Name = "Test Module";
            this.Type = "Test Module";
            this.Category = "TestModule";
            this.DefaultController = "TestModule";
            this.DefaultAction = "";

        }

    }
}