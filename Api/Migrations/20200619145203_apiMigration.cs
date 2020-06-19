using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class apiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "CompleteState",
                table: "Works",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteState",
                table: "Works");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Works",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
