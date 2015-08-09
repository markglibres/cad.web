using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAD.Web.Host
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Baseurl { get; set; }
        private Lazy<List<MenuItem>> _items = new Lazy<List<MenuItem>>(() => new List<MenuItem>());

        public List<MenuItem> Items
        {
            get
            {
                return this._items.Value;
            }
            set
            {
                this._items = new Lazy<List<MenuItem>>(() => value);
            }
        }
    }
}