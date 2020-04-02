
namespace FCAI_Shop.Migrations
{
#pragma warning disable 1591
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            Sql("insert into [dbo].[ApplicationUsers] values ('belal@gmail.com','belal','belal','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('felecia.herrera@example.com','Felecia','Herrera','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('akseli.jutila@example.com','Akseli','Jutila','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('ruth.carvalho@example.com','Ruth','Carvalho','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('iina.hakola@example.com','Iina','Hakola','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('isac.sonstebo@example.com','Isac','Sønstebø','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('elif.eksioglu@example.com','Elif','Ekşioğlu','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('onni.sakala@example.com','Onni','Sakala','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('onur.ozdenak@example.com','Onur','Özdenak','123','Admin')");
            Sql("insert into [dbo].[ApplicationUsers] values ('joseph.hall@example.com','Joseph','Hall','123','Admin')");

            Sql("insert into [dbo].[ApplicationUsers] values ('ahmed@gmail.com','ahmed','ahmed','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('gloria.ferrer@example.com','Gloria','Ferrer','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('cristian.aguilar@example.com','Cristian','Aguilar','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('isaac.cooper@example.com','Isaac','Cooper','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('ridwan.finne@example.com','Ridwan','Finne','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('vivan.miller@example.com','Vivan','Miller','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('isabella.clarke@example.com','Isabella','Clarke','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('armando.koppenol@example.com','Armando','Koppenol','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('ronja.kauppi@example.com','Ronja','Kauppi','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('elli.wirtanen@example.com','Elli','Wirtanen','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('idris.sulen@example.com','Idris','Sulen','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('margot.denis@example.com','Margot','Denis','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('stella.lee@example.com','Stella','Lee','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('frederikke.hansen@example.com','Frederikke','Hansen','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('mustafa.karabocek@example.com','Mustafa','Karaböcek','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('margaux.picard@example.com','Margaux','Picard','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('anas.gjonnes@example.com','Anas','Gjønnes','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('katrine.christensen@example.com','Katrine','Christensen','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('sebastian.hawkins@example.com','Sebastian','Hawkins','123','User')");
            Sql("insert into [dbo].[ApplicationUsers] values ('dimitri.lucas@example.com','Dimitri','Lucas','123','User')");

            Sql("insert into [dbo].[Admins] values (1)");
            Sql("insert into [dbo].[Admins] values (2)");
            Sql("insert into [dbo].[Admins] values (3)");
            Sql("insert into [dbo].[Admins] values (4)");
            Sql("insert into [dbo].[Admins] values (5)");
            Sql("insert into [dbo].[Admins] values (6)");
            Sql("insert into [dbo].[Admins] values (7)");
            Sql("insert into [dbo].[Admins] values (8)");
            Sql("insert into [dbo].[Admins] values (9)");
            Sql("insert into [dbo].[Admins] values (10)");

            Sql("insert into [dbo].[Users] values (11)");
            Sql("insert into [dbo].[Users] values (12)");
            Sql("insert into [dbo].[Users] values (13)");
            Sql("insert into [dbo].[Users] values (14)");
            Sql("insert into [dbo].[Users] values (15)");
            Sql("insert into [dbo].[Users] values (16)");
            Sql("insert into [dbo].[Users] values (17)");
            Sql("insert into [dbo].[Users] values (18)");
            Sql("insert into [dbo].[Users] values (19)");
            Sql("insert into [dbo].[Users] values (20)");
            Sql("insert into [dbo].[Users] values (21)");
            Sql("insert into [dbo].[Users] values (22)");
            Sql("insert into [dbo].[Users] values (23)");
            Sql("insert into [dbo].[Users] values (24)");
            Sql("insert into [dbo].[Users] values (25)");
            Sql("insert into [dbo].[Users] values (26)");
            Sql("insert into [dbo].[Users] values (27)");
            Sql("insert into [dbo].[Users] values (28)");
            Sql("insert into [dbo].[Users] values (29)");
            Sql("insert into [dbo].[Users] values (30)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Admins", "Id", "dbo.ApplicationUsers");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "UserName" });
            DropIndex("dbo.ApplicationUsers", new[] { "Email" });
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
