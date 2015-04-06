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
        public List<ListItem> langitems;
        public List<ListItem> timeitems;
        public List<ListItem> accessitems;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                langitems = new List<ListItem>();
                timeitems = new List<ListItem>();
                accessitems = new List<ListItem>();
                langitems.Add(new ListItem("Text"));
                langitems.Add(new ListItem("C"));
                langitems.Add(new ListItem("C++"));
                langitems.Add(new ListItem("C#"));
                langitems.Add(new ListItem("Java"));
                langitems.Add(new ListItem("Python"));
                langitems.Add(new ListItem("Ruby"));
                langitems.Add(new ListItem("JS"));
                langitems.Add(new ListItem("CSS"));
                langitems.Add(new ListItem("XML"));
                langitems.Add(new ListItem("HTML"));
                langitems.Add(new ListItem("PHP"));
                langitems.Add(new ListItem("CoffeeScipt"));
                timeitems.Add(new ListItem("10 minutes", (new TimeSpan(0, 10, 0)).ToString()));
                timeitems.Add(new ListItem("1 hour", (new TimeSpan(1, 0, 0)).ToString()));
                timeitems.Add(new ListItem("1 day", (new TimeSpan(1, 0, 0, 0)).ToString()));
                timeitems.Add(new ListItem("1 week", (new TimeSpan(7, 0, 0, 0)).ToString()));
                timeitems.Add(new ListItem("2 weeks", (new TimeSpan(14, 0, 0, 0)).ToString()));
                timeitems.Add(new ListItem("1 month", (new TimeSpan(30, 0, 0, 0)).ToString()));
                timeitems.Add(new ListItem("Never"));
                accessitems.Add(new ListItem("Public"));
                accessitems.Add(new ListItem("Protected"));
                if(User.Identity.IsAuthenticated)
                    accessitems.Add(new ListItem("Private"));
                if (DropDownList1.Items.Count == 0)
                {
                    DropDownList1.Items.AddRange(langitems.ToArray());
                    DropDownList2.Items.AddRange(timeitems.ToArray());
                    DropDownList3.Items.AddRange(accessitems.ToArray());
                }
            }
            catch
            {
                err.Text = "Sorry! Something went wrong.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var _db = new SnipContext();
                var newsnip = new Snip();
                if (TextBox1.Text == "")
                    newsnip.SnipTitle = "Untitled";
                else
                    newsnip.SnipTitle = TextBox1.Text;
                newsnip.SnipLanguage = langitems[DropDownList1.SelectedIndex].Text;
                newsnip.SnipCreatedTime = DateTime.Now;
                if (DropDownList2.SelectedIndex == 6)
                    newsnip.SnipExpirationTime = DateTime.MaxValue;
                else
                {
                    TimeSpan result;
                    TimeSpan.TryParse(timeitems[DropDownList2.SelectedIndex].Value, out result);
                    newsnip.SnipExpirationTime = newsnip.SnipCreatedTime.Add(result);
                }

                if (User.Identity.IsAuthenticated)
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    newsnip.SnipCreatedBy = manager.GetEmail(User.Identity.GetUserId());
                }
                else
                {
                    newsnip.SnipCreatedBy = "default@default.com";
                }
                if(DropDownList3.SelectedIndex == 2 && !User.Identity.IsAuthenticated)
                {
                    err.Text = "You cannot create Private Snips!";
                    return;
                }
                else
                    newsnip.SnipAccessType = DropDownList3.SelectedIndex;
                if(DropDownList3.SelectedIndex == 1 && TextBox2.Text == "")
                {
                    err.Text = "Password cannot be left empty for Protected mode!";
                }
                else
                {
                    newsnip.SnipAccessPass = TextBox2.Text;
                    if (TextArea1.Text == "")
                    {
                        err.Text = "Textbox cannot be left empty!";
                    }
                    else
                    {
                        newsnip.SnipContent = TextArea1.Text;
                        _db.Snips.Add(newsnip);
                        _db.SaveChanges();
                        string s = Codec.Encode(newsnip.SnipID);
                        TextBox1.Text = s;
                        Response.Redirect(GetRouteUrl("ViewByID", new { snipid = s }),false);
                    }
                }
            }
            catch
            {
                err.Text = "Sorry! Something went wrong.";
            }
        }
    }
}