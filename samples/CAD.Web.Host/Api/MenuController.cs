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
    public class MenuController : ApiController
    {
        [ImportMany(typeof(IModuleInfo))]
        public IEnumerable<IModuleInfo> modules;

        // GET: api/MenuApi
        public List<MenuItem> Get()
        {
            List<MenuItem> menus = new List<MenuItem>();

            menus.Add(new MenuItem() { Text = "Home", Action = "Home", Baseurl = "Index" });
            menus.Add(new MenuItem()
            {
                Text = "Forms",
                Action = "RequestInvite",
                Baseurl = "Forms",
                Items = new List<MenuItem>() { { new MenuItem() { Text = "Request Invite", Baseurl = "Index", Action = "RequestInvite" } } }
            });

            return menus;

        }

        // GET: api/MenuApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenuApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MenuApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MenuApi/5
        public void Delete(int id)
        {
        }
    }
}
