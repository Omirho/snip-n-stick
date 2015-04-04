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

        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly int Base = Alphabet.Length;

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

        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            i += 100000;

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            i -= 100000;

            return i;
        }
    }
}