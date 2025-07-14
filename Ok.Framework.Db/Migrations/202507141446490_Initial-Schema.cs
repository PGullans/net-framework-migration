namespace Ok.Framework.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Contacts", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Orders", new[] { "AccountId" });
            DropIndex("dbo.Contacts", new[] { "AccountId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
            DropTable("dbo.Accounts");
        }
    }
}
