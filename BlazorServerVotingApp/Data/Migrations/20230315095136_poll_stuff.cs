using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerVotingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class poll_stuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PollID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollOptions_Poll_PollID",
                        column: x => x.PollID,
                        principalTable: "Poll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PollOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollVote_PollOptions_PollOptionId",
                        column: x => x.PollOptionId,
                        principalTable: "PollOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollOptions_PollID",
                table: "PollOptions",
                column: "PollID");

            migrationBuilder.CreateIndex(
                name: "IX_PollVote_PollOptionId",
                table: "PollVote",
                column: "PollOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollVote");

            migrationBuilder.DropTable(
                name: "PollOptions");

            migrationBuilder.DropTable(
                name: "Poll");
        }
    }
}
