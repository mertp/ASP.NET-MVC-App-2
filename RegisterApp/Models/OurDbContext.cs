using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RegisterApp.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> useraccount { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // other code 
            Database.SetInitializer<OurDbContext>(null);
            base.OnModelCreating(modelBuilder);
            // more code here.
        }
    }
}
    