using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeData.Migrations
{
    public partial class theoffice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dashBoards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    getTodayMessage = table.Column<int>(type: "int", nullable: false),
                    getMonthMessage = table.Column<int>(type: "int", nullable: false),
                    getYearMessage = table.Column<int>(type: "int", nullable: false),
                    getTodayTask = table.Column<int>(type: "int", nullable: false),
                    getMonthTask = table.Column<int>(type: "int", nullable: false),
                    getYearTask = table.Column<int>(type: "int", nullable: false),
                    getTodayComment = table.Column<int>(type: "int", nullable: false),
                    getMonthComment = table.Column<int>(type: "int", nullable: false),
                    getYearComment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashBoards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_profile_pId",
                        column: x => x.pId,
                        principalTable: "profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_tasks_profile_profileId",
                        column: x => x.profileId,
                        principalTable: "profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taskBoards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskid = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countMessage = table.Column<int>(type: "int", nullable: false),
                    commentsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskBoards", x => x.id);
                    table.ForeignKey(
                        name: "FK_taskBoards_tasks_taskid",
                        column: x => x.taskid,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false),
                    TaskBoardid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_profile_profileId",
                        column: x => x.profileId,
                        principalTable: "profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_taskBoards_TaskBoardid",
                        column: x => x.TaskBoardid,
                        principalTable: "taskBoards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_profileId",
                table: "comments",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_TaskBoardid",
                table: "comments",
                column: "TaskBoardid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_taskId",
                table: "comments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_pId",
                table: "messages",
                column: "pId");

            migrationBuilder.CreateIndex(
                name: "IX_taskBoards_commentsid",
                table: "taskBoards",
                column: "commentsid");

            migrationBuilder.CreateIndex(
                name: "IX_taskBoards_taskid",
                table: "taskBoards",
                column: "taskid");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_profileId",
                table: "tasks",
                column: "profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_taskBoards_comments_commentsid",
                table: "taskBoards",
                column: "commentsid",
                principalTable: "comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_profile_profileId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_profile_profileId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_taskBoards_TaskBoardid",
                table: "comments");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "dashBoards");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "taskBoards");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "tasks");
        }
    }
}
