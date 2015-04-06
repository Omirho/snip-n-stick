using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using snip_n_stick.Models;

namespace snip_n_stick
{
    public partial class ViewProtected : System.Web.UI.Page
    {
        public string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var a = RouteData.Values["id"];
                if (a == null)
                    Response.Redirect("/");
                else
                {
                    id = a.ToString();
                }
            }
            catch
            {
                err.Text = "Sorry! Something went wrong.";
            }
        }

        protected void Auth(object sender, EventArgs e)
        {
            try
            {
                string pass = passbox.Text;
                var _db = new SnipContext();
                IQueryable<Snip> query = _db.Snips;
                var d = Codec.Decode(id);
                query = query.Where(p => p.SnipID == d);
                if (query != null)
                {
                    if (query.First().SnipAccessType != 1)
                        Response.Redirect(GetRouteUrl("ViewByID", new { snipid = id }));
                    if (query.First().SnipAccessPass != null && query.First().SnipAccessPass == pass)
                    {
                        Session[id] = "True";
                        Response.Redirect(GetRouteUrl("ViewByID", new { snipid = id }));
                    }

                }
                err.Text = "Wrong password! Try Again.";
                passbox.Text = null;
            }
            catch
            {
                err.Text = "Sorry! Something went wrong.";
            }
        }
    }
}