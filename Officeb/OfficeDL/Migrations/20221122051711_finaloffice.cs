using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeDL.Migrations
{
    public partial class finaloffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countmessagemonth",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "countmessagetoday",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "countmessageyear",
                table: "messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "countmessagemonth",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countmessagetoday",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countmessageyear",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
