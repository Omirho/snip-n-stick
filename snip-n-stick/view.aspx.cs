using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using snip_n_stick.Models;

namespace snip_n_stick
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Snip> GetSnip([RouteData] string snipid)
        {
            var _db = new snip_n_stick.Models.SnipContext();
            int id = Decode(snipid);
            IQueryable<Snip> query = _db.Snips;
            query = query.Where(p => p.SnipID == id);
            return query;
        }
    }
}