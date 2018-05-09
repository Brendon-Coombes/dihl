using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DIHL.Repository.Sql.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Leagues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Conditional = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => new { x.Key, x.Conditional });
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LeagueId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "dbo",
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    JerseyNumber = table.Column<int>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LeagueId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TeamDataModelId = table.Column<Guid>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "dbo",
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seasons_Teams_TeamDataModelId",
                        column: x => x.TeamDataModelId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AwayTeamId = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    HomeTeamId = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    PlayerDataModelId = table.Column<Guid>(nullable: true),
                    SeasonId = table.Column<Guid>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerDataModelId",
                        column: x => x.PlayerDataModelId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "dbo",
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGoalieStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    GoalsAllowed = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    Result = table.Column<int>(nullable: false),
                    Saves = table.Column<int>(nullable: false),
                    ShotsAgainst = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    Tier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGoalieStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGoalieStatistics_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGoalieStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGoalieStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameSkaterStatistics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    PrimaryAssistPlayerId = table.Column<Guid>(nullable: true),
                    ScoreType = table.Column<int>(nullable: false),
                    SecondaryAssistPlayerId = table.Column<Guid>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSkaterStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSkaterStatistics_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSkaterStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSkaterStatistics_Players_PrimaryAssistPlayerId",
                        column: x => x.PrimaryAssistPlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameSkaterStatistics_Players_SecondaryAssistPlayerId",
                        column: x => x.SecondaryAssistPlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameSkaterStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamesPlayed",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesPlayed", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GamesPlayed_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesPlayed_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesPlayed_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    Length = table.Column<TimeSpan>(nullable: false),
                    PenaltyType = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    PowerPlaySuccessful = table.Column<bool>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalties_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalties_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalties_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalieStatistics_GameId",
                schema: "dbo",
                table: "GameGoalieStatistics",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalieStatistics_PlayerId",
                schema: "dbo",
                table: "GameGoalieStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalieStatistics_TeamId",
                schema: "dbo",
                table: "GameGoalieStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                schema: "dbo",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                schema: "dbo",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerDataModelId",
                schema: "dbo",
                table: "Games",
                column: "PlayerDataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SeasonId",
                schema: "dbo",
                table: "Games",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSkaterStatistics_GameId",
                schema: "dbo",
                table: "GameSkaterStatistics",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSkaterStatistics_PlayerId",
                schema: "dbo",
                table: "GameSkaterStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSkaterStatistics_PrimaryAssistPlayerId",
                schema: "dbo",
                table: "GameSkaterStatistics",
                column: "PrimaryAssistPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSkaterStatistics_SecondaryAssistPlayerId",
                schema: "dbo",
                table: "GameSkaterStatistics",
                column: "SecondaryAssistPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSkaterStatistics_TeamId",
                schema: "dbo",
                table: "GameSkaterStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlayed_GameId",
                schema: "dbo",
                table: "GamesPlayed",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlayed_TeamId",
                schema: "dbo",
                table: "GamesPlayed",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_GameId",
                schema: "dbo",
                table: "Penalties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_PlayerId",
                schema: "dbo",
                table: "Penalties",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_TeamId",
                schema: "dbo",
                table: "Penalties",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerId",
                schema: "dbo",
                table: "PlayerTeams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId",
                schema: "dbo",
                table: "PlayerTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_LeagueId",
                schema: "dbo",
                table: "Seasons",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TeamDataModelId",
                schema: "dbo",
                table: "Seasons",
                column: "TeamDataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                schema: "dbo",
                table: "Teams",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGoalieStatistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GameSkaterStatistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GamesPlayed",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Penalties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerTeams",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Seasons",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Leagues",
                schema: "dbo");
        }
    }
}
