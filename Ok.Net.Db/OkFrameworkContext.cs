using Microsoft.EntityFrameworkCore;

using Ok.Framework.Db.Model;

namespace Ok.Framework.Db
{
    public class OkFrameworkContext(DbContextOptions<OkFrameworkContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
