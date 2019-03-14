using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionSee.Migrations
{
    public partial class qqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Desription",
                table: "Questions",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Answers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Questions",
                newName: "Desription");
        }
    }
}
