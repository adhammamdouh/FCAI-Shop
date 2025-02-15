﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FCAI_Shop.Migrations
{
    public partial class azure_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    Role = table.Column<string>(maxLength: 256, nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.UniqueConstraint("AK_ApplicationUsers_Email", x => x.Email);
                    table.UniqueConstraint("AK_ApplicationUsers_UserName", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
