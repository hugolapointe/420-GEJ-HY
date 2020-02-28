using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManager.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(nullable: false),
                    ClientPhoneNumber = table.Column<string>(nullable: false),
                    ClientEmailAddress = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
