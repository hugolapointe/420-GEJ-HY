using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VCExample.Migrations
{
    public partial class DBInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDone = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "IsDone", "Name", "Priority" },
                values: new object[,]
                {
                    { 1, true, "TASK_NAME_1", 1 },
                    { 2, false, "TASK_NAME_2", 2 },
                    { 3, false, "TASK_NAME_3", 3 },
                    { 4, true, "TASK_NAME_4", 4 },
                    { 5, false, "TASK_NAME_5", 5 },
                    { 6, false, "TASK_NAME_6", 1 },
                    { 7, true, "TASK_NAME_7", 2 },
                    { 8, false, "TASK_NAME_8", 3 },
                    { 9, false, "TASK_NAME_9", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");
        }
    }
}
