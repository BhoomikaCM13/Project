using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeDL.Migrations
{
    public partial class dashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GetTodaymsg = table.Column<int>(type: "int", nullable: false),
                    GetMonthmsg = table.Column<int>(type: "int", nullable: false),
                    GetYearmsg = table.Column<int>(type: "int", nullable: false),
                    GetTodayTask = table.Column<int>(type: "int", nullable: false),
                    GetMonthTask = table.Column<int>(type: "int", nullable: false),
                    GetYearTask = table.Column<int>(type: "int", nullable: false),
                    GetTodaycomment = table.Column<int>(type: "int", nullable: false),
                    GetMonthcomment = table.Column<int>(type: "int", nullable: false),
                    GetYearcomment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dashboards");
        }
    }
}
