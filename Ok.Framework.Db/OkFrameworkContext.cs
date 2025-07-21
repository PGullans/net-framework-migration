using Ok.Framework.Db.Model;

using System.Data.Entity;

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
