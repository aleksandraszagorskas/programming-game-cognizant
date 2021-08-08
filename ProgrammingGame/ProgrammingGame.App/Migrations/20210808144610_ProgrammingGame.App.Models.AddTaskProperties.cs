using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammingGame.App.Migrations
{
    public partial class ProgrammingGameAppModelsAddTaskProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Task",
                newName: "Solution");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "Description", "Name", "Solution" },
                values: new object[] { 1, "Write a program in C# that outputs 'Hello World!' to console.", "Hello World", "Hello World!" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "Description", "Name", "Solution" },
                values: new object[] { 2, "Write a program in C# that outputs 'AAA' to console.", "Test AAA", "AAA" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "Description", "Name", "Solution" },
                values: new object[] { 3, "Write a program in C# that outputs 'BBB' to console.", "Test BBB", "BBB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Solution",
                table: "Task",
                newName: "TaskName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
