using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class ThirdDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("9a7ffdca-10be-4b78-9187-eecbbcbe24ef"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("a57bc2b4-e071-43ce-bf97-bb8dc2aa595d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("8f3a6b25-ea43-4d18-88b7-f4c6c5f0e4b7"), "ceb9d4ed-e180-458e-89d0-040c6558463d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("34d22d48-05cd-465d-9251-ea6252a4b0b4"), 0, "ef49d24f-d84f-402f-a0e7-f1924c9dd865", "hlapointe@cegepsth.qc.ca", true, false, null, "hlapointe@cegepsth.qc.ca", "hlapointe", "AQAAAAEAACcQAAAAEI7vWCh4gL8JtIBa88h1tuGWs0fwKBDK6/j7VSy3qa9gjKpXtkN0N1rarbISpL5fIA==", null, false, "", false, "hlapointe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("aed8b864-251b-48ff-933c-1f57ef4d956b"), 0, "0c14466f-18a0-48b3-a12d-e802bb86a6c4", "hstlouis@cegepsth.qc.ca", true, false, null, "hstlouis@cegepsth.qc.ca", "hstlouis", null, null, false, "", false, "hstlouis" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("46c4821e-3f29-45ef-9013-444f9d920cfa"), "mlalancette@cegepsth.qc.ca", "Martin", "Lalancette", new Guid("34d22d48-05cd-465d-9251-ea6252a4b0b4") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("2ecd1f08-07e7-479b-acca-6086de104d88"), "aouellet@cegepsth.qc.ca", "Arthur", "Ouellet", new Guid("34d22d48-05cd-465d-9251-ea6252a4b0b4") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("aed8b864-251b-48ff-933c-1f57ef4d956b"), "0c14466f-18a0-48b3-a12d-e802bb86a6c4" });

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("2ecd1f08-07e7-479b-acca-6086de104d88"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("46c4821e-3f29-45ef-9013-444f9d920cfa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("34d22d48-05cd-465d-9251-ea6252a4b0b4"), "ef49d24f-d84f-402f-a0e7-f1924c9dd865" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8f3a6b25-ea43-4d18-88b7-f4c6c5f0e4b7"), 0, "ceb9d4ed-e180-458e-89d0-040c6558463d", "hlapointe@cegepsth.qc.ca", true, false, null, "hlapointe@cegepsth.qc.ca", "hlapointe", "AQAAAAEAACcQAAAAEMSmCfURjD99onFo9gxykUZv7GgQJcnSmtH+8CiaTLuTHA95WdxtlkGbAoh73tZdew==", null, false, "", false, "hlapointe" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("a57bc2b4-e071-43ce-bf97-bb8dc2aa595d"), "mlalancette@cegepsth.qc.ca", "Martin", "Lalancette", new Guid("8f3a6b25-ea43-4d18-88b7-f4c6c5f0e4b7") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("9a7ffdca-10be-4b78-9187-eecbbcbe24ef"), "aouellet@cegepsth.qc.ca", "Arthur", "Ouellet", new Guid("8f3a6b25-ea43-4d18-88b7-f4c6c5f0e4b7") });
        }
    }
}
