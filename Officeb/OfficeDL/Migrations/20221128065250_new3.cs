using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeDL.Migrations
{
    public partial class new3 : Migration
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

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_profile_PId",
                        column: x => x.PId,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tasks_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taskboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _taskId = table.Column<int>(type: "int", nullable: true),
                    _comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countMessage = table.Column<int>(type: "int", nullable: false),
                    comment_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskboards_tasks__taskId",
                        column: x => x._taskId,
                        principalTable: "tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false),
                    TaskBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_profile_PId",
                        column: x => x.PId,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_taskboards_TaskBoardId",
                        column: x => x.TaskBoardId,
                        principalTable: "taskboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_PId",
                table: "comments",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_TaskBoardId",
                table: "comments",
                column: "TaskBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_taskId",
                table: "comments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_PId",
                table: "messages",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_taskboards__taskId",
                table: "taskboards",
                column: "_taskId");

            migrationBuilder.CreateIndex(
                name: "IX_taskboards_comment_Id",
                table: "taskboards",
                column: "comment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_ProfileId",
                table: "tasks",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_taskboards_comments_comment_Id",
                table: "taskboards",
                column: "comment_Id",
                principalTable: "comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_profile_PId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_profile_ProfileId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_taskboards_TaskBoardId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "dashboards");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "taskboards");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "tasks");
        }
    }
}
