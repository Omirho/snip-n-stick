using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace snip_n_stick.Models
{
    public class SnipContext : DbContext
    {
        public SnipContext() : base("snip_n_stick")
        { 
        }
        
        public DbSet<Snip> Snips { get; set; }
    }
}