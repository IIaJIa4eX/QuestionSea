using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionSee.Migrations
{
    public partial class UpdateDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Answered",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Asked",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answered",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Asked",
                table: "Users");
        }
    }
}
