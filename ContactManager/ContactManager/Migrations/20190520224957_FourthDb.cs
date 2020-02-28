using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class FourthDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("1fa176f4-4647-4ffe-a266-1df8e0238712"), 0, "dae45d10-7541-4333-9299-17fea7c10f1f", "hlapointe@cegepsth.qc.ca", true, false, null, "hlapointe@cegepsth.qc.ca", "hlapointe", "AQAAAAEAACcQAAAAEAacHknqUBTgrX6BjEdemC1ww2Co2EH+dBd0jUuqCvjoeRcAO+a8Bzj8y8N+Ba6nKw==", null, false, "", false, "hlapointe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("46318a30-8e22-4eaf-8e1c-c939085715cd"), 0, "1316d217-77ae-4d1a-92ea-f2ddc91ff619", "hstlouis@cegepsth.qc.ca", true, false, null, "hstlouis@cegepsth.qc.ca", "hstlouis", null, null, false, "", false, "hstlouis" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("0e72698e-03ee-4b12-ac0d-ee7496303eb9"), "mlalancette@cegepsth.qc.ca", "Martin", "Lalancette", new Guid("1fa176f4-4647-4ffe-a266-1df8e0238712") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("27e543fa-ecd4-4c27-9282-73a4b1864997"), "aouellet@cegepsth.qc.ca", "Arthur", "Ouellet", new Guid("1fa176f4-4647-4ffe-a266-1df8e0238712") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OwnerId" },
                values: new object[] { new Guid("8cef9147-5a49-4069-9f8b-84fa3b114576"), "spoulit@cegepsth.qc.ca", "Sébstien", "Pouliot", new Guid("46318a30-8e22-4eaf-8e1c-c939085715cd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("0e72698e-03ee-4b12-ac0d-ee7496303eb9"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("27e543fa-ecd4-4c27-9282-73a4b1864997"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("8cef9147-5a49-4069-9f8b-84fa3b114576"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("1fa176f4-4647-4ffe-a266-1df8e0238712"), "dae45d10-7541-4333-9299-17fea7c10f1f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("46318a30-8e22-4eaf-8e1c-c939085715cd"), "1316d217-77ae-4d1a-92ea-f2ddc91ff619" });

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
    }
}
