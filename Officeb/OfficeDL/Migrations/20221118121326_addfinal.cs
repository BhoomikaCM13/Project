using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeDL.Migrations
{
    public partial class addfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "counttask",
                table: "tasks",
                newName: "countyear");

            migrationBuilder.RenameColumn(
                name: "countmessage",
                table: "messages",
                newName: "countmessageyear");

            migrationBuilder.RenameColumn(
                name: "countcomment",
                table: "comments",
                newName: "countcommentyear");

            migrationBuilder.AddColumn<int>(
                name: "countmonth",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "counttoday",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countmessagemonth",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countmessagetoady",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countcommentmonth",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countcommenttoady",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countmonth",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "counttoday",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "countmessagemonth",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "countmessagetoady",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "countcommentmonth",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "countcommenttoady",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "countyear",
                table: "tasks",
                newName: "counttask");

            migrationBuilder.RenameColumn(
                name: "countmessageyear",
                table: "messages",
                newName: "countmessage");

            migrationBuilder.RenameColumn(
                name: "countcommentyear",
                table: "comments",
                newName: "countcomment");
        }
    }
}
