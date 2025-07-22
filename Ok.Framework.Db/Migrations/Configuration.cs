namespace Ok.Framework.Db.Migrations
{
    using Ok.Framework.Db.Model;

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.Contracts;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ok.Framework.Db.OkFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ok.Framework.Db.OkFrameworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var accountId1 = new Guid("77780d15-a36e-4062-9e20-0335dc1ada0e");
            var accountId2 = new Guid("efca560b-9c4f-4e1c-9915-62397d354051");

            context.Accounts.AddOrUpdate(
                new Account() { AccountId = accountId1, Name = "Objektkultur Software GmbH", Address = "Ritterstrasse 5, 76133 Karlsruhe", ModifiedOn = DateTime.UtcNow },
                new Account() { AccountId = accountId2, Name = "Suspektkultur AG", Address = "Ritterstrasse 4, 76133 Karlsruhe", ModifiedOn = DateTime.UtcNow }
             );

            context.Orders.AddOrUpdate(
                new Order() { OrderId = new Guid("1d1356a1-85fd-4770-afd9-c45b1c120c9f"), Price = 500, Name = "Order 500", AccountId = accountId1 },
                new Order() { OrderId = new Guid("1eb0dc05-8678-4b0b-b3eb-543d3c08a02d"), Price = 1000, Name = "Order 1000", AccountId = accountId1 },
                new Order() { OrderId = new Guid("40222d99-b2ba-4a76-8597-ecce0dba64e3"), Price = 2000, Name = "Order 2000", AccountId = accountId2 },
                new Order() { OrderId = new Guid("0e33ee38-9553-4cdf-a832-e5814454d3a9"), Price = 5000, Name = "Order 5000", AccountId = accountId1 },
                new Order() { OrderId = new Guid("75551870-6910-423a-b8b3-dac02c22c911"), Price = 8000, Name = "Order 8000", AccountId = accountId2 }
             );

            context.Contacts.AddOrUpdate(
                new Contact() { ContactId = new Guid("67a86470-3cf5-4123-9daa-641954c52d25"), FirstName = "Paul", LastName = "Objekt", AccountId = accountId1, ModifiedOn = DateTime.UtcNow, Email = "paul.objekt@fakebox.com" },
                new Contact() { ContactId = new Guid("47b60c05-a429-46c8-8291-2c69e4c839b2"), FirstName = "Milena", LastName = "Suspekt", AccountId = accountId2, ModifiedOn = DateTime.UtcNow, Email = "milena.suspekt@fakebox.com" }
             );
        }
    }
}
