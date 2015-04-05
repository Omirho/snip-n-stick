using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace snip_n_stick.Models
{
    public class SnipDatabaseInitialize : DropCreateDatabaseAlways<SnipContext>
    {
        protected override void Seed(SnipContext context)
        {
            GetInitialSnips().ForEach(c => context.Snips.Add(c));
        }
        private static List<Snip> GetInitialSnips()
        {
            var snips = new List<Snip> {
                new Snip
                {
                    SnipID = 1,
                    SnipTitle = "test",
                    SnipLanguage = "C++",
                    SnipCreatedTime = DateTime.Now,
                    SnipExpirationTime = DateTime.MaxValue,
                    SnipCreatedBy = "default@default.com",
                    SnipAccessType = 0,
                    SnipContent = "#include <iostream>\n"
                                + "int main()\n"
                                + "{\n\treturn 0;\n}"
          
                }
            };
            return snips;
        }
    }
}