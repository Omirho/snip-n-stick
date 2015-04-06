using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
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
            try
            {
                var _db = new snip_n_stick.Models.SnipContext();
                int id = Codec.Decode(snipid);
                IQueryable<Snip> query = _db.Snips;
                query = query.Where(p => p.SnipID == id);
                if (query != null && query.Count() > 0)
                {
                    if (query.First().SnipExpirationTime < DateTime.Now)
                    {
                        _db.Snips.Remove(query.First());
                        _db.SaveChanges();
                        query = null;
                    }

                    if (query != null && query.First().SnipAccessType == 2)
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                            if (manager.GetEmail(User.Identity.GetUserId()) != query.First().SnipCreatedBy)
                                query = null;
                        }
                        else
                            query = null;
                    }
                    else if (query != null && query.First().SnipAccessType == 1)
                    {
                        if (Session[snipid] == null)
                        {
                            //Response.Redirect(GetRouteUrl("ViewProtected", new { id = snipid }));
                            Response.Redirect("ViewProtected.aspx?id=" + snipid);
                        }
                    }
                    if (query != null && query.First().SnipCreatedBy == "default@default.com")
                        query.First().SnipCreatedBy = "Guest";
                }
                return query;
            }
            catch
            {
                return null;
            }
        }

    }
}