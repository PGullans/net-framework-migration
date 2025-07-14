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
                        Account_AccountId = c.Guid(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Account_AccountId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Account_AccountId = c.Guid(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Account_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Account_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Contacts", "Account_AccountId", "dbo.Accounts");
            DropIndex("dbo.Orders", new[] { "Account_AccountId" });
            DropIndex("dbo.Contacts", new[] { "Account_AccountId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Contacts");
            DropTable("dbo.Accounts");
        }
    }
}
