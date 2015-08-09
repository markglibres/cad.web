using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.Composition;
using CAD.Web;
using System.Web.Http.Controllers;

namespace CAD.Web.Host.Api
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FormServiceController : ApiController
    {
        [ImportMany(typeof(IModuleInfo))]
        public IEnumerable<Lazy<IModuleInfo>> modules;

        // GET api/<controller>
        public List<MenuItem> Get()
        {
            List<MenuItem> menus = new List<MenuItem>();

            var formModules = modules.Where(m => m.Value.Category == "Forms");
            foreach (var module in formModules)
            {
                var mod = module.Value;
                MenuItem menu = new MenuItem() { 
                    Text = mod.Name,
                    Baseurl = mod.DefaultAction,
                    Action = mod.DefaultController
                };
                menus.Add(menu);
            }
          
            return menus;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}