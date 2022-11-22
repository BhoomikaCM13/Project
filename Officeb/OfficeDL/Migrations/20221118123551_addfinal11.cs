using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeDL.Migrations
{
    public partial class addfinal11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "countmessagetoady",
                table: "messages",
                newName: "countmessagetoday");

            migrationBuilder.RenameColumn(
                name: "countcommenttoady",
                table: "comments",
                newName: "countcommenttoday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "countmessagetoday",
                table: "messages",
                newName: "countmessagetoady");

            migrationBuilder.RenameColumn(
                name: "countcommenttoday",
                table: "comments",
                newName: "countcommenttoady");
        }
    }
}
