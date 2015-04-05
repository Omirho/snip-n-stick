using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System.Web.UI.WebControls;
using snip_n_stick.Models;

namespace snip_n_stick.Account
{
    public partial class MySnips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Snip> GetMySnips()
        {
            var _db = new SnipContext();
            IQueryable<Snip> query = _db.Snips;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            query = query.Where(p => p.SnipCreatedBy == manager.GetEmail(User.Identity.GetUserId()));
            return query;
        }
    }
}