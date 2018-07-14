using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Migrations
{
    public partial class AddShootoutModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameShootoutStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    TeamDataModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameShootoutStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameShootoutStatistics_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameShootoutStatistics_Teams_TeamDataModelId",
                        column: x => x.TeamDataModelId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoalieShootoutStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameShootoutStatisticId = table.Column<Guid>(nullable: false),
                    GoalsAllowed = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true),
                    ShotsAgainst = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    WonShootout = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalieShootoutStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalieShootoutStatistics_GameShootoutStatistics_GameShootoutStatisticId",
                        column: x => x.GameShootoutStatisticId,
                        principalSchema: "dbo",
                        principalTable: "GameShootoutStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoalieShootoutStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoalieShootoutStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkaterShootoutStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameShootoutStatisticId = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true),
                    ShotNumber = table.Column<int>(nullable: false),
                    Successful = table.Column<bool>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkaterShootoutStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkaterShootoutStatistics_GameShootoutStatistics_GameShootoutStatisticId",
                        column: x => x.GameShootoutStatisticId,
                        principalSchema: "dbo",
                        principalTable: "GameShootoutStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkaterShootoutStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkaterShootoutStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameShootoutStatistics_GameId",
                schema: "dbo",
                table: "GameShootoutStatistics",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameShootoutStatistics_TeamDataModelId",
                schema: "dbo",
                table: "GameShootoutStatistics",
                column: "TeamDataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalieShootoutStatistics_GameShootoutStatisticId",
                schema: "dbo",
                table: "GoalieShootoutStatistics",
                column: "GameShootoutStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalieShootoutStatistics_PlayerId",
                schema: "dbo",
                table: "GoalieShootoutStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalieShootoutStatistics_TeamId",
                schema: "dbo",
                table: "GoalieShootoutStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SkaterShootoutStatistics_GameShootoutStatisticId",
                schema: "dbo",
                table: "SkaterShootoutStatistics",
                column: "GameShootoutStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_SkaterShootoutStatistics_PlayerId",
                schema: "dbo",
                table: "SkaterShootoutStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkaterShootoutStatistics_TeamId",
                schema: "dbo",
                table: "SkaterShootoutStatistics",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalieShootoutStatistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SkaterShootoutStatistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GameShootoutStatistics",
                schema: "dbo");
        }
    }
}
