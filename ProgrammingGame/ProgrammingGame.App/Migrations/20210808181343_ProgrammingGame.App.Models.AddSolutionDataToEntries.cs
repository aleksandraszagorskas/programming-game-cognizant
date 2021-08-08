using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammingGame.App.Migrations
{
    public partial class ProgrammingGameAppModelsAddSolutionDataToEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "Entries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Entries");
        }
    }
}
