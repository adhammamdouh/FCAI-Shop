namespace FCAI_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 256),
                        UserRoles = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.User",
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
            DropForeignKey("dbo.User", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Admin", "Id", "dbo.ApplicationUsers");
            DropIndex("dbo.User", new[] { "Id" });
            DropIndex("dbo.Admin", new[] { "Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "UserName" });
            DropIndex("dbo.ApplicationUsers", new[] { "Email" });
            DropTable("dbo.User");
            DropTable("dbo.Admin");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
