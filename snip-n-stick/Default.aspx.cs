using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var _db = new SnipContext();
            var newsnip = new Snip();
            newsnip.SnipTitle = TextBox1.Text;
            newsnip.SnipLanguage = DropDownList1.SelectedItem.Text;
            newsnip.SnipCreatedTime = DateTime.Now;
            //newsnip.SnipExpirationTime = newsnip.SnipCreatedTime.Add(TimeSpan.TryParse(DropDownList2.);
            newsnip.SnipExpirationTime = DateTime.MaxValue;
            if (User.Identity.IsAuthenticated)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                newsnip.SnipCreatedBy = manager.GetEmail(User.Identity.GetUserId());
            }
            else
            {
                newsnip.SnipCreatedBy = "default@default.com";
            }
            newsnip.SnipAccessType = 2;
            newsnip.SnipAccessPass = "";
            newsnip.SnipContent = TextArea1.Text;
            _db.Snips.Add(newsnip);
            _db.SaveChanges();
            string s = Codec.Encode(newsnip.SnipID);
            TextBox1.Text = s;
            Response.Redirect(GetRouteUrl("ViewByID", new { snipid = s }));
        }
    }
}