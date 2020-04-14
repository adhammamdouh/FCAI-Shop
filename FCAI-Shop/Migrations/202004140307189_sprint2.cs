namespace FCAI_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprint2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false, maxLength: 256),
                        UserRoles = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ShopOwners",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopOwners", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Customers", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Admins", "Id", "dbo.ApplicationUsers");
            DropIndex("dbo.ShopOwners", new[] { "Id" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "UserName" });
            DropIndex("dbo.ApplicationUsers", new[] { "Email" });
            DropTable("dbo.ShopOwners");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
