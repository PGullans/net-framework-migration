using Ok.Framework.Db.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ok.Framework.Db
{
    public class OkFrameworkContext : DbContext
    {
        public OkFrameworkContext() : base("DefaultConnection")
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
