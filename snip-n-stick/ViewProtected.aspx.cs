﻿using System;
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
            id = Request.QueryString["id"];
            if (id == null)
                Response.Redirect("/");
        }

        protected void Auth(object sender, EventArgs e)
        {
            string pass = passbox.Text;
            var _db = new SnipContext();
            IQueryable<Snip> query = _db.Snips;
            var d = Codec.Decode(id);
            query = query.Where(p => p.SnipID == d);
            if(query != null)
            {
                if (query.First().SnipAccessPass == pass)
                {
                    Session[id] = "True";
                    Response.Redirect(GetRouteUrl("ViewByID", new { snipid = id }));
                }
                    
            }
            err.Text = "Wrong password! Try Again.";
            passbox.Text = null;
        }
    }
}