namespace FCAI_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firststep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.User");
            DropTable("dbo.Admin");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
